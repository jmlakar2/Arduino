#include <LiquidCrystal.h>
#include<stdlib.h>

#define TEMPpin A2
#define LIGHTpin A3

float rezultatTemp = 0;
long valTemp = 0;
char tempVal[10];
String tempStr = "";

LiquidCrystal lcd(4, 6, 10, 11, 12, 13);

void setup() {

  lcd.begin(16,2);
  //Serial.begin(9600);

}

void loop() {
  tempStr = "";
  valTemp = analogRead(TEMPpin);
  rezultatTemp = (valTemp * 0.0048828125 * 100);
  int light = analogRead(LIGHTpin);
  
  dtostrf(rezultatTemp, 4, 2, tempVal);
  for (int i=0; i<4; i++) {
    tempStr+=tempVal[i];
    }
    
  String temperatura = "TEMP: "+ tempStr +" C";
  //String svijetlo = light;
  //Serial.println(light);
  String statusSvijetlo="";
  if (light < 400) {
    statusSvijetlo = "LIGHT IS OFF";
    }
  else {
    statusSvijetlo = "LIGHT IS ON";
    }
    
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print(temperatura);
  lcd.setCursor(0,1);
  lcd.print(statusSvijetlo);
  
  delay(1000);

}
