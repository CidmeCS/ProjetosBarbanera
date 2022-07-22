#ifndef INVENTARIO_H_INCLUDED
#define INVENTARIO_H_INCLUDED

#include "Classes/Cartao.h"
#include "Classes/ObterTXTs.h"
#include "RTClib.h"
#include <Arduino.h>
#include <FS.h>
#include <MFRC522.h>
#include <SPIFFS.h>
#include <SPI.h>
#include <iostream>
#include <time.h>
using namespace std;
#include <istream>
#include <stdio.h>
#include <string>

class Inventario
{
public:
    Inventario()
    {

        // digitalWrite(SS_SLAVE_RFID_EXT, LOW);  // Habilita o SS.
        // digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Habilita o SS.
        // digitalWrite(SS_SLAVE_SPIFFS, HIGH);       // Desabilita o SS.
    }

    byte RST_PIN = 4;
    byte SS_SLAVE_RFID = 5;

    byte pinAzul = 32;
    
    byte buzer = 17;

    long timezone = -3;
    byte daysavetime = 1;

    RTC_DS3231 rtc;
    DateTime now;
    MFRC522::MIFARE_Key key;
    File root, leituras, inventarios;
    vector<String> vIDs;

    void createDir2(fs::FS &fs, const char *path)
    {
        if (fs.exists(path))
        {
            //Serial.printf("Ja existe: %s\n", path);
            return;
        }

        //Serial.printf("Criando Dir: %s\n", path);
        if (fs.mkdir(path))
        {
            //Serial.println("Dir created");
        }
        else
        {
            //Serial.println("Dir failed");
        }
    }

    void createFile(fs::FS &fs, const char *path)
    {
        if (fs.exists(path))
        {
            //Serial.println("Arquivo ja existe");
            return;
        }
        File file = fs.open(path, FILE_WRITE);
        if (!file)
        {
            //Serial.println("Failed to open file for writing");
            return;
        }
        else
        {
            //Serial.println("Arquivo criado");
        }
        file.close();
    }

    void readFile(fs::FS &fs, const char *path)
    {
        //Serial.printf("Reading file: %s\n", path);

        File file = fs.open(path);
        if (!file)
        {
            //Serial.println("Failed to open file for reading");
            return;
        }

        //Serial.println("Read from file: ");
        while (file.available())
        {
            Serial.write(file.read());
        }
        file.close();
    }

    void deleteFile(fs::FS &fs, const char *path)
    {
        //Serial.printf("Deleting file: %s\n", path);
        if (fs.remove(path))
        {
            //Serial.println("File deleted");
        }
        else
        {
            //Serial.println("Delete failed");
        }
    }

    void appendFile(fs::FS &fs, const char *path, String message)
    {
        ////Serial.printf("Appending to file: %s\n", path);

        File file = fs.open(path, FILE_APPEND);
        if (!file)
        {
            ////Serial.println("Failed to open file for appending");
            return;
        }
        if (file.print(message))
        {
            ////Serial.println("Message appended");
        }
        else
        {
            //Serial.println("Append failed");
        }

        file.close();
    }

    void reset()
    {
        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN);
        // mfrc522.PICC_HaltA();

        // mfrc522.PCD_StopCrypto1();
        //porque esta lendo o cartao mais de uma vez....
        mfrc522.PCD_Reset();
    }

    void start(char t, String RFID, String data)
    {
        SPI.begin();
        rtc.begin();
        now = rtc.now();

        char file[27];

        ("/Inventario_" + data.substring(0, 10) + ".txt").toCharArray(file, 27);

        MontandoSD(t, file);

       
        Cartao *c = new Cartao(RFID);

        c->ObterBufferCartao();
        

        data += "\t";

        if (c->Codigo_1.length() > 1)
        {
            appendFile(SPIFFS, file, "1\t" + data + c->UID + c->Codigo_1 + c->Descricao_1 + c->UND_1 + c->Quantidade_1 + c->Prateleira_1 + c->Conversor_1 + c->Convertido_1);
        }
        if (c->Codigo_2.length() > 1)
        {
            appendFile(SPIFFS, file, "2\t" + data + c->UID + c->Codigo_2 + c->Descricao_2 + c->UND_2 + c->Quantidade_2 + c->Prateleira_2 + c->Conversor_2 + c->Convertido_2);
        }
        if (c->Codigo_3.length() > 1)
        {
            appendFile(SPIFFS, file, "3\t" + data + c->UID + c->Codigo_3 + c->Descricao_3 + c->UND_3 + c->Quantidade_3 + c->Prateleira_3 + c->Conversor_3 + c->Convertido_3);
        }
        if (c->Codigo_4.length() > 1)
        {
            appendFile(SPIFFS, file, "4\t" + data + c->UID + c->Codigo_4 + c->Descricao_4 + c->UND_4 + c->Quantidade_4 + c->Prateleira_4 + c->Conversor_4 + c->Convertido_4);
        }

        if (c->Codigo_5.length() > 1)
        {
            appendFile(SPIFFS, file, "5\t" + data + c->UID + c->Codigo_5 + c->Descricao_5 + c->UND_5 + c->Quantidade_5 + c->Prateleira_5 + c->Conversor_5 + c->Convertido_5);
        }

        appendFile(SPIFFS, file, "\r");

        //Serial.println();


        delay(100); //change value if you want to read cards faster
    }

    void MontandoSD(int t, char file[39])
    {
        digitalWrite(SS_SLAVE_RFID, HIGH); // Desabilita o SS.

        if (!SPIFFS.begin(true))
        {
            //Serial.println("An Error has occurred while mounting SPIFFS");
            return;
        }
        else
        {
            //Serial.println("Card Mount Sucesso");

            // if (t == 'I')
            //     createDir2(SPIFFS, "/Inventarios");
            // else if (t == 'L')
            //     createDir2(SPIFFS, "/Leituras");

            createFile(SPIFFS, file);

            //Serial.print(file);
        }
    }

    vector<String> obtemIDs(char *file)
    {
        //Serial.println("<<PATH>>");
        //Serial.println(file);
        String texto = SPIFFS.open(file).readString();

        //Serial.println(texto);

        vector<string> uids = explode2(texto);

        vector<String> vs;
        for (auto uid : uids)
        {
            vs.push_back(uid.data());
        }
        return vs;
    }

    vector<string> explode2(String texto)
    {
        //get linhas
        String linha = "";
        vector<String> linhas;
        for (auto n : texto)
        {
            if (linha == "" & n == '\n')
            {
                continue;
            }
            if (n == '\n')
            {
                linhas.push_back(linha);
                linha = "";
                continue;
            }
            linha += n;
        }

        //get UIDs
        vector<string> uids;

        //Serial.println("*******---------**********");
        for (auto linha : linhas)
        {
            auto sbs = linha.substring(22, 34);
            sbs.trim();
            uids.push_back(sbs.c_str());
        }
        sort(uids.begin(), uids.end());
        auto gg = unique(uids.begin(), uids.end());
        uids.resize(std::distance(uids.begin(), gg));

        for (auto uid : uids)
        {
            //Serial.println(uid.c_str());
        }
        //Serial.println("*******---------**********");

        return uids;
    }
};
#endif