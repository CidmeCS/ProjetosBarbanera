#ifndef GRAVADOR_H
#define GRAVADOR_H
#include <Arduino.h>
#include <Classes/Cartao.h>
//#include <Classes/Inventario.h>
#include <Classes/Prateleira.h>
#include <Classes/Produto.h>
#include <Classes/Teclado.h>
#include <MFRC522.h>
#include <SPIFFS.h>
#include <TFT_eSPI.h>
TFT_eSPI tft7 = TFT_eSPI();
#include <stdlib.h>
using namespace std;

#include <iostream>
#include <stdio.h>

using std::cout;

class Gravador
{

public:
    Gravador()
    {
        tcl = new Teclado();
    }

    Cartao *c;
    Teclado *tcl;
    vector<Produto *> vp;
    int grupo = 1;
    int index = 0;
    int linha = 0;
    byte SS_SLAVE_RFID = 17;
    byte RST_PIN = 4;

    MFRC522::MIFARE_Key key;

    void seleciona()
    {
        tft7.init();
        tft7.setRotation(1);
        tft7.fillScreen(TFT_BLUE);
        tft7.setTextSize(2);
        tft7.setTextColor(TFT_YELLOW);
        tft7.setCursor(90, 40);
        tft7.print("MANUTENCAO / EXCLUSAO");

        tft7.setCursor(90, 80);
        tft7.print("MANUTENCAO");
        tft7.setCursor(90, 120);
        tft7.println("1 - APARTIR DO CARTAO");
        tft7.setCursor(90, 140);
        tft7.println("2 - APARTIR DAS LEITURAS");
        tft7.setCursor(90, 160);
        tft7.println("3 - APARTIR DOS INVENTARIOS");

        tft7.setCursor(90, 200);
        tft7.print("EXCLUSAO");
        tft7.setCursor(90, 240);
        tft7.print("4 - EXCLUI UM ITEM");
        tft7.setCursor(90, 260);
        tft7.print("5 - EXCLUI TODO CARTAO");

        tcl = new Teclado();
        char j = '\0';
        char p = '\0';
        AntiRepet();
        while (true)
        {

            while (j != 'E')
            {
                //p = '1'; //automatico**
                //break;   // automativo**

                j = tcl->tecla();
                switch (j)
                {
                case '1':
                    tft7.setTextColor(TFT_YELLOW);
                    tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                    tft7.setCursor(10, 300);
                    tft7.println("1 - DO CARTAO. PRES Esc ou Ent");
                    p = '1';
                    break;
                case '2':
                    tft7.setTextColor(TFT_YELLOW);
                    tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                    tft7.setCursor(10, 300);
                    tft7.println("2 - DAS LEITURAS. PRES Esc ou Ent");
                    p = '2';
                    break;
                case '3':
                    tft7.setTextColor(TFT_YELLOW);
                    tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                    tft7.setCursor(10, 300);
                    tft7.println("3 - DOS INVENTARIOS. PRES Esc ou Ent");
                    p = '3';
                    break;
                case '4':
                    tft7.setTextColor(TFT_YELLOW);
                    tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                    tft7.setCursor(10, 300);
                    tft7.println("4 - EXCLUI UM ITEM. PRES Esc ou Ent");
                    p = '4';
                    break;
                case '5':
                    tft7.setTextColor(TFT_YELLOW);
                    tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                    tft7.setCursor(10, 300);
                    tft7.println("5 - EXCLUI TODO CARTAO. PRES Esc ou Ent");
                    p = '5';
                    break;
                case 'E':
                    break;
                case 'e':
                    tft7.setTextColor(TFT_YELLOW);
                    tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                    tft7.setCursor(10, 300);
                    j = '.';
                    break;
                }
            }

            //j = '2';
            if (p == '1')
            {
                AntiRepet();
                j = ' ';
                Serial.println("1- DO CARTAO SELECIONADO");
                LerCard("1- DO CARTAO SELECIONADO");
                break;
            }
            if (p == '2')
            {
                AntiRepet();
                j = ' ';
                Serial.println("2- LEITURAS SELECIONADO");
                NavegaFiles("2- LEITURAS SELECIONADO", "/Leituras");
                break;
            }
            if (p == '3')
            {
                AntiRepet();
                j = ' ';
                Serial.println("3- INVENTARIOS SELECIONADO");
                NavegaFiles("3- INVENTARIOS SELECIONADO", "/Inventarios");
                break;
            }
            if (p == '4')
            {
                AntiRepet();
                j = ' ';
                Serial.println("4- EXCLUIR UM ITEM SELECIONADO");
                ExcluiItens("4 - EXCLUI UM ITEM DO CARTAO");
                break;
            }
            if (p == '5')
            {
                AntiRepet();
                j = ' ';
                Serial.println("5- EXCLUIR TODO CARTAO SELECIONADO");
                c = new Cartao();
                c->ExcluiItens(6);
                break;
            }
            if (j == 'e')
            {
                tft7.setTextColor(TFT_YELLOW);
                tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft7.setCursor(10, 300);
                tft7.println("ESC -> Aguarde...");
                ESP.restart();
            }
        }
    }

    void createFile(fs::FS &fs, const char *path)
    {
        if (fs.exists(path))
        {
            Serial.println("Arquivo ja existe");
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
            Serial.println("Arquivo criado");
        }
        file.close();
    }

    void NavegaFiles(String titulo, String root)
    {
        tft7.fillScreen(TFT_BLACK);
        tft7.setTextSize(2);
        tft7.setTextColor(TFT_YELLOW);
        tft7.setCursor(30, 30);
        tft7.println(titulo);

        vector<File> files;
        vector<File> filesSorted;
        File dir = SPIFFS.open(root);
        File nextFile = dir.openNextFile();
        while (nextFile)
        {
            files.push_back(nextFile);
            nextFile = dir.openNextFile();
        }
        Serial.println("Saiu");
        tft7.setCursor(0, 90);
        tft7.fillRect(0, 90, 360, 16, TFT_DARKCYAN);
        int k = files.size();
        //sort(files.begin(), files.end());
        for (auto i = files.end(); i > files.begin(); i--)
        {
            filesSorted.push_back(files.at(--k));
        }
        int i = 1;

        for (auto f : filesSorted)
        {
            tft7.println(String(i) + "- " + String(f.name()).substring(String(f.name()).lastIndexOf("/") + 1, String(f.name()).length()));
            if (i == 14)
                break;
            i++;
        }
        tcl = new Teclado();
        char j = '\0';
        AntiRepet();
        int total = filesSorted.size();
        index = 0;

        Serial.printf("total %d - index %d\n", total, index);
        while (j != 'e')
        {
            j = tcl->tecla();

            if (j == 'U')
            {
                if ((index + 1) == total)
                {
                    continue;
                }

                tft7.fillRect(0, 90, 480, 230, TFT_BLACK);
                tft7.fillRect(0, 90, 360, 16, TFT_DARKCYAN);
                tft7.setCursor(0, 90);
                index++;
                int gh = 0;
                for (int i = index; i < total; i++)
                {
                    tft7.println(String(i + 1) + "- " + String(filesSorted.at(i).name()).substring(String(filesSorted.at(i).name()).lastIndexOf("/") + 1, String(filesSorted.at(i).name()).length()));
                    if (gh++ == 13)
                        break;
                }

                Serial.printf("total %d - index %d\n", total, index);
            }
            if (j == 'D')
            {
                if (index <= 0)
                {
                    continue;
                }

                tft7.fillRect(0, 90, 480, 230, TFT_BLACK);
                tft7.fillRect(0, 90, 360, 16, TFT_DARKCYAN);
                tft7.setCursor(0, 90);
                index--;
                int gh = 0;
                for (int i = index; i < total; i++)
                {
                    tft7.println(String(i + 1) + "- " + String(filesSorted.at(i).name()).substring(String(filesSorted.at(i).name()).lastIndexOf("/") + 1, String(filesSorted.at(i).name()).length()));
                    if (gh++ == 13)
                        break;
                }
                Serial.printf("total %d - index %d\n", total, index);
            }

            if (j == 'E')
            {
                LerFiles(filesSorted.at(index), titulo);
            }
            if (j == 'e')
            {
                tft7.setTextColor(TFT_YELLOW);
                tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft7.setCursor(10, 300);
                tft7.println("ESC -> Aguarde...");
                ESP.restart();
            }
        }
    }

    void LerFiles(File vf, String titulo)
    {

        tft7.fillScreen(TFT_BLACK);
        tft7.setTextSize(2);
        tft7.setTextColor(TFT_YELLOW);
        tft7.setCursor(30, 30);
        tft7.println(titulo);

        tft7.setCursor(30, 60);

        Serial.println(vf.name());
        Serial.println(vf.size());
        Serial.println(vf.getLastWrite());
        Serial.println(vf.getTimeout());
        Serial.println(vf.isDirectory());
        Serial.println(vf.available());

        String s = vf.readString();
        vf.close();
        Produto *p = new Produto();
        int c = 1;

        char ff[s.length()];
        for (auto i = 0; i < s.length(); i++)
        {
            ff[i] = s[i];
        }

        vector<string> linhas{explode(ff, '\n')};

        vector<string> d3;
        for (auto n : linhas)
        {
            vector<string> dados2{explode(n, '\n')};
            d3.emplace_back(dados2[0].data());
        }

        //obtendo linha
        std::string sg = ff;
        size_t l = sg.find_last_not_of('\n');
        sg.resize(l);

        size_t pos = 0;
        std::string token, token2;
        while ((pos = sg.find('\n')) != std::string::npos)
        {
            token = sg.substr(0, pos);
            token.push_back('\t');
            size_t pos2 = 0;

            while ((pos2 = token.find('\t')) != std::string::npos)
            {

                token2 = token.substr(0, pos2);
                switch (c)
                {
                case 1:
                    p->seq = atoi(token2.c_str());
                    break;
                case 2:
                    p->data = token2.c_str();
                    break;
                case 3:
                    p->id = token2.c_str();
                    break;
                case 4:
                    p->codigo = token2.c_str();
                    break;
                case 5:
                    p->descricao = token2.c_str();
                    break;
                case 6:
                    p->und = token2.c_str();
                    break;
                case 7:
                    p->qtd = atof(token2.data());
                    break;
                case 8:
                    p->prateleira = token2.c_str();
                    break;
                case 9:
                    p->convsor = atof(token2.data());
                    break;
                case 10:
                    p->convert = atof(token2.data());
                    break;
                }
                token2.clear();
                token.erase(0, pos2 + 1);
                c++;
            }
            c = 1;
            vp.push_back(p);
            p = new Produto();
            sg.erase(0, pos + 1);
        }

        Teclado *tcl = new Teclado();
        char j = ' ';
        tft7.fillRect(0, 100, 480, 320, TFT_OLIVE);

        tft7.setCursor(0, 100);
        linha = vp.size();
        index = next(vp, linha);

        while (j != 'e')
        {
            j = tcl->tecla();
            if ((j == 'U') & (linha > 1))
            {
                linha--;
                index = next(vp, linha);
                j = ' ';
            }
            if ((j == 'D') & (linha <= vp.size() - 1))
            {
                linha++;
                index = next(vp, linha);
                j = ' ';
            }

            if (j == '1')
            {
                AntiRepet();
                opcaoA('1');
                j = ' ';
                bool b = true;
                while (b)
                {
                    j = tcl->tecla();
                    AntiRepet();
                    switch (j)
                    {
                    case '1':
                        b = false;
                        opcaoB('1', 'Q');
                        break;
                    case '2':
                        b = false;
                        opcaoB('2', 'Q');
                        break;
                    case '3':
                        b = false;
                        opcaoB('3', 'Q');
                        break;
                    case 'e':
                        tft7.setTextColor(TFT_YELLOW);
                        tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                        tft7.setCursor(10, 300);
                        tft7.println("ESC -> Aguarde...");
                        ESP.restart();
                    }
                }
                changeQTD(j);
            }
        }
        tft7.setTextColor(TFT_YELLOW);
        tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
        tft7.setCursor(10, 300);
        tft7.println("ESC -> Aguarde...");
        ESP.restart();
    }

    void LerCard(String li)
    {
        tft7.fillScreen(TFT_BLACK);
        tft7.setTextSize(2);
        tft7.setTextColor(TFT_YELLOW);
        tft7.setCursor(30, 30);
        tft7.println(li);

        Cartao *c = new Cartao();
        byte buzer = 27;
        pinMode(buzer, OUTPUT); //  9
        do
        {
            digitalWrite(buzer, HIGH);
            delay(100);
            digitalWrite(buzer, LOW);
            Serial.println(F("aguardando card..."));
            delay(1000);
            tc.update();

        } while (!c->ObterBufferCartao(tc));

        digitalWrite(buzer, HIGH);
        delay(50);
        digitalWrite(buzer, LOW);
        delay(50);
        digitalWrite(buzer, HIGH);
        delay(50);
        digitalWrite(buzer, LOW);

        Serial.println("Variaveis Carregadas...");

        vp.clear();
        vp = c->vp;

        Serial.println(vp[4]->qtd);
        Serial.println(vp[4]->convsor);
        Serial.println(vp[4]->convert);

        tcl = new Teclado();
        char j = '\0';
        tft7.setCursor(30, 60);
        tft7.println("CARTAO LIDO");
        index = next(c->vp, 1);

        grupo = 1;
        AntiRepet();
        while (j != 'e')
        {
        F:

            j = tcl->tecla();
            Serial.println("Pres: " + String(j));
            delay(100);
            if ((j == 'U') & (grupo < 5))
            {
                grupo++;
                index = next(c->vp, grupo);
                j = '\0';
            }
            if ((j == 'D') & (grupo > 1))
            {
                grupo--;
                index = next(c->vp, grupo);
                j = '\0';
            }

            if (j == 'e')
            {
                tft7.setTextColor(TFT_YELLOW);
                tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft7.setCursor(10, 300);
                tft7.println("ESC -> Aguarde...");
                ESP.restart();
            }

            //j = '4'; //automatico** vertical

            if (j == ' ')
            {
                continue;
            }

            char j2 = ' ';

            if (j == '1' | j == '2' | j == '3' | j == '4')
            {
                j2 = j;
                tft7.fillRect(10, 300, 12, 16, TFT_RED);
                tft7.setCursor(10, 300);
                tft7.println(j);

                AntiRepet();
                while (true)
                {
                    j = ' ';
                    j = tcl->tecla();
                    //j = 'E'; //automatico**
                    if (j == 'E')
                    {
                        break;
                    }
                    if (j == '<')
                    {
                        tft7.fillRect(10, 300, 12, 16, TFT_RED);
                        AntiRepet();
                        j = '\0';
                        goto F;
                    }
                }
            }

            if (j2 == '1')
            {
                AntiRepet();
                opcaoA('1');
                j = ' ';
                bool b = true;
                while (b)
                {
                G:
                    j = tcl->tecla();

                    char j3 = '\0';
                    if (j == '1' | j == '2' | j == '3') // opcao B horizontal
                    {
                        j3 = j;
                        tft7.setTextColor(TFT_YELLOW);
                        tft7.fillRect(30, 300, 12, 16, TFT_RED);
                        tft7.setCursor(30, 300);
                        tft7.println(j);
                        AntiRepet();
                        while (true)
                        {
                            j = tcl->tecla();
                            if (j == 'E')
                            {
                                break;
                            }
                            if (j == '<')
                            {
                                tft7.fillRect(30, 300, 12, 16, TFT_RED);
                                j = '\0';
                                goto G;
                            }
                        }
                    }
                    else
                        continue;

                    switch (j3)
                    {
                    case '1':
                        b = false;
                        opcaoB('1', 'Q');
                        j = '1';
                        break;
                    case '2':
                        b = false;
                        opcaoB('2', 'Q');
                        j = '2';
                        break;
                    case '3':
                        b = false;
                        opcaoB('3', 'Q');
                        j = '3';
                        break;
                    case 'e':
                        tft7.setTextColor(TFT_YELLOW);
                        tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                        tft7.setCursor(10, 300);
                        tft7.println("ESC -> Aguarde...");
                        ESP.restart();
                    }
                }
                Serial.println("Entra changeQTD");
                changeQTD(j);
                grupo = 1;
                index = 0;
            }
            if (j2 == '2')
            {
                AntiRepet();
                opcaoA('2');
                changePateleira();
                grupo = 1;
                index = 0;
            }
            if (j2 == '3')
            {
                AntiRepet();
                opcaoA('3');
                changeConversor();
                grupo = 1;
                index = 0;
            }
            if (j2 == '4')
            {
                AntiRepet();
                opcaoA('4');
                j = ' ';
                bool b = true;
                while (b)
                {
                D:
                    j = tcl->tecla();
                    //j = '3'; // automatico**
                    char j3 = '\0';
                    if (j == '1' | j == '2' | j == '3') // opcao B horizontal
                    {
                        j3 = j;
                        tft7.setTextColor(TFT_YELLOW);
                        tft7.fillRect(30, 300, 12, 16, TFT_RED);
                        tft7.setCursor(30, 300);
                        tft7.println(j);
                        AntiRepet();
                        while (true)
                        {
                            j = tcl->tecla();
                            //j = 'E'; // automatico**
                            if (j == 'E')
                            {
                                break;
                            }
                            if (j == '<')
                            {
                                tft7.fillRect(30, 300, 12, 16, TFT_RED);
                                j = '\0';
                                goto D;
                            }
                        }
                    }
                    else
                        continue;

                    switch (j3)
                    {
                    case '1':
                        b = false;
                        opcaoB('1', 'C');
                        j = '1';
                        break;
                    case '2':
                        b = false;
                        opcaoB('2', 'C');
                        j = '2';
                        break;
                    case '3':
                        b = false;
                        opcaoB('3', 'C');
                        j = '3';
                        break;
                    case 'e':
                        tft7.setTextColor(TFT_YELLOW);
                        tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                        tft7.setCursor(10, 300);
                        tft7.println("ESC -> Aguarde...");
                        ESP.restart();
                    }
                }
                Serial.println("Entra changeConvertido");
                changeConvertido(j);
                grupo = 1;
                index = 0;
            }
            j = ' ';
        }
    }

    void changeConvertido(char y)
    {
        char j = ' ';
        Teclado *tcl2 = new Teclado();
        delay(1000);
        string m;
        double convertido = 0.000;
        Cartao *c = new Cartao();
        AntiRepet();
        while (true)
        {
            j = tcl2->tecla();

            if (j == 'E') //enter
            {
                AntiRepet();

                switch (y)
                {
                case '1':
                    convertido = vp[index]->convert + atof(m.data());
                    Serial.printf("\n%f %f %f %i\n", convertido, vp[index]->convsor, atof(m.data()), grupo);
                    c->gravarConvertido(convertido, grupo, vp);
                    tft7.setCursor(250, 60);
                    tft7.print("Convertido OK");
                    delay(2000);
                    LerCard("DO CARTAO SELECIONADO");
                    break;
                case '2':
                    Serial.println(vp[index]->convert);
                    Serial.println(atof(m.data()));
                    if (vp[index]->convert >= atof(m.data()))
                    {
                        convertido = vp[index]->convert - atof(m.data());
                        Serial.printf("\n%f %f %f %i\n", convertido, vp[index]->convsor, atof(m.data()), grupo);
                        c->gravarConvertido(convertido, grupo, vp);
                        tft7.setCursor(250, 60);
                        tft7.print("Convertido OK");
                        delay(2000);
                        LerCard("DO CARTAO SELECIONADO");
                    }
                    else
                    {
                        convertido = 0;
                        tft7.fillRect(0, 264, 142, 16, TFT_RED);
                        tft7.setCursor(0, 264);
                        tft7.println("ERRO:qtd<sub");
                    }
                    break;
                case '3':
                    convertido = atof(m.data());
                    Serial.printf("%f %f", convertido, atof(m.data()));
                    c->gravarConvertido(convertido, grupo, vp);
                    tft7.setCursor(250, 60);
                    tft7.print("Convertido OK");
                    delay(2000);
                    LerCard("DO CARTAO SELECIONADO");
                    break;
                }
                grupo = 1;
                index = 0;
            }
            if (j == 'e') //esc
            {
                return;
            }

            if (m.length() <= 7)
            {
                if (j == '*')
                {
                    tft7.print(',');
                    m += '.';
                }
                if (j == '0' || j == '1' || j == '2' || j == '3' || j == '4' || j == '5' || j == '6' || j == '7' || j == '8' || j == '9')
                {
                    tft7.print(j);
                    m += j;
                }
            }
            if (j == '<')
            {
                m.pop_back();
                auto x = tft7.getCursorX();
                Serial.println(x);
                if (x > 50)
                {
                    tft7.fillRect(x - 12, 300, 158 - x, 16, TFT_RED);
                    tft7.setCursor(x - 12, 300);
                }
                x = tft7.getCursorX();
                if (x <= 50)
                {
                    tft7.setCursor(50, 300);
                    x = 50;
                    m.clear();
                }
                Serial.println(x);
            }
            j = ' ';
            delay(300);
        }
    }

    void changeQTD(char y)
    {
        Serial.println(y);
        char j = ' ';
        Teclado *tcl2 = new Teclado();
        delay(1000);
        string m;
        double qtd = 0.000;
        Cartao *c = new Cartao();
        while (true)
        {
            j = tcl2->tecla();

            if (j == 'E' & m.length() > 0) //enter
            {
                switch (y)
                {
                case '1':
                    qtd = vp[index]->qtd + atof(m.data());
                    Serial.printf("\n%f %f %f %i\n", qtd, vp[index]->qtd, atof(m.data()), grupo);
                    c->gravarQuantidade(qtd, grupo, vp);
                    tft7.setCursor(250, 60);
                    tft7.print("QTD Adicionada");
                    delay(2000);
                    LerCard("DO CARTAO SELECIONADO");
                    break;
                case '2':
                    Serial.println(vp[index]->qtd);
                    Serial.println(atof(m.data()));
                    if (vp[index]->qtd >= atof(m.data()))
                    {
                        qtd = vp[index]->qtd - atof(m.data());
                        Serial.printf("\n%f %f %f %i\n", qtd, vp[index]->qtd, atof(m.data()), grupo);
                        c->gravarQuantidade(qtd, grupo, vp);
                        tft7.setCursor(250, 60);
                        tft7.print("QTD Subtraida");
                        delay(2000);
                        LerCard("DO CARTAO SELECIONADO");
                    }
                    else
                    {
                        qtd = 0;
                        tft7.fillRect(50, 300, 96, 16, TFT_RED);
                        tft7.setCursor(50, 300);
                        tft7.println("ERRO q<s");
                    }
                    break;
                case '3':
                    qtd = atof(m.data());
                    Serial.printf("\n%f %f %f %i\n", qtd, vp[index]->qtd, atof(m.data()), grupo);
                    c->gravarQuantidade(qtd, grupo, vp);
                    tft7.setCursor(250, 60);
                    tft7.print("QTD Atualizada");
                    delay(2000);
                    LerCard("DO CARTAO SELECIONADO");
                    break;
                }
                grupo = 1;
                index = 0;
            }
            if (j == 'e') //esc
            {
                tft7.setTextColor(TFT_YELLOW);
                tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft7.setCursor(10, 300);
                tft7.println("ESC -> Aguarde...");
                ESP.restart();
            }

            if (m.length() <= 7)
            {
                if (j == '*')
                {
                    tft7.print(',');
                    m += '.';
                }
                if (j == '0' || j == '1' || j == '2' || j == '3' || j == '4' || j == '5' || j == '6' || j == '7' || j == '8' || j == '9')
                {
                    tft7.print(j);
                    m += j;
                }
            }
            if (j == '<')
            {
                m.pop_back();
                auto x = tft7.getCursorX();
                Serial.println(x);
                if (x > 50)
                {
                    tft7.fillRect(x - 12, 300, 158 - x, 16, TFT_RED);
                    tft7.setCursor(x - 12, 300);
                }
                x = tft7.getCursorX();
                if (x <= 50)
                {
                    tft7.setCursor(50, 300);
                    x = 50;
                    m.clear();
                }
                Serial.println(x);
            }
            j = ' ';
            delay(300);
        }
        Serial.println("saiu change");
    }

    void changeConversor()
    {
        tft7.fillRect(50, 300, 96, 16, TFT_RED);
        tft7.setTextColor(TFT_YELLOW);
        char j = ' ';
        Teclado *tcl3 = new Teclado();
        tft7.setCursor(50, 300);
        Cartao *c = new Cartao();
        string m;
        double conversor = 0.000;

        AntiRepet();
        while (true)
        {
            j = tcl3->tecla();
            if (j == 'E' & m.length() > 0)
            {
                conversor = atof(m.data());
                c->gravaConversor(grupo, conversor, vp);
                tft7.setCursor(250, 60);
                tft7.print("Conversor OK");
                delay(2000);
                LerCard("DO CARTAO SELECIONADO");
            }
            if (m.length() <= 7)
            {
                if (j == '*')
                {
                    tft7.print(',');
                    m += '.';
                    delay(500);
                }
                if (j == '0' || j == '1' || j == '2' || j == '3' || j == '4' || j == '5' || j == '6' || j == '7' || j == '8' || j == '9')
                {
                    tft7.print(j);
                    m += j;
                    j = ' ';
                    delay(500);
                }
            }
            if (j == '<')
            {
                m.pop_back();
                auto x = tft7.getCursorX();
                Serial.println(x);
                if (x > 50)
                {
                    tft7.fillRect(x - 12, 300, 158 - x, 16, TFT_RED);
                    tft7.setCursor(x - 12, 300);
                }
                x = tft7.getCursorX();
                if (x <= 50)
                {
                    tft7.setCursor(50, 300);
                    x = 50;
                    m.clear();
                }
                Serial.println(x);
            }
            if (j == 'e')
            {
                tft7.setTextColor(TFT_YELLOW);
                tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft7.setCursor(10, 300);
                tft7.println("ESC -> Aguarde...");
                ESP.restart();
            }
            delay(200);
        }
    }

    void changePateleira()
    {
        tft7.fillRect(50, 300, 142, 16, TFT_RED);
        tft7.setTextColor(TFT_YELLOW);
        char j = ' ';
        Teclado *tcl3 = new Teclado();
        Prateleira *p = new Prateleira();
        int q = p->p.size(), i = 0;
        sort(p->p.begin(), p->p.end());
        tft7.setCursor(50, 300);
        tft7.print(p->p[0]);
        string m = p->p[0].c_str();
        Cartao *c = new Cartao();

        AntiRepet();
        while (true)
        {
            j = tcl3->tecla();
            if (j == 'E' & m != "A-")
            {

                c->gravaPrateleira(m.data(), vp);
                tft7.setCursor(250, 60);
                tft7.print("Prateleira OK");
                delay(2000);
                LerCard("DO CARTAO SELECIONADO");
            }
            if (((j == 'U') | (j == '>')) & (i < q - 1))
            {

                tft7.fillRect(50, 300, 142, 16, TFT_RED);
                tft7.setCursor(50, 300);
                tft7.print(p->p[++i]);
                m = p->p[i].c_str();
                j = ' ';
            }
            if (((j == 'D') | (j == '<')) & (i > 0))
            {
                tft7.fillRect(50, 300, 142, 16, TFT_RED);
                tft7.setCursor(50, 300);
                tft7.print(p->p[--i]);
                m = p->p[i].c_str();
                j = ' ';
            }
            if (j == '0' || j == '1' || j == '2' || j == '3' || j == '4' || j == '5' || j == '6' || j == '7' || j == '8' || j == '9')
            {
                tft7.print(j);
                m += j;
                j = ' ';
                delay(500);
            }
            if (j == '<')
            {
                m.pop_back();
                auto x = tft7.getCursorX();
                Serial.println(x);
                if (x > 50)
                {
                    tft7.fillRect(x - 12, 300, 158 - x, 16, TFT_RED);
                    tft7.setCursor(x - 12, 300);
                }
                x = tft7.getCursorX();
                if (x <= 50)
                {
                    tft7.setCursor(50, 300);
                    x = 50;
                    m.clear();
                }
                Serial.println(x);
            }
            if (j == 'e')
            {
                tft7.setTextColor(TFT_YELLOW);
                tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft7.setCursor(10, 300);
                tft7.println("ESC -> Aguarde...");
                ESP.restart();
            }
            j = ' ';
            delay(200);
        }
    }

    vector<string> explode(const string &s, const char &c)
    {
        string buff{""};
        vector<string> v;

        for (auto n : s)
        {
            if (n != c)
                buff += n;
            else if (n == c && buff != "")
            {
                v.push_back(buff);
                buff.clear();
            }
        }
        if (buff != "")
            v.push_back(buff);
        v.pop_back();
        return v;
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

        Serial.println("*******---------**********");
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
            Serial.println(uid.c_str());
        }
        Serial.println("*******---------**********");

        return uids;
    }

    int next(vector<Produto *> vp, int g)
    {

        --g;

        if (vp[g]->codigo.length() == 1)
        {
            tft7.fillRect(0, 100, 480, 320, TFT_OLIVE);
            tft7.setCursor(432, 100);
            tft7.print(g + 1);
            delay(300);
            return g;
        }

        tft7.fillRect(0, 100, 480, 320, TFT_OLIVE);
        tft7.setCursor(432, 100);
        tft7.print(g + 1);

        tft7.setCursor(0, 100);
        tft7.println(vp[g]->seq);
        tft7.println(vp[g]->data);
        tft7.println(vp[g]->id);
        tft7.println(vp[g]->codigo);
        tft7.println(vp[g]->descricao);
        tft7.setCursor(0, 200);
        tft7.println(vp[g]->und);
        tft7.print("QTD ");
        tft7.println(vp[g]->qtd, 3);
        tft7.println(vp[g]->prateleira);
        tft7.print("L17 ");
        tft7.println(vp[g]->convsor, 5);
        tft7.print("Con ");
        tft7.println(vp[g]->convert, 3);
        tft7.setCursor(150, 216);
        tft7.print("1   1=(+)   2=(-)   3=(Alt)");
        tft7.setCursor(150, 232);
        tft7.print("2                   3=(Alt)");
        tft7.setCursor(150, 248);
        tft7.print("3                   3=(Alt)");
        tft7.setCursor(150, 264);
        tft7.print("4   1=(+)   2=(-)   3=(Alt)");
        delay(300);
        return g;
    }

    void opcaoA(char j)
    {
        //AntiRepet();
        tft7.setTextColor(TFT_RED);
        if (j == '1')
        {
            tft7.setCursor(150, 216);
            tft7.print('1');
        }
        if (j == '2')
        {
            tft7.setCursor(150, 232);
            tft7.print("2                   3=(Alt)");
        }
        if (j == '3')
        {
            tft7.setCursor(150, 248);
            tft7.print("3                   3=(Alt)");
        }
        if (j == '4')
        {
            tft7.setCursor(150, 264);
            tft7.print('4');
        }
    }

    void opcaoB(char y, char x)
    {
        tft7.setTextColor(TFT_RED);
        AntiRepet();
        if (x == 'Q') // quantidade
        {
            switch (y)
            {
            case '1':
                tft7.setCursor(198, 216);
                tft7.print("1=(+)");
                break;
            case '2':
                tft7.setCursor(294, 216);
                tft7.print("2=(-)");
                break;
            case '3':
                tft7.setCursor(390, 216);
                tft7.print("3=(Alt)");
                break;
            }
        }
        if (x == 'C') // conversor
        {
            switch (y)
            {
            case '1':
                tft7.setCursor(198, 264);
                tft7.print("1=(+)");
                break;
            case '2':
                tft7.setCursor(294, 264);
                tft7.print("2=(-)");
                break;
            case '3':
                tft7.setCursor(390, 264);
                tft7.print("3=(Alt)");
                break;
            }
        }
        tft7.fillRect(50, 300, 96, 16, TFT_RED);
        tft7.setCursor(50, 300);
        tft7.setTextColor(TFT_YELLOW);
    }

    void ExcluiItens(String li)
    {
    F:
        tft7.fillScreen(TFT_BLACK);
        tft7.setTextSize(2);
        tft7.setTextColor(TFT_YELLOW);
        tft7.setCursor(30, 30);
        tft7.println(li);

        Cartao *c = new Cartao();
        byte buzer = 27;
        pinMode(buzer, OUTPUT); //  9
        do
        {
            digitalWrite(buzer, HIGH);
            delay(100);
            digitalWrite(buzer, LOW);
            Serial.println(F("aguardando card..."));
            delay(1000);
            tc.update();

        } while (!c->ObterBufferCartao(tc));

        digitalWrite(buzer, HIGH);
        delay(50);
        digitalWrite(buzer, LOW);
        delay(50);
        digitalWrite(buzer, HIGH);
        delay(50);
        digitalWrite(buzer, LOW);

        Serial.println("Variaveis Carregadas...");

        vp = c->vp;

        tcl = new Teclado();
        char j = ' ';
        tft7.setCursor(30, 60);
        tft7.println("CARTAO LIDO");
        index = next(c->vp, 1);

        while (j != 'e')
        {
            j = tcl->tecla();
            if ((j == 'U') & (grupo < 5))
            {
                grupo++;
                index = next(c->vp, grupo);
                j = ' ';
            }
            if ((j == 'D') & (grupo > 1))
            {
                grupo--;
                index = next(c->vp, grupo);
                j = ' ';
            }

            if (j == 'E')
            {
                c->ExcluiItens(grupo);
                goto F;
            }
        }
        if (j == 'e')
        {
            tft7.setTextColor(TFT_YELLOW);
            tft7.fillRect(10, 300, 470, 18, TFT_BLUE);
            tft7.setCursor(10, 300);
            tft7.println("ESC -> Aguarde...");
            ESP.restart();
        }
    }

    void AntiRepet()
    {
        char J = '\0';
        while ((J = tcl->tecla()) != ' ')
        {
            //Serial.printf("Pressionado %c ... \n", J);
        }
        //Serial.printf("Soltei %c ... \n", J);
    }
};
#endif
