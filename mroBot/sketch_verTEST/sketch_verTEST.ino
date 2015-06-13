#define enableA 10
#define pinA1 2
#define pinA2 3

#define enableB 11
#define pinB1 4
#define pinB2 5

#define trigPin 7
#define echoPin 6

#include <SoftwareSerial.h>

//boolean prvo = true;

const int photoD = A0;
const int photoL = A1;
const int speedCtrl = A2;

int maxSpeed = 255;

boolean pocTrazi = true; 
unsigned long pocVrijeme = true;

int lightD, lightL, razlikaLight;

long trajanje, udaljenost;
long brzina_zvuka = 29;

String izlaz = "";

SoftwareSerial Genotronex(8,9);

void setup() {
 
 pinMode(enableA, OUTPUT);
 pinMode(pinA1, OUTPUT);
 pinMode(pinA2, OUTPUT);
 
 pinMode(enableB, OUTPUT);
 pinMode(pinB1, OUTPUT);
 pinMode(pinB2, OUTPUT);
 
 pinMode (trigPin, OUTPUT);
 pinMode (echoPin, INPUT);
 
 Genotronex.begin(9600);
 Serial.begin(9600);
 
}

void loop() {
  //slozi da se tu resetira string izlaz, u while stavi
  // izlaz = char...
  maxSpeed = analogRead(speedCtrl) / 4;
  
  if (maxSpeed > 255) maxSpeed = 255;
  
  if(Genotronex.available()>0)
  {
      izlaz = "";
    while (Genotronex.available()>0)
    {
      izlaz += char(Genotronex.read());
    }
      //Serial.println(izlaz);
  }
  delay (200);
  
  getUdaljenost();

  if (udaljenost >= 10 && udaljenost <= 20 && izlaz == "n" && izlaz != "x")
    izlaz = "s";

  if (izlaz == "a")
  {
    if (udaljenost > 20 && udaljenost <= 40)
    {
      motorOn();
      naprijed();
      pocTrazi = true;
      Serial.println ("naprijed");
    }
    else if (udaljenost >= 10 && udaljenost <= 20) {
      motorOff();
      Serial.println ("stani");
      }
    else
    {
      if (pocTrazi == true) 
      {
        pocVrijeme = millis();
        pocTrazi = false;
        Serial.println ("novoVrijeme");
      }
      if (millis() - pocVrijeme <= 4000)
      {
        motorOn();
        lijevo();
        Serial.println ("lijevo");
      }
      else 
      {
        motorOff();
        Serial.println(millis() - pocVrijeme);
        Serial.println("istrajalo vrijeme");
      }
    }
  }
      

  lightD = analogRead (photoD);
  lightL = analogRead (photoL);
  razlikaLight = lightD - lightL;
  if (razlikaLight < 0) razlikaLight *= -1;
  
  if (izlaz == "x")
  {
    if (razlikaLight >= 150 && lightD > lightL)
    {
      motorOn();
      desno();
      Serial.println("TEBI LIJEVI: ");
      Serial.println(lightL);
      Serial.println(lightD);
    }
    else if (razlikaLight >= 150 && lightL > lightD)
    {
      motorOn();
      lijevo();
      Serial.println("TEBI DESNI: ");
      Serial.println(lightL);
      Serial.println(lightD);
    }
    else if (lightL > 600 && lightD > 600)
    {
      motorOn();
      naprijed();
      Serial.println("NAPRIJED: ");
      Serial.println(lightL);
      Serial.println(lightD);
    }
    else {
      motorOff();
      Serial.println("STOP: ");
      Serial.println(lightL);
      Serial.println(lightD);
    }  
  }
      
  Genotronex.println(maxSpeed);
  
  if (izlaz == "n")
  {
    //if (isMotorOn == false)
      motorOn();
    naprijed();
    //delay(1000);
    //motorOff();
  }
  else if (izlaz == "b")
  {
    //if (isMotorOn == false)
      motorOn();
    nazad();
    //delay(1000);
    //motorOff();
  }
  else if (izlaz == "l")
  {
    //if (isMotorOn == false)
      motorOn();
    lijevo();
    //delay(1000);
    //motorOff();
  }
  else if (izlaz == "d")
  {
    //if (isMotorOn == false)
      motorOn();
    desno();
    //delay(1000);
    //motorOff();
  }
  else if (izlaz == "s")
    motorOff();

  //delay(200);
  /*if (prvo == true){
    delay(2000);
    motorOn();
    naprijed();
    delay(2000);
    nazad();
    delay(2000);
    prvo = false;
  }
  else {
    motorOff();
  }*/
}

//funkcije za upravljanje
void naprijed ()
{
  naprijedA();
  naprijedB();
}
void nazad ()
{
  nazadA();
  nazadB();
}
void lijevo ()
{
  naprijedA();
  //analogWrite(enableB, 0);
  nazadB();
}
void desno ()
{
  nazadA();
  naprijedB();
  //analogWrite(enableA, 0);
}

//funkcije za motore
void motorOn ()
{
  analogWrite(enableA, maxSpeed);
  analogWrite(enableB, maxSpeed);
}
void motorOff()
{
  analogWrite(enableA, 0);
  analogWrite(enableB, 0);
}
  
void naprijedA ()
{
  digitalWrite(pinA1, LOW);
  digitalWrite(pinA2, HIGH);
}
void nazadA ()
{
  digitalWrite(pinA1, HIGH);
  digitalWrite(pinA2, LOW);
}
void naprijedB ()
{
  digitalWrite(pinB1, LOW);
  digitalWrite(pinB2, HIGH);
}
void nazadB()
{
  digitalWrite(pinB1, HIGH);
  digitalWrite(pinB2, LOW);
}

boolean isMotorOn ()
{
  if (analogRead(enableA) == 0 && analogRead(enableB) == 0)
   return false;
  return true;
}

long getUdaljenost ()
{
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  
  digitalWrite(trigPin, LOW);
  trajanje = pulseIn(echoPin, HIGH);
  
  udaljenost = trajanje / brzina_zvuka / 2;
}
