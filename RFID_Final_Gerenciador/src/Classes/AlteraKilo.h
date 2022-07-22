#ifndef ALTERAKILO_H_INCLUDED
#define ALTERAKILO_H_INCLUDED

#include <Classes/Manutencao.h>

class AlteraKilo
{
public:
    AlteraKilo()
    {
    }

    Manutencao *m;

    void Alterar(NTPClient tc)
    {
        m = new Manutencao();
        m->LerCard("ALTERA KILO - ESCOLHA UM E PRES ENT", '*', tc);
    }
};
#endif