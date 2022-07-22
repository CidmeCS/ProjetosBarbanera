#ifndef SUBTRAIMETRO_H_INCLUDED
#define SUBTRAIMETRO_H_INCLUDED

#include <Classes/Manutencao.h>

class SubtraiMetro
{
public:
    SubtraiMetro()
    {
    }

    Manutencao *m;

    void Subtrair(NTPClient tc)
    {
        m = new Manutencao();
        m->LerCard("SUBTRAI METRO - ESCOLHA UM E PRES ENT", 'F', tc);
    }
};
#endif