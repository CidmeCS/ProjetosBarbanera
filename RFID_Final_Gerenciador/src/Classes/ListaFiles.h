#ifndef LISTAFILES_H_INCLUDED
#define LISTAFILES_H_INCLUDED

#include "FS.h"
#include "SPIFFS.h"
#include <NTPClient.h>
#include <iostream>  // std::cout
#include <algorithm> // std::sort
#include <vector>    // std::vector
using namespace std;

class ListaFiles
{
public:
    ListaFiles()
    {
    }

    static vector<String> ListaTudo()
    {
        std::vector<String> fls;
        File root = SPIFFS.open("/");
        File files = root.openNextFile();
        while (files)
        {
            String file = String(files.name());
            fls.push_back(file);
            files = root.openNextFile();
        }
        std::sort(fls.begin(), fls.end());
        std::reverse(fls.begin(), fls.end());
        return fls;
    }

    static void MantemDezUltimos()
    {
        std::vector<String> files = ListaFiles::ListaTudo();
        for(String d : files)
        {
            Serial.print("z -- ");
            Serial.println(d);
        }
        
       
        //SendItem
        std::vector<String> AtuaCard;
        std::vector<String> CriaCard;
        std::vector<String> Leitura;
        std::vector<String> UIDs;
        std::vector<String> SendItem;

        for (String fl : files)
        {
            
            string f = fl.c_str();
            if (f.find("AtuaCard") != std::string::npos)
            {
                AtuaCard.push_back(fl);
                continue;
            }

            if (f.find("CriaCard") != std::string::npos)
            {
                CriaCard.push_back(fl);
                continue;
            }

            if (f.find("Leitura") != std::string::npos)
            {
                Leitura.push_back(fl);
                continue;
            }
            if (f.find("UIDs") != std::string::npos)
            {
                UIDs.push_back(fl);
                continue;
            }
            if (f.find("SendItem") != std::string::npos)
            {
                SendItem.push_back(fl);
                continue;
            }
        }

        reverse(AtuaCard.begin(), AtuaCard.end());
        reverse(CriaCard.begin(), CriaCard.end());
        reverse(Leitura.begin(), Leitura.end());
        reverse(UIDs.begin(), UIDs.end());
        reverse(SendItem.begin(), SendItem.end());

        int a = 1;
        for (String ac : AtuaCard)
        {
            if (a > 10)
            {
                SPIFFS.remove(ac);
            }
            a++;
        }
        int c = 1;
        for (String cc : CriaCard)
        {
            if (c > 10)
            {
                SPIFFS.remove(cc);
            }
            c++;
        }
        int l = 1;
        for (String lt : Leitura)
        {
            if (l > 10)
            {
                SPIFFS.remove(lt);
            }
            l++;
        }
        int u = 1;
        for (String ud : UIDs)
        {
            if (u > 10)
            {
                SPIFFS.remove(ud);
            }
            u++;
        }
        int t = 1;
        for (String ud : SendItem)
        {
            if (t > 10)
            {
                SPIFFS.remove(ud);
            }
            t++;
        }
    }

    void TesteCriarFiles(NTPClient tc)
    {
        for (size_t i = 1; i <= 12; i++)
        {
            String data = GetDataHora(tc);
            SPIFFS.open("/AtuaCard_" + data + ".txt", FILE_WRITE);
            SPIFFS.open("/CriaCard_" + data + ".txt", FILE_WRITE);
            SPIFFS.open("/Leitura_" + data + ".txt", FILE_WRITE);
            SPIFFS.open("/UIDs_" + data + ".txt", FILE_WRITE);
            SPIFFS.open("/SendItem_" + data + ".txt", FILE_WRITE);
            delay(1000);
        }
    }

    static String GetUltimoAtualCard()
    {
        std::vector<String> files = ListaFiles::ListaTudo();
        std::vector<String> AtuaCard;
        for (String fl : files)
        {
            string f = fl.c_str();
            if (f.find("AtuaCard") != std::string::npos)
            {
                AtuaCard.push_back(fl);
                continue;
            }
        }
        reverse(AtuaCard.begin(), AtuaCard.end());
        return AtuaCard.front();
    }

    static vector<String> GetAtualCard()
    {
        std::vector<String> files = ListaFiles::ListaTudo();
        std::vector<String> AtuaCard;
        for (String fl : files)
        {
            string f = fl.c_str();
            if (f.find("AtuaCard") != std::string::npos)
            {
                AtuaCard.push_back(fl);
                continue;
            }
            reverse(AtuaCard.begin(), AtuaCard.end());
        }
        return AtuaCard;
    }

    String GetDataHora(NTPClient tc)
    {
        tc.update();
        String fd = tc.getFormattedDate();
        fd.replace('T', ' ');
        fd.replace('Z', ' ');
        fd.replace(":", "");
        fd.trim();
        return fd;
    }
};
#endif