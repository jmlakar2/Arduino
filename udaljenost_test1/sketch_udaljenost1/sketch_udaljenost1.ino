#include <Stepper.h>


#define trigPin 2
#define echoPin 4
//#define LEDpin 5
//#define LEDpin2 6
#define Rpin 5
#define Gpin 6
#define Bpin 3
#define STEPS 100
//#define irPin 4

//IRrecv irrecv(irPin);
//decode_results rezultat;

Stepper stepper (STEPS,10,11,12,13);

long trajanje, udaljenost;
long brzina_zvuka = 29;
boolean upaljen = false;
int trenutno_vrijeme = 0, razlika, jacinaLED;

void setup ()
{
  Serial.begin(9600);
  //irrecv.enableIRIn();
  pinMode (trigPin, OUTPUT);
  pinMode (echoPin, INPUT);
  //pinMode (LEDpin, OUTPUT);
  //digitalWrite (LEDpin, LOW);
  //pinMode (LEDpin2, OUTPUT);
  pinMode (Rpin, OUTPUT);
  pinMode (Gpin, OUTPUT);
  pinMode (Bpin, OUTPUT);
  
  stepper.setSpeed(180);
  
}

void loop()
{
  /*if (IRrecived) {   
    Serial.print("irCode: ");            
    Serial.print(getIRresult()); 
    Serial.print(",  bits: ");           
    Serial.println(rezultat.bits); 
    irrecv.resume();    
  }  
  delay(600);*/
  
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  
  digitalWrite(trigPin, LOW);
  trajanje = pulseIn(echoPin, HIGH);
  
  udaljenost = trajanje / brzina_zvuka / 2;
  
  /*if (udaljenost <= 10)
    Serial.println (udaljenost);*/
  
  razlika = millis() - trenutno_vrijeme;
  
  if (upaljen == false && udaljenost < 9 && razlika >= 2000)
  {
    upaljen = true;
    //digitalWrite (LEDpin, HIGH);
    trenutno_vrijeme = millis();
    //delay (2000);
  }
  else if (upaljen == true && udaljenost < 9 && razlika >= 2000)
  {
    upaljen = false;
    //digitalWrite (LEDpin, LOW);
    trenutno_vrijeme = millis();
    //delay (2000);
  }
  //else delay(2000);
  jacinaLED = 255 - (udaljenost*30);
  if (jacinaLED < 0) jacinaLED = 0;
  
  //analogWrite (LEDpin2, jacinaLED);
  delay(8); 
  
  if (udaljenost < 9)
  {
    int nova_brzina = 180 - udaljenost * 20;
    stepper.setSpeed(nova_brzina);
    int novi_koraci = nova_brzina / 1.8;
    if (novi_koraci < 0) novi_koraci *= -1;
    stepper.step(novi_koraci);
    //int nova_boja = udaljenost * 30;
    boja (255,0,0);
  }
  else 
  {
    stepper.setSpeed(180);
    stepper.step(-100);
    boja (0,255,0);
  }
}

void boja (int R, int G, int B)
{
  analogWrite (Rpin, R);
  analogWrite (Gpin, G);
  analogWrite (Bpin, B);
}
