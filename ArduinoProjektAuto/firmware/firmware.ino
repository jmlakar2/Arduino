#include <Servo.h>
#include <Stepper.h>

#define pinServo 9
#define pinBuzzer 12
#define STEPS 100
#define Lled 10

Servo servo;
Stepper stepper (STEPS,2,3,4,5);
String unos = "";
int trenutno;
boolean lLEDon = false;
boolean upaliLED = true;
unsigned int trenutnoVrijeme;
unsigned int brojac = 1000;

void setup()
{
  servo.attach(pinServo);
  servo.write(90);
  
  stepper.setSpeed(180);
  
  Serial.begin(9600);
  //Serial.print ("Unesite");
  Serial.println();
  
  trenutno = 90;
  
  pinMode(pinBuzzer, OUTPUT);
  pinMode(Lled, OUTPUT);
}

void loop()
{
    unos = "";
   if (Serial.available()>0)
   {
     //unos = "";
     while (Serial.available() > 0)
     {
       unos += char(Serial.read());
       delay(2);
     } 
     Serial.println(unos);
   }
   if (unos == "desno")
   {
      trenutno += 15;
      servo.write(trenutno);
      //delay(1000); 
   }
   else if (unos == "lijevo")
   {
     trenutno -=15;
     servo.write(trenutno); 
     delay(1000);
   }
   else if (unos == "reset")
   {
     trenutno = 90;
    servo.write(trenutno); 
    //delay(1000);
   }
   else if (unos == "naprijed")
   {
    stepper.step(100); 
   }
   else if (unos == "nazad")
   {
    stepper.step(-100); 
   }
   else if (unos == "truba")
   {
     digitalWrite(pinBuzzer, HIGH);
     delay(5);
     digitalWrite (pinBuzzer, LOW); 
   }
   else if (unos == "lLED")
   {
     Serial.println("naredba radi");
       if (lLEDon == false)
       { 
         Serial.println("promijenio u true");
         trenutnoVrijeme = millis();
         lLEDon = true;
       }
       else
       {
         Serial.println("jel i tu mozda ulazi");
         analogWrite(Lled, 0);
         lLEDon = false; 
         brojac = 1000;
       }
   }
   if (lLEDon == true)
   {
      if (((trenutnoVrijeme+brojac)<=millis()) && (upaliLED == true))
      {
        Serial.println("USAO DI TREBA");
        analogWrite(Lled, 255);
        upaliLED = false;
        brojac += 1000; 
      }
      else if (((trenutnoVrijeme+brojac)<=millis()) && (upaliLED == false))
      {
        analogWrite(Lled, 0);
        upaliLED = true;
        brojac += 1000; 
      }
   }
}
