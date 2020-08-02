#include <Wire.h> //I2C
#include <LiquidCrystal_I2C.h>
#include <Servo.h>
#include "Arduino.h"
#include "NewPing.h"
#include "RFID.h"

#define HCSR04_PIN_TRIG 9
#define HCSR04_PIN_ECHO 8

#define SERVO_PIN 6

#define RFID_PIN_RST 2
#define RFID_PIN_SDA 10

#define BUZZER 3
#define LED_RED 4
#define LED_GREEN 5

LiquidCrystal_I2C lcd = LiquidCrystal_I2C(0x27, 20, 4);
NewPing sonar(HCSR04_PIN_TRIG, HCSR04_PIN_ECHO);
RFID rfid(RFID_PIN_SDA, RFID_PIN_RST);
Servo servo;

String state = "stop";
int servoAngle = 90;
bool servoRight = true;

bool stringComplete = false;
String inputString = "";
String displayString = "";

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

  displayString = "Ready to connect";
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
  else if (state == "play")
  {
    if (timePreviousLed > 0)
    {
      if (millis() - timePreviousLed > 1000)
      {
        timePreviousLed = 0;
        digitalWrite(LED_GREEN, LOW);
      }
    }
    if (millis() - timePreviousServo > 50)
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
      timePreviousServo = millis();
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
    lcd.clear();
    lcd.print(inputString);
  }
  else if (inputString.startsWith("DSC"))
  {
    inputString = inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print(inputString);
    state = "stop";
    displayString = "Ready to connect";
    delay(1000);
  }
  else if (inputString.startsWith("LSC"))
  {
    inputString = inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print("Logged in as:");
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
    displayString = "Ready to connect";
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
}
