using AutoIt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace LoginERP2
{
    class Program
    {
        static void Main(string[] args)
        {
            FecharABC71();

            string Dep = "TI";
            string User = "CID";
            string PW = "THALES10";

            
            InputSimulator ins = new InputSimulator();

            Process erp = Process.Start(@"C:\Exports\erpPronto.jnlp");
            AutoItX.WinWaitActive("Identificação");
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("332");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("1");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry(Dep);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry(User); // USUARIO

            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry(PW); // SENHA

            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }

            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            AutoItX.WinWaitClose("Identificação"); // saindo do lonin

            AutoItX.WinWaitActive("ERP Pronto - ABC71");
        }

        internal static void FecharABC71()
        {
            var processos = Process.GetProcesses();
            foreach (var processo in processos)
            {
                if (processo.ProcessName == "jp2launcher")
                {
                    processo.Kill();
                }
            }
        }
    }
}
