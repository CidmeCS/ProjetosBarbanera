// See SetupX_Template.h for all options available

#define ILI9488_DRIVER

//#define TFT_INVERSION_OFF

////VSPI
//#define TFT_MISO 19 // LILAS
//#define TFT_MOSI 23 // AMARELO
//#define TFT_SCLK 18 // VERDE
//#define TFT_CS   15 // MARROM

//HSPI
#define TFT_MISO 12 // LILAS
#define TFT_MOSI 13 // AMARELO
#define TFT_SCLK 14 // VERDE
#define TFT_CS   15   // MARROM
#define TFT_DC 5  // LARANJA DC/RS
#define TFT_RST 0 // VERMELHO


#define LOAD_GLCD   // Font 1. Original Adafruit 8 pixel font needs ~1820 bytes in FLASH
#define LOAD_FONT2  // Font 2. Small 16 pixel high font, needs ~3534 bytes in FLASH, 96 characters
#define LOAD_FONT4  // Font 4. Medium 26 pixel high font, needs ~5848 bytes in FLASH, 96 characters
#define LOAD_FONT6  // Font 6. Large 48 pixel font, needs ~2666 bytes in FLASH, only characters 1234567890:-.apm
#define LOAD_FONT7  // Font 7. 7 segment 48 pixel font, needs ~2438 bytes in FLASH, only characters 1234567890:.
#define LOAD_FONT8  // Font 8. Large 75 pixel font needs ~3256 bytes in FLASH, only characters 1234567890:-.
#define LOAD_GFXFF  // FreeFonts. Include access to the 48 Adafruit_GFX free fonts FF1 to FF48 and custom fonts

#define SMOOTH_FONT


// #define SPI_FREQUENCY  20000000
#define SPI_FREQUENCY  27000000
// #define SPI_FREQUENCY  40000000
// #define SPI_FREQUENCY  80000000

// Optional reduced SPI frequency for reading TFT
#define SPI_READ_FREQUENCY  16000000

#define SPI_TOUCH_FREQUENCY  2500000
