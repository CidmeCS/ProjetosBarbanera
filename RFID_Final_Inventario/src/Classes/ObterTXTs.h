#ifndef OBTERTXT_H_INCLUDED
#define OBTERTXT_H_INCLUDED

#include <SPIFFS.h>
#include <Arduino.h>
#include <Classes/WiFiConnect.h>
#include <ESP32WebServer.h>
#include <ESPmDNS.h>
#include <SPIFFS.h>
#include <SPI.h>
#include <WiFi.h>
#include <WiFiClient.h>
#include <Classes/Inventario.h>
#include <MFRC522.h>
#include <NTPClient.h>
#include <fstream>
#include <string>
#include <iostream>

#define RST_PIN 2
#define SS_RFID 5

MFRC522 mfrc522(SS_RFID, RST_PIN); // Create MFRC522 instance

ESP32WebServer server2(80);
using namespace std;

byte pinAzul = 16;
byte buzer = 17;
byte power = 4;

class ObterTXTs
{
public:
    ObterTXTs()
    {
        pinMode(pinAzul, OUTPUT);
        pinMode(power, OUTPUT);
        digitalWrite(power, HIGH);
    }

    bool opened = false;
    const char *host = "rfid";

    void Obter(NTPClient timeClient)
    {
        SPI.begin();

        //Serial.println("MODO WEB SERVER");

        //Spiffs
        if (!SPIFFS.begin(true))
            Serial.println(F("An Error has occurred while mounting SPIFFS"));
        else
            Serial.println(F("SPIFFS ok"));

        //Serial.println("PRESS 'ESC' PARA SAIR");

        // WEBSERVER INICIO
        WebServerW(timeClient);
        // WEBSERVER FIM
    }

    void WebServerW(NTPClient timeClient)
    {

        if (MDNS.begin(host))
        {
            MDNS.addService("http", "tcp", 80);
            // //Serial.println("MDNS responder started");
            // //Serial.println("You can now connect to http://" + String(host) + ".local");
            // //Serial.println("http://" + String(host) + ".local");
        }

        //handle uri
        server2.on("/", listarArquivos);
        server2.on("/del", del);
        server2.onNotFound(handleNotFound);
        server2.begin();
        ////Serial.println("HTTP server2 started");

        //RFID
        MFRC522 mfrc522(SS_RFID, RST_PIN); // Create MFRC522 instance
        mfrc522.PCD_Init();                // Init MFRC522 card
        mfrc522.PCD_DumpVersionToSerial();

        while (true)
        {
            server2.handleClient();
            mfrc522.PCD_Init(); // Init MFRC522 card
            digitalWrite(pinAzul, HIGH);

            if (!mfrc522.PICC_IsNewCardPresent() | !mfrc522.PICC_ReadCardSerial())
            {
                continue;
            }

            String formattedDate = timeClient.getFormattedDate();
            formattedDate.replace('T', ' ');
            formattedDate.replace('Z', ' ');
            formattedDate.trim();
            //Serial.println(formattedDate);

            Inventario *inv = new Inventario();
            inv->start('I', "INTERNO", formattedDate);

            mfrc522.PICC_HaltA();
            mfrc522.PCD_StopCrypto1();

            InfoMemorias();

            //
            if (ESP.getFreeHeap() < 60000)
            {
                digitalWrite(pinAzul, LOW);
                ESP.restart();
            }
        }
    }

    void InfoMemorias()
    {
         Serial.println(String(ESP.getFreeHeap()) + " bytes de RAM LIVRE \n");
            // Get all information of SPIFFS

            //
            unsigned int totalBytes = SPIFFS.totalBytes();
            unsigned int usedBytes = SPIFFS.usedBytes();

            Serial.println("===== File system info =====");

            Serial.print("Total space:      ");
            Serial.print(totalBytes);
            Serial.println(" bytes");

            Serial.print("Total space used: ");
            Serial.print(usedBytes);
            Serial.println("  bytes");

            Serial.println();
    }

    static String delFile()
    {
        //Serial.println("DelFile entrou");
        auto args = server2.arg(0);
        File root = SPIFFS.open("/");
        File file = root.openNextFile();
        //
        while (file)
        {
            SPIFFS.remove(file.name());
            //Serial.printf("File deletada: %s\n", String(args));
            file.close();
            file = root.openNextFile();
        }
        return String("Lista de Arquivos:</br></br><a href='http://rfid.local/'>HOME</a>\t\t<a href='http://rfid.local/del'>DEL</a></br></br>");
    }

    static String getArquivos()
    {
        String response = "";
        File root = SPIFFS.open("/");
        File file2 = root.openNextFile();

        //String cabecalho = String("<table><tr><th>SEQ</th><th>DataHora</th><th>UID</th><th>CODIGO</th><th>DESCRICAO</th><th>UND</th><th>SaldoAtual</th><th>Prateleira</th><th>Conversor</th><th>Convertido</th></tr>");
        //String tabela = String("<tr><td>Jill</td><td>Smith</td><td>50</td></tr><tr><td>Eve</td><td>Jackson</td><td>94</td></tr></table>");

        while (file2)
        {
            response += String("<a href='") + String(file2.name()) + String("'>") + String(file2.name()) + String("</a>") + String("</br>");
            file2.close();
            file2 = root.openNextFile();
        }

        return String("Lista de Arquivos:</br></br><a href='http://rfid.local/'>HOME</a>\t\t<a href='http://rfid.local/del'>DEL</a></br></br>") + response;
    }

    static void listarArquivos()
    {
        String res = getArquivos();
        server2.send(200, "text/html", res);
    }

    static void del()
    {
        String res = delFile();
        server2.send(200, "text/html", res);
    }

    static bool loadFromSDCARD(String path)
    {
        //Serial.println("Vazio 002 " + path);
        File dataFile = SPIFFS.open(path, FILE_READ);
        // auto g = dataFile.readString();
        ////Serial.println(g);
        if (!dataFile)
            return false;

        // AQUI, CONVETER TEXTO EM STREAM E SUBSTITUIR PELO DATAFILE NA PROXIMA CONDIÇÃO ABAIXO;

        if (server2.streamFile(dataFile, "text/plain"))
        {
            //Serial.println("Sent less data than expected!");
        }
        dataFile.close();
        return true;

        path.toLowerCase();
        String dataType = "text/plain";
        if (path.endsWith("/"))
            path += "index.htm";

        if (path.endsWith(".src"))
            path = path.substring(0, path.lastIndexOf("."));
        else if (path.endsWith(".jpg"))
            dataType = "image/jpeg";
        else if (path.endsWith(".txt"))
            dataType = "text/plain";
        else if (path.endsWith(".zip"))
            dataType = "application/zip";
        //Serial.println(dataType);
        path.replace("%20", " ");
        dataFile = SPIFFS.open(path, FILE_READ);

        dataFile.close();
    }

    static void handleNotFound()
    {

        //Serial.println("Vazio 001");
        if (loadFromSDCARD(server2.uri()))
        {
            //Serial.println(server2.uri());
            return;
        }
        String message = "SDCARD Not Detected\n\n";
        message += "URI: ";
        message += server2.uri();
        message += "\nMethod: ";
        message += (server2.method() == HTTP_GET) ? "GET" : "POST";
        message += "\nArguments: ";
        message += server2.args();
        message += "\n";
        for (uint8_t i = 0; i < server2.args(); i++)
        {
            message += " NAME:" + server2.argName(i) + "\n VALUE:" + server2.arg(i) + "\n";
        }
        server2.send(404, "text/plain", message);
        //Serial.println(message);
    }

    static void listarPasta()
    {
        String res = getPasta();
        server2.send(200, "text/html", res);
    }

    static String getPasta()
    {
        String uri = server2.uri();
        //Serial.println(uri);
        String response = "";
        File root = SPIFFS.open(uri);
        File file = root.openNextFile();
        vector<String> vs;
        while (file)
        {
            vs.push_back(file.name());
            file.close();
            file = root.openNextFile();
        }
        sort(vs.begin(), vs.end());
        for (auto v : vs)
        {
            response += String("<a href='") + v + String("'>") + v + String("</a>") + String("</br>");
        }

        return String("Lista de " + uri + ":</br></br>") + response;
    }
};

#endif
