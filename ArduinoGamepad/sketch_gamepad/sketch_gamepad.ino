#define xPin A0
#define yPin A1
#define swPin 8

#define btnPin1 9
#define btnPin2 10
#define btnPin3 11
#define btnPin4 12

int trenutniX = 0;
int trenutniY = 0;
boolean btn1 = false, btn2 = false, btn3 = false, btn4 = false;
String ulaz = ""; 

void setup()
{
   pinMode(swPin, INPUT);
   digitalWrite(swPin, HIGH);
   
   pinMode (btnPin1, INPUT);
   pinMode (btnPin2, INPUT);
   pinMode (btnPin3, INPUT);
   pinMode (btnPin4, INPUT); 
   
   Serial.begin(9600);  
}

void loop()
{
  if(Serial.available()>0)  
  {  
    ulaz = "";
    while (Serial.available() > 0)  
    {        
      ulaz += char(Serial.read());
      delay(2);
    }
  }
  if (ulaz == "start")
  {
   if (trenutniX != analogRead(xPin) || trenutniY != analogRead(yPin))
   {
     trenutniX = analogRead(xPin);
     trenutniY = analogRead(yPin);
     Serial.println("X");
     Serial.println(trenutniX);
     Serial.println("Y");
     Serial.println(trenutniY);
   }
    //delay(100);
    if (digitalRead(btnPin1) == HIGH){
      if(btn1 == false)
      {
        Serial.println("e");
        btn1 = true;
      }}
    else btn1 = false;
    
    if (digitalRead(btnPin2) == HIGH){
      if(btn2 == false)
      {
        Serial.println("r");
        btn2 = true;
      }}
    else btn2 = false;
    
    if (digitalRead(btnPin3) == HIGH){
      if(btn3 == false)
      {
        Serial.println("t");
        btn3 = true;
      }}
    else btn3 = false;
    
    if (digitalRead(btnPin4) == HIGH){
      if(btn4 == false)
      {
        Serial.println("z");
        btn4 = true;
      }}
    else btn4 = false;
  }
}
