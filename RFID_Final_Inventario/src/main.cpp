#include <Arduino.h>
#include <Classes/WiFiConnect.h>
#include <Classes/ObterTXTs.h>
#include <NTPClient.h>
#include <SPIFFS.h>

WiFiUDP ntpUDP;
NTPClient timeClient(ntpUDP);

void setup()
{

  Serial.begin(115200);
}

void loop()
{
  unsigned int usedBytes = SPIFFS.usedBytes();

  if (usedBytes > 1375000)
  {
    Serial.println("Memoria Flash / SPIFFS cheio");
    delay(1000);
    return;
  }
  

  //HORA e data
  WiFiConnect *wc = new WiFiConnect();

  if (!wc->Relogio())
  {
    return;
  }

  //Serial.println("Relogio OK");

  timeClient.begin();
  timeClient.setTimeOffset(-10800);
  timeClient.update();

  String formattedDate = timeClient.getFormattedDate();
  //Serial.println(formattedDate);
  formattedDate.replace('T', ' ');
  formattedDate.replace('Z', ' ');
  formattedDate.trim();
  String year = formattedDate.substring(0, 4);

  int yearr = year.toInt();

  Serial.println(yearr);

  if (yearr != 2022)
  {
    byte pinAzul = 16;
    byte buzer = 17;
    pinMode(pinAzul, OUTPUT);
    pinMode(buzer, OUTPUT);

    for (size_t i = 0; i < 10; i++)
    {
      digitalWrite(pinAzul, HIGH);
      digitalWrite(buzer, HIGH);
      delay(50);
      digitalWrite(pinAzul, LOW);
      digitalWrite(buzer, LOW);
      delay(50);
    }

    Serial.println(yearr);
    ESP.restart(); //return;
  }

  //WEBSERVER
  wc->ObterTXTs();
  ObterTXTs *o = new ObterTXTs();
  o->Obter(timeClient);
}