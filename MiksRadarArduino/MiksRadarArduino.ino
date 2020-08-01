#include <Wire.h> //I2C
#include <LiquidCrystal_I2C.h>
#include <Servo.h>
#include "Arduino.h"
#include "NewPing.h"
#include "RFID.h"

#define HCSR04_PIN_TRIG 9
#define HCSR04_PIN_ECHO 8

#define SERVO_PIN 10

#define RFID_PIN_RST 2
#define RFID_PIN_SDA 10

#define BUZZER 4
#define GREEN_LED 6
#define RED_LED 7
#define BUTTON 7

LiquidCrystal_I2C lcd = LiquidCrystal_I2C(0x27, 20, 4);
NewPing sonar(HCSR04_PIN_TRIG, HCSR04_PIN_ECHO);
RFID rfid(RFID_PIN_SDA, RFID_PIN_RST);
Servo servo;

int servoAngle = 90;
bool servoRight = true;

void setup()
{
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
  rfid.init();

  servo.attach(SERVO_PIN);
  servo.write(servoAngle);

  pinMode(BUZZER, OUTPUT);
  pinMode(GREEN_LED, OUTPUT);
  pinMode(RED_LED, OUTPUT);
  pinMode(BUTTON, INPUT);
}

void loop()
{
}
