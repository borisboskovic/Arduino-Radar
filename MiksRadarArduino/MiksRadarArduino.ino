#include <Wire.h> //I2C
#include <LiquidCrystal_I2C.h>
#include <Servo.h>
#include "Arduino.h"
#include "NewPing.h"
#include "RFID.h"

#define HCSR04_PIN_TRIG 9
#define HCSR04_PIN_ECHO 8

#define SERVO_PIN 4

#define RFID_PIN_RST 2
#define RFID_PIN_SDA 10

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

  displayString="Ready to connect";
}

void loop()
{
  if (state == "stop")
  {
    if(displayString!=""){
      lcd.clear();
      lcd.setCursor(0, 0);
      lcd.print(displayString);
      displayString="";
    }
    String tag = rfid.readTag();
    if (tag != "None")
      Serial.println(tag);
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
  //Napisi kao SWITCH
  if(inputString.startsWith("CON")){
    inputString=inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print(inputString);
    state = "play";
  }else if(inputString.startsWith("MSG")){
    inputString=inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print(inputString);
    state = "play";
  }else if(inputString.startsWith("DSC")){
    inputString=inputString.substring(3, inputString.length());
    lcd.clear();
    lcd.print(inputString);
    state = "stop";
    displayString="Ready to connect";
    delay(1000);
  }
}
