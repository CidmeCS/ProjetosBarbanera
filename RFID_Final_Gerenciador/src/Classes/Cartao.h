#ifndef CARTAO_H
#define CARTAO_H
#include <Arduino.h>
//#include <Classes/Gravador.h>
#include <Classes/Produto.h>
#include <MFRC522.h>
#include <TFT_eSPI.h>
#include <stdlib.h>
#include <time.h>
TFT_eSPI tft8 = TFT_eSPI();
#include <Classes/Teclado.h>
#include <cstddef>
#include <cstring>
#include <encode.h>
#include <iostream>
#include <stdlib.h>
#include <Classes/stringhelper.h>
#include <MFRC522.h>
#include <SPI.h>
#include <NTPClient.h>

using namespace std;

class Cartao
{
public:
    Cartao(String RFID)
    {
        pinMode(pinVerde, OUTPUT); // 25
        pinMode(pinAzul, OUTPUT);

        if (RFID == "")
        {
            return;
        }

        pinMode(SS_SLAVE_RFID_INT, OUTPUT);
        pinMode(SS_SLAVE_RFID_EXT, OUTPUT);

        if (RFID == "EXTERNO")
        {
            digitalWrite(SS_SLAVE_RFID_EXT, LOW);  // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_EXT;
        }
        else if (RFID == "INTERNO")
        {
            digitalWrite(SS_SLAVE_RFID_EXT, HIGH); // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, LOW);  // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_INT;
            p = new Produto();
        }
    }

//variaveis
#pragma region Variaveis

    byte SS_SLAVE_RFID_INT = 17;
    byte SS_SLAVE_RFID_EXT = 26;
    byte SS_SLAVE_RFID;
    byte RST_PIN = 4;
    MFRC522::MIFARE_Key key;
    int newSeq = 0;
    //MFRC522 mfrc522;

    vector<Produto *> vp;
    Produto *p;
    byte **BufferCartao = 0;
    byte pinVerde = 33;
    byte pinAzul = 32;

    //Grupo 6
    String L61;
    String L62;

    byte **buffer;
    MFRC522::StatusCode status;
    Teclado *t;

    enum TIPOS
    {
        CONVERTIDO,
        QUANTIDADE,
        CONVERSOR
    };
#pragma endregion

    void Virgula(NTPClient tc)
    {
        byte buzer = 27;
        pinMode(buzer, OUTPUT);
        for (size_t i = 0; i < 11; i++)
        {

            ObterBufferCartao(tc);

            int q1 = 11, q2 = 8, c1 = 15, c2 = 12, cs1 = 11, cs2 = 10, grupo = 1;

            for (Produto *p : vp)
            {
                if (p->codigo.length() <= 0)
                {
                    continue;
                }

                byte Quantidade[16];
                byte Conversor[16];
                byte Convertido[16];

                auto QT = String(p->qtd);
                auto CS = String(p->convsor);
                auto CT = String(p->convert);

                QT.replace(",", ".");
                CS.replace(",", ".");
                CT.replace(",", ".");

                for (size_t i = 0; i < 16; i++)
                {
                    Quantidade[i] = (char)QT[i];
                    Conversor[i] = (char)CS[i];
                    Convertido[i] = (char)CT[i];
                }

                gravaBrolckAdress2(q1, q2, Quantidade, p, grupo);
                gravaBrolckAdress2(cs1, cs2, Conversor, p, grupo);
                gravaBrolckAdress2(c1, c2, Convertido, p, grupo);
                q1 += 12;
                q2 += 12;
                cs1 += 12;
                cs2 += 12;
                c1 += 12;
                c2 += 12;
                digitalWrite(buzer, HIGH);
                delay(100);
                digitalWrite(buzer, LOW);
            }
            delay(5000);
            vp.clear();
        }
    }

    double calculoDependente(vector<Produto *> vp, double conversor, int index, TIPOS TIPO, double qtd, double convertido)
    {

        if (verificaDescricao(vp, index))
        {
            if (TIPO == CONVERSOR)
            {
                return (vp[index]->qtd.toDouble() / conversor);
            }
            else if (TIPO == QUANTIDADE)
            {
                return (qtd / vp[index]->convsor.toDouble());
            }
            else if (TIPO == CONVERTIDO)
            {
                return (convertido * vp[index]->convsor.toDouble());
            }
        }
        else
        {
            if (TIPO == CONVERSOR)
            {
                return (vp[index]->qtd.toDouble() * conversor);
            }
            else if (TIPO == QUANTIDADE)
            {
                return (qtd * vp[index]->convsor.toDouble());
            }
            else if (TIPO == CONVERTIDO)
            {
                return (convertido / vp[index]->convsor.toDouble());
            }
        }
    }

    bool verificaDescricao(vector<Produto *> vp, int index)
    {
        String strArr[] = {"TUBO ", "BARRA ", "PERFIL "};

        for (auto i : strArr)
        {
            if (vp[index]->descricao.startsWith(i))
                return true;
        }
        return false;
    }

    void gravarConvertido(double convertido, int grupo, vector<Produto *> vp)
    {
        auto quantidade = String(calculoDependente(vp, 0.0, grupo - 1, CONVERTIDO, 0.0, convertido), 3);
        auto cv = String(convertido, 3);

        // QUANTIDADE
        byte trailerBlockQT = 63;
        byte blockAddrQT = 62;

        //CONVERTIDO
        byte trailerBlockCT = 63;
        byte blockAddrCT = 62;

        switch (grupo)
        {
        case 1:
            trailerBlockQT = 11;
            blockAddrQT = 8;
            trailerBlockCT = 15;
            blockAddrCT = 12;
            break;
        case 2:
            trailerBlockQT = 23;
            blockAddrQT = 20;
            trailerBlockCT = 27;
            blockAddrCT = 24;
            break;
        case 3:
            trailerBlockQT = 35;
            blockAddrQT = 32;
            trailerBlockCT = 39;
            blockAddrCT = 36;
            break;
        case 4:
            trailerBlockQT = 47;
            blockAddrQT = 44;
            trailerBlockCT = 51;
            blockAddrCT = 48;
            break;
        case 5:
            trailerBlockQT = 59;
            blockAddrQT = 56;
            trailerBlockCT = 63;
            blockAddrCT = 60;
            break;
        }

        byte size = 16;
        byte dataBlockQT[size];
        byte dataBlockCT[size];
        for (size_t i = 0; i < size; i++)
        {
            dataBlockQT[i] = quantidade[i];
            dataBlockCT[i] = cv[i]; // para barras, tubos ...
        }

        tft8.setRotation(1);
        tft8.setTextSize(2);
        tft8.setCursor(100, 80);
        tft8.println("Retire e Re-Aproxime o Cartao ");
        ///////////////////////////////////////////////////////

        /*
        char L = 'I';

    F:

        if (L == 'I')
        {
            digitalWrite(SS_SLAVE_RFID_EXT, HIGH); // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, LOW);  // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_INT;
        }
        else if (L == 'E')
        {
            digitalWrite(SS_SLAVE_RFID_EXT, LOW);  // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_EXT;
        }

        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance

        mfrc522.PCD_Init(); // Init MFRC522 card

        mfrc522.PICC_HaltA();
        // Stop encryption on PCD
        mfrc522.PCD_StopCrypto1();
        //

        while (!mfrc522.PICC_IsNewCardPresent())
        {
            delay(1000);
            if (L == 'I')
                L = 'E';
            else
                L = 'I';
            goto F;
        }
        */
        /////////////////////////////////////////////////////////////
        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }

    F:
        MFRC522 mfrc522_X = RfidDual();
        MFRC522 mfrc522 = mfrc522_X;

        while (!mfrc522.PICC_ReadCardSerial())
        {
            //delay(1000);
        }

        //tft8.fillRect(100, 80, 350, 16, TFT_BLACK);

        auto p = vp[0];
        bool b = CertificarCartaoCorreto(mfrc522, p);
        if (b == false)
        {
            goto F;
        }

        MFRC522::StatusCode status;

        try
        {

            // ///////////    CONVERSOR     /////////////////
            // Authenticate using key B
            status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, trailerBlockQT, &key, &(mfrc522.uid));
            if (status != MFRC522::STATUS_OK)
            {
                return;
            }
            status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(blockAddrQT, dataBlockQT, size);
        }
        catch (const std::exception &e)
        {
            Serial.println("ERRO ERRO");
            Serial.println(e.what());
        }
        /////////////        CONVERTIDO           ////////////////////
        try
        {
            status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, trailerBlockCT, &key, &(mfrc522.uid));
            if (status != MFRC522::STATUS_OK)
            {
                return;
            }
            status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(blockAddrCT, dataBlockCT, size);
        }
        catch (const std::exception &e)
        {
            Serial.println("ERRO ERRO");
            Serial.println(e.what());
        }
    }

    void gravaConversor(int SeqGrupo, double conversor, vector<Produto *> vp)
    {
        double convertido = calculoDependente(vp, conversor, SeqGrupo - 1, CONVERSOR, 0.0, 0.0);

        auto cd = String(convertido, 3);

        auto cv = String(conversor, 5);

        // CONVERSOR
        byte trailerBlockCV = 63;
        byte blockAddrCV = 62;

        //CONVERTIDO
        byte trailerBlockCT = 63;
        byte blockAddrCT = 62;

        switch (SeqGrupo)
        {
        case 1:
            trailerBlockCV = 11;
            blockAddrCV = 10;
            trailerBlockCT = 15;
            blockAddrCT = 12;
            break;
        case 2:
            trailerBlockCV = 23;
            blockAddrCV = 22;
            trailerBlockCT = 27;
            blockAddrCT = 24;
            break;
        case 3:
            trailerBlockCV = 35;
            blockAddrCV = 34;
            trailerBlockCT = 39;
            blockAddrCT = 36;
            break;
        case 4:
            trailerBlockCV = 47;
            blockAddrCV = 46;
            trailerBlockCT = 51;
            blockAddrCT = 48;
            break;
        case 5:
            trailerBlockCV = 59;
            blockAddrCV = 58;
            trailerBlockCT = 63;
            blockAddrCT = 60;
            break;
        }

        byte size = 16;
        byte dataBlockCV[size];
        byte dataBlockCT[size];
        for (size_t i = 0; i < size; i++)
        {
            dataBlockCV[i] = cv[i];
            dataBlockCT[i] = cd[i];
        }

        tft8.setRotation(1);
        tft8.setTextSize(2);
        tft8.setCursor(100, 80);
        tft8.println("Retire e Re-Aproxime o Cartao");

        /*
        char L = 'I';

    F:

        if (L == 'I')
        {
            digitalWrite(SS_SLAVE_RFID_EXT, HIGH); // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, LOW);  // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_INT;
        }
        else if (L == 'E')
        {
            digitalWrite(SS_SLAVE_RFID_EXT, LOW);  // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_EXT;
        }
        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance

        pinMode(SS_SLAVE_RFID, OUTPUT);
        mfrc522.PCD_Init(); // Init MFRC522 card

        mfrc522.PICC_HaltA();
        // Stop encryption on PCD
        mfrc522.PCD_StopCrypto1();
        //

        while (!mfrc522.PICC_IsNewCardPresent())
        {
            delay(1000);
            if (L == 'I')
                L = 'E';
            else
                L = 'I';
            goto F;
        }

        */
        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }
    F:
        MFRC522 mfrc522_X = RfidDual();
        MFRC522 mfrc522 = mfrc522_X;

        while (!mfrc522.PICC_ReadCardSerial())
        {
            //delay(1000);
        }

        //tft8.fillRect(100, 80, 350, 16, TFT_BLACK);

        auto p = vp[0];
        bool b = CertificarCartaoCorreto(mfrc522, p);
        if (b == false)
        {
            goto F;
        }

        MFRC522::StatusCode status;

        try
        {

            // ///////////    CONVERSOR     /////////////////
            // Authenticate using key B
            status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, trailerBlockCV, &key, &(mfrc522.uid));
            if (status != MFRC522::STATUS_OK)
            {
                return;
            }
            status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(blockAddrCV, dataBlockCV, size);
        }
        catch (const std::exception &e)
        {
            Serial.println("ERRO ERRO");
            Serial.println(e.what());
        }
        /////////////        CONVERTIDO           ////////////////////
        try
        {
            status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, trailerBlockCT, &key, &(mfrc522.uid));
            if (status != MFRC522::STATUS_OK)
            {
                return;
            }

            status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(blockAddrCT, dataBlockCT, size);
        }
        catch (const std::exception &e)
        {
            Serial.println("ERRO ERRO");
            Serial.println(e.what());
        }
    }

    void gravarQuantidade(double qtd, int grupo, vector<Produto *> vp)
    {
        auto convertido = String(calculoDependente(vp, 0.0, grupo - 1, QUANTIDADE, qtd, 0.0), 3);

        String vlr = String(qtd, 3);
        byte trailerBlockQT = 63;
        byte blockAddrQT = 62;
        byte trailerBlockCT = 63;
        byte blockAddrCT = 62;
        switch (grupo)
        {
        case 1:
            trailerBlockQT = 11;
            blockAddrQT = 8;
            trailerBlockCT = 15;
            blockAddrCT = 12;
            break;
        case 2:
            trailerBlockQT = 23;
            blockAddrQT = 20;
            trailerBlockCT = 27;
            blockAddrCT = 24;
            break;
        case 3:
            trailerBlockQT = 35;
            blockAddrQT = 32;
            trailerBlockCT = 39;
            blockAddrCT = 36;
            break;
        case 4:
            trailerBlockQT = 47;
            blockAddrQT = 44;
            trailerBlockCT = 51;
            blockAddrCT = 48;
            break;
        case 5:
            trailerBlockQT = 59;
            blockAddrQT = 56;
            trailerBlockCT = 63;
            blockAddrCT = 60;
            break;
        }

        byte size = 16;
        byte dataBlockQT[size];
        for (size_t i = 0; i < size; i++)
        {
            dataBlockQT[i] = vlr[i];
        }
        //
        byte dataBlockCT[size];
        for (size_t i = 0; i < size; i++)
        {
            dataBlockCT[i] = convertido[i];
        }

        tft8.setRotation(1);
        tft8.setTextSize(2);
        tft8.setCursor(100, 80);
        tft8.println("Retire e Re-Aproxime o Cartao");

        char L = 'I';

        /*
        if (L == 'I')
        {
            digitalWrite(SS_SLAVE_RFID_EXT, HIGH); // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, LOW);  // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_INT;
        }
        else if (L == 'E')
        {
            digitalWrite(SS_SLAVE_RFID_EXT, LOW);  // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_EXT;
        }

        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance

        mfrc522.PCD_Init(); // Init MFRC522 card

        while (!mfrc522.PICC_IsNewCardPresent())
        {
            delay(1000);
            if (L == 'I')
                L = 'E';
            else
                L = 'I';
            goto F;
        }
        */

        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }

    F:
        MFRC522 mfrc522_X = RfidDual();
        MFRC522 mfrc522 = mfrc522_X;

        while (!mfrc522.PICC_ReadCardSerial())
        {
            //delay(1000);
        }

        //tft8.fillRect(100, 80, 350, 16, TFT_BLACK);

        auto p = vp[0];
        bool b = CertificarCartaoCorreto(mfrc522, p);
        if (b == false)
        {
            goto F;
        }

        MFRC522::StatusCode status;

        // Authenticate using key B
        status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, trailerBlockQT, &key, &(mfrc522.uid));
        if (status != MFRC522::STATUS_OK)
        {
            return;
        }
        status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(blockAddrQT, dataBlockQT, size);

        /////////////convertido
        try
        {
            status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, trailerBlockCT, &key, &(mfrc522.uid));
            if (status != MFRC522::STATUS_OK)
            {
                return;
            }
            status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(blockAddrCT, dataBlockCT, size);
        }
        catch (const std::exception &e)
        {
            Serial.println("ERRO ERRO");
            Serial.println(e.what());
        }

        mfrc522.PICC_HaltA();
        // Stop encryption on PCD
        mfrc522.PCD_StopCrypto1();
    }

    void gravaPrateleira(String vlr, vector<Produto *> vp)
    {
        byte size = 16;
        byte dataBlockQT[size];
        for (size_t i = 0; i < size; i++)
        {
            dataBlockQT[i] = vlr[i];
        }
        /*
        char L = 'I';

    F:

        if (L == 'I')
        {
            digitalWrite(SS_SLAVE_RFID_EXT, HIGH); // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, LOW);  // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_INT;
        }
        else if (L == 'E')
        {
            digitalWrite(SS_SLAVE_RFID_EXT, LOW);  // Habilita o SS.
            digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Habilita o SS.
            SS_SLAVE_RFID = SS_SLAVE_RFID_EXT;
        }
        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance

        mfrc522.PCD_Init(); // Init MFRC522 card

        tft8.setRotation(1);
        tft8.setTextSize(2);
        tft8.setCursor(100, 80);
        tft8.println("Retire e Re-Aproxime o Cartao");

        while (!mfrc522.PICC_IsNewCardPresent())
        {
            delay(1000);
            if (L == 'I')
                L = 'E';
            else
                L = 'I';
            goto F;
        }
        */
    F:
        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }
        MFRC522 mfrc522_X = RfidDual();
        MFRC522 mfrc522 = mfrc522_X;

        while (!mfrc522.PICC_ReadCardSerial())
        {
            delay(1000);
        }
        auto p = vp[0];
        bool b = CertificarCartaoCorreto(mfrc522, p);
        if (b == false)
        {
            goto F;
        }

        byte trailerBlock2[5] = {11, 23, 35, 47, 59};
        byte blockAddr2[5] = {9, 21, 33, 45, 57};

        for (size_t i = 0; i < 5; i++)
        {

            // Authenticate using key B
            status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, trailerBlock2[i], &key, &(mfrc522.uid));
            if (status != MFRC522::STATUS_OK)
            {
                return;
            }
            status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(blockAddr2[i], dataBlockQT, size);
        }
        mfrc522.PICC_HaltA();
        // Stop encryption on PCD
        mfrc522.PCD_StopCrypto1();
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

        t = new Teclado();
        auto tcd = t->tecla();

        while (true)
        {
            if (!mfrc522.PICC_IsNewCardPresent() || !mfrc522.PICC_ReadCardSerial())
            {
                delay(50);
            }
            else
                break;
            tcd = t->tecla();
            if (tcd == 'e')
            {
                tft8.setTextColor(TFT_YELLOW);
                tft8.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft8.setCursor(10, 300);
                tft8.println("ESC -> Aguarde...");
                ESP.restart();
            }
        }
        byte uid[4];
        int i = 0;

        for (auto uid2 : mfrc522.uid.uidByte)
        {
            uid[i] = uid2;
            i++;
        }

        UID2 = DecToHex(uid, 4);
        mfrc522.PICC_HaltA();

        return UID2;
    }

    String ObterUIDCartao2()
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

        t = new Teclado();
        auto tcd = t->tecla();

        while (true)
        {
            if (!mfrc522.PICC_IsNewCardPresent() || !mfrc522.PICC_ReadCardSerial())
            {
                return "";
            }
            else
                break;
            tcd = t->tecla();
            if (tcd == 'e')
            {
                tft8.setTextColor(TFT_YELLOW);
                tft8.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft8.setCursor(10, 300);
                tft8.println("ESC -> Aguarde...");
                ESP.restart();
            }
        }
        byte uid[4];
        int i = 0;

        for (auto uid2 : mfrc522.uid.uidByte)
        {
            uid[i] = uid2;
            i++;
        }

        UID2 = DecToHex(uid, 4);
        mfrc522.PICC_HaltA();

        return UID2;
    }

    String ObterBufferCartao(NTPClient tc)
    {
        BufferCartao = 0;
        BufferCartao = new byte *[63];
        for (byte h = 0; h < 63; h++)
        {
            BufferCartao[h] = new byte[18];
        }

        byte sb = 18;

        tft8.setRotation(1);
        tft8.setTextSize(1);
        tft8.setCursor(336, 216);
        tft8.print("Aproxime um cartao");
        tft8.setCursor(380, 305);
        tft8.print("ESC >> MENU");

        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }

        MFRC522 mfrc522_X = RfidDual();
        MFRC522 mfrc522 = mfrc522_X;

        int v = 0;

        while (!mfrc522.PICC_ReadCardSerial())
        {
            return "ERRO";
        }

        digitalWrite(pinAzul, HIGH); //acende

        for (byte i = 0; i < 63; i++)
        {
            status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, i, &key, &(mfrc522.uid)); //line 834 of MFRC522.cpp file
            if (status != MFRC522::STATUS_OK)
            {
                digitalWrite(pinAzul, LOW);
                return "ERRO";
            }
            status = mfrc522.MIFARE_Read(i, &BufferCartao[i][0], &sb);
        }
        digitalWrite(pinAzul, LOW);

        digitalWrite(pinVerde, LOW); //apaga

        mfrc522.PICC_HaltA();

        mfrc522.PCD_StopCrypto1();

        MontarVariaveis(tc);

        byte uid3[4];
        byte ih = 0;
        for (auto i : mfrc522.uid.uidByte)
        {
            if (ih < 4)
            {
                uid3[ih++] = i;
            }
        }

        String UID2;
        UID2 = DecToHex(uid3, 4);
        Serial.println(UID2); //

        mfrc522.PCD_Reset();

        return UID2;
    }

    MFRC522 RfidDual()
    {
        bool In = true, Ex = false, lido = false;
        MFRC522 mfrc522;
        t = new Teclado();
        char tt = ' ';

        do
        {
            if (Ex)
            {
                // Interno
                Ex = false;
                In = true;
                digitalWrite(SS_SLAVE_RFID_EXT, HIGH);
                delay(10);
                digitalWrite(SS_SLAVE_RFID_INT, LOW); // Habilita o SS.
                SS_SLAVE_RFID = SS_SLAVE_RFID_INT;
                //Serial.println("INTERNO " + String(SS_SLAVE_RFID));
            }
            else
            {
                // Externo
                Ex = true;
                In = false;
                digitalWrite(SS_SLAVE_RFID_EXT, LOW); // Habilita o SS.
                delay(10);
                digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Habilita o SS.
                SS_SLAVE_RFID = SS_SLAVE_RFID_EXT;
                //Serial.println("EXTERNO " + String(SS_SLAVE_RFID));
            }

            lido = false;

            MFRC522 mfrc522_X(SS_SLAVE_RFID, RST_PIN);
            mfrc522 = mfrc522_X;
            mfrc522.PCD_Init();
            while (!mfrc522.PICC_IsNewCardPresent())
            {
                lido = true;
                digitalWrite(pinVerde, HIGH); //acende
                tt = t->tecla();
                delay(200);
                digitalWrite(pinVerde, LOW); //acende
                tft8.setCursor(450, 216);
                for (size_t i = 0; i < 5; i++)
                {
                    delay(100);
                    tft8.print(".");
                    tt = t->tecla();
                    if (tt == 'e')
                    {
                        tft8.setTextColor(TFT_YELLOW);
                        tft8.fillRect(10, 300, 470, 18, TFT_BLUE);
                        tft8.setCursor(10, 300);
                        tft8.println("ESC -> Aguarde...");
                        ESP.restart();
                    }
                }

                tft8.fillRect(450, 216, 30, 8, TFT_BLACK);
                if (tt == 'e')
                {
                    tft8.setTextColor(TFT_YELLOW);
                    tft8.fillRect(10, 300, 470, 18, TFT_BLUE);
                    tft8.setCursor(10, 300);
                    tft8.println("ESC -> Aguarde...");
                    ESP.restart();
                }
                mfrc522.PCD_Reset();
                break;
            }

        } while (lido);

        return mfrc522;
    }

    void reset()
    {
        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN);
        // mfrc522.PICC_HaltA();

        // mfrc522.PCD_StopCrypto1();
        //porque esta lendo o cartao mais de uma vez....
        mfrc522.PCD_Reset();
    }

    String GetData(NTPClient tc)
    {
        auto ss = tc.getFormattedDate().substring(0, 10);
        return ss;
    }

    String GetDataHora(NTPClient tc)
    {
        String fd = tc.getFormattedDate();
        fd.replace('T', ' ');
        fd.replace('Z', ' ');
        fd.trim();

        return fd;
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

    String cs2(String v)
    {
        String q;
        for (size_t i = 0; i < v.length(); i++)
        {
            q[i] = v[i];
        }
        return q;
    }

    void MontarVariaveis(NTPClient tc)
    {

        String data = String(GetDataHora(tc));

        vector<Produto *> pn;
        Produto *p1 = new Produto();
        Produto *p2 = new Produto();
        Produto *p3 = new Produto();
        Produto *p4 = new Produto();
        Produto *p5 = new Produto();

        p1->seq = 1;
        p1->data = data;

        p2->seq = 2;
        p2->data = data;

        p3->seq = 3;
        p3->data = data;

        p4->seq = 4;
        p4->data = data;

        p5->seq = 5;
        p5->data = data;

        //UID
        byte c[4];
        for (byte t = 0; t < 4; t++)
        {
            c[t] = BufferCartao[0][t];
        }
        String id = DecToHex(c, 4);
        p1->id = id;
        p2->id = id;
        p3->id = id;
        p4->id = id;
        p5->id = id;

        //CODIGO
        byte c1[14], c2[14], c3[14], c4[14], c5[14];
        for (byte t = 0; t < 14; t++)
        {
            c1[t] = BufferCartao[1][t];
            c2[t] = BufferCartao[13][t];
            c3[t] = BufferCartao[25][t];
            c4[t] = BufferCartao[37][t];
            c5[t] = BufferCartao[49][t];
        }
        p1->codigo = DecToCHAR(c1, 14);
        p2->codigo = DecToCHAR(c2, 14);
        p3->codigo = DecToCHAR(c3, 14);
        p4->codigo = DecToCHAR(c4, 14);
        p5->codigo = DecToCHAR(c5, 14);

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
        p1->descricao = DecToCHAR(bl, 50);

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
        p2->descricao = DecToCHAR(bl, 50);

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
        p3->descricao = DecToCHAR(bl, 50);

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
        p4->descricao = DecToCHAR(bl, 50);

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
        p5->descricao = DecToCHAR(bl, 50);

        //UND
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

        p1->und = DecToCHAR(u1, 2);
        p2->und = DecToCHAR(u2, 2);
        p3->und = DecToCHAR(u3, 2);
        p4->und = DecToCHAR(u4, 2);
        p5->und = DecToCHAR(u5, 2);

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

        p1->prateleira = DecToCHAR(pt1, 11);
        p2->prateleira = DecToCHAR(pt2, 11);
        p3->prateleira = DecToCHAR(pt3, 11);
        p4->prateleira = DecToCHAR(pt4, 11);
        p5->prateleira = DecToCHAR(pt5, 11);

        p1->qtd = DecToCHAR(qt1, 10);
        p2->qtd = DecToCHAR(qt2, 10);
        p3->qtd = DecToCHAR(qt3, 10);
        p4->qtd = DecToCHAR(qt4, 10);
        p5->qtd = DecToCHAR(qt5, 10);

        p1->convsor = DecToCHAR(cs1, 10);
        p2->convsor = DecToCHAR(cs2, 10);
        p3->convsor = DecToCHAR(cs3, 10);
        p4->convsor = DecToCHAR(cs4, 10);
        p5->convsor = DecToCHAR(cs5, 10);

        p1->convert = DecToCHAR(ct1, 10);
        p2->convert = DecToCHAR(ct2, 10);
        p3->convert = DecToCHAR(ct3, 10);
        p4->convert = DecToCHAR(ct4, 10);
        p5->convert = DecToCHAR(ct5, 10);

        pn.push_back(p1);
        pn.push_back(p2);
        pn.push_back(p3);
        pn.push_back(p4);
        pn.push_back(p5);

        for (Produto *pp : pn)
        {
            pp->qtd.replace(",", ".");
            pp->convsor.replace(",", ".");
            pp->convert.replace(",", ".");
            Serial.println();
        }
        vp.clear();
        vp = pn;
    }

    String CardIntOK()
    {
        MFRC522 mfrc522_I;
        pinMode(17, OUTPUT);
        pinMode(26, OUTPUT);

        digitalWrite(17, LOW);  // Desabilita o SS.
        digitalWrite(26, HIGH); // Habilita o SS.
        mfrc522_I.PCD_Init();   // Init MFRC522 card
        mfrc522_I.PCD_DumpVersionToSerial();
        if (!mfrc522_I.PCD_PerformSelfTest())
        {
            return "RFID INT OK";
        }
        else
        {
            return "RFID INT ERRO";
        }
    }

    String CardExtOK()
    {
        MFRC522 mfrc522_E;
        pinMode(17, OUTPUT);
        pinMode(26, OUTPUT);

        digitalWrite(17, HIGH); // Habilita o SS.
        digitalWrite(26, LOW);  // Desabilita o SS.
        mfrc522_E.PCD_Init();   // Init MFRC522 card
        mfrc522_E.PCD_DumpVersionToSerial();
        if (!mfrc522_E.PCD_PerformSelfTest())
        {
            return "RFID EXT OK";
        }
        else
        {
            return "RFID EXT ERRO";
        }
    }

    bool CertificarCartaoCorreto2(MFRC522 mfrc522, Produto *p)
    {
        byte uid3[4];
        byte ih = 0;
        for (auto i : mfrc522.uid.uidByte)
        {
            if (ih < 4)
            {
                uid3[ih++] = i;
            }
        }

        auto u = DecToHex(uid3, 4); ///cartao
        auto o = p->id;             // memoria

        o.trim();
        u.trim();

        if (o.compareTo(u) != 0)
        {
            tft8.fillRect(100, 80, 350, 16, TFT_BLACK);
            tft8.setCursor(100, 80);
            tft8.print("Aproxime o Cartao! " + o);
            tft8.setCursor(100, 96);
            tft8.print("Cartao Incorreto!  " + u);
            delay(1000);
            mfrc522.PCD_Reset();
            return false;
        }

        return true;
    }

    bool CertificarCartaoCorreto(MFRC522 mfrc522, Produto *p)
    {
        byte uid3[4];
        byte ih = 0;
        for (auto i : mfrc522.uid.uidByte)
        {
            if (ih < 4)
            {
                uid3[ih++] = i;
            }
        }

        auto u = DecToHex(uid3, 4); ///cartao
        auto o = p->id;             // memoria

        o.trim();
        u.trim();

        if (o.compareTo(u) != 0)
        {
            tft8.fillRect(100, 80, 350, 16, TFT_BLACK);
            tft8.setCursor(100, 80);
            tft8.print("Aproxime o Cartao! " + o);
            tft8.setCursor(100, 96);
            tft8.print("Cartao Incorreto!  " + u);
            delay(1000);
            mfrc522.PCD_Reset();
            return false;
        }

        return true;
    }

    void ExcluiItens(int grupo)
    {
        byte syze = 16;
        byte dataBlock[] = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        byte TrailerBlock_BlockAdress[47][2];
        byte grupo1[9][2] = {{3, 1}, {3, 2}, {7, 4}, {7, 5}, {7, 6}, {11, 8}, {11, 9}, {11, 10}, {15, 12}};
        byte grupo2[9][2] = {{15, 13}, {15, 14}, {19, 16}, {19, 17}, {19, 18}, {23, 20}, {23, 21}, {23, 22}, {27, 24}};
        byte grupo3[9][2] = {{27, 25}, {27, 26}, {31, 28}, {31, 29}, {31, 30}, {35, 32}, {35, 33}, {35, 34}, {39, 36}};
        byte grupo4[9][2] = {{39, 37}, {39, 38}, {43, 40}, {43, 41}, {43, 42}, {47, 44}, {47, 45}, {47, 46}, {51, 48}};
        byte grupo5[9][2] = {{51, 49}, {51, 50}, {55, 52}, {55, 53}, {55, 54}, {59, 56}, {59, 57}, {59, 58}, {63, 60}};
        byte tudo[47][2] =
            {
                {3, 1}, {3, 2}, {7, 4}, {7, 5}, {7, 6}, {11, 8}, {11, 9}, {11, 10}, {15, 12}, {15, 13}, {15, 14}, {19, 16}, {19, 17}, {19, 18}, {23, 20}, {23, 21}, {23, 22}, {27, 24}, {27, 25}, {27, 26}, {31, 28}, {31, 29}, {31, 30}, {35, 32}, {35, 33}, {35, 34}, {39, 36}, {39, 37}, {39, 38}, {43, 40}, {43, 41}, {43, 42}, {47, 44}, {47, 45}, {47, 46}, {51, 48}, {51, 49}, {51, 50}, {55, 52}, {55, 53}, {55, 54}, {59, 56}, {59, 57}, {59, 58}, {63, 60}, {63, 61}, {63, 62}};
        switch (grupo)
        {
        case 1:
            for (size_t i = 0; i < 9; i++)
            {
                for (size_t j = 0; j < 2; j++)
                {
                    TrailerBlock_BlockAdress[i][j] = grupo1[i][j];
                }
            }
            break;
        case 2:
            for (size_t i = 0; i < 9; i++)
            {
                for (size_t j = 0; j < 2; j++)
                {
                    TrailerBlock_BlockAdress[i][j] = grupo2[i][j];
                }
            }
            break;
        case 3:
            for (size_t i = 0; i < 9; i++)
            {
                for (size_t j = 0; j < 2; j++)
                {
                    TrailerBlock_BlockAdress[i][j] = grupo3[i][j];
                }
            }
            break;
        case 4:
            for (size_t i = 0; i < 9; i++)
            {
                for (size_t j = 0; j < 2; j++)
                {
                    TrailerBlock_BlockAdress[i][j] = grupo4[i][j];
                }
            }
            break;
        case 5:
            for (size_t i = 0; i < 9; i++)
            {
                for (size_t j = 0; j < 2; j++)
                {
                    TrailerBlock_BlockAdress[i][j] = grupo5[i][j];
                }
            }
            break;
        case 6:
            for (size_t i = 0; i < 47; i++)
            {
                for (size_t j = 0; j < 2; j++)
                {
                    TrailerBlock_BlockAdress[i][j] = tudo[i][j];
                }
            }
            break;
        }

        tft8.setRotation(1);
        tft8.setTextSize(2);
        tft8.setCursor(0, 300);
        tft8.fillRect(0, 300, 480, 20, TFT_BLUE);
        tft8.print("APROXIME UM CARTAO >> ");
    F:

        // MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance

        // mfrc522.PCD_Init(); // Init MFRC522 card
        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }

        //mfrc522.PICC_HaltA();
        //mfrc522.PCD_StopCrypto1();

        MFRC522 mfrc522_X = RfidDual();
        MFRC522 mfrc522 = mfrc522_X;
        // while (!mfrc522.PICC_IsNewCardPresent())
        // {
        //     delay(1000);
        // }

        while (!mfrc522.PICC_ReadCardSerial())
        {
        }

        //tft8.fillRect(100, 80, 350, 16, TFT_BLACK);

        if (grupo < 6)
        {
            auto p = vp[0];
            bool b = CertificarCartaoCorreto(mfrc522, p);
            if (b == false)
            {
                goto F;
            }
        }

        MFRC522::StatusCode status;

        int size = 0;

        if (grupo == 6)
            size = 47;
        else
            size = 9;

        for (size_t i = 0; i < size; i++)
        {

            try
            {

                // Authenticate using key B
                status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, TrailerBlock_BlockAdress[i][0], &key, &(mfrc522.uid));
                if (status != MFRC522::STATUS_OK)
                {
                    return;
                }

                // Write data to the block

                status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(TrailerBlock_BlockAdress[i][1], dataBlock, syze);
            }
            catch (const std::exception &e)
            {
                Serial.println(e.what());
            }
        }
        if (grupo == 6)
        {
            tft8.setCursor(270, 300);
            tft8.print("CARTAO LIMPO!!");
            delay(2000);
            //ESP.restart();
        }
    }

    void ZeraTodosItens(Produto *p)
    {
        byte Quantidade[16];
        byte Convertido[16];

        auto D = String(p->qtd);
        auto V = String(p->convert);
        for (size_t i = 0; i < 16; i++)
        {
            Quantidade[i] = (char)D[i];
            Convertido[i] = (char)V[i];
        }

        int q1 = 11, q2 = 8, c1 = 15, c2 = 12;

        for (size_t grupo = 1; grupo <= 5; grupo++)
        {
            //grupo 1
            gravaBrolckAdress2(q1, q2, Quantidade, p, grupo);
            gravaBrolckAdress2(c1, c2, Convertido, p, grupo);
            q1 += 12;
            q2 += 12;
            c1 += 12;
            c2 += 12;
        }
        Serial.println("Todos os Itens foram ZERADOS!!");
    }

    void GravaItens2(Produto *p)
    {
#pragma region variaveis
        //DataBlocks
        byte Codigo[14];
        byte Descricao1[16];
        byte Descricao2[16];
        byte Descricao3[16];
        byte Descricao4[2];
        byte UND[2];
        byte Quantidade[16];
        byte Prateleira[16];
        byte Conversor[16];
        byte Convertido[16];

#pragma endregion
        //grupo
        int grupo = p->seq;

        auto CD = String(p->codigo);
        for (size_t i = 0; i < 14; i++)
        {
            Codigo[i] = (char)CD[i];
        }

        //descricao
        for (size_t i = 0; i < 50; i++)
        {
            if (i <= 15)
            {
                Descricao1[i] = p->descricao[i];
            }
            if (i >= 16 & i <= 31)
            {
                Descricao2[i - 16] = p->descricao[i];
            }
            if (i >= 32 & i <= 47)
            {
                Descricao3[i - 32] = p->descricao[i];
            }
            if (i >= 48 & i <= 49)
            {
                Descricao4[i - 48] = p->descricao[i];
            }
        }

        //UND
        for (size_t i = 0; i < 2; i++)
        {
            UND[i] = (char)p->und[i];
        }

        //QUANTIDADE
        auto D = String(p->qtd);
        for (size_t i = 0; i < 16; i++)
        {
            Quantidade[i] = (char)D[i];
        }

        //PRATELEIRA
        auto P = String(p->prateleira);
        for (size_t i = 0; i < 16; i++)
        {
            Prateleira[i] = (char)P[i];
        }

        //CONVERSOR
        auto C = String(p->convsor);
        for (size_t i = 0; i < 16; i++)
        {
            Conversor[i] = (char)C[i];
        }

        //CONVERTIDO
        auto V = String(p->convert);
        for (size_t i = 0; i < 16; i++)
        {
            Convertido[i] = (char)V[i];
        }

        if (grupo == 1)
        {
            //Codigo
            gravaBrolckAdress2(3, 1, Codigo, p, grupo);

            //Descricao e UND
            gravaBrolckAdress2(3, 2, Descricao1, p, grupo);
            gravaBrolckAdress2(7, 4, Descricao2, p, grupo);
            gravaBrolckAdress2(7, 5, Descricao3, p, grupo);

            //descricao4 e UND tem que ser juntos
            byte DescUND[4] = {Descricao4[0], Descricao4[1], UND[0], UND[1]};
            gravaBrolckAdress2(7, 6, DescUND, p, grupo);

            //Quantidade
            gravaBrolckAdress2(11, 8, Quantidade, p, grupo);

            //Prateleira
            gravaBrolckAdress2(11, 9, Prateleira, p, grupo);

            //Conversor
            gravaBrolckAdress2(11, 10, Conversor, p, grupo);

            //Convertido
            gravaBrolckAdress2(15, 12, Convertido, p, grupo);
        }

        if (grupo == 2)
        {
            //Codigo
            //        byte grupo2[9][2] = {{15, 13}, {15, 14}, {19, 16}, {19, 17}, {19, 18}, {23, 20}, {23, 21}, {23, 22}, {27, 24}};

            gravaBrolckAdress2(15, 13, Codigo, p, grupo);

            //Descricao e UND
            gravaBrolckAdress2(15, 14, Descricao1, p, grupo);
            gravaBrolckAdress2(19, 16, Descricao2, p, grupo);
            gravaBrolckAdress2(19, 17, Descricao3, p, grupo);

            //descricao4 e UND tem que ser juntos
            byte DescUND[4] = {Descricao4[0], Descricao4[1], UND[0], UND[1]};
            gravaBrolckAdress2(19, 18, DescUND, p, grupo);

            //Quantidade
            gravaBrolckAdress2(23, 20, Quantidade, p, grupo);

            //Prateleira
            gravaBrolckAdress2(23, 21, Prateleira, p, grupo);

            //Conversor
            gravaBrolckAdress2(23, 22, Conversor, p, grupo);

            //Convertido
            gravaBrolckAdress2(27, 24, Convertido, p, grupo);
        }

        if (grupo == 3)
        {
            //        byte grupo3[9][2] = {{27, 25}, {27, 26}, {31, 28}, {31, 29}, {31, 30}, {35, 32}, {35, 33}, {35, 34}, {39, 36}};

            gravaBrolckAdress2(27, 25, Codigo, p, grupo);

            //Descricao e UND
            gravaBrolckAdress2(27, 26, Descricao1, p, grupo);
            gravaBrolckAdress2(31, 28, Descricao2, p, grupo);
            gravaBrolckAdress2(31, 29, Descricao3, p, grupo);

            //descricao4 e UND tem que ser juntos
            byte DescUND[4] = {Descricao4[0], Descricao4[1], UND[0], UND[1]};
            gravaBrolckAdress2(31, 30, DescUND, p, grupo);

            //Quantidade
            gravaBrolckAdress2(35, 32, Quantidade, p, grupo);

            //Prateleira
            gravaBrolckAdress2(35, 33, Prateleira, p, grupo);

            //Conversor
            gravaBrolckAdress2(35, 34, Conversor, p, grupo);

            //Convertido
            gravaBrolckAdress2(39, 36, Convertido, p, grupo);
        }

        if (grupo == 4)
        {
            //byte grupo4[9][2] = {{39, 37}, {39, 38}, {43, 40}, {43, 41}, {43, 42}, {47, 44}, {47, 45}, {47, 46}, {51, 48}};

            gravaBrolckAdress2(39, 37, Codigo, p, grupo);

            //Descricao e UND
            gravaBrolckAdress2(39, 38, Descricao1, p, grupo);
            gravaBrolckAdress2(43, 40, Descricao2, p, grupo);
            gravaBrolckAdress2(43, 41, Descricao3, p, grupo);

            //descricao4 e UND tem que ser juntos
            byte DescUND[4] = {Descricao4[0], Descricao4[1], UND[0], UND[1]};
            gravaBrolckAdress2(43, 42, DescUND, p, grupo);

            //Quantidade
            gravaBrolckAdress2(47, 44, Quantidade, p, grupo);

            //Prateleira
            gravaBrolckAdress2(47, 45, Prateleira, p, grupo);

            //Conversor
            gravaBrolckAdress2(47, 46, Conversor, p, grupo);

            //Convertido
            gravaBrolckAdress2(51, 48, Convertido, p, grupo);
        }

        if (grupo == 5)
        {
            //byte grupo5[9][2] = {{51, 49}, {51, 50}, {55, 52}, {55, 53}, {55, 54}, {59, 56}, {59, 57}, {59, 58}, {63, 60}};

            gravaBrolckAdress2(51, 49, Codigo, p, grupo);

            //Descricao e UND
            gravaBrolckAdress2(51, 50, Descricao1, p, grupo);
            gravaBrolckAdress2(55, 52, Descricao2, p, grupo);
            gravaBrolckAdress2(55, 53, Descricao3, p, grupo);

            //descricao4 e UND tem que ser juntos
            byte DescUND[4] = {Descricao4[0], Descricao4[1], UND[0], UND[1]};
            gravaBrolckAdress2(55, 54, DescUND, p, grupo);

            //Quantidade
            gravaBrolckAdress2(59, 56, Quantidade, p, grupo);

            //Prateleira
            gravaBrolckAdress2(59, 57, Prateleira, p, grupo);

            //Conversor
            gravaBrolckAdress2(59, 58, Conversor, p, grupo);

            //Convertido
            gravaBrolckAdress2(63, 60, Convertido, p, grupo);
        }

        return;
    }

    void gravaBrolckAdress(byte TrailerBlock, byte BlockAdress, byte dataBlock[], Produto *p, int grupo)
    {

    F:
        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance

        mfrc522.PCD_Init(); // Init MFRC522 card
        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }
        mfrc522.PICC_HaltA();
        // Stop encryption on PCD
        mfrc522.PCD_StopCrypto1();
        //

        while (!mfrc522.PICC_IsNewCardPresent())
        {
            delay(1000);
        }
        while (!mfrc522.PICC_ReadCardSerial())
        {
            //delay(1000);
        }

        //tft8.fillRect(100, 80, 350, 16, TFT_BLACK);

        bool b = CertificarCartaoCorreto(mfrc522, p);
        if (b == false)
        {
            goto F;
        }

        MFRC522::StatusCode status;

        // Authenticate using key B
        status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, TrailerBlock, &key, &(mfrc522.uid));
        if (status != MFRC522::STATUS_OK)
        {
            return;
        }

        // Write data to the block

        status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(BlockAdress, dataBlock, 16);
        if (status != MFRC522::STATUS_OK)
        {
            return;
        }
        mfrc522.PCD_Reset();
    }

    void gravaBrolckAdress2(byte TrailerBlock, byte BlockAdress, byte dataBlock[], Produto *p, int grupo)
    {

    F:
        MFRC522 mfrc522(SS_SLAVE_RFID, RST_PIN); // Create MFRC522 instance

        mfrc522.PCD_Init(); // Init MFRC522 card
        for (byte i = 0; i < 6; i++)
        {
            key.keyByte[i] = 0xFF;
        }
        mfrc522.PICC_HaltA();
        // Stop encryption on PCD
        mfrc522.PCD_StopCrypto1();
        //

        while (!mfrc522.PICC_IsNewCardPresent())
        {
            delay(1000);
        }

        while (!mfrc522.PICC_ReadCardSerial())
        {
            //delay(1000);
        }

        //tft8.fillRect(100, 80, 350, 16, TFT_BLACK);

        if (p->id == "00000000")
        {
            /* ZERA O CARTAO INTEIRO */
        }
        else
        {
            bool b = CertificarCartaoCorreto2(mfrc522, p);
            if (b == false)
            {
                goto F;
            }
        }

        MFRC522::StatusCode status;

        // Authenticate using key B
        status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, TrailerBlock, &key, &(mfrc522.uid));
        if (status != MFRC522::STATUS_OK)
        {
            return;
        }
        status = (MFRC522::StatusCode)mfrc522.MIFARE_Write(BlockAdress, dataBlock, 16);
        if (status != MFRC522::STATUS_OK)
        {
            return;
        }
        mfrc522.PCD_Reset();
    }

    //Cria novo cartao. Apaga dados e depois grana novas informacoes
    void CriaCartaoCompleto(const uint8_t *buf)
    {
        string dados = (char *)buf;

        auto linhas = StringHelper::split(dados, '\n');

        int i = 1;
        for (auto l : linhas)
        {
            l.trim();
            Produto *p2 = new Produto();
            auto colunas = StringHelper::split2(l.c_str(), '\t');

            String seq = colunas[0].c_str();
            seq.trim();
            if (seq == "6")
            {
                seq = newSeq;
            }

            p2->seq = atoi(seq.c_str());

            p2->data = colunas[1].c_str();
            p2->id = colunas[2].c_str();
            p2->codigo = colunas[3].c_str();
            p2->descricao = colunas[4].c_str();
            p2->und = colunas[5].c_str();

            p2->qtd = colunas[6].c_str();

            p2->prateleira = colunas[7].c_str();

            p2->convsor = colunas[8].c_str();

            p2->convert = colunas[9];

            vp.push_back(p2);
        }

        int k = 1;
        for (auto pp : vp)
        {
            GravaItens2(pp);
        }
        vp.clear();
    }

    //Retorna uma string
    String DecToCHAR(byte *cj, byte sz)
    {
        String u = "";

        for (size_t i = 0; i < sz; i++)
        {
            if (cj[i] == 0)
            {
                continue;
            }
            u += char(cj[i]);
        }

        u.trim();
        return u;
    }

    String DecToHex(byte *cj, byte sz)
    {

        String u = "";

        for (size_t i = 0; i < sz; i++)
        {
            if (cj[i] == 0 & cj[i + 1] == 0)
            {
                u += "00 ";
                continue;
            }

            String tm = String(cj[i], HEX);
            Serial.println(tm);
            Serial.println(tm.length());
            if (tm.length() == 1)
            {
               u += "0";
            }

            u += String(cj[i], HEX) + " ";
            u.toUpperCase();
        }
        u.trim();
        Serial.println(u + ">>");
        return u;
    }

    void RetiraReaproxima()
    {
        byte SS_PIN = 17;
        byte RST_PIN = 4;
        MFRC522 mfrc522(SS_PIN, RST_PIN);
        SPI.begin(); // Init SPI bus
        mfrc522.PCD_Init();

        while (mfrc522.PICC_IsNewCardPresent())
        {
            delay(1000);
            mfrc522.PICC_IsNewCardPresent();
        }
    }

    int PesquisaSeqDisponivel(NTPClient tc)
    {
        newSeq = 1;
        ObterBufferCartao(tc);
        for (auto d : vp)
        {
            String c = d->codigo;
            c.trim();
            if (c.length() == 0)
            {
                p = new Produto();
                vp.clear();
                return newSeq;
            }
            newSeq++;
        }
    }
};
#endif