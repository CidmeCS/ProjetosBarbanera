#ifndef PRODUTO_H
#define PRODUTO_H
#include <Arduino.h>

class Produto
{

public:
    int seq;
    String data;
    String id;
    String codigo;
    String descricao;
    String und;
    String prateleira;
    String qtd;
    String convsor;
    String convert;
};

class Anotacao
{

public:
    String cod;
    String qtd;
    String opr;
    String ptl;
    String op2;
};
#endif
