#ifndef OBTERTXT_H
#define OBTERTXT_H

#include "Classes/Teclado.h"
#include "Classes/Produto.h"
#include "Classes/stringhelper.h"
#include <Arduino.h>
#include <Classes/WiFiConnect.h>
#include <FS.h>
#include <WString.h>
#include <SPI.h>
#include <TFT_eSPI.h>

#include <ESPmDNS.h>
#include <ESP32WebServer.h>
#include <WiFi.h>
#include <WiFiClient.h>

#include <Classes/ManutencaoSpeed.h>
#include <SPIFFS.h>
#include <NTPClient.h>

WiFiUDP ntpUDP2;
NTPClient tc2(ntpUDP2);

TFT_eSPI tft5 = TFT_eSPI();
ESP32WebServer server2(80);
using namespace std;

byte pinAzul = 32;
byte pinVermelho = 25;
byte pinVerde = 33;
byte buzer = 27;
String mss = "";

String reqsc = "";

class ObterTXTs
{
public:
    ObterTXTs()
    {
        byte SS_SLAVE_RFID_INT = 17;
        byte SS_SLAVE_RFID_EXT = 26;

        pinMode(SS_SLAVE_RFID_INT, OUTPUT);
        pinMode(SS_SLAVE_RFID_EXT, OUTPUT);

        digitalWrite(SS_SLAVE_RFID_EXT, HIGH); // Desabilita o SS.
        digitalWrite(SS_SLAVE_RFID_INT, HIGH); // Desabilita o SS.

        pinMode(pinAzul, OUTPUT);
        pinMode(buzer, OUTPUT);
        pinMode(pinVermelho, OUTPUT);
        pinMode(pinVerde, OUTPUT);
    }

    bool opened = false;
    const char *host = "rfid";

    void Obter(NTPClient tc)
    {
        tc2 = tc;
        SPI.begin();

        tft5.init();
        tft5.setRotation(1);
        tft5.fillScreen(TFT_OLIVE);
        tft5.setTextSize(2);
        tft5.setTextColor(TFT_YELLOW);
        tft5.setCursor(90, 40);
        tft5.print("MODO WEB SERVER");

        tft5.setCursor(90, 300);
        tft5.print("PRESS 'ESC' PARA SAIR");

        // WEBSERVER INICIO
        WebServerW(tc);
        // WEBSERVER FIM
    }

    void WebServerW(NTPClient tc)
    {

        ManutencaoSpeed *ms = new ManutencaoSpeed();
        WiFiConnect *wc = new WiFiConnect();
        WiFi = wc->con(wc->OBTERTXTS, tft5);

        tft5.setCursor(90, 180);
        tft5.print("Conectado a ");
        tft5.print(wc->ssid2);

        tft5.setCursor(90, 200);
        tft5.print("IP address: ");
        tft5.print(WiFi.localIP());

        if (MDNS.begin(host))
        {
            MDNS.addService("http", "tcp", 80);
            Serial.println("You can now connect to http://" + String(host) + ".local");
            tft5.setCursor(90, 220);
            tft5.println("http://" + String(host) + ".local");
        }

        //handle uri
        server2.on("/", listarArquivos);
        server2.on("/dir", listarDiretorios);
        server2.on("/Inventarios", listarPasta);
        server2.on("/Leituras", listarPasta);
        server2.on("/Temp", listarPasta);
        server2.on(
            "/criacard", HTTP_POST, []()
            { server2.send(200); },
            criaCard);
        server2.on(
            "/send1Item", HTTP_POST, []()
            { server2.send(200); },
            send1Item);
        server2.on(
            "/atuacard", HTTP_POST, []()
            { server2.send(200); },
            atuaCard);
        server2.on( //com spiffs nao e possivel criar pasta
            "/criapasta", criaPasta);
        server2.on(
            "/delpasta", delPasta);
        server2.on(
            "/delallfiles", delAllFiles);
        server2.on(
            "/formatspiffs", formatSPIFFS);
        server2.on(
            "/delfile", delFile);

        server2.onNotFound(handleNotFound);

        server2.begin();
        Serial.println("HTTP server2 started");

        Teclado *tclo = new Teclado();
        char jp = ' ';

        while (true)
        {
            //teste
            if (mss == "AC")
            {
                 Serial.println("AC");
                ManutencaoSpeed *ms = new ManutencaoSpeed();
                ms->Start(tc2);
                mss = "";
            }
            if (mss == "CC")
            {
                Serial.println("CC");
                ManutencaoSpeed *ms = new ManutencaoSpeed();
                ms->CriaCards(tc2);
                mss = "";
            }

            server2.handleClient();
            jp = tclo->tecla();
            if (jp == 'e')
            {
                tft5.setTextColor(TFT_YELLOW);
                tft5.fillRect(10, 300, 470, 18, TFT_BLUE);
                tft5.setCursor(10, 300);
                tft5.println("ESC -> Aguarde...");
                //ESP.restart();
                return;
            }
        }
    }

    void static delFile()
    {
        Serial.println("DELFILE");
        String path = server2.arg(0);
        Serial.println("DELFILE2");

        Serial.println(path);
        if (SPIFFS.remove(path))
        {
            Serial.println(path + " DELETADO");
            server2.send(200);
        }
        else
        {
            Serial.println("NÃO DELETADO");
            server2.send(500);
        }
        Serial.println("FINAL 3");
    }

    void static atuaCard()
    {
        static File UploadFilee;
        HTTPUpload &uploadfile = server2.upload();

        if (uploadfile.status == UPLOAD_FILE_START)
        {
            String filename = "/" + uploadfile.filename;

            UploadFilee = SPIFFS.open(filename, FILE_WRITE);
            filename = String();
        }
        else if (uploadfile.status == UPLOAD_FILE_WRITE)
        {

            if (UploadFilee)
                UploadFilee.write(uploadfile.buf, uploadfile.currentSize);
        }
        else if (uploadfile.status == UPLOAD_FILE_END)
        {
            if (UploadFilee)
            {
                UploadFilee.close();
                tft5.setCursor(70, 250);
                tft5.println("UPLOAD ManutSpeed OK!");
                delay(1000);
                mss = "AC";
            }
        }
    }

    void static send1Item()
    {
        Serial.println("1YY");
        static File UploadFile;
        Serial.println("2YY");
        HTTPUpload &uploadfile = server2.upload();
        Serial.println("3YY");
        const String filename = "/SendItem_" + uploadfile.filename.substring(14);

        if (uploadfile.status == UPLOAD_FILE_START)
        {

            Serial.print("Upload File Name: ");
            Serial.println(filename);

            UploadFile = SPIFFS.open(filename, FILE_WRITE);
            Serial.println("4YY");
            //filename = String();
            Serial.println("1XX");
        }
        else if (uploadfile.status == UPLOAD_FILE_WRITE)
        {
            Serial.println("2XX");

            if (UploadFile)
                UploadFile.write(uploadfile.buf, uploadfile.currentSize);

            Serial.println("3XX");
        }
        else if (uploadfile.status == UPLOAD_FILE_END)
        {
            Serial.println("4XX");

            if (UploadFile)
            {
                Serial.println("5XX");

                UploadFile.close();
                Serial.print("Upload Size: ");
                Serial.println(uploadfile.totalSize);

                File file = SPIFFS.open(filename);
                String texto = file.readString();
                texto.trim();
                String p = texto.substring(0, 1);
                int posicao = atoi(p.c_str());
                file.close();
                Cartao *ca = new Cartao("INTERNO");

                tft5.fillRect(0, 300, 480, 20, TFT_BLUE);
                tft5.setCursor(10, 300);
                tft5.print("APROXIME UM CARTAO");

                if (posicao == 6)
                {
                    posicao = ca->PesquisaSeqDisponivel(tc2);
                    if (posicao == 6)
                    {
                        tft5.fillRect(0, 300, 480, 20, TFT_BLUE);
                        tft5.setCursor(10, 300);
                        tft5.print("ERRO >> CARTAO CHEIO");
                        return;
                    }
                }
                Serial.println("posicao " + String(posicao) + ", " + p + ", " + texto);

                ca->p->id = texto.substring(22, 34);
                ca->vp.push_back(ca->p);
                ca->ExcluiItens(posicao);

                tft5.fillRect(0, 300, 480, 20, TFT_BLUE);
                tft5.setCursor(10, 300);
                tft5.print("RETIRE O CARTAO...");
                digitalWrite(pinAzul, HIGH);
                digitalWrite(buzer, HIGH);
                delay(200);
                digitalWrite(buzer, LOW);
                digitalWrite(pinAzul, LOW);
                ca->RetiraReaproxima();

                tft5.fillRect(0, 300, 480, 20, TFT_BLUE);
                tft5.setCursor(10, 300);
                tft5.print("REAPROXIME O CARTAO...");

                ca->CriaCartaoCompleto(uploadfile.buf);
                Serial.println("6XX");
                tft5.fillRect(0, 300, 480, 20, TFT_BLUE);
                tft5.setCursor(10, 300);
                tft5.print("GRAVACAO OK");
                delay(3000);
                digitalWrite(pinAzul, HIGH);
                digitalWrite(buzer, HIGH);
                delay(200);
                digitalWrite(buzer, LOW);
                digitalWrite(pinAzul, LOW);

                //idp.start(tc2);
                tft5.setCursor(10, 300);
                tft5.print("PRONTO PARA CRIAR NOVO CARTAO...");
            }
            else
            {
                Serial.print("nao fez upload ");
            }
        }
    }

    void static criaCard()
    {
        static File UploadFile;
        HTTPUpload &uploadfile = server2.upload();

        if (uploadfile.status == UPLOAD_FILE_START)
        {
            String filename = uploadfile.filename;
            filename = "/" + filename;
            

            Serial.print("Upload File Name: ");
            Serial.println(filename);

            //SPIFFS.open("/");

            UploadFile = SPIFFS.open(filename, FILE_WRITE);
        }
        else if (uploadfile.status == UPLOAD_FILE_WRITE)
        {

            if (UploadFile)
                UploadFile.write(uploadfile.buf, uploadfile.currentSize);
        }
        else if (uploadfile.status == UPLOAD_FILE_END)
        {

            if (UploadFile)
            {

                UploadFile.close();
                tft5.setCursor(70, 250);
                tft5.println("UPLOAD ManutSpeed OK!");
                delay(1000);
                mss = "CC";

                return;

                Cartao *ca = new Cartao("INTERNO");

                //limpa o cartao completo
                ca->ExcluiItens(6);

                tft5.fillRect(0, 300, 480, 20, TFT_BLUE);

                tft5.setCursor(10, 300);
                tft5.print("RETIRE O CARTAO...");
                digitalWrite(pinAzul, HIGH);
                digitalWrite(buzer, HIGH);
                delay(200);
                digitalWrite(buzer, LOW);
                digitalWrite(pinAzul, LOW);
                ca->RetiraReaproxima();

                tft5.fillRect(0, 300, 480, 20, TFT_BLUE);
                tft5.setCursor(10, 300);
                tft5.print("REAPROXIME O CARTAO...");

                ca->CriaCartaoCompleto(uploadfile.buf);
                Serial.println("6XX");
                tft5.fillRect(0, 300, 480, 20, TFT_BLUE);
                tft5.setCursor(10, 300);
                tft5.print("GRAVACAO OK");
                delay(3000);
                digitalWrite(pinAzul, HIGH);
                digitalWrite(buzer, HIGH);
                delay(200);
                digitalWrite(buzer, LOW);
                digitalWrite(pinAzul, LOW);

                //idp.start(tc2);
                tft5.setCursor(10, 300);
                tft5.print("PRONTO PARA CRIAR NOVO CARTAO...");
            }
            else
            {
                Serial.print("nao fez upload ");
            }
        }
    }

    static String criaPasta()
    {
        Serial.println("CriaPasta entrou");
        bool b = false;
        auto args = server2.arg(0);

        SPIFFS.open("/");
        b = SPIFFS.mkdir(args); //com spiffs nao e possivel criar pasta

        if (b)
        {
            Serial.printf("Pasta Criada: %s\n", String(args));
        }
        else
        {
            Serial.printf("ERRO ao Criar Pasta: %s\n", String(args));
        }
        return "";
    }

    static String delPasta()
    {
        Serial.println("DelPasta entrou");
        bool b = false;
        auto args = server2.arg(0);

        File root = SPIFFS.open(args);
        File file = root.openNextFile();
        while (file)
        {
            SPIFFS.remove(file.name());
            file.close();
            file = root.openNextFile();
        }

        if (true)
        {
            SPIFFS.open("/");
            b = SPIFFS.rmdir(args);
        }

        if (b)
        {
            Serial.printf("Pasta deletada: %s\n", String(args));
        }
        else
        {
            Serial.printf("ERRO ao deletar Pasta: %s\n", String(args));
        }
        return "";
    }

    static void delAllFiles()
    {

        File root = SPIFFS.open("/");
        File file = root.openNextFile();
        vector<String> vs;
        while (file)
        {
            vs.push_back(file.name());
            file.close();
            file = root.openNextFile();
        }

        for (auto r : vs)
        {
            SPIFFS.remove(r);
        }
    }

    static void formatSPIFFS()
    {

        bool formatted = SPIFFS.format();

        if (formatted)
        {
            Serial.println("\n\nSuccess formatting");
        }
        else
        {
            Serial.println("\n\nError formatting");
        }
    }

    static String getDiretorios()
    {
        String response = "";

        File root = SPIFFS.open("/");

        File file = root.openNextFile();

        while (file)
        {
            if (!file.isDirectory() /*| String(file.name()) == "/System Volume Information"*/)
            {
                file.close();
                file = root.openNextFile();
                continue;
            }

            Serial.print("Diretório: ");
            Serial.println(file.name());
            response += String("<a href='") + String(file.name()) + String("'>") + String(file.name()) + String("</a>") + String("</br>");
            file.close();
            file = root.openNextFile();
        }
        return String("Lista de diretorios:</br></br>") + response;
    }

    static String getArquivos()
    {
        String response = "";
        File root = SPIFFS.open("/");
        File file = root.openNextFile();
        vector<String> vs;
        while (file)
        {
            if (file.isDirectory() | String(file.name()) == "/System Volume Information")
            {
                file.close();
                file = root.openNextFile();
                continue;
            }
            vs.push_back(file.name());
            file.close();
            file = root.openNextFile();
        }
        sort(vs.begin(), vs.end());

        response += "<table>";
        for (auto dir : vs)
        {
            response += "<tr><td>";
            response += String("<a href='") + String(dir) + String("'>") + String(dir) + String("</a>");
            response += "</td>";
            response += "<td><button onclick=\"myFunction('" + dir + "')\";>Delete</button></td></tr>";
        }
        response += "</table>";

        String script = R"rawliteral(
        <script type="text/javascript">

            function sleep(ms) {
                return new Promise(
                resolve => setTimeout(resolve, ms)
                );
            }

            async function myFunction(dir) 
                {
                    var xhr = new XMLHttpRequest();
                    xhr.open("POST", "http://rfid.local/delfile", true); 
                    xhr.setRequestHeader('Content-Type', 'text/html'); 
                    xhr.send(dir);
                    await sleep(1000);
                    window.location.href = "http://rfid.local"; 
            }

        </script>
        )rawliteral";

        response += script;

        String Home = "<a href='/'>Home</a></br></br>";
        String Deleta = "<a href='/delallfiles'>Deleta Tudo</a></br>";
        String Formata = "<a href='/formatspiffs'>Formata Memorias</a></br></br>";

        return String("Lista de Arquivos:</br></br>") + Home + Deleta + Formata + response;
    }

    static void listarDiretorios()
    {
        String res = getDiretorios();
        server2.send(200, "text/html", res);
    }

    static void listarArquivos()
    {
        String res = getArquivos();
        server2.send(200, "text/html", res);
    }

    static bool loadFromSDCARD(String path)
    {

        String dataType = "text/plain";
        if (path.endsWith("/"))
            path += "index.html";

        path.replace("%20", " ");
        File dataFile = SPIFFS.open(path.c_str());

        if (!dataFile)
            return false;

        if (server2.streamFile(dataFile, dataType) != dataFile.size())
        {
            Serial.println("Sent less data than expected!");
        }

        dataFile.close();
        return true;
    }

    static void handleNotFound()
    {
        Serial.println("Vazio 001");
        if (loadFromSDCARD(server2.uri()))
            return;
        String message = "SDCARD Not Detected\n\n";
        message += "URI: ";
        message += server2.uri();
        message += "\nMethod: ";
        message += (server2.method() == HTTP_GET) ? "GET" : "POST";
        message += "\nArguments: ";
        message += server2.args();
        message += "\n";
        for (uint8_t i = 0; i < server2.args(); i++)
        {
            message += " NAME:" + server2.argName(i) + "\n VALUE:" + server2.arg(i) + "\n";
        }
        server2.send(404, "text/plain", message);
        Serial.println(message);
    }

    static void listarPasta()
    {
        String res = getPasta();
        server2.send(200, "text/html", res);
    }

    static String getPasta()
    {
        String uri = server2.uri();
        Serial.println(uri);
        String response = "";
        File root = SPIFFS.open(uri);
        File file = root.openNextFile();
        vector<String> vs;
        while (file)
        {
            vs.push_back(file.name());
            file.close();
            file = root.openNextFile();
        }
        sort(vs.begin(), vs.end());
        for (auto v : vs)
        {
            response += String("<a href='") + v + String("'>") + v + String("</a>") + String("</br>");
        }

        return String("Lista de Arquivos:</br></br>") + response;
    }
};

#endif
