#ifndef WIFICONNECT_H
#define WIFICONNECT_H
#include <Arduino.h>
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

    WiFiClass con()
    {

        switch (2)
        {
        case OBTERTXTS:
            if (true)
            {
                return wc;
            }
            break;
        case RELOGIO:
            if (Relogio())
            {
                return wc;
            }
            break;
        }
        y++;

        return wc;
    }

    bool Relogio()
    {
        
        //Serial.print("Connecting to... ");

        // Wait for connection
        WiFi.mode(WIFI_STA);

        BuscaSSID();

        //Serial.print(ssid2);
        WiFi.begin(ssid2, pwd);
        uint8_t ij = 0;
        while (WiFi.status() != WL_CONNECTED && ij++ <= 20)
        { //wait 10 seconds
            //Serial.print(".");
            delay(500);
        }
        
        if (WiFi.status() == WL_CONNECTED)
        {
            //Serial.print("Conectado to... " + String(ssid2));
            wc = WiFi;
            return true;
        }
        else
        {
            //Serial.print("Not connect to " + String(ssid2));
            wc = WiFi;
            return false;
        }
    }

    void ObterTXTs()
    {
        

        WiFi.mode(WIFI_STA);

        BuscaSSID();
        //Serial.printf("Connecting to %s ", String(ssid2));

        if (!WiFi.config(local_IP, gateway, subnet, primaryDNS, secondaryDNS))
        {
            //Serial.println("STA Failed to configure");
        }

        WiFi.begin(ssid2, pwd);

        wc = WiFi;

        // Wait for connection
        uint8_t ij = 1;
        while (WiFi.status() != WL_CONNECTED & ij <= 20)
        { //wait 10 seconds
            delay(500);
            //Serial.print(".");
            ij++;
        }
        if (WiFi.status() != WL_CONNECTED)
        {
            //Serial.printf(" Could not connect to %s ", String(ssid2));
            wc = WiFi;
            return ;
        }
        else
        {
            //Serial.printf("Conectado a %s \n", String(ssid2));
            wc = WiFi;
            //Serial.printf("WIFI: IP %s, SSID %s \n", wc.localIP().toString().c_str(), wc.SSID().c_str());

            //Serial.print("WEB SERVER OK!!");
            return ;
        }
    }
    void BuscaSSID()
    {
        int n = WiFi.scanNetworks();

        //Serial.println("scan done");
        if (n == 0)
        {
            //Serial.println("no networks found");
        }
        else
        {
            //Serial.print(n);
            //Serial.println(" networks found");
            for (int i = 0; i < n; ++i)
            {
                // Print SSID and RSSI for each network found
                //Serial.print(i + 1);
                //Serial.print(": ");
                //Serial.print(WiFi.SSID(i));
                //Serial.print(" (");
                //Serial.print(WiFi.RSSI(i));
                //Serial.print(")");
                //Serial.println((WiFi.encryptionType(i) == WIFI_AUTH_OPEN) ? " " : "*");
                delay(10);
            }
        }
        //Serial.println("");

        for (int i = 0; i < n; ++i)
        {
            //Serial.println(WiFi.SSID(i));
            if (WiFi.SSID(i) == "Estoque") // NÃO ESTA FUNCIONANDO. AGUARDAR O MARCOS ARRUMAR
            {
                ssid2 = "Estoque";
                pwd = "3L3Tr0BaEF18";
                break;
            }
            if (WiFi.SSID(i) == "Barbanera") // ??
            {
                ssid2 = "Barbanera";
                pwd = "3L3Tr0BaEF18";
                break;
            }
            if (WiFi.SSID(i) == "Cid") // para atualizar o relogio nao precisa do WiFi.config(...). Para WebServer usar IP, Getway e subnet Statico
            {
                ssid2 = "Cid";
                pwd = "xxxxxxxx";
                break;
            }
            if (WiFi.SSID(i) == "RedmiCid") // ??
            {
                ssid2 = "RedmiCid";
                pwd = "Th@les10";
                break;
            }
        }
        // Wait a bit before scanning again
        //delay(5000);
    }
};
#endif