#define bluePin  4 //the green led pin attact to
#define yellowPin  3 //the yellow led pin attact to
#define redPin  2 //the red led pin attach to 
String comdata = "";
int lastLength = 0;

void setup()
{
  pinMode(bluePin,OUTPUT);  //initialize the greenPin as output
  pinMode(yellowPin, OUTPUT);  //initialize the yellowPin as output
  pinMode(redPin, OUTPUT);  //initialize the redPin as output
  Serial.begin(9600);  // start serial port at 9600 bps:
  Serial.print("Unesite boju da svetli:");  //print message on serial monitor
  Serial.println();
}

void loop()
{
  //read string from serial monitor
  if(Serial.available()>0)  // if we get a valid byte, read analog ins:
  {  
    comdata = "";
    while (Serial.available() > 0)  
    {        
      comdata += char(Serial.read());
      delay(2);
    }
    Serial.println(comdata);
  }
    if(comdata == "crvena")
    {
      digitalWrite(redPin, HIGH);//turn the red led on
      digitalWrite(bluePin, LOW);//turn the green led off
      digitalWrite(yellowPin, LOW);//turn the yellow led off
    }
    else if(comdata == "zuta")
    {
      digitalWrite(redPin, LOW);//turn the red led off
      digitalWrite(bluePin, LOW);//turn the green led off
      digitalWrite(yellowPin, HIGH);//turn the yellow led on
    }
    else if(comdata == "plava")
    {
      digitalWrite(redPin, LOW);//turn the red led off
      digitalWrite(bluePin, HIGH);//turn the green led on
      digitalWrite(yellowPin, LOW);//turn the yellow led off
    }
    else
    {
      digitalWrite(redPin, LOW);//turn the red led off
      digitalWrite(bluePin, LOW);//turn the green led off
      digitalWrite(yellowPin, LOW);//turn the yellow led off
    }    
}
