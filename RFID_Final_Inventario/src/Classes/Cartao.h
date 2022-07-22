#ifndef CARTAO_H_INCLUDED
#define CARTAO_H
#include <Arduino.h>
#include <Classes/Produto.h>
#include <MFRC522.h>
#include <RTClib.h>
#include <stdlib.h>
#include <time.h>
#include <cstddef>
#include <cstring>
#include <encode.h>
#include <iostream>
#include <stdlib.h>
#include <Classes/stringhelper.h>

using namespace std;

class Cartao
{
public:
    Cartao(String RFID)
    {
        if (RFID == "")
        {
            return;
        }

        byte SS_SLAVE_RFID_INT = 5;
        byte SS_SLAVE_RFID_EXT = 5;
        pinMode(SS_SLAVE_RFID_INT, OUTPUT);
        pinMode(SS_SLAVE_RFID_EXT, OUTPUT);
        pinMode(SS_SLAVE_SD, OUTPUT);
        if (RFID == "EXTERNO")
        {
            digitalWrite(SS_SLAVE_RFID_EXT, LOW);  // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Habilita o SS.
            digitalWrite(SS_SLAVE_SD, HIGH);       // Desabilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_EXT;
        }
        else if (RFID == "INTERNO")
        {
            digitalWrite(SS_SLAVE_RFID_EXT, HIGH); // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, LOW);  // Habilita o SS.
            digitalWrite(SS_SLAVE_SD, HIGH);       // Desabilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_INT;
        }
    }

//variaveis
#pragma region Variaveis

    byte SS_SLAVE_RFID = 5;
    byte SS_SLAVE_SD = 16;
    byte RST_PIN = 2;
    MFRC522::MIFARE_Key key;

    vector<Produto *> vp, vc;
    vector<Produto2 *> vc2;
    Produto *p;
    byte **BufferCartao = 0;

    String UID;

    //Grupo 1
    String Codigo_1;
    String Descricao_1;
    String UND_1;
    String Quantidade_1;
    String Prateleira_1;
    String Conversor_1;
    String Convertido_1;

    //Grupo 2
    String Codigo_2;
    String Descricao_2;
    String UND_2;
    String Quantidade_2;
    String Prateleira_2;
    String Conversor_2;
    String Convertido_2;

    //Grupo 3
    String Codigo_3;
    String Descricao_3;
    String UND_3;
    String Quantidade_3;
    String Prateleira_3;
    String Conversor_3;
    String Convertido_3;

    //Grupo 4
    String Codigo_4;
    String Descricao_4;
    String UND_4;
    String Quantidade_4;
    String Prateleira_4;
    String Conversor_4;
    String Convertido_4;

    //Grupo 5
    String Codigo_5;
    String Descricao_5;
    String UND_5;
    String Quantidade_5;
    String Prateleira_5;
    String Conversor_5;
    String Convertido_5;

    //Grupo 6
    String L61;
    String L62;

    byte **buffer;
    MFRC522::StatusCode status;

    enum TIPOS
    {
        CONVERTIDO,
        QUANTIDADE,
        CONVERSOR
    };
#pragma endregion

    double calculoDependente(vector<Produto *> vp, double conversor, int index, TIPOS TIPO, double qtd, double convertido)
    {

        if (verificaDescricao(vp, index))
        {
            if (TIPO == CONVERSOR)
            {
                return (vp[index]->qtd / conversor);
            }
            else if (TIPO == QUANTIDADE)
            {
                return (qtd / vp[index]->convsor);
            }
            else if (TIPO == CONVERTIDO)
            {
                return (convertido * vp[index]->convsor);
            }
        }
        else
        {
            if (TIPO == CONVERSOR)
            {
                return (vp[index]->qtd * conversor);
            }
            else if (TIPO == QUANTIDADE)
            {
                return (qtd * vp[index]->convsor);
            }
            else if (TIPO == CONVERTIDO)
            {
                return (convertido / vp[index]->convsor);
            }
        }
    }

    bool verificaDescricao(vector<Produto *> vp, int index)
    {
        String strArr[] = {"DESC", "TUBO ", "BARRA ", "Thursday", "Friday", "Saturday", "Sunday"};

        for (auto i : strArr)
        {
            if (vp[index]->descricao.startsWith(i))
                return true;
        }
        return false;
    }

    String getID(MFRC522 mfrc522)
    {
        byte readCard[4];

        if (!mfrc522.PICC_IsNewCardPresent())
        {
            return "";
        }
        ////Serial.println("Novo Cartao Presente");

        if (!mfrc522.PICC_ReadCardSerial())
        {
            return "";
        }
        ////Serial.println(F("Lendo Cartao..."));

        ////Serial.println(F("Scanned PICC's UID:"));
        for (uint8_t i = 0; i < 4; i++)
        { //
            readCard[i] = mfrc522.uid.uidByte[i];
        }

        byte c[4];
        for (byte t = 0; t < 4; t++)
        {
            c[t] = readCard[t];
        }
        UID = DecToHex(c, 4);
        ////Serial.println(UID);
        // mfrc522.PICC_HaltA(); // Stop reading
        // mfrc522.PCD_StopCrypto1();
        return UID;
    }

    //Obtem a UID do cartao.
    String ObterUIDCartao()
    {
        String UID2;

        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance
        MFRC522::MIFARE_Key key2;

        //mfrc522.PCD_Reset();

        mfrc522.PCD_Init(); // Init MFRC522 card
        for (byte i = 0; i < 6; i++)
        {
            key2.keyByte[i] = 0xFF;
        }

        byte pinVerde = 33;
        pinMode(pinVerde, OUTPUT); // 25

        while (true)
        {
            if (!mfrc522.PICC_IsNewCardPresent() || !mfrc522.PICC_ReadCardSerial())
            {
                delay(50);
            }
            else
                break;
        }
        byte uid[4];
        int i = 0;

        for (auto uid2 : mfrc522.uid.uidByte)
        {
            uid[i] = uid2;
            i++;
        }

        UID2 = DecToHex(uid, 4);

        ////Serial.println(F("Card UID:"));
        ////Serial.println(UID2);

        mfrc522.PICC_HaltA();

        return UID2;
    }

    String ObterBufferCartao()
    {
        String UID2;
        BufferCartao = 0;
        BufferCartao = new byte *[63];
        for (byte h = 0; h < 63; h++)
        {
            BufferCartao[h] = new byte[18];
        }

        byte sb = 18;

        ////Serial.println("Aproxime um cartao");

        ////Serial.println("ESC >> MENU");

        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance
        ////Serial.println(SS_SLAVE_RFID);
        mfrc522.PCD_Reset();

        mfrc522.PCD_Init(); // Init MFRC522 card
        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }

        byte buzer = 17;
        byte pinAzul = 16;
        pinMode(buzer, OUTPUT);
        pinMode(pinAzul, OUTPUT);
        digitalWrite(buzer, HIGH);

    F:
        if (!mfrc522.PICC_IsNewCardPresent())
        {
            goto F;
        }

        // Select one of the cards
        if (!mfrc522.PICC_ReadCardSerial())
        {
            goto F;
        }

        ////Serial.println(F("Lendo Cartao..."));

        for (byte i = 0; i < 63; i++)
        {
            status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, i, &key, &(mfrc522.uid)); //line 834 of MFRC522.cpp file
            if (status != MFRC522::STATUS_OK)
            {
                ////Serial.print(F("Authentication failed: "));
                ////Serial.println(mfrc522.GetStatusCodeName(status));
                return "ERRO";
            }
            status = mfrc522.MIFARE_Read(i, &BufferCartao[i][0], &sb);
        }
        digitalWrite(pinAzul, LOW);
        digitalWrite(buzer, LOW);

        delay(500); // DEPOIS DE LIDO 0,5 SEGUNDOS PARA RETIRAR

        ////Serial.println(F("Cartao Autenticado"));

        mfrc522.PICC_HaltA();

        mfrc522.PCD_StopCrypto1();

        MontarVariaveis();

        MontarVetor();

        byte uid3[4];
        byte ih = 0;
        for (auto i : mfrc522.uid.uidByte)
        {
            if (ih < 4)
            {
                uid3[ih++] = i;
            }
        }

        UID2 = DecToHex(uid3, 4);
        mfrc522.PCD_Reset();

        return UID2;
    }

    string cs(String v)
    {
        string q;
        for (size_t i = 0; i < v.length(); i++)
        {
            q[i] = v[i];
        }
        return q;
    }

    void MontarVetor()
    {
        Produto *p;
        DateTime now;
        RTC_DS3231 rtc;
        now = rtc.now();
        vp.clear();

        for (size_t i = 1; i <= 5; i++)
        {
            p = new Produto();
            p->seq = i;
            p->data = String(now.timestamp());
            p->id = UID;
            if (i == 1)
            {
                p->codigo = Codigo_1;
                p->descricao = Descricao_1;
                p->und = UND_1;
                p->qtd = atof(cs(Quantidade_1).data());
                p->prateleira = Prateleira_1;
                p->convsor = atof(cs(Conversor_1).data());
                p->convert = atof(cs(Convertido_1).data());
                vp.push_back(p);
            }
            if (i == 2)
            {
                p->codigo = Codigo_2;
                p->descricao = Descricao_2;
                p->und = UND_2;
                p->qtd = atof(cs(Quantidade_2).data());
                p->prateleira = Prateleira_2;
                p->convsor = atof(cs(Conversor_2).data());
                p->convert = atof(cs(Convertido_2).data());
                vp.push_back(p);
            }
            if (i == 3)
            {
                p->codigo = Codigo_3;
                p->descricao = Descricao_3;
                p->und = UND_3;
                p->qtd = atof(cs(Quantidade_3).data());
                p->prateleira = Prateleira_3;
                p->convsor = atof(cs(Conversor_3).data());
                p->convert = atof(cs(Convertido_3).data());
                vp.push_back(p);
            }
            if (i == 4)
            {
                p->codigo = Codigo_4;
                p->descricao = Descricao_4;
                p->und = UND_4;
                p->qtd = atof(cs(Quantidade_4).data());
                p->prateleira = Prateleira_4;
                p->convsor = atof(cs(Conversor_4).data());
                p->convert = atof(cs(Convertido_4).data());
                vp.push_back(p);
            }
            if (i == 5)
            {
                p->codigo = Codigo_5;
                p->descricao = Descricao_5;
                p->und = UND_5;
                p->qtd = atof(cs(Quantidade_5).data());
                p->prateleira = Prateleira_5;
                p->convsor = atof(cs(Conversor_5).data());
                p->convert = atof(cs(Convertido_5).data());
                vp.push_back(p);
            }
        }
    }

    void MontarVariaveis()
    {

        //UID

        //////Serial.println("\nUID memorizando...");
        byte c[4];
        for (byte t = 0; t < 4; t++)
        {
            c[t] = BufferCartao[0][t];
        }
        UID = DecToHex(c, 4);

        //CODIGO

        //////Serial.println("\nCodigo memorizando...");

        byte c1[14], c2[14], c3[14], c4[14], c5[14];
        for (byte t = 0; t < 14; t++)
        {
            c1[t] = BufferCartao[1][t];
            c2[t] = BufferCartao[13][t];
            c3[t] = BufferCartao[25][t];
            c4[t] = BufferCartao[37][t];
            c5[t] = BufferCartao[49][t];
        }
        Codigo_1 = DecToCHAR(c1, 14) + "\t";
        Codigo_2 = DecToCHAR(c2, 14) + "\t";
        Codigo_3 = DecToCHAR(c3, 14) + "\t";
        Codigo_4 = DecToCHAR(c4, 14) + "\t";
        Codigo_5 = DecToCHAR(c5, 14) + "\t";

        //DESCRICAO

        byte bl[50];
        byte b;

        //DESC1
        memset(bl, 0x00, 50);
        b = 0;
        for (byte ll = 2; ll < 7; ll++)
        {
            if (ll == 3)
            {
                continue;
            }
            if (ll <= 5)
            {
                for (byte t = 0; t < 16; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
            if (ll == 6)
            {
                for (byte t = 0; t < 2; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
        }
        Descricao_1 = DecToCHAR(bl, 50) + "\t";

        //DESC2
        memset(bl, 0x00, 50);
        b = 0;
        for (byte ll = 14; ll < 19; ll++)
        {
            if (ll == 15)
            {
                continue;
            }
            if (ll <= 17)
            {
                for (byte t = 0; t < 16; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
            if (ll == 18)
            {
                for (byte t = 0; t < 2; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
        }
        Descricao_2 = DecToCHAR(bl, 50) + "\t";

        //DESC3
        memset(bl, 0x00, 50);
        b = 0;
        for (byte ll = 26; ll < 31; ll++)
        {
            if (ll == 27)
            {
                continue;
            }
            if (ll <= 29)
            {
                for (byte t = 0; t < 16; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
            if (ll == 30)
            {
                for (byte t = 0; t < 2; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
        }
        Descricao_3 = DecToCHAR(bl, 50) + "\t";

        //DESC4
        memset(bl, 0x00, 50);
        b = 0;
        for (byte ll = 38; ll < 43; ll++)
        {
            if (ll == 39)
            {
                continue;
            }
            if (ll <= 41)
            {
                for (byte t = 0; t < 16; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
            if (ll == 42)
            {
                for (byte t = 0; t < 2; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
        }
        Descricao_4 = DecToCHAR(bl, 50) + "\t";

        //DESC5
        memset(bl, 0x00, 50);
        b = 0;
        for (byte ll = 50; ll < 55; ll++)
        {
            if (ll == 51)
            {
                continue;
            }
            if (ll <= 53)
            {
                for (byte t = 0; t < 16; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
            if (ll == 54)
            {
                for (byte t = 0; t < 2; t++)
                {
                    bl[b++] = BufferCartao[ll][t];
                }
            }
        }
        Descricao_5 = DecToCHAR(bl, 50) + "\t";

        //////Serial.println("\nUnidade memorizando...");
        byte u1[2], u2[2], u3[2], u4[2], u5[2];

        u1[0] = BufferCartao[6][2];
        u1[1] = BufferCartao[6][3];

        u2[0] = BufferCartao[18][2];
        u2[1] = BufferCartao[18][3];

        u3[0] = BufferCartao[30][2];
        u3[1] = BufferCartao[30][3];

        u4[0] = BufferCartao[42][2];
        u4[1] = BufferCartao[42][3];

        u5[0] = BufferCartao[54][2];
        u5[1] = BufferCartao[54][3];

        UND_1 = DecToCHAR(u1, 2) + "\t";
        UND_2 = DecToCHAR(u2, 2) + "\t";
        UND_3 = DecToCHAR(u3, 2) + "\t";
        UND_4 = DecToCHAR(u4, 2) + "\t";
        UND_5 = DecToCHAR(u5, 2) + "\t";

        //Demais... VARIAVEIS{

        byte qt1[16], pt1[16], cs1[16], ct1[16];
        byte qt2[16], pt2[16], cs2[16], ct2[16];
        byte qt3[16], pt3[16], cs3[16], ct3[16];
        byte qt4[16], pt4[16], cs4[16], ct4[16];
        byte qt5[16], pt5[16], cs5[16], ct5[16];
        for (byte t = 0; t < 16; t++)
        {
            qt1[t] = BufferCartao[8][t];
            pt1[t] = BufferCartao[9][t];
            cs1[t] = BufferCartao[10][t];
            ct1[t] = BufferCartao[12][t];

            qt2[t] = BufferCartao[20][t];
            pt2[t] = BufferCartao[21][t];
            cs2[t] = BufferCartao[22][t];
            ct2[t] = BufferCartao[24][t];

            qt3[t] = BufferCartao[32][t];
            pt3[t] = BufferCartao[33][t];
            cs3[t] = BufferCartao[34][t];
            ct3[t] = BufferCartao[36][t];

            qt4[t] = BufferCartao[44][t];
            pt4[t] = BufferCartao[45][t];
            cs4[t] = BufferCartao[46][t];
            ct4[t] = BufferCartao[48][t];

            qt5[t] = BufferCartao[56][t];
            pt5[t] = BufferCartao[57][t];
            cs5[t] = BufferCartao[58][t];
            ct5[t] = BufferCartao[60][t];
        }
        Quantidade_1 = DecToCHAR(qt1, 10) + "\t";
        Prateleira_1 = DecToCHAR(pt1, 11) + "\t";
        Conversor_1 = DecToCHAR(cs1, 10) + "\t";
        Convertido_1 = DecToCHAR(ct1, 10) + "\n";

        Quantidade_2 = DecToCHAR(qt2, 10) + "\t";
        Prateleira_2 = DecToCHAR(pt2, 11) + "\t";
        Conversor_2 = DecToCHAR(cs2, 10) + "\t";
        Convertido_2 = DecToCHAR(ct2, 10) + "\n";

        Quantidade_3 = DecToCHAR(qt3, 10) + "\t";
        Prateleira_3 = DecToCHAR(pt3, 11) + "\t";
        Conversor_3 = DecToCHAR(cs3, 10) + "\t";
        Convertido_3 = DecToCHAR(ct3, 10) + "\n";

        Quantidade_4 = DecToCHAR(qt4, 10) + "\t";
        Prateleira_4 = DecToCHAR(pt4, 11) + "\t";
        Conversor_4 = DecToCHAR(cs4, 10) + "\t";
        Convertido_4 = DecToCHAR(ct4, 10) + "\n";

        Quantidade_5 = DecToCHAR(qt5, 10) + "\t";
        Prateleira_5 = DecToCHAR(pt5, 11) + "\t";
        Conversor_5 = DecToCHAR(cs5, 10) + "\t";
        Convertido_5 = DecToCHAR(ct5, 10) + "\n";
    }

    String DecToHex(byte *cj, byte sz)
    {

        String u = "";
        for (size_t i = 0; i < sz; i++)
        {
            switch (cj[i])
            {
            case 0:
                u += "00 ";
                break;
            case 1:
                u += "01 ";
                break;
            case 2:
                u += "02 ";
                break;
            case 3:
                u += "03 ";
                break;
            case 4:
                u += "04 ";
                break;
            case 5:
                u += "05 ";
                break;
            case 6:
                u += "06 ";
                break;
            case 7:
                u += "07 ";
                break;
            case 8:
                u += "08 ";
                break;
            case 9:
                u += "09 ";
                break;
            case 10:
                u += "0A ";
                break;
            case 11:
                u += "0B ";
                break;
            case 12:
                u += "0C ";
                break;
            case 13:
                u += "0D ";
                break;
            case 14:
                u += "0E ";
                break;
            case 15:
                u += "0F ";
                break;
            case 16:
                u += "10 ";
                break;
            case 17:
                u += "11 ";
                break;
            case 18:
                u += "12 ";
                break;
            case 19:
                u += "13 ";
                break;
            case 20:
                u += "14 ";
                break;
            case 21:
                u += "15 ";
                break;
            case 22:
                u += "16 ";
                break;
            case 23:
                u += "17 ";
                break;
            case 24:
                u += "18 ";
                break;
            case 25:
                u += "19 ";
                break;
            case 26:
                u += "1A ";
                break;
            case 27:
                u += "1B ";
                break;
            case 28:
                u += "1C ";
                break;
            case 29:
                u += "1D ";
                break;
            case 30:
                u += "1E ";
                break;
            case 31:
                u += "1F ";
                break;
            case 32:
                u += "20 ";
                break;
            case 33:
                u += "21 ";
                break;
            case 34:
                u += "22 ";
                break;
            case 35:
                u += "23 ";
                break;
            case 36:
                u += "24 ";
                break;
            case 37:
                u += "25 ";
                break;
            case 38:
                u += "26 ";
                break;
            case 39:
                u += "27 ";
                break;
            case 40:
                u += "28 ";
                break;
            case 41:
                u += "29 ";
                break;
            case 42:
                u += "2A ";
                break;
            case 43:
                u += "2B ";
                break;
            case 44:
                u += "2C ";
                break;
            case 45:
                u += "2D ";
                break;
            case 46:
                u += "2E ";
                break;
            case 47:
                u += "2F ";
                break;
            case 48:
                u += "30 ";
                break;
            case 49:
                u += "31 ";
                break;
            case 50:
                u += "32 ";
                break;
            case 51:
                u += "33 ";
                break;
            case 52:
                u += "34 ";
                break;
            case 53:
                u += "35 ";
                break;
            case 54:
                u += "36 ";
                break;
            case 55:
                u += "37 ";
                break;
            case 56:
                u += "38 ";
                break;
            case 57:
                u += "39 ";
                break;
            case 58:
                u += "3A ";
                break;
            case 59:
                u += "3B ";
                break;
            case 60:
                u += "3C ";
                break;
            case 61:
                u += "3D ";
                break;
            case 62:
                u += "3E ";
                break;
            case 63:
                u += "3F ";
                break;
            case 64:
                u += "40 ";
                break;
            case 65:
                u += "41 ";
                break;
            case 66:
                u += "42 ";
                break;
            case 67:
                u += "43 ";
                break;
            case 68:
                u += "44 ";
                break;
            case 69:
                u += "45 ";
                break;
            case 70:
                u += "46 ";
                break;
            case 71:
                u += "47 ";
                break;
            case 72:
                u += "48 ";
                break;
            case 73:
                u += "49 ";
                break;
            case 74:
                u += "4A ";
                break;
            case 75:
                u += "4B ";
                break;
            case 76:
                u += "4C ";
                break;
            case 77:
                u += "4D ";
                break;
            case 78:
                u += "4E ";
                break;
            case 79:
                u += "4F ";
                break;
            case 80:
                u += "50 ";
                break;
            case 81:
                u += "51 ";
                break;
            case 82:
                u += "52 ";
                break;
            case 83:
                u += "53 ";
                break;
            case 84:
                u += "54 ";
                break;
            case 85:
                u += "55 ";
                break;
            case 86:
                u += "56 ";
                break;
            case 87:
                u += "57 ";
                break;
            case 88:
                u += "58 ";
                break;
            case 89:
                u += "59 ";
                break;
            case 90:
                u += "5A ";
                break;
            case 91:
                u += "5B ";
                break;
            case 92:
                u += "5C ";
                break;
            case 93:
                u += "5D ";
                break;
            case 94:
                u += "5E ";
                break;
            case 95:
                u += "5F ";
                break;
            case 96:
                u += "60 ";
                break;
            case 97:
                u += "61 ";
                break;
            case 98:
                u += "62 ";
                break;
            case 99:
                u += "63 ";
                break;
            case 100:
                u += "64 ";
                break;
            case 101:
                u += "65 ";
                break;
            case 102:
                u += "66 ";
                break;
            case 103:
                u += "67 ";
                break;
            case 104:
                u += "68 ";
                break;
            case 105:
                u += "69 ";
                break;
            case 106:
                u += "6A ";
                break;
            case 107:
                u += "6B ";
                break;
            case 108:
                u += "6C ";
                break;
            case 109:
                u += "6D ";
                break;
            case 110:
                u += "6E ";
                break;
            case 111:
                u += "6F ";
                break;
            case 112:
                u += "70 ";
                break;
            case 113:
                u += "71 ";
                break;
            case 114:
                u += "72 ";
                break;
            case 115:
                u += "73 ";
                break;
            case 116:
                u += "74 ";
                break;
            case 117:
                u += "75 ";
                break;
            case 118:
                u += "76 ";
                break;
            case 119:
                u += "77 ";
                break;
            case 120:
                u += "78 ";
                break;
            case 121:
                u += "79 ";
                break;
            case 122:
                u += "7A ";
                break;
            case 123:
                u += "7B ";
                break;
            case 124:
                u += "7C ";
                break;
            case 125:
                u += "7D ";
                break;
            case 126:
                u += "7E ";
                break;
            case 127:
                u += "7F ";
                break;
            case 128:
                u += "80 ";
                break;
            case 129:
                u += "81 ";
                break;
            case 130:
                u += "82 ";
                break;
            case 131:
                u += "83 ";
                break;
            case 132:
                u += "84 ";
                break;
            case 133:
                u += "85 ";
                break;
            case 134:
                u += "86 ";
                break;
            case 135:
                u += "87 ";
                break;
            case 136:
                u += "88 ";
                break;
            case 137:
                u += "89 ";
                break;
            case 138:
                u += "8A ";
                break;
            case 139:
                u += "8B ";
                break;
            case 140:
                u += "8C ";
                break;
            case 141:
                u += "8D ";
                break;
            case 142:
                u += "8E ";
                break;
            case 143:
                u += "8F ";
                break;
            case 144:
                u += "90 ";
                break;
            case 145:
                u += "91 ";
                break;
            case 146:
                u += "92 ";
                break;
            case 147:
                u += "93 ";
                break;
            case 148:
                u += "94 ";
                break;
            case 149:
                u += "95 ";
                break;
            case 150:
                u += "96 ";
                break;
            case 151:
                u += "97 ";
                break;
            case 152:
                u += "98 ";
                break;
            case 153:
                u += "99 ";
                break;
            case 154:
                u += "9A ";
                break;
            case 155:
                u += "9B ";
                break;
            case 156:
                u += "9C ";
                break;
            case 157:
                u += "9D ";
                break;
            case 158:
                u += "9E ";
                break;
            case 159:
                u += "9F ";
                break;
            case 160:
                u += "A0 ";
                break;
            case 161:
                u += "A1 ";
                break;
            case 162:
                u += "A2 ";
                break;
            case 163:
                u += "A3 ";
                break;
            case 164:
                u += "A4 ";
                break;
            case 165:
                u += "A5 ";
                break;
            case 166:
                u += "A6 ";
                break;
            case 167:
                u += "A7 ";
                break;
            case 168:
                u += "A8 ";
                break;
            case 169:
                u += "A9 ";
                break;
            case 170:
                u += "AA ";
                break;
            case 171:
                u += "AB ";
                break;
            case 172:
                u += "AC ";
                break;
            case 173:
                u += "AD ";
                break;
            case 174:
                u += "AE ";
                break;
            case 175:
                u += "AF ";
                break;
            case 176:
                u += "B0 ";
                break;
            case 177:
                u += "B1 ";
                break;
            case 178:
                u += "B2 ";
                break;
            case 179:
                u += "B3 ";
                break;
            case 180:
                u += "B4 ";
                break;
            case 181:
                u += "B5 ";
                break;
            case 182:
                u += "B6 ";
                break;
            case 183:
                u += "B7 ";
                break;
            case 184:
                u += "B8 ";
                break;
            case 185:
                u += "B9 ";
                break;
            case 186:
                u += "BA ";
                break;
            case 187:
                u += "BB ";
                break;
            case 188:
                u += "BC ";
                break;
            case 189:
                u += "BD ";
                break;
            case 190:
                u += "BE ";
                break;
            case 191:
                u += "BF ";
                break;
            case 192:
                u += "C0 ";
                break;
            case 193:
                u += "C1 ";
                break;
            case 194:
                u += "C2 ";
                break;
            case 195:
                u += "C3 ";
                break;
            case 196:
                u += "C4 ";
                break;
            case 197:
                u += "C5 ";
                break;
            case 198:
                u += "C6 ";
                break;
            case 199:
                u += "C7 ";
                break;
            case 200:
                u += "C8 ";
                break;
            case 201:
                u += "C9 ";
                break;
            case 202:
                u += "CA ";
                break;
            case 203:
                u += "CB ";
                break;
            case 204:
                u += "CC ";
                break;
            case 205:
                u += "CD ";
                break;
            case 206:
                u += "CE ";
                break;
            case 207:
                u += "CF ";
                break;
            case 208:
                u += "D0 ";
                break;
            case 209:
                u += "D1 ";
                break;
            case 210:
                u += "D2 ";
                break;
            case 211:
                u += "D3 ";
                break;
            case 212:
                u += "D4 ";
                break;
            case 213:
                u += "D5 ";
                break;
            case 214:
                u += "D6 ";
                break;
            case 215:
                u += "D7 ";
                break;
            case 216:
                u += "D8 ";
                break;
            case 217:
                u += "D9 ";
                break;
            case 218:
                u += "DA ";
                break;
            case 219:
                u += "DB ";
                break;
            case 220:
                u += "DC ";
                break;
            case 221:
                u += "DD ";
                break;
            case 222:
                u += "DE ";
                break;
            case 223:
                u += "DF ";
                break;
            case 224:
                u += "E0 ";
                break;
            case 225:
                u += "E1 ";
                break;
            case 226:
                u += "E2 ";
                break;
            case 227:
                u += "E3 ";
                break;
            case 228:
                u += "E4 ";
                break;
            case 229:
                u += "E5 ";
                break;
            case 230:
                u += "E6 ";
                break;
            case 231:
                u += "E7 ";
                break;
            case 232:
                u += "E8 ";
                break;
            case 233:
                u += "E9 ";
                break;
            case 234:
                u += "EA ";
                break;
            case 235:
                u += "EB ";
                break;
            case 236:
                u += "EC ";
                break;
            case 237:
                u += "ED ";
                break;
            case 238:
                u += "EE ";
                break;
            case 239:
                u += "EF ";
                break;
            case 240:
                u += "F0 ";
                break;
            case 241:
                u += "F1 ";
                break;
            case 242:
                u += "F2 ";
                break;
            case 243:
                u += "F3 ";
                break;
            case 244:
                u += "F4 ";
                break;
            case 245:
                u += "F5 ";
                break;
            case 246:
                u += "F6 ";
                break;
            case 247:
                u += "F7 ";
                break;
            case 248:
                u += "F8 ";
                break;
            case 249:
                u += "F9 ";
                break;
            case 250:
                u += "FA ";
                break;
            case 251:
                u += "FB ";
                break;
            case 252:
                u += "FC ";
                break;
            case 253:
                u += "FD ";
                break;
            case 254:
                u += "FE ";
                break;
            case 255:
                u += "FF ";
                break;
            }
        }

        u.trim();
        return u += "\t";
    }

    //Retorna uma string
    String DecToCHAR(byte *cj, byte sz)
    {

        String u = "";
        for (size_t i = 0; i < sz; i++)
        {
            switch (cj[i])
            {
            case 0:
                u += "";
                break;
            case 13:
                u += "\n"; // precisa para o metodo SalvaListaUIDs.ListaUIDsSD()
                break;
            case 32:
                u += " ";
                break;
            case 33:
                u += "!";
                break;
            case 34:
                u += "\"";
                break;
            case 35:
                u += "#";
                break;
            case 36:
                u += "$";
                break;
            case 37:
                u += "%";
                break;
            case 38:
                u += "&";
                break;
            case 39:
                u += "'";
                break;
            case 40:
                u += "(";
                break;
            case 41:
                u += ")";
                break;
            case 42:
                u += "*";
                break;
            case 43:
                u += "+";
                break;
            case 44:
                u += ",";
                break;
            case 45:
                u += "-";
                break;
            case 46:
                u += ".";
                break;
            case 47:
                u += "/";
                break;
            case 48:
                u += "0";
                break;
            case 49:
                u += "1";
                break;
            case 50:
                u += "2";
                break;
            case 51:
                u += "3";
                break;
            case 52:
                u += "4";
                break;
            case 53:
                u += "5";
                break;
            case 54:
                u += "6";
                break;
            case 55:
                u += "7";
                break;
            case 56:
                u += "8";
                break;
            case 57:
                u += "9";
                break;
            case 58:
                u += ":";
                break;
            case 59:
                u += ";";
                break;
            case 60:
                u += "<";
                break;
            case 61:
                u += "=";
                break;
            case 62:
                u += ">";
                break;
            case 63:
                u += "?";
                break;
            case 64:
                u += "@";
                break;
            case 65:
                u += "A";
                break;
            case 66:
                u += "B";
                break;
            case 67:
                u += "C";
                break;
            case 68:
                u += "D";
                break;
            case 69:
                u += "E";
                break;
            case 70:
                u += "F";
                break;
            case 71:
                u += "G";
                break;
            case 72:
                u += "H";
                break;
            case 73:
                u += "I";
                break;
            case 74:
                u += "J";
                break;
            case 75:
                u += "K";
                break;
            case 76:
                u += "L";
                break;
            case 77:
                u += "M";
                break;
            case 78:
                u += "N";
                break;
            case 79:
                u += "O";
                break;
            case 80:
                u += "P";
                break;
            case 81:
                u += "Q";
                break;
            case 82:
                u += "R";
                break;
            case 83:
                u += "S";
                break;
            case 84:
                u += "T";
                break;
            case 85:
                u += "U";
                break;
            case 86:
                u += "V";
                break;
            case 87:
                u += "W";
                break;
            case 88:
                u += "X";
                break;
            case 89:
                u += "Y";
                break;
            case 90:
                u += "Z";
                break;
            case 91:
                u += "[";
                break;
            case 92:
                u += "\\";
                break;
            case 93:
                u += "]";
                break;
            case 94:
                u += "^";
                break;
            case 95:
                u += "_";
                break;
            case 96:
                u += "`";
                break;
            }
        }

        u.trim();
        return u /* += "\t"*/;
    }

    void reset()
    {
        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN);
        // mfrc522.PICC_HaltA();

        // mfrc522.PCD_StopCrypto1();
        //porque esta lendo o cartao mais de uma vez....
        mfrc522.PCD_Reset();
    }
};
#endif