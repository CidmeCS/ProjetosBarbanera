#ifndef MAIN_H_INCLUDED
#define MAIN_H_INCLUDED
#include <Arduino.h>
#include <NTPClient.h>
class Main
{
public:
    Main();
    void M(NTPClient timeClient);
};
#endif