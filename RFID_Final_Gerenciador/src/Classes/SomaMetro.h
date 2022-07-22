#ifndef SOMAMETRO_H_INCLUDED
#define SOMAMETRO_H_INCLUDED

#include <Classes/Manutencao.h>

class SomaMetro
{
public:
    SomaMetro()
    {
    }

    Manutencao *m;

    void Somar(NTPClient tc)
    {
        m = new Manutencao();
        m->LerCard("SOMA METRO - ESCOLHA UM E PRES ENT", '5', tc);
    }
};
#endif