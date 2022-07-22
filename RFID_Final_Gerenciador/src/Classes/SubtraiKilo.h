#ifndef SUBTRAIKILO_H_INCLUDED
#define SUBTRAIKILO_H_INCLUDED

#include <Classes/Manutencao.h>

class SubtraiKilo
{
public:
    SubtraiKilo()
    {
    }

    Manutencao *m;

    void Subtrair(NTPClient tc)
    {
        m = new Manutencao();
        m->LerCard("SUBTRAI KILO - ESCOLHA UM E PRES ENT", 'f', tc);
    }
};
#endif