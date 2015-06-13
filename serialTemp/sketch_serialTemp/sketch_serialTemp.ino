#define pinTemp A0

float rezultat = 0;
long tempVal = 0;

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  tempVal = analogRead(pinTemp);
  rezultat = (tempVal * 0.0048828125 * 100);
  Serial.println(rezultat);
  delay(1000);
}


