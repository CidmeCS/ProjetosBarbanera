#ifndef SOMAKILO_H_INCLUDED
#define SOMAKILO_H_INCLUDED

#include <Classes/Manutencao.h>

class SomaKilo
{
public:
    SomaKilo()
    {
    }

    Manutencao *m;

    void Somar(NTPClient tc)
    {
        m = new Manutencao();
        m->LerCard("SOMA KILO - ESCOLHA UM E PRES ENT", '6', tc);
    }
};
#endif