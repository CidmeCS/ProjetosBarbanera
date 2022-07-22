#ifndef SALVALISTAUIDS_H_INCLUDED
#define SALVALISTAUIDS_H_INCLUDED

#include "Classes/Cartao.h"
#include "Classes/Teclado.h"
#include <Arduino.h>
//#include <SD.h>
#include <SPI.h>
#include <time.h>
TFT_eSPI tft30 = TFT_eSPI();
using namespace std;
#include <stdlib.h>
#include <iostream>
#include <stdio.h>
#include <bits/stdc++.h>
#include <algorithm>
#include <iostream>
#include <vector>

using std::cout;

class SalvaListaUIDs
{
public:
    byte buzer = 27;
    byte pinVerde = 33;
    byte pinAzul = 32;
    byte pinVermelho = 25;
    Teclado *tecla;

    File file;
    String Texto = "";
    int ctd = 1; 

    vector<String> uids, UIDsSD;

    byte SS_SLAVE_RFID_EXT = 26;
    byte SS_SLAVE_RFID_INT = 17;
    //byte SS_SLAVE_SD = 16;
    SalvaListaUIDs(String RFID)
    {
        pinMode(pinAzul, OUTPUT);
        pinMode(pinVermelho, OUTPUT);
        pinMode(pinVerde, OUTPUT);
        pinMode(buzer, OUTPUT);
        pinMode(SS_SLAVE_RFID_EXT, OUTPUT);
        pinMode(SS_SLAVE_RFID_INT, OUTPUT);
        //pinMode(SS_SLAVE_SD, OUTPUT);

        digitalWrite(SS_SLAVE_RFID_EXT, HIGH); //desabilita
        digitalWrite(SS_SLAVE_RFID_INT, HIGH); //desabilita
        //digitalWrite(SS_SLAVE_SD, LOW);        // habilita

        // //INICIA SSD
        SPI.begin();
        // if (!SD.begin(SS_SLAVE_SD))
        // {
        //     Serial.println("Montagem erro");
        //     tft20.setCursor(300, 10);
        //     tft20.print("SD ERRO");
        // }
        // else
        // {
        //     Serial.println("Montagem OK SD");
        //     tft20.setCursor(300, 10);
        //     tft20.print("SD OK");
        // }
    }

    //obtem a UID do cartao.
    String StartCard(NTPClient tc)
    {
        Cartao *c = new Cartao("");
        String uid = "";
        do
        {
            uid = c->ObterBufferCartao(tc);
        } while (uid == "" | uid == "ERRO");
        return uid;
    }

    String GetData(NTPClient tc)
    {
        tc.update();
        return tc.getFormattedDate().substring(0, 10);
    }


    // Grava a UID no SD
    void GravaUidNoSD(String uidNew, NTPClient tc)
    {
        uidNew.trim();
        
        String data = GetData(tc);
        File file2 = SPIFFS.open("/UIDs_" + data + ".txt", FILE_APPEND);
        file2.println(uidNew);
        file2.close();
    }

    // Lista todas as UIDs do  SD. inclusive se houver Repetidas
    vector<String> ListarUIDsSD(NTPClient tc)
    {
        
        String data = GetData(tc);

        
            //cria file e diretorio se nescessario
           

            if (SPIFFS.exists("/UIDs_" + data + ".txt"))
            {
                Serial.println("EXISTE FILE");
            }
            else
            {
                Serial.println("NAO EXISTE FILE");
                file = SPIFFS.open("/UIDs_" + data + ".txt", FILE_WRITE);
                file.close();
                Serial.println("FILE CREATED >> /UIDs_" + data + ".txt");
            }

            // so para saber o tamanho. sz
            file = SPIFFS.open("/UIDs_" + data + ".txt", FILE_READ);
            int sz = 0, i = 0;
            while (file.available())
            {
                file.read();
                sz++;
            }
            file.close();

            Serial.println(sz);

            file = SPIFFS.open("/UIDs_" + data + ".txt", FILE_READ);
            auto f = file.readString();
            f.trim();
            auto uids = Split(f);
            for (auto u : uids)
            {
                UIDsSD.push_back(u.c_str());
            }
        
        Serial.println(String(UIDsSD.size()) + " >>");

        return UIDsSD;
    }

    vector<string> Split(String texto)
    {
        //get linhas
        String linha = "";
        vector<String> linhas;
        for (auto n : texto)
        {
            if (n == '\n')
            {
                linha.trim();
                linhas.push_back(linha);
                linha = "";
                continue;
            }
            linha += n;
        }
        if (linha.length() > 0)
        {
            linha.trim();
            linhas.push_back(linha);
        }

        //get UIDs
        vector<string> uids;

        Serial.println("*******---------**********");
        for (auto linha : linhas)
        {
            auto sbs = linha.substring(0, 11);
            sbs.trim();
            uids.push_back(sbs.c_str());
        }

        for (auto uid : uids)
        {
            Serial.println(uid.c_str());
        }
        Serial.println("*******---------**********");

        return uids;
    }

    void Start(NTPClient tc)
    {
        tft30.init();
        tft30.setRotation(1);
        tft30.fillScreen(TFT_BLACK);
        tft30.setTextSize(2);
        tft30.setTextColor(TFT_WHITE);
        tft30.setCursor(10, 10);

        tecla = new Teclado();
        auto t = tecla->tecla();

        auto uidsSD = ListarUIDsSD(tc);
        int szz = uidsSD.size();
        ctd = szz;
        tft30.print("SALVA LISTA RFIDs >> " + String(ctd));
        Listando45Ultimos(uidsSD);

        String uidNew = "", uidOld = "";

        while (true)
        {
        F:
            t = tecla->tecla();
            if (t == 'e')
            {
                ESP.restart();
            }

            auto u = StartCard(tc);
            u.trim();
            uidNew = u;

            if (uidNew == uidOld)
            {
                continue;
            }
            uidOld = uidNew;
            for (String s : uidsSD)
            {
                s.trim();
                if (s == uidNew)
                {
                    digitalWrite(pinVermelho, HIGH); //PRONTO PARA LER
                    delay(100);
                    digitalWrite(pinVermelho, LOW);
                    goto F;
                }
            }
            uidsSD.push_back(u);
            ctd++;
            GravaUidNoSD(uidNew, tc);

            Listando45Ultimos(uidsSD);


            digitalWrite(pinVerde, HIGH); //PRONTO PARA LER
            delay(200);
            digitalWrite(pinVerde, LOW);

            digitalWrite(buzer, HIGH);
            delay(100);
            digitalWrite(buzer, LOW);
        }
    }

    void Listando45Ultimos(vector<String> uidsSD)
    {
        if (uidsSD.size() > 45)
        {
            std::reverse(uidsSD.begin(), uidsSD.end());
            uidsSD.resize(45);
            std::reverse(uidsSD.begin(), uidsSD.end());
        }

        tft30.fillScreen(TFT_BLACK);
        tft30.setCursor(10, 10);
        tft30.print("SALVA LISTA RFIDs >> " + String(ctd));

        tft30.setTextSize(1);

        int i1 = 30, i2 = 30, i3 = 30, y = 1, k = ctd - 44;

        if (k <=0 )
        {
            k = 1;
        }
        

        for (auto u : uidsSD)
        {
            if (y <= 15)
            {
                tft30.setCursor(10, i1);
                tft30.print(String(u) + " <> " + String(k++));
                i1 += 16;
            }
            if (y >= 16 & y <= 30)
            {
                tft30.setCursor(170, i2);
                tft30.print(String(u) + " <> " + String(k++));
                i2 += 16;
            }
            if (y >= 31)
            {
                tft30.setCursor(330, i3);
                tft30.print(String(u) + " <> " + String(k++));
                i3 += 16;
            }
            y++;
        }
         tft30.setTextSize(2);
    }
};
#endif