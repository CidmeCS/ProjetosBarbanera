#ifndef MANUTENCAOSPEED_H_INCLUDED
#define MANUTENCAOSPEED_H_INCLUDED

#include <Arduino.h>
#include <Classes/Produto.h>
#include <Classes/Cartao.h>
#include <TFT_eSPI.h>
#include <stdlib.h>
#include <SPIFFS.h>
#include "FS.h"
#include <Classes/ListaFiles.h>
#include "Classes/Teclado.h"

TFT_eSPI tft51 = TFT_eSPI();

class ManutencaoSpeed
{
    bool b = false;
    int seq = 0;
    String cod = "";
    double qtd = 0;
    byte buzer = 27;
    int cursorY = 60;
    int cursorX = 250;
    Cartao *cs;
    Produto *pd2;
    Teclado *tecla = new Teclado();
    vector<String> files;
    int item = 0;

public:
    ManutencaoSpeed()
    {
        tft51.init();
        tft51.setRotation(1);
        tft51.fillScreen(TFT_BLACK);
        tft51.setTextSize(2);
        tft51.setTextColor(TFT_YELLOW);
        tft51.setCursor(10, 10);
        tft51.print("MODO MANUTENCAO ETIQUETAS AUTOMATICO");

        pinMode(buzer, OUTPUT);
    }

    String SelecionaFilesAtuaCard()
    {
        tft51.setCursor(0, 60);
        files = ListaFiles::GetAtualCard();
        for (String s : files)
        {
            string k = s.c_str();
            k.replace(0, 10, "");

            tft51.println(String(k.c_str()));
        }

        tft51.setCursor(cursorX, cursorY);
        tft51.print("<<");

        char c = ' ';
        bool sair = true;
        while (sair)
        {
            AntiRepet();
            c = tecla->tecla();
            switch (c)
            {
            case 'U':
                UP();
                break;
            case 'D':
                DOWN();
                break;
            case 'E':
                sair = false;
                break;
            case 'e':
                tft51.setTextColor(TFT_YELLOW);
                tft51.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft51.setCursor(10, 300);
                tft51.println("ESC -> Aguarde...");
                ESP.restart();
                break;
            }
        }
        return files[item];
    }

    void UP()
    {
        if (cursorY <= 60)
        {
            return;
        }
        tft51.fillRect(250, 60, 24, 160, TFT_BLACK);
        item--;
        cursorY -= 16;
        tft51.setCursor(cursorX, cursorY);
        tft51.print("<<");
    }

    void DOWN()
    {
        if (cursorY >= 200)
        {
            return;
        }
        if ((item + 2) > files.size())
        {
            return;
        }
        tft51.fillRect(250, 60, 24, 160, TFT_BLACK);
        item++;
        cursorY += 16;
        tft51.setCursor(cursorX, cursorY);
        tft51.print("<<");
    }

    void AntiRepet()
    {
        char J = '\0';
        while ((J = tecla->tecla()) != ' ')
        {
            //Serial.printf("Pressionado %c ... \n", J);
        }
        //Serial.printf("Soltei %c ... \n", J);
    }

    void Start(NTPClient tc)
    {

        //Seleciona files
        String fileSelect = SelecionaFilesAtuaCard();

        //String file = ListaFiles::GetUltimoAtualCard();
        Serial.println(fileSelect);

        File text = SPIFFS.open(fileSelect);
        String texto2 = text.readString();

        //split linha
        vector<String> linhas = StringHelper::SplitLinha(texto2, '\n');
        Serial.println(linhas.size());
        vector<Anotacao *> va;
        Anotacao *a;
        for (String l : linhas)
        {
            vector<String> dado = StringHelper::SplitDados(l, ';');

            a = new Anotacao();
            a->cod = dado[0];
            a->qtd = dado[1];
            a->opr = dado[2];
            a->ptl = dado[3];
            a->op2 = dado[4];

            va.push_back(a);
            dado.clear();
        }

        tc.update();

        int sd2 = 1;

        for (Anotacao *an : va)
        {
            unsigned long start = 0, elapsed = 0, finished = 0;
            start = millis();

            cs = new Cartao("");

            Serial.println(sd2++);
            Serial.print("INI HEAP: ");
            Serial.println(ESP.getFreeHeap());

            if (an->opr == "-")
            {
                MenosItem(an, tc);
            }
            if (an->opr == "+")
            {
                SomaItem(an, tc);
            }
            if (an->opr == "Z")
            {
                ZeraItem(an, tc);
            }
            if (an->opr == "A")
            {
                AtualizaItem(an, tc);
            }

            //
            Serial.println(linhas.size());
            linhas.erase(linhas.begin() + 0);
            String ss = "";
            for (String s : linhas)
            {
                ss += s + "\n";
            }
            ss.trim();
            if (ss == "")
            {
                SPIFFS.remove(fileSelect);
            }
            else
            {
                File file = SPIFFS.open(fileSelect, FILE_WRITE);
                file.print(ss);
                file.close();
            }

            //

            delete an;

            Serial.print("FIM HEAP: ");
            Serial.println(ESP.getFreeHeap());
            delete cs;

            finished = millis();
            elapsed = finished - start;
            Serial.print(elapsed);
            Serial.println(" milliseconds elapsed BUFFER 10");
        }
        linhas.clear();
        va.clear();
        tft51.setCursor(90, 120);
        tft51.print("FIM DAS ALTERACOES");
    }

    void SomaItem(Anotacao *an, NTPClient tc)
    {
        tft51.fillRect(0, 30, 480, 320, TFT_BLACK);
        tft51.setCursor(90, 40);
        tft51.print("Prateleira: " + an->ptl);
        tft51.setCursor(90, 140);
        an->qtd.replace(',', '.');
        tft51.print(an->cod + "; " + an->qtd + "; " + an->opr + "; " + an->op2);
        //verifica se o card contem o codigo
        CodXCard(an, tc);
        bip1x();
        CardLido();
        //Grava novos dados
        pd2->convert.replace(',', '.');
        an->qtd.replace(',', '.');

        //CASO BL
        if (an->op2 == "M")
        {
            String nc = String(pd2->convert.toDouble() + an->qtd.toDouble(), 2);
            pd2->convert = nc;
            pd2->convsor.replace(',', '.');
            pd2->convert.replace(',', '.');
            String nb = String(pd2->convert.toDouble() * pd2->convsor.toDouble(), 3);
            pd2->qtd = nb;
        }
        // CASO PP2
        if (an->op2 == "D")
        {
            String nc = String(pd2->qtd.toDouble() + an->qtd.toDouble(), 2);
            pd2->qtd = nc;
            pd2->convsor.replace(',', '.');
            String nb = String(pd2->qtd.toDouble() * pd2->convsor.toDouble(), 3);
            pd2->convert = nb;
            pd2->convert.replace(',', '.');
        }
        //CASO SEM LIVRE17
        if (an->op2 == "N")
        {
            String nb = String(pd2->qtd.toDouble() + an->qtd.toDouble(), 2);
            pd2->qtd = nb;
            pd2->convert = "0.000";
        }

        Serial.println("Nova quantidade ");
        Serial.println(pd2->qtd);

        cs->GravaItens2(pd2);
        bip2x();
        CardGravado();
    }

    void MenosItem(Anotacao *an, NTPClient tc)
    {
        tft51.fillRect(0, 30, 480, 320, TFT_BLACK);
        tft51.setCursor(90, 40);
        tft51.print("Prateleira: " + an->ptl);
        tft51.setCursor(90, 140);
        an->qtd.replace(',', '.');
        tft51.print(an->cod + "; " + an->qtd + "; " + an->opr + "; " + an->op2);
        //verifica se o card contem o codigo
        CodXCard(an, tc);
        bip1x();
        CardLido();
        //Grava novos dados

        pd2->convert.replace(',', '.');
        an->qtd.replace(',', '.');

        if (an->op2 == "M")
        {
            String nc = String(pd2->convert.toDouble() - an->qtd.toDouble(), 2);
            pd2->convert = nc;
            pd2->convsor.replace(',', '.');
            pd2->convert.replace(',', '.');
            String nb = String(pd2->convert.toDouble() * pd2->convsor.toDouble(), 3);
            pd2->qtd = nb;
        }
        // CASO PP2
        if (an->op2 == "D")
        {
            String nc = String(pd2->qtd.toDouble() - an->qtd.toDouble(), 2);
            pd2->qtd = nc;
            pd2->convsor.replace(',', '.');
            String nb = String(pd2->qtd.toDouble() * pd2->convsor.toDouble(), 3);
            pd2->convert = nb;
            pd2->convert.replace(',', '.');
        }
        //CASO SEM LIVRE17
        if (an->op2 == "N")
        {
            String nb = String(pd2->qtd.toDouble() - an->qtd.toDouble(), 2);
            pd2->qtd = nb;
            pd2->convert = "0.000";
        }

        cs->GravaItens2(pd2);
        bip2x();
        CardGravado();
    }

    void ZeraItem(Anotacao *an, NTPClient tc)
    {
        tft51.fillRect(0, 30, 480, 320, TFT_BLACK);
        tft51.setCursor(90, 40);
        tft51.println("Prateleira: " + an->ptl);
        tft51.setCursor(90, 140);
        an->qtd.replace(',', '.');
        tft51.print(an->cod + "; " + an->qtd + "; " + an->opr);
        //verifica se o card contem o codigo
        CodXCard(an, tc);
        bip1x();
        CardLido();

        //Grava novos dados

        pd2->convert = "0.00";

        pd2->qtd = "0.000";

        cs->GravaItens2(pd2);
        bip2x();
        CardGravado();
    }

    void AtualizaItem(Anotacao *an, NTPClient tc)
    {
        tft51.fillRect(0, 30, 480, 320, TFT_BLACK);
        tft51.setCursor(90, 40);
        tft51.println("Prateleira: " + an->ptl);
        tft51.setCursor(90, 140);
        an->qtd.replace(',', '.');
        tft51.print(an->cod + "; " + an->qtd + "; " + an->opr + "; " + an->op2);
        //verifica se o card contem o codigo
        CodXCard(an, tc);
        bip1x();
        CardLido();

        //Grava novos dados
        //String nc = String(qtd);
        pd2->convert = an->qtd;

        pd2->convert.replace(',', '.');
        pd2->convsor.replace(',', '.');

        //
        String nb = String();

        //CASO BL
        if (an->op2 == "M")
        {
            nb = String(pd2->convert.toDouble() * pd2->convsor.toDouble(), 3);
        }

        // CASO PP2
        else if (an->op2 == "D")
        {
            nb = String(pd2->convert.toDouble(), 3);
            pd2->convert = String(nb.toDouble() * pd2->convsor.toDouble(), 3);
        }

        //CASO SEM LIVRE17
        else if (an->op2 == "N")
        {
            nb = pd2->convert;
            pd2->convert = "0.000";
        }
        pd2->qtd = nb;
        //

        Serial.println("Novo Quantidade" + pd2->qtd);

        cs->GravaItens2(pd2);
        bip2x();
        CardGravado();
    }

    void bip1x()
    {
        digitalWrite(buzer, HIGH);
        delay(200);
        digitalWrite(buzer, LOW);
    }

    void CardLido()
    {
        tft51.setCursor(90, 60);
        tft51.println("CARD LIDO");
        delay(1000);
    }

    void bipERRO()
    {
        digitalWrite(buzer, HIGH);
        delay(50);
        digitalWrite(buzer, LOW);
        tft51.print(".");
        delay(50);
    }

    void bip2x()
    {
        for (size_t i = 0; i < 2; i++)
        {
            digitalWrite(buzer, HIGH);
            delay(200);
            digitalWrite(buzer, LOW);
            delay(100);
        }
    }

    void CardGravado()
    {
        tft51.setCursor(90, 80);
        tft51.println("CARD GRAVADO");
        delay(2000);
    }

    void CodXCard(Anotacao *an, NTPClient tc)
    {
        this->b = false;
        this->seq = 0;
        this->cod = "";
        this->qtd = 0.0;
        do
        {
            cs->ObterBufferCartao(tc);
            vector<Produto *> vpi = cs->vp;
            tft51.setCursor(90, 100);
            tft51.fillRect(90, 60, 216, 60, TFT_BLACK);
            for (Produto *ps : vpi)
            {
                String fg = "";
                for (char ch : ps->codigo)
                {
                    fg += ch;
                }
                fg.trim();
                if (an->cod == fg)
                {
                    pd2 = ps;
                    this->b = true;
                    this->seq = ps->seq;
                    this->cod = fg;

                    String sg = (an->qtd);
                    sg.replace(',', '.');

                    this->qtd = sg.toDouble();
                    break;
                }
                bipERRO();
            }

        } while (this->b == false);
    }

    void CriaCards(NTPClient tc)
    {
        File file = SPIFFS.open("/CriaCards.txt", FILE_READ);
        String texto = file.readString();
        vector<String> linhas = StringHelper::SplitLinha(texto, '\r');
        linhas.erase(linhas.end()); // deu bug. precisei deletar a ultma linha
        vector<Produto *> vp;
        vector<vector<Produto *>> v2;
        String uidNew = "", uidOld = "";

        int i = 0, ii = 1;
        for (String linha : linhas)
        {
            i++;
            linha.trim();
            vector<String> dados = StringHelper::split2(linha.c_str(), '\t');

            Produto *p = new Produto();

            p->seq = dados[0].toInt();
            p->data = dados[1];
            p->id = dados[2];
            p->codigo = dados[3];
            p->descricao = dados[4];
            p->und = dados[5];
            p->prateleira = dados[6];
            p->qtd = dados[7];
            p->convsor = dados[8];
            p->convert = dados[9];

            uidNew = p->id;

            if (i == 1)
            {
                vp.push_back(p);
                uidOld = uidNew;
                continue;
            }
            if (uidOld == uidNew)
            {
                vp.push_back(p);
                uidOld = uidNew;
                continue;
            }
            if (uidNew != uidOld)
            {
                v2.push_back(vp);
                vp.clear();
                vp.push_back(p);
            }
            uidOld = uidNew;
        }

        v2.push_back(vp);

        Cartao *ca = new Cartao("INTERNO");

        Serial.println(ESP.getFreeHeap());

        i = 0;

        for (vector<Produto *> cartoes : v2)
        {
            bip1x();
            tft51.fillRect(0, 30, 480, 320, TFT_BLACK);
            tft51.setCursor(50, 120);
            tft51.println("Aproxime o cartao " + String(cartoes[i]->id));
            String uidTXT = cartoes[i]->id;
            String uidCard = "";
            do
            {
                 char t = tecla->tecla(); 
                 if(t == 'e')
                 {return;}  
                tft51.fillRect(400, 120, 80, 16, TFT_BLACK);
                tft51.setCursor(400, 120);
                for (size_t i = 0; i < 5; i++)
                {
                    tft51.print(".");
                    delay(50);
                }

                uidCard = ca->ObterUIDCartao2();
                uidTXT.trim();
                uidCard.trim();

            } while (uidCard != uidTXT);

            tft51.println("\nExcluindo Cartao...");
            ca->ExcluiItens(6);
            tft51.println("Cartao excluido");

            i++;

            for (Produto *dados : cartoes)
            {
                tft51.println("ADD item " + dados->codigo);
                ca->GravaItens2(dados);
            }
            Serial.println(ESP.getFreeHeap());
        }

        bip2x();
        tft51.fillRect(0, 30, 480, 320, TFT_BLACK);
        tft51.setCursor(50, 120);
        tft51.println("OS CARTOES FORAM CRIADOS\n");
        tft51.println("ESC ou MENU");
        Serial.println(ii++);
    }
};
#endif