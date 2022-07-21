using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoIt;
using Estoque.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsInput;
using System.Threading;

namespace Estoque.Classes
{
    /// <summary>
    /// Classe static para detectar imagens na tela
    /// </summary>
    public static class DetectaImagem
    {
        public static int X { get; private set; }
        public static int Y { get; private set; }

        /// <summary>
        /// Método para pesquisar uma imagem na tela
        /// </summary>
        /// <param name="recurso">Recurso Bitmap. É a imagem a ser procurada.</param>
        /// <param name="click">Se desejar o acionamento do click</param>
        /// <param name="X">Retorna a posição X da tela</param>
        /// <param name="Y">Retorna a posição Y da tela</param>
        /// <param name="Vezes">vezes que o metodo repetirá se nao achar. entao lança uma exception</param>
        public static bool Start(Bitmap recurso, bool click, int vezes, int cutX, int cutY, int cutW, int cutH, bool mouse, string nomeControle)
        {

            bool isInCapture = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int i = 0;
            do
            {
                if (vezes == 0) // se for zero é infinitas vezez
                {
                    i--;
                }
                //Console.WriteLine(i + 1);
                Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                Graphics g = Graphics.FromImage(screenCapture);
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 screenCapture.Size,
                                 CopyPixelOperation.SourceCopy);
                Bitmap myPic = recurso;
                isInCapture = IsInCapture(myPic, screenCapture, cutX, cutY, cutW, cutH, mouse);
                if (isInCapture == false & i == vezes)
                {
                    if (nomeControle == "VerificaSugestao.PNG")
                    {
                        return false;
                    }
                    //Debug.WriteLine($"ERRO no X = {X}, Y = {Y}, {Clipboard.GetText()}");
                    throw new Exception($"Botão ou Controle não encontrado... {nomeControle}");
                }
                if (isInCapture)
                {
                    AutoItX.MouseMove(X, Y, 10);
                    if (click)
                    {
                        AutoItX.MouseClick();
                    }
                    AutoItX.MouseMove(0, 0, 10);
                    break;
                }

                i++;
                Thread.Sleep(2000);
            } while (true);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            //Console.WriteLine($"X = {X} - Y = {Y} Tempo = {ts}");
            return isInCapture;
        }

        /// <summary>
        /// Método aguardar o download concluir
        /// </summary>

        private static bool IsInCapture(Bitmap recurso, Bitmap Tela, int cutX, int cutY, int cutW, int cutH, bool mouse)
        {
            int xi = 0;
            int yi = 0;
            int xf = 0;
            int yf = 0;

            var win = AutoItX.WinGetPos();

            if (win.X < 0)
            {
                win.X = 0;
            }
            if (win.Y < 0)
            {
                win.Y = 0;
            }

            int WinX = 0;
            int WinY = 0;
            int WinW = 0;
            int WinH = 0;

            if (cutX == 0 & cutY == 0 & cutW == 0 & cutH == 0)
            {
                WinX = win.X;
                WinY = win.Y;
                WinW = WinX + win.Width;
                WinH = WinY + win.Height;
            }
            else
            {
                WinX = win.X + cutX;
                WinY = win.Y + cutY;
                WinW = cutW + WinX;
                WinH = cutH + WinY;
            }


            for (int x = WinX; x < WinW; x++)
            {
                for (int y = WinY; y < WinH; y++)
                {
                    if (mouse)
                    {
                        AutoItX.MouseMove(x, y, 0);
                    }
                    bool invalid = false;
                    int k = x, l = y;
                    for (int a = 0; a < recurso.Width; a++)
                    {
                        l = y;
                        for (int b = 0; b < recurso.Height; b++)
                        {
                            if (recurso.GetPixel(a, b) != Tela.GetPixel(k, l))
                            {
                                invalid = true;
                                break;
                            }
                            else
                                l++;
                        }
                        if (invalid)
                            break;
                        else
                            k++;
                    }

                    if (!invalid)
                    {
                        xi = x;
                        xf = k;
                        yi = y;
                        yf = l;

                        X = (int)(x + k) / 2;
                        Y = (int)(y + l) / 2;

                        AutoItX.MouseMove(X, Y, 10);

                        return true;
                    }
                }
            }
            AutoItX.MouseMove(X - 25, Y - 25, 10);
            return false;
        }
    }
}
