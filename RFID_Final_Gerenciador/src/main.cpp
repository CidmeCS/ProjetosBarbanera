#include <Arduino.h>
#include <Main/Main.h>
#include <SPIFFS.h>
#include <NTPClient.h>
#include <WiFi.h>
#include <iostream> 


using namespace std;

int timeZone = -3;
WiFiUDP udp;
NTPClient timeClient(
    udp,                 //socket udp
    "0.br.pool.ntp.org", //URL do servwer NTP
    timeZone * 3600,     //Deslocamento do horário em relacão ao GMT 0
    60000);              //Intervalo entre verificações online

void BuscaSSID();
void _Relogio();
void Teste();
const char *ssid;
const char *pswd;

class Logins
{
public:
};

void setup()
{

  Serial.begin(115200);

  Teste();
  //return;

  if (!SPIFFS.begin(true))
  {
    Serial.println("An Error has occurred while mounting SPIFFS");
  }
  else
    Serial.println("\nSPIFFS Montado OK!");

  //

  _Relogio();

  Main *m = new Main();
  m->M(timeClient);
}

void loop()
{
}

void Teste()
{
}

void BuscaSSID()
{
  int n = WiFi.scanNetworks();

  Serial.println("scan done");
  if (n == 0)
  {
    Serial.println("no networks found");
  }
  else
  {
    Serial.print(n);
    Serial.println(" networks found");
    for (int i = 0; i < n; ++i)
    {
      // Print SSID and RSSI for each network found
      Serial.print(i + 1);
      Serial.print(": ");
      Serial.print(WiFi.SSID(i));
      Serial.print(" (");
      Serial.print(WiFi.RSSI(i));
      Serial.print(")");
      Serial.println((WiFi.encryptionType(i) == WIFI_AUTH_OPEN) ? " " : "*");
      delay(10);
    }
  }
  Serial.println("");

  for (int i = 0; i < n; ++i)
  {
    Serial.println(WiFi.SSID(i));
    if (WiFi.SSID(i) != "Cid" & WiFi.SSID(i) != "Estoque")
    {
      continue;
    }

    if (WiFi.SSID(i) == "Estoque") // NÃO ESTA FUNCIONANDO. AGUARDAR O MARCOS ARRUMAR
    {
      ssid = "Estoque";
      pswd = "3L3Tr0BaEF18";
      break;
    }
    if (WiFi.SSID(i) == "Barbanera") // ??
    {
      ssid = "Barbanera";
      pswd = "3L3Tr0BaEF18";
      break;
    }
    if (WiFi.SSID(i) == "Cid") // para atualizar o relogio nao precisa do WiFi.config(...). Para WebServer usar IP, Getway e subnet Statico
    {
      ssid = "Cid";
      pswd = "xxxxxxxx";
      break;
    }
    if (WiFi.SSID(i) == "RedmiCid") // ??
    {
      ssid = "RedmiCid";
      pswd = "Th@les10";
      break;
    }
  }
}
void _Relogio()
{
  WiFi.mode(WIFI_STA);

  BuscaSSID();

  WiFi.begin(ssid, pswd);

  uint8_t ij = 1;
  while (WiFi.status() != WL_CONNECTED & ij <= 20)
  {
    delay(500);
    ij++;
  }

  if (WiFi.status() != WL_CONNECTED)
  {
    Serial.printf(" Could not connect to %s ", String(ssid));
    timeClient.begin();
    timeClient.setTimeOffset(-3600);
    timeClient.update();
    return;
  }
  else
  {
    Serial.printf("Conectado a %s ", String(ssid));
    Serial.printf("WIFI: IP %s, SSID %s \n", WiFi.localIP().toString().c_str(), WiFi.SSID());
    return;
  }
}