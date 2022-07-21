using Estoque.Classes.ERP;
using Estoque.DAO;
using Estoque.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    public class CorrigeDescricaoItem
    {
        public DataGridView dgv;
        private static StringBuilder sb;
        private static List<string> l;
        public Label lbl;

        public CorrigeDescricaoItem(DataGridView dgv, Label lbl)
        {
            this.dgv = new DataGridView();
            this.dgv = dgv;
            this.lbl = lbl;
        }
        public void Corrige()
        {
            Crud c = new Crud();
            var d = c.ListaSaldo().OrderBy(p => p.Descricao).ToList();
            dgv.DataSource = obterDados(d);
            if (l.Count == 0)
            {
                return;
            }
            if (File.Exists(@"C:\Exports\ListaCorrigeDescricao.txt"))
            {
                File.Delete(@"C:\Exports\ListaCorrigeDescricao.txt");
                using (File.Create(@"C:\Exports\ListaCorrigeDescricao.txt"))
                { }
            }
            else
            {
                using (File.Create(@"C:\Exports\ListaCorrigeDescricao.txt"))
                { }
            }
            File.AppendAllText(@"C:\Exports\ListaCorrigeDescricao.txt", sb.ToString());
            if (MessageBox.Show("Deseja Alterar no ERP?", "Atualização", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ControllerERP_Pronto.AlteraDescricaoManual(l, lbl);
            }
        }

        internal static List<SaldoT> CorrigeTubo(List<SaldoT> lista, string antigo, string novo)
        {
            List<SaldoT> listT = new List<SaldoT>();
            foreach (var i in lista)
            {
                var size = i.Descricao.Length;
                string desc1 = string.Empty;
                string desc2 = string.Empty;
                string descFull = string.Empty;

                if (size <= 25)
                {
                    desc1 = i.Descricao.Replace(antigo, novo).Replace("  ", "\" ").Trim();

                    if (!desc1.Contains("/") & !desc1.Contains("MM"))
                    {
                        desc1 = desc1.Insert(desc1.Length, "\"");
                    }
                    descFull = desc1.Trim();
                }
                else
                {
                    desc1 = i.Descricao2.Replace(antigo, novo).Replace("  ", "\" ").Trim();
                    desc2 = i.DESCR_2.Trim().Replace("  ", "\" ");
                    descFull = desc1 + " " + desc2;
                }

                listT.Add(new SaldoT
                {
                    Produto = i.Produto,
                    Descricao = descFull,
                    Descricao2 = desc1,
                    DESCR_2 = desc2
                });
            }

            return listT;
        }

        private List<Descricao> obterDados(List<Entidade.Saldo> d)
        {

            sb = new StringBuilder();
            l = new List<string>();
            List<Descricao> ld = new List<Descricao>();
            foreach (var i in d)
            {
                var x = Regex.IsMatch(i.Descricao, "[a-zéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËÜÏÖÄçÇ;!@$¨*<>#?]");
                if (x)
                {
                    var d1 = RemoveDiacritics(i.Descricao2).ToUpper();
                    var d2 = RemoveDiacritics(i.DESCR_2).ToUpper();
                    sb.AppendLine($"{i.Produto};{d1};{d2}");
                    l.Add($"{i.Produto};{d1};{d2}");
                    ld.Add(new Descricao { Produto = i.Produto, DescAtual = i.Descricao, Corrigida = d1 + d2 });
                }
            }

            lbl.Text = $"Corrigindo {ld.Count}, {l.Count} linhas";
            return ld;
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > 255)
                    sb.Append(text[i]);
                else
                    sb.Append(s_Diacritics[text[i]]);
            }
            return sb.ToString();
        }

        private static readonly char[] s_Diacritics = GetDiacritics();

        private static char[] GetDiacritics()
        {
            char[] accents = new char[256];

            for (int i = 0; i < 256; i++)
                accents[i] = (char)i;

            accents[(byte)'á'] = accents[(byte)'à'] = accents[(byte)'ã'] = accents[(byte)'â'] = accents[(byte)'ä'] = 'A';
            accents[(byte)'Á'] = accents[(byte)'À'] = accents[(byte)'Ã'] = accents[(byte)'Â'] = accents[(byte)'Ä'] = 'A';

            accents[(byte)'é'] = accents[(byte)'è'] = accents[(byte)'ê'] = accents[(byte)'ë'] = 'E';
            accents[(byte)'É'] = accents[(byte)'È'] = accents[(byte)'Ê'] = accents[(byte)'Ë'] = 'E';

            accents[(byte)'í'] = accents[(byte)'ì'] = accents[(byte)'î'] = accents[(byte)'ï'] = 'I';
            accents[(byte)'Í'] = accents[(byte)'Ì'] = accents[(byte)'Î'] = accents[(byte)'Ï'] = 'I';

            accents[(byte)'ó'] = accents[(byte)'ò'] = accents[(byte)'ô'] = accents[(byte)'õ'] = accents[(byte)'ö'] = 'O';
            accents[(byte)'Ó'] = accents[(byte)'Ò'] = accents[(byte)'Ô'] = accents[(byte)'Õ'] = accents[(byte)'Ö'] = 'O';

            accents[(byte)'ú'] = accents[(byte)'ù'] = accents[(byte)'û'] = accents[(byte)'ü'] = 'U';
            accents[(byte)'Ú'] = accents[(byte)'Ù'] = accents[(byte)'Û'] = accents[(byte)'Ü'] = 'U';

            accents[(byte)'ç'] = 'C';
            accents[(byte)'Ç'] = 'C';

            accents[(byte)'ñ'] = 'N';
            accents[(byte)'Ñ'] = 'N';

            accents[(byte)'ÿ'] = accents[(byte)'ý'] = 'Y';
            accents[(byte)'Ý'] = 'Y';

            return accents;
        }

        private class Descricao
        {
            public string Produto { get; internal set; }
            public string DescAtual { get; internal set; }
            public string Corrigida { get; internal set; }
        }
    }
}
