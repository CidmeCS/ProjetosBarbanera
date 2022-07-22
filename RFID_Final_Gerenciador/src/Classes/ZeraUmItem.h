#ifndef ZERAUMITEM_H_INCLUDED
#define ZERAUMITEM_H_INCLUDED

#include <Classes/Manutencao.h>

class ZeraUmItem
{
public:
    ZeraUmItem()
    {
    }

    Manutencao *m;

    void Zerar(NTPClient tc)
    {
        m = new Manutencao();
        m->LerCard("ZERA UM ITEM - ESCOLHA UM E PRES ENT", '4', tc);
    }
};
#endif