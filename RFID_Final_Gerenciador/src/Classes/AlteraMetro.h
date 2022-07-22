#ifndef ALTERAMETRO_H_INCLUDED
#define ALTERAMETRO_H_INCLUDED

#include <Classes/Manutencao.h>

class AlteraMetro
{
public:
    AlteraMetro()
    {
    }

    Manutencao *m;

    void Alterar(NTPClient tc)
    {
        m = new Manutencao();
        m->LerCard("ALTERA METRO - ESCOLHA UM E PRES ENT", '#', tc);
    }
};
#endif