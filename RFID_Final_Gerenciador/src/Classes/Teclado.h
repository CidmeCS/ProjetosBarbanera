#ifndef TECLADO_H
#define TECLADO_H
#include <Arduino.h>
#include <Keypad.h>
#include <Keypad_I2C.h>
#include <Wire.h>
using namespace std;

class Teclado
{
public:
  //novo
  static const byte I2CADDR1 = 32;
  static const byte I2CADDR2 = 33;
  //antigo
  //static const byte I2CADDR1 = 33;
  //static const byte I2CADDR2 = 34;
  static const byte ROWS = 4;
  static const byte ROWS2 = 1;
  static const byte COLS = 4;
  char keysB[ROWS][COLS] = {
      {'F', 'f', '#', '*'},
      {'1', '2', '3', 'U'},
      {'4', '5', '6', 'D'},
      {'7', '8', '9', 'e'}};
  char keysC[ROWS2][COLS] = {
      {'<', '0', '>', 'E'}};
      // novo
  byte rowPins[ROWS] = {3, 2, 1, 0};
  byte rowPins2[ROWS2] = {0};
  byte colPins[COLS] = {7, 6, 5, 4};
//antigo
  //byte rowPins[ROWS] = {0, 1, 2, 3};
  //byte rowPins2[ROWS2] = {0};
  //byte colPins[COLS] = {4, 5, 6, 7};

  Teclado() {}

  char tecla()
  {
    Wire.begin();
    Keypad_I2C kpd(makeKeymap(keysB), rowPins, colPins, ROWS, COLS, I2CADDR1, PCF8574);
    Keypad_I2C kpd2(makeKeymap(keysC), rowPins2, colPins, ROWS2, COLS, I2CADDR2, PCF8574);

    kpd.begin(makeKeymap(keysB));
    kpd2.begin(makeKeymap(keysC));

    char keyB = kpd.getKey();
    char keyC = kpd2.getKey();

    if (keyB)
    {
      return keyB;
    }
    else if (keyC)
    {
      return keyC;
    }
    return ' ';
  }
};
#endif