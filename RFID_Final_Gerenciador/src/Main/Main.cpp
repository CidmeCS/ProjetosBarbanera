#include <Main/Main.h>
#include <Classes/Principal.h>
#include <NTPClient.h>
#include <Classes/ObterTXTs.h>

ObterTXTs ox = ObterTXTs();
Principal p = Principal();
Main::Main()
{
}

void Main::M(NTPClient timeClient)
{
   ox.Obter(timeClient);
   p.start(timeClient);
}