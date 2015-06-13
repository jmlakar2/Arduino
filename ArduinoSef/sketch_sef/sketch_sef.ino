#define potPin 0
#define btnPin 12

int trenutniPot = 0;
boolean unesen = false;

int sifra[3] = {756,1,200};
int brojac = 0;
int unos[3];

void setup()
{
  Serial.begin(9600);
  pinMode (btnPin, INPUT);
}

void loop ()
{
  //if (digitalRead(btnPin) == HIGH)
  //{
    //if (unesen == false)
    //{
      int pot = analogRead(potPin);
      if(trenutniPot<(pot-10) || trenutniPot>(pot+10))
      {
        Serial.println (pot);
        trenutniPot = pot;
      }
      //unesen = true;
    //}
  //}
  //else unesen = false;
  if (digitalRead(btnPin) == HIGH)
  {
     if (unesen == false)
     {
       unos[brojac] = analogRead(potPin);
       brojac++;
       unesen = true;
     }
  }
  else unesen = false;
  
  if (brojac == 3)
  {
    brojac = 0;
    boolean istina = true;
    for (int i = 0; i<3; i++)
    {
      if (unos[i]<(sifra[i]-100) || unos[i]>(sifra[i]+100)) 
        istina = false;
    } 
    if (istina == true)
    {
      Serial.println("BRAVO");
    } 
    else Serial.println("CCCC");
  }
}
