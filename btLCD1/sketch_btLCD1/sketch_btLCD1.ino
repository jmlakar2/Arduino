#include <SoftwareSerial.h>
#include <LiquidCrystal.h>

SoftwareSerial Genotronex(8,9);
LiquidCrystal lcd(4, 6, 10, 11, 12, 13);

String izlaz = "test";

void setup()
{
  Genotronex.begin(9600);
  Genotronex.println("UNESITE ONO STO ZELITE ISPISATI: ");
  //Serial.begin(9600);
  lcd.begin(16,2);
}

void loop()
{
    //Genotronex.println("SPOJENO");
    
  //Genotronex.println("UNESITE ONO STO ZELITE ISPISATI: ");
  if(Genotronex.available()>0)
  {
    izlaz = "";
    while (Genotronex.available()>0)
    {
      izlaz += char(Genotronex.read());
    }
  }
  
  delay(100);
  
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print(izlaz);
}
