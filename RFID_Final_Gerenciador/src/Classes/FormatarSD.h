#ifndef FORMATASD_H
#define FORMATASD_H
#include <Arduino.h>
#include <Classes/Teclado.h>
#include <SPIFFS.h>
#include <SPI.h>
#include <TFT_eSPI.h>
TFT_eSPI tft4 = TFT_eSPI();
using namespace std;

class FormatarSD
{
public:
    FormatarSD()
    {
    }
    File root;
    const char *f = "/";
    int fileOK = 0, fileERRO = 0, dirERRO = 0, dirOK = 0;

    void Formatar()
    {
        SPI.begin();

        tft4.init();
        tft4.setRotation(1);
        tft4.fillScreen(TFT_BLUE);
        tft4.setTextSize(2);
        tft4.setTextColor(TFT_YELLOW);
        tft4.setCursor(90, 30);

        root = SPIFFS.open("/");
        ObterFiles();

        tft4.setCursor(90, 60);
        tft4.print("Files OK  : " + String(fileOK));
        tft4.setCursor(90, 80);
        tft4.print("DIR OK    : " + String(dirOK));

        tft4.setCursor(90, 120);
        tft4.print("Files ERRO: " + String(fileERRO));
        tft4.setCursor(90, 140);
        tft4.print("DIR ERRO  : " + String(dirERRO));
        tft4.setCursor(90, 200);
        tft4.print("PRESSIONE 'ESC' PARA SAIR");

        Teclado *tcl = new Teclado();
        char j = ' ';

        while (j != 'e')
        {
            j = tcl->tecla();
        }
        tft4.setCursor(10, 300);
        tft4.print("REINICIANDO... AGUARDE...");
        ESP.restart();
    }

    void Remover(String filename, File file)
    { // Delete the file

        File dataFile = SPIFFS.open(filename, FILE_READ); // Now read data from SD Card
        if (dataFile)
        {
            if (!file.isDirectory())
            {

                if (SPIFFS.remove(filename))
                {
                    fileOK++;
                    Serial.println(F("File deleted successfully"));
                }
                else
                {
                    fileERRO++;
                    Serial.println(F("Falha em deletar..."));
                }
            }
            else if (file.isDirectory())
            {
                if (SPIFFS.rmdir(filename))
                {
                    dirOK++;
                    Serial.println(F("File deleted successfully"));
                }
                else
                {
                    dirERRO++;
                    Serial.println(F("Falha em deletar..."));
                }
            }
        }
    }
    
    void ObterFiles()
    {

        File root = SPIFFS.open("/");
        File file = root.openNextFile();
        vector<String> vs;
        while (file)
        {

            Serial.println(file.name());
            
            Remover(file.name(), file);
           

            file = root.openNextFile();
        }
        file.close();
    }
};
#endif
