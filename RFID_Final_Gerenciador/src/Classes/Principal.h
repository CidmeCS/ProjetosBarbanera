#ifndef PRINCIPAL_H
#define PRINCIPAL_H

#include "Classes/FormatarSD.h"
#include "Classes/Leitura.h"
#include "Classes/Cartao.h"
#include "Classes/ObterTXTs.h"
#include "Classes/Teclado.h"
#include "Classes/SomaMetro.h"
#include "Classes/SomaKilo.h"
#include "Classes/SubtraiMetro.h"
#include "Classes/SubtraiKilo.h"
#include "Classes/ManutencaoSpeed.h"
#include <Arduino.h>
#include <Classes/Manutencao.h>
#include <Classes/Prateleira.h>
#include <Classes/AlteraMetro.h>
#include <Classes/AlteraKilo.h>
#include <SPI.h>
#include "Classes/SalvaListaUIDs.h"
#include "Classes/ZeraUmItem.h"
#include <NTPClient.h>
#include <Classes/ListaFiles.h>
using namespace std;

TFT_eSPI tft = TFT_eSPI();

class Principal
{
public:
    Principal()
    {
    }

    Teclado *tecla;
    char c = ' ';
    Leitura *l;
    ObterTXTs *o;
    FormatarSD *f;
    Manutencao *manut;
    ManutencaoSpeed *ms;
    Prateleira *p;
    SalvaListaUIDs *slu;
    ZeraUmItem *zui;
    SomaMetro *sm;
    SomaKilo *sk;
    SubtraiMetro *sbm;
    SubtraiKilo *sbk;
    AlteraMetro *am;
    AlteraKilo *ak;
    Cartao *cp_;

    void start(NTPClient tc)
    {

        SPI.begin();
        tft.init();
        tft.setRotation(1);
        tft.fillScreen(TFT_BLACK);
        tft.setTextSize(2);
        tft.setTextColor(TFT_GREEN);

        tft.setCursor(10, 20);
        tft.print("AGUARDE...");

        // ListaFiles *lf = new ListaFiles();
        // lf->TesteCriarFiles(tc);

        ListaFiles::MantemDezUltimos();

        tft.fillScreen(TFT_BLACK);
        tft.setCursor(10, 20);
        tft.print("SELECIONE UMA OPCAO");

        tft.setTextColor(TFT_SILVER);
        tft.setCursor(10, 40);
        tft.print("<- Virgula");

        tft.setTextColor(TFT_SILVER);
        tft.setCursor(10, 60);
        tft.print("2- Leituras");

        tft.setTextColor(TFT_SKYBLUE);
        tft.setCursor(10, 80);
        tft.print("3- Manutencao");

        tft.setTextColor(TFT_YELLOW);
        tft.setCursor(10, 100);
        tft.print("4- Zera Um Item");

        tft.setTextColor(TFT_WHITE);
        tft.setCursor(10, 120);
        tft.print("5- Somar Conv");

        tft.setTextColor(TFT_CYAN);
        tft.setCursor(10, 140);
        tft.print("6- Somar QTD");

        tft.setTextColor(TFT_LIGHTGREY);
        tft.setCursor(10, 160);
        tft.print("7- WebServer");

        tft.setTextColor(TFT_NAVY);
        tft.setCursor(10, 180);
        tft.print("8- Formatar Memorias");

        tft.setTextColor(TFT_PINK);
        tft.setCursor(10, 220);
        tft.print("0- Salva Lista UIDs");

        tft.setTextColor(TFT_MAGENTA);
        tft.setCursor(10, 240);
        tft.print("F1- Subtrair Conv");

        tft.setTextColor(TFT_BLUE);
        tft.setCursor(10, 260);
        tft.print("F2- Subtrair QTD");

        tft.setTextColor(TFT_RED);
        tft.setCursor(10, 280);
        tft.print("#- Altera Conv ");

        tft.setTextColor(TFT_ORANGE);
        tft.print("*- Altera QTD");

        tft.setTextColor(TFT_ORANGE);
        tft.setCursor(316, 140);
        tft.print("^- ManutSpeed");

        tft.setTextColor(TFT_ORANGE);
        tft.setCursor(300, 80);
        tft.print("DOWN- CriaCards");

        tft.setTextColor(TFT_GREENYELLOW);

        //TesteTeclado();
        tecla = new Teclado();

        Cartao *c = new Cartao("");

        String iint = c->CardIntOK();
        tft.setCursor(340, 100);
        tft.print(iint);

        String ext = c->CardExtOK();
        tft.setCursor(340, 120);
        tft.print(ext);

        loop(tc);
    }

    void loop(NTPClient tc)
    {
        Serial.println("PPRINCIPAL");
        while (true)
        {
            //TesteTeclado();
            tft.setTextColor(TFT_OLIVE);
            tft.setCursor(230, 200);
            tft.fillRect(230, 200, 250, 18, TFT_BLACK);
            tc.update();
            tft.print(tc.getFormattedDate());

            c = tecla->tecla();
            if (c == '0' | c == '1' | c == '2' | c == '3' | c == '4' | c == '5' | c == '6' | c == '7' | c == '8' | c == '9' | c == 'F' | c == 'f' | c == '#' | c == '*' | c == 'U' | c == 'D' | c == '>' | c == '<' | c == 'e')
            {

                char cc = c;
                tft.fillRect(0, 300, 480, 18, TFT_BLACK);
                tft.setCursor(10, 300);
                tft.setTextColor(TFT_WHITE);

                switch (c)
                {
                case '<':
                    tft.print("< TiraVirgula Press ESC ou ENT");
                    break;
                case 'U':
                    tft.print("^ ManutSpeed Press ESC ou ENT");
                    break;
                case 'D':
                    tft.print("CriaCards Press ESC ou ENT");
                    break;
                case '2':
                    tft.print("2- Leituras Press ESC ou ENT");
                    break;
                case '3':
                    tft.print("3- Manutencao Press ESC ou ENT");
                    break;
                case '7':
                    tft.print("7- WebServer Press ESC ou ENT");
                    break;
                case '8':
                    tft.print("8- Formatar Mem Press ESC ou ENT");
                    break;
                case '9':
                    tft.print("9- Press ESC ou ENT");
                    break;
                case '0':
                    tft.print("0- Salva Lista UID Press ESC ou ENT");
                    break;
                case '4':
                    tft.print("4- Zera Um Item");
                    break;
                case '5':
                    tft.print("5- Somar Conv");
                    break;
                case '6':
                    tft.print("6- Somar QTD");
                    break;
                case 'F':
                    tft.print("F1- Subtrai Conv");
                    break;
                case 'f':
                    tft.print("F2- Subtrai QTD");
                    break;
                case '#':
                    tft.print("#- Altera Conv");
                    break;
                case '*':
                    tft.print("*- Altera QTD");
                    break;
                case 'e':
                    tft.print("ESC- ESC");
                    delay(1000);
                    break;
                default:
                    tft.print(c + String(" Press ESC ou ENT"));
                    break;
                }

                while (true)
                {
                    c = tecla->tecla();
                    if (c == 'E')
                    {
                        c = cc;
                        break;
                    }
                    if (c == 'e')
                    {
                        tft.fillRect(0, 300, 480, 18, TFT_BLACK);
                        c = '.';
                        delay(500);
                        break;
                    }
                }
            }
            switch (c)
            {
            case '<':
                Serial.println("Virgula");
                cp_ = new Cartao("INTERNO");
                cp_->Virgula(tc);
                break;
            case 'U':
                Serial.println("ManutSpeed");
                ms = new ManutencaoSpeed();
                ms->Start(tc);
                break;
            case 'D':
                Serial.println("CriaCards");
                ms = new ManutencaoSpeed();
                ms->CriaCards(tc);
                break;
            case '2':
                Serial.println("Leituras Selecionado");
                l = new Leitura();
                l->start(tc);
                break;
            case '3':
                c = ' ';
                Serial.println("Manutencao Selecionado");
                manut = new Manutencao();
                manut->seleciona(tc);
                break;
            case '7':
                Serial.println("WebServer Selecionado");
                o = new ObterTXTs();
                o->Obter(tc);
                break;
            case '8':
                Serial.println("Formatar Memorias Selecionado");
                f = new FormatarSD();
                f->Formatar();
                break;

            case '0':
                Serial.println("Salva Lista UIDs");
                slu = new SalvaListaUIDs("INTERNO");
                slu->Start(tc);
                break;
            case '4':
                Serial.println("Zera um Item");
                zui = new ZeraUmItem();
                zui->Zerar(tc);
                break;
            case '5':
                Serial.println("Somar Conv");
                sm = new SomaMetro();
                sm->Somar(tc);
                break;
            case '6':
                Serial.println("Somar QTD");
                sk = new SomaKilo();
                sk->Somar(tc);
                break;
            case 'F':
                Serial.println("Subtrair Conv");
                sbm = new SubtraiMetro();
                sbm->Subtrair(tc);
                break;
            case 'f':
                Serial.println("Subtrair QTD");
                sbk = new SubtraiKilo();
                sbk->Subtrair(tc);
                break;
            case '#':
                Serial.println("Altera Conv");
                am = new AlteraMetro();
                am->Alterar(tc);
                break;
            case '*':
                Serial.println("Altera QTD");
                ak = new AlteraKilo();
                ak->Alterar(tc);
                break;
            case 'e':
                tft.print(" --> aguarde...");
                ESP.restart();
                break;
            }
        }
    }

    void TesteTeclado()
    {
        manut = new Manutencao();
        tecla = new Teclado();
        while (true)
        {
            auto t = tecla->tecla();

            Serial.println(t);

            //gvd->AntiRepet();

            tft.setCursor(10, 280);

            tft.print(t);

            delay(200);

            tft.fillRect(10, 280, 12, 18, TFT_RED);
        }
    }
};
#endif