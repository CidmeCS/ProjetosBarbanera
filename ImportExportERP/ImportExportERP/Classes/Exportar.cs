using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImportExportERP.Classes;
using ImportExportERP.Entidade;
using ImportExportERP.Views;

namespace ImportExportERP.Classes
{
    public class Exportar
    {
        public static List<string> ListaExport;
        public static List<string> ListaImport;
        public static string ControleAtual { get; private set; }

        TextBox txtDepartamento, txtUser, txtPassWord, txtFilial;
        public static Label lblDownloadCorrente;
        CheckBox cdSaldoDeTerceiro;
        DateTimePicker dtp;
        IOrderedEnumerable<DepositoDeTerceiro> sh = null, sh2 = null;
        List<int> li;
        private GroupBox g;

        RichTextBox rtbMensagens;

        public static Continua jj { get; set; }
        public static List<string> PendentesExport { get; private set; }
        public static string lbl { get; private set; }



        Exports exports;

        //Construtor
        public Exportar(Label lblDownloadCorrente) { Exportar.lblDownloadCorrente = lblDownloadCorrente; }
        public Exportar(GroupBox g, TextBox txtDepartamento, TextBox txtUser, TextBox txtPassWord, DateTimePicker dtp, Label lblDownloadCorrente, TextBox txtFilial, RichTextBox rtbMensagens)
        {
            exports = new Exports(lblDownloadCorrente);

            this.g = g;
            CRUD c = new CRUD();
            Parallel.Invoke(
                    //() => sh = c.ListaDepositoDeTerceiroSqlServer().OrderBy(p => p.Deposito),
                    () => sh2 = c.ListaDepositoDeTerceiroMySql().OrderBy(p => p.Deposito)
                    );
            this.txtDepartamento = txtDepartamento;
            this.txtUser = txtUser;
            this.txtPassWord = txtPassWord;
            this.txtFilial = txtFilial;
            this.dtp = dtp;
            this.rtbMensagens = rtbMensagens;
            Exportar.lblDownloadCorrente = lblDownloadCorrente;


            ListaImport = new List<string>();
            ListaExport = new List<string>();
            foreach (CheckBox item in g.Controls)
            {
                if (item.Checked & item.Text.Contains(" I."))
                {
                    ListaImport.Add(item.Text);
                }
                if (item.Name == "cdSaldoDeTerceiro")
                {
                    cdSaldoDeTerceiro = item;
                }
                switch (item.Checked & item.Text.Contains(" E."))
                {
                    case true:
                        ListaExport.Add(item.Text);
                        break;
                }
            }
            ListaExport.Sort();
        }

        internal string Inicio()
        {
            string erro2 = null;

            StringBuilder erro = new StringBuilder();
            PendentesExport = new List<string>(ListaExport);
            foreach (var item in ListaExport)
            {
                lblDownloadCorrente.Text = "Export Corrente: " + item + $" Loop: {Principal.kl}";
                new ERP_Pronto(txtDepartamento, txtUser, txtPassWord, txtFilial, rtbMensagens);
                string x = null;
                ControleAtual = item;
                x = exports.Start(item, null, dtp);
                PendentesExport.Remove(item);
                erro.AppendLine(x);
                erro2 = x;
            }
            

            return erro2;
        }

        internal StringBuilder Exportando(object sender)
        {
            exports = new Exports(lblDownloadCorrente);
            CRUD c;
            Button btn = (Button)sender;
            IOrderedEnumerable<DepositoDeTerceiro> sh = null, sh2 = null;
            StringBuilder sb = null;
            if (btn.Name == "btnExportarSqlServer")
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                c = new CRUD();
                sh = c.ListaDepositoDeTerceiroSqlServer().OrderBy(p => p.Deposito);
                s.Stop();
                Console.WriteLine("Tempo: {0} 5 Segundos", s.ElapsedMilliseconds / 1000.0);
            }

            else if (btn.Name == "btnExportarMySql")
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                c = new CRUD();
                sh = c.ListaDepositoDeTerceiroMySql().OrderBy(p => p.Deposito);
                s.Stop();
                Console.WriteLine("Tempo: {0} 6 Segundos", s.ElapsedMilliseconds / 1000.0);
            }

            else if (btn.Name == "btnExportarAmbos")
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                c = new CRUD();
                Parallel.Invoke(
                    () => sh = c.ListaDepositoDeTerceiroSqlServer().OrderBy(p => p.Deposito),
                    () => sh2 = c.ListaDepositoDeTerceiroMySql().OrderBy(p => p.Deposito)
                    );
                s.Stop();
                Console.WriteLine("Tempo: {0} 2 Segundos", s.ElapsedMilliseconds / 1000.0);
                var x = (from s1 in sh
                         join s2 in sh2 on s1.Deposito equals s2.Deposito
                         where s1.Nome == s2.Nome
                         select new { s1.Deposito }).ToList();
                if (sh.Count() == sh2.Count() & sh.Count() == x.Count())
                { }
                else
                {
                    Mensagerias.Send("Ambos os databases nao podem ser adds \n " +
                        "as tabelas: \n\t" +
                        "'DepositoDeTerceiro MySql' e \n\t" +
                        "'DepositoDeTerceiro SqlServer' \n\n" +
                        "nao podem ser adds paralelamente. \n\n\t" +
                        "Faca um de cada vez" + "\n---------\n");
                    goto fim;
                }
                Button sqlserver = new Button(), mysql = new Button();
                sqlserver.Name = "btnExportarSqlServer";
                mysql.Name = "btnExportarMySql";
                sb = new StringBuilder();

                foreach (var m in ListaImport)
                {
                    
                    //Sem Paralelo
                    sb.AppendLine(exports.Start(m, sqlserver, dtp));
                    sb.AppendLine(exports.Start(m, mysql, dtp));

                    //Com metodos Paralelo
                    //Parallel.Invoke(
                    //    () => sb.AppendLine(Exports.Start(m, null, sqlserver, dtp)),
                    //    () => sb.AppendLine(Exports.Start(m, null, mysql, dtp))
                    //    );
                }
                goto fim;
            }

            Stopwatch j = new Stopwatch();
            j.Start();
            sb = new StringBuilder();
            ListaImport.Sort();
            int qtd = ListaImport.Count(), i = 0;
            foreach (var m in ListaImport)
            {
                lbl = $"Import Corrente: {++i}/{qtd} >> {m}";
                sb.AppendLine(exports.Start(m, btn, dtp));                
            }
            j.Stop();
            Console.WriteLine("Tempo: {0} 10 Segundos", j.ElapsedMilliseconds / 1000.0);
        fim:;

            return sb;
        }
    }
}
