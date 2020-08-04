#include <Wire.h> //I2C
#include <LiquidCrystal_I2C.h>
#include <Servo.h>
#include "Arduino.h"
#include "NewPing.h"
#include "RFID.h"

#define HCSR04_PIN_TRIG 7
#define HCSR04_PIN_ECHO 8

#define SERVO_PIN 6
#define SERVO_DELAY 75

#define RFID_PIN_RST 2
#define RFID_PIN_SDA 10

#define BUZZER 3
#define LED_RED 4
#define LED_GREEN 5
#define BUTTON 9

LiquidCrystal_I2C lcd = LiquidCrystal_I2C(0x27, 16, 2);
NewPing sonar(HCSR04_PIN_TRIG, HCSR04_PIN_ECHO);
RFID rfid(RFID_PIN_SDA, RFID_PIN_RST);
Servo servo;

String state;
String previousState;
int servoAngle = 90;
bool servoRight = true;

bool stringComplete = false;
String inputString = "";
String displayString = "";

int buttonStatePrevious=0;

long timePreviousRfid = 0;
long timePreviousLed = 0;
long timePreviousServo = 0;

void setup()
{
  Serial.begin(9600);
  while (!Serial)
    ;
  lcd.init();
  lcd.backlight();

  rfid.init();

  servo.attach(SERVO_PIN);
  servo.write(servoAngle);

  pinMode(BUZZER, OUTPUT);
  pinMode(LED_RED, OUTPUT);
  pinMode(LED_GREEN, OUTPUT);
  pinMode(BUTTON, INPUT);

  displayString = "Nije povezano";
  state="stop";
}

void loop()
{
  if (displayString != "")
  {
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print(displayString);
    displayString = "";
  }

  if (timePreviousLed > 0)
    {
      if (millis() - timePreviousLed > 1000)
      {
        timePreviousLed = 0;
        digitalWrite(LED_GREEN, LOW);
      }
    }
  
  //Ukoliko je uspostavljena veza preko serijskog porta ali nije izvrsena autorizacija
  if (state == "wait")
  {
    long currentTime = millis();
    String tag = rfid.readTag();
    if (tag != "None")
    {
      if (currentTime - timePreviousRfid > 1000)
      {
        Serial.println("RFD" + tag);
      }
      timePreviousRfid = millis();
    }
  }
  else if (state == "play" || previousState=="play")
  {
    int buttonState=digitalRead(BUTTON);
    if(buttonStatePrevious==1 && buttonState==0){
      state="pause";
      Serial.println("PAU");
      lcd.clear();
      lcd.print("Radar");
      lcd.setCursor(0,1);
      lcd.print("Zaustavljen");
    }
    buttonStatePrevious = buttonState;
    if (millis() - timePreviousServo > SERVO_DELAY)
    {
      if (servoRight)
      {
        servoAngle += 2;
        if (servoAngle > 180)
        {
          servoAngle = 178;
          servoRight = false;
        }
      }
      else
      {
        servoAngle -= 2;
        if (servoAngle < 0)
        {
          servoAngle = 2;
          servoRight = true;
        }
      }
      servo.write(servoAngle);
      int distance = sonar.ping_cm();
      Serial.println("RES"+String(servoAngle)+":"+String(distance));
      timePreviousServo = millis();
    }
  }else if(state=="pause" || previousState=="pause"){
    int buttonState=digitalRead(BUTTON);
    if(buttonStatePrevious==1 && buttonState==0){
      state="play";
      Serial.println("PAU");
      lcd.clear();
      lcd.print("Radar");
      lcd.setCursor(0,1);
      lcd.print("Pokrenut");
    }
    buttonStatePrevious = buttonState;
  }

  if(state=="add"){
    String tag = rfid.readTag();
    if (tag != "None")
    {
      Serial.println("ADD" + tag);
      state=previousState;
      previousState="";
      lcd.clear();
      lcd.print("Kartica skenirana");
      tone(BUZZER, 740, 300);
      digitalWrite(LED_GREEN, HIGH);
      timePreviousLed = millis();
    }
  }

  if (stringComplete)
  {
    executeCommand();
    stringComplete = false;
    inputString = "";
  }

  //Citanje sa serijskog porta
  while (Serial.available() > 0)
  {
    char inChar = (char)Serial.read();
    if (inChar == '#')
    {
      stringComplete = true;
      //break;
    }
    else if (!stringComplete)
      inputString += inChar;
  }
}

void executeCommand()
{
  if (inputString.startsWith("CON"))
  {
    inputString = inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print(inputString);
    state = "wait";
  }
  else if (inputString.startsWith("MSG"))
  {
    inputString = inputString.substring(3, inputString.length());
    if(inputString.length()>8){
      String str1=inputString.substring(0, 16);
      String str2=inputString.substring(16, inputString.length());
      lcd.clear();
      lcd.print(str1);
      lcd.setCursor(0, 1);
      lcd.print(str2);
    }else{
      lcd.clear();
      lcd.print(inputString);
    }
  }
  else if (inputString.startsWith("DSC"))
  {
    inputString = inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print(inputString);
    state = "stop";
    displayString = "Nije povezano";
    delay(1000);
  }
  else if (inputString.startsWith("LSC"))
  {
    inputString = inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print("Prijavljen:");
    lcd.setCursor(0, 1);
    lcd.print(inputString);
    tone(BUZZER, 740, 300);
    digitalWrite(LED_GREEN, HIGH);
    timePreviousLed = millis();
    state = "play";
  }
  else if (inputString.startsWith("LFD"))
  {
    inputString = inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print(inputString);
    displayString = "Nije povezano";
    digitalWrite(LED_RED, HIGH);
    tone(BUZZER, 220);
    delay(200);
    noTone(BUZZER);
    delay(200);
    tone(BUZZER, 220);
    delay(200);
    noTone(BUZZER);
    delay(400);
    digitalWrite(LED_RED, LOW);
  }
  else if(inputString.startsWith("PAU")){
    state="pause";
    lcd.clear();
    lcd.print("Radar");
    lcd.setCursor(0,1);
    lcd.print("Zaustavljen");
  }
  else if(inputString.startsWith("RSM")){
    state="play";
    lcd.clear();
    lcd.print("Radar");
    lcd.setCursor(0,1);
    lcd.print("Pokrenut");
  }else if(inputString.startsWith("ADD")){
    previousState=state;
    state="add";
    lcd.clear();
    lcd.print("Skenirajte");
    lcd.setCursor(0, 1);
    lcd.print("novu karticu");
  }
}
