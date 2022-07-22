#ifndef INVENTARIO_H_INCLUDED
#define INVENTARIO_H_INCLUDED

#include "Classes/Cartao.h"
#include "Classes/Manutencao.h"
#include "Classes/Teclado.h"
#include "Classes/ObterTXTs.h"
#include <Arduino.h>
#include <FS.h>
#include <MFRC522.h>
#include <SPI.h>
#include <TFT_eSPI.h>
#include <SPIFFS.h>
#include <iostream>
#include <time.h>
TFT_eSPI tft2 = TFT_eSPI();
using namespace std;
#include <istream>
#include <stdio.h>
#include <string>

class Leitura
{
public:
    Leitura()
    {
        SS_SLAVE_RFID_EXT = 26;
        SS_SLAVE_RFID_INT = 17;

        pinMode(SS_SLAVE_RFID_EXT, OUTPUT);    //  9
        digitalWrite(SS_SLAVE_RFID_EXT, HIGH); // HABILITA o SS.

        pinMode(SS_SLAVE_RFID_INT, OUTPUT);   //  9
        digitalWrite(SS_SLAVE_RFID_INT, LOW); // Desabilita o SS.
    }

    byte SS_SLAVE_RFID_INT = 17;
    byte SS_SLAVE_RFID_EXT = 26;
    byte RST_PIN = 4;

    byte pinAzul = 32;
    byte pinVermelho = 25;
    byte pinVerde = 33;
    byte buzer = 27;

    long timezone = -3;
    byte daysavetime = 1;

    MFRC522::MIFARE_Key key;
    File root, leituras; //, inventarios;
    vector<String> vIDs;

    void createDir2(fs::FS &fs, const char *path)
    {
        if (fs.exists(path))
        {
            Serial.printf("Ja existe: %s", path);
            return;
        }

        Serial.printf("Criando Dir: %s", path);
        if (fs.mkdir(path))
        {
            Serial.println("Dir created");
        }
        else
        {
            Serial.println("Dir failed");
        }
    }

    void createFile(fs::FS &fs, const char *path)
    {
        if (SPIFFS.exists(path))
        {
            Serial.printf("Arquivo ja existe: %s\n", path);
            return;
        }
        File file = fs.open(path, FILE_WRITE);
        if (!file)
        {
            Serial.println("Failed to open file for writing");
            return;
        }
        else
        {
            Serial.printf("Arquivo criado: %s\n");
        }
        file.close();
    }

    void readFile(fs::FS &fs, const char *path)
    {
        Serial.printf("Reading file: %s\n", path);

        File file = fs.open(path);
        if (!file)
        {
            Serial.println("Failed to open file for reading");
            return;
        }

        //Serial.print("Read from file: ");
        while (file.available())
        {
            Serial.write(file.read());
        }
        file.close();
    }

    void deleteFile(fs::FS &fs, const char *path)
    {
        Serial.printf("Deleting file: %s\n", path);
        if (fs.remove(path))
        {
            Serial.println("File deleted");
        }
        else
        {
            Serial.println("Delete failed");
        }
    }

    void appendFile(fs::FS &fs, const char *path, String message)
    {
        Serial.printf("Appending to file: %s\n", path);

        File file = fs.open(path, FILE_APPEND);
        if (!file)
        {
            Serial.println("Failed to open file for appending");
            return;
        }
        if (file.print(message))
        {
            Serial.println("Message appended");
        }
        else
        {
            Serial.println("Append failed");
        }

        file.close();
    }

    String GetData(NTPClient tc)
    {
        //tc.update();
        return tc.getFormattedDate().substring(0, 10);
    }

    String GetDataHora(NTPClient tc)
    {
        //tc.update();
        String fd = tc.getFormattedDate();
        fd.replace('T', ' ');
        fd.replace('Z', ' ');
        fd.trim();
        return fd;
    }

    void start(NTPClient tc)
    {

        String data = GetData(tc);

        pinMode(buzer, OUTPUT); //  9

        SPI.begin();
        tft2.init();

        char file[23];

        ("/Leitura_" + data + ".txt").toCharArray(file, 24);

        createFile(SPIFFS, file);

        tft2.setRotation(1);

        Serial.println("Leituras");
        tft2.fillScreen(TFT_YELLOW);
        tft2.setTextSize(2);
        tft2.setTextColor(TFT_BLACK);
        tft2.setCursor(90, 40);
        tft2.print("LEITURA BARBANERA");

        pinMode(pinAzul, OUTPUT);     // 32
        pinMode(pinVermelho, OUTPUT); // 33
        pinMode(pinVerde, OUTPUT);    // 25

        digitalWrite(pinAzul, HIGH);
        delay(200);
        digitalWrite(pinAzul, LOW);
        delay(200);
        digitalWrite(pinVermelho, HIGH); //PRONTO PARA LER
        delay(200);
        digitalWrite(pinVermelho, LOW); //PRONTO PARA LER
        delay(200);
        digitalWrite(pinVerde, HIGH); //PRONTO PARA LER
        delay(200);
        digitalWrite(pinVerde, LOW); //PRONTO PARA LER

        Cartao *c;

        Teclado *tcl = new Teclado();
        char j = ' ';

        String uidNew = "";
        String uidOld = "";

        digitalWrite(buzer, HIGH);
        delay(100);
        digitalWrite(buzer, LOW);
        while (j != 'e')
        {
            digitalWrite(pinVermelho, LOW); //apaga

            j = tcl->tecla();
            c = new Cartao("");
            uidNew = c->ObterBufferCartao(tc);
            uidNew.trim();

            if (uidNew == uidOld | uidNew == "ERRO")
            {
                digitalWrite(pinVermelho, HIGH); //acende
                delay(100);
                c->reset();
                Serial.println("ERRO DO CARTAO. uidNew: " + String(uidNew) + " uidOld: " + String(uidOld) + ", " + String(ESP.getFreeHeap()));
                delete c;
                continue;
            }
            uidOld = uidNew;

            tc.update();

            tft2.fillScreen(TFT_BLACK);

            tft2.setTextColor(TFT_MAGENTA);
            tft2.setCursor(0, 0);
            tft2.println("UID: " + c->vp[0]->id + "\nPrateleira: " + c->vp[0]->prateleira);
            tft2.println("Data: " + c->vp[0]->data);

            int x1 = 50, x2 = 82;
            for (size_t i = 0; i < 5; i++)
            {
                if (c->vp[i]->codigo.length() == 0)
                {
                    x1 += 50;
                    x2 += 50;
                    continue;
                }

                switch (i)
                {
                case 0:
                    tft2.setTextColor(TFT_GREEN);
                    break;
                case 1:
                    tft2.setTextColor(TFT_YELLOW);
                    break;
                case 2:
                    tft2.setTextColor(TFT_RED);
                    break;
                case 3:
                    tft2.setTextColor(TFT_CYAN);
                    break;
                case 4:
                    tft2.setTextColor(TFT_WHITE);
                    break;
                }

                tft2.setCursor(0, x1);
                tft2.print(c->vp[i]->seq);
                tft2.setCursor(24, x1);
                tft2.print(c->vp[i]->codigo);
                tft2.setCursor(204, x1);
                tft2.print(c->vp[i]->descricao);
                tft2.setCursor(0, x2);
                tft2.print(c->vp[i]->und);
                tft2.setCursor(36, x2);
                tft2.print(c->vp[i]->qtd);
                tft2.setCursor(168, x2);
                tft2.print(c->vp[i]->convsor);
                tft2.setCursor(300, x2);
                tft2.print(c->vp[i]->convert);

                appendFile(SPIFFS, file, String(i + 1) + "\t" + c->vp[i]->data + "\t" + c->vp[i]->id + "\t" + c->vp[i]->codigo + "\t" + c->vp[i]->descricao + "\t" + c->vp[i]->und + "\t" + c->vp[i]->qtd + "\t" + c->vp[i]->prateleira + "\t" + c->vp[i]->convsor + "\t" + c->vp[i]->convert + "\r");

                x1 += 50;
                x2 += 50;
            }

            appendFile(SPIFFS, file, "\r");

            digitalWrite(buzer, HIGH);
            delay(50);
            digitalWrite(buzer, LOW);
            delay(50);
            digitalWrite(buzer, HIGH);
            delay(50);
            digitalWrite(buzer, LOW);
           
            delete c;
        }

        tft2.setTextColor(TFT_YELLOW);
        tft2.fillRect(10, 300, 470, 18, TFT_BLUE);
        tft2.setCursor(10, 300);
        tft2.println("ESC -> Aguarde...");
        ESP.restart();
    }

    vector<String> obtemIDs(char *file)
    {
        Serial.println("<<PATH>>");
        Serial.println(file);
        String texto = SPIFFS.open(file).readString();

        Manutencao *g = new Manutencao();
        vector<string> uids = g->explode2(texto);

        vector<String> vs;
        for (auto uid : uids)
        {
            vs.push_back(uid.data());
        }
        return vs;
    }
};
#endif