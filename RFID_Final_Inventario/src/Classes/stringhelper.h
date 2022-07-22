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
                //Serial.print(i);
            }
            //Serial.print("Split OK ");
        }

        return vs;
    }
    static vector<String> split2(string texto, char caracter)
    {
        vector<String> vs;
        String st = "";
        for (auto s : texto)
        {
            if (s == caracter)
            {
                vs.push_back(st);
                st = "";
                continue;
            }
            st += s;
        }
        vs.push_back(st);
        //Serial.print("Split OK ");
        return vs;
    }
};
#endif