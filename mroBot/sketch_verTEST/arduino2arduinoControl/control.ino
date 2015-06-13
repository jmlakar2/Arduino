#include <SoftwareSerial.h>
#include <LiquidCrystal.h>

#define xPin A0
#define yPin A1
#define swPin 8
#define xButton 7


int trenutniX = 0;
int trenutniY = 0;
String ulaz = ""; 
String izlaz= "";
String trenutni="";
boolean xBtn = false;
String brzina="";

SoftwareSerial BTSerial(10,11);
LiquidCrystal lcd(53, 51, 49, 47, 45, 43);

void setup()
{
   pinMode(swPin, INPUT);
   digitalWrite(swPin, HIGH);
   
   BTSerial.begin(9600);
   Serial.begin(9600);  
   
   lcd.begin(16,2);
}

void loop()
{
  
  if(BTSerial.available()>0)
  {
      brzina = "";
    while (BTSerial.available()>0)
    {
      brzina += char(BTSerial.read());
    }
  }
  
  
  /*
  if(Serial.available()>0)  
  {  
    ulaz = "";
    while (Serial.available() > 0)  
    {        
      ulaz += char(Serial.read());
      delay(2);
    }
  }
*/
    if (BTSerial.available())
    Serial.write(BTSerial.read());
  
   if (trenutniX != analogRead(xPin) || trenutniY != analogRead(yPin))
   {
     trenutniX = analogRead(xPin);
     trenutniY = analogRead(yPin);
     /*
     Serial.println("X");
     Serial.println(trenutniX);
     Serial.println("Y");
     Serial.println(trenutniY);
     */
     
     if ((trenutniX > 400 && trenutniX<600) && (trenutniY> 400 && trenutniY<600) && trenutni != "s"){
       trenutni = "s";
       BTSerial.write("s");
       //Serial.println(trenutni);
       }
      else if ((trenutniX<100) && (trenutniY> 400 && trenutniY<600) && trenutni!="n") {
        trenutni = "n";
        BTSerial.write("n");
        //Serial.println(trenutni);
        }
       else if ((trenutniX>900) && (trenutniY> 400 && trenutniY<600) && trenutni!="b") {
         trenutni = "b";
        BTSerial.write("b");
        //Serial.println(trenutni);
         }
        else if ((trenutniX > 400 && trenutniX<600) && (trenutniY>900) && trenutni!="l") {
          trenutni = "l";
        BTSerial.write("l");
        //Serial.println(trenutni);
          }
         else if ((trenutniY<100) && (trenutniX> 400 && trenutniX<600) && trenutni!="d"){
           trenutni = "d";
        BTSerial.write("d");
        //Serial.println(trenutni);
           }

   }
   
   if (digitalRead(xButton) == HIGH){
      if(xBtn == false)
      {
        BTSerial.write("x");
        xBtn = true;
      }}
    else xBtn = false;
    
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("TRENUTNA BRZINA:");
  lcd.setCursor(0,1);
  lcd.print(brzina);
  delay(100);
}
