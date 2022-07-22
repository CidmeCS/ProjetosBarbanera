#ifndef WIFICONNECT_H_INCLUDED
#define WIFICONNECT_H_INCLUDED
#include <Arduino.h>
#include <TFT_eSPI.h>
#include <WiFi.h>

using namespace std;
IPAddress local_IP(192, 168, 0, 70);
IPAddress subnet(255, 255, 255, 0);
IPAddress gateway(192, 168, 0, 1);
IPAddress primaryDNS(192, 168, 0, 1); //optional
IPAddress secondaryDNS(0, 0, 0, 0);   //optional

class WiFiConnect
{
public:
    WiFiConnect()
    {
    }

    byte y;

    //const vector<char *> ssid = {"CID_MODEM", "Barbanera", "Barbanera Fabrica", "Elaine Souza", "RedmiCid"};
    //const vector<char *> password = {"xxxxxxxx", "3L3Tr0BaEF18", "3L3Tr0BaEF18", "elaineonca", "Th@les10"};

    enum chama
    {
        OBTERTXTS = 1,
        RELOGIO = 2
    };
    char *ssid2;
    char *pwd;

    WiFiClass wc;

    WiFiClass con(chama chamax, TFT_eSPI tft)
    {

        switch (chamax)
        {
        case OBTERTXTS:
            if (ObterTXTs(tft))
            {
                return wc;
            }
            break;
        case RELOGIO:
            if (Relogio(tft))
            {
                return wc;
            }
            break;
        }
        y++;

        return wc;
    }

    bool Relogio(TFT_eSPI tft3)
    {
        tft3.fillRect(0, 90, 480, 60, TFT_BLUE);
        tft3.setCursor(50, 90);
        tft3.print("Connecting to... ");

        // Wait for connection
        WiFi.mode(WIFI_STA);

        BuscaSSID();

        tft3.print(ssid2);
        WiFi.begin(ssid2, pwd);
        uint8_t ij = 0;
        tft3.setCursor(50, 110);
        while (WiFi.status() != WL_CONNECTED && ij++ <= 20)
        { //wait 10 seconds
            tft3.print(".");
            delay(500);
        }

        tft3.fillRect(0, 90, 480, 60, TFT_BLUE);
        wl_status_t stat = WiFi.status();
        Serial.println(stat);
        if (WiFi.status() == WL_CONNECTED)
        {
            tft3.setCursor(50, 100);
            tft3.print("Conectado to... " + String(ssid2));
            wc = WiFi;
            return true;
        }
        else
        {
            tft3.setCursor(50, 130);
            tft3.print("Not connect to " + String(ssid2));
            wc = WiFi;
            return false;
        }
    }

    bool ObterTXTs(TFT_eSPI tft9)
    {
        WiFi.mode(WIFI_STA);

        BuscaSSID();

        if (!WiFi.config(local_IP, gateway, subnet, primaryDNS, secondaryDNS))
        {
            Serial.println("STA Failed to configure");
        }

        WiFi.begin(ssid2, pwd);

        wc = WiFi;

        uint8_t ij = 1;
        while (WiFi.status() != WL_CONNECTED & ij <= 20)
        {
            delay(500);
            ij++;
        }

        if (WiFi.status() != WL_CONNECTED)
        {
            Serial.printf(" Could not connect to %s ", String(ssid2));
            wc = WiFi;
            return false;
        }
        else
        {
            Serial.printf("Conectado a %s ", String(ssid2));
            wc = WiFi;
            Serial.printf("WIFI: IP %s, SSID %s \n", wc.localIP().toString().c_str(), wc.SSID());

            tft9.setCursor(90, 80);
            tft9.print("WEB SERVER OK!!");
            return true;
        }
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
                ssid2 = "Estoque";
                pwd = "3L3Tr0BaEF18";
                break;
            }
            if (WiFi.SSID(i) == "Cid") // para atualizar o relogio nao precisa do WiFi.config(...). Para WebServer usar IP, Getway e subnet Statico
            {
                ssid2 = "Cid";
                pwd = "xxxxxxxx";
                break;
            }
            if (WiFi.SSID(i) == "Barbanera") // ??
            {
                ssid2 = "Barbanera";
                pwd = "3L3Tr0BaEF18";
                break;
            }
            if (WiFi.SSID(i) == "RedmiCid") // ??
            {
                ssid2 = "RedmiCid";
                pwd = "Th@les10";
                break;
            }
        }
    }};
#endif