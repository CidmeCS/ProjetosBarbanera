using System;

namespace Estoque.Views
{
    internal class VerificaFeriados
    {
        internal static int Start(string inicio, string fim)
        {
            int qtd = 0;
            DateTime D_Inicio = DateTime.Parse(inicio);
            DateTime D_Fim = DateTime.Parse(fim);
            for (DateTime i = D_Inicio; i <= D_Fim;)
            {
                string semana = i.DayOfWeek.ToString();
                if (semana.Contains("Saturday") | semana.Contains("Sunday"))
                {

                }
                else
                {
                    qtd++;
                }
                i = i.AddDays(1);
            }
            return qtd;
        }
    }
}