#ifndef STRINGHELPER_H
#define STRINGHELPER_H

#include <Arduino.h>

class StringHelper
{
public:
    static vector<String> split(string texto, char caracter)
    {
        vector<String> vs;
        String st = "";

        for (auto s : texto)
        {
            st += s;

            if (s == caracter)
            {
                vs.push_back(st);
                st = "";
                continue;
            }
        }
        if (caracter == '\n')
        {
            for (auto i : vs)
            {
                Serial.print(i);
            }
            Serial.print("Split OK ");
        }

        return vs;
    }
    static vector<String> split2(string texto, char caracter)
    {
        vector<String> vs;
        String st = "";
        for (auto s : texto)
        {
            if (s >= 128) // diferentes de: space + , - . ; 0-9 A-Z respectivamente
            {
                Serial.println(".Z. " + String(s) + " " + String(s, 10));
                continue;
            }
            if (s == caracter)
            {
                vs.push_back(st);
                st = "";
                continue;
            }
            st += s;
        }

        vs.push_back(st);
        return vs;
    }
    static vector<String> SplitDados(String texto, char caracter)
    {
        vector<String> vs;
        String st = "";
        for (auto s : texto)
        {
            if (s != 32 & !(s >= 43 & s <= 46) & s != 59 & !(s >= 48 & s <= 57) & !(s >= 65 & s <= 90)) // diferentes de: space + , - . ; 0-9 A-Z respectivamente
            {
                continue;
            }
            if (s == caracter)
            {
                st.trim();
                vs.push_back(st);
                st = "";
                continue;
            }
            st += s;
        }
        st.trim();
        vs.push_back(st);
        return vs;
    }

    static vector<String> SplitLinha(String texto, char caracter)
    {
        vector<String> vs;
        String st = String();

        for (auto s : texto)
        {
            st += s;
            if (s == caracter)
            {
                st.trim();
                vs.push_back(st);
                //Serial.println(st);
                st = "";
                continue;
            }
        }
        st.trim();
        //Serial.println(st);
        vs.push_back(st);
        return vs;
    }
};
#endif