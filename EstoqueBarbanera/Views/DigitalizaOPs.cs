using Bytescout.PDFExtractor;
using IronOcr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


namespace Estoque.Views
{
    public partial class DigitalizaOPs : Form
    {
        List<Dicionary> dic = null;
        int i = 0;
        private string path;

        private int j;
        private bool FIM = true;
        private int paraFragmentar = 0;
        private List<string> Lotes;
        private int lote;
        public OcrResult Result { get; private set; }
        public Match er { get; private set; }
        public int rp1 { get; private set; } = 0;
        public decimal pb1 { get; private set; }
        public decimal pb2 { get; private set; }
        public decimal pb6 { get; private set; }
        public decimal pb3 { get; private set; }
        public Decimal pb4 { get; private set; }
        public int pb5 { get; private set; }
        public decimal pb7 { get; private set; }

        public DigitalizaOPs()
        {
            InitializeComponent();
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //define o stilo padrao do progressbar
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 0;

            //executa o processo de forma assincrona.
            backgroundWorker1.RunWorkerAsync();


            //lblScanOK.Text = "SCans OK";
        }

        private void Fragmenta_E_Ler()
        {
            Fragmentar();
            OCR();
        }

        private void OCR()
        {

            var files = Directory.GetFiles(@"Z:\Cid\OPs scaneadas\SCAN", "*.pdf", SearchOption.TopDirectoryOnly).ToList();
            if (files.Count == paraFragmentar)
            {

                if (files.Count == 0)
                {
                    goto ir;
                }

                lblCount.BeginInvoke(new Action(() => { lblCount.Text = "Scaneando..."; }));
                var Ocr = new AdvancedOcr()
                {
                    Language = IronOcr.Languages.Portuguese.OcrLanguagePack,
                    ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                    EnhanceResolution = true,
                    EnhanceContrast = true,
                    CleanBackgroundNoise = true,
                    ColorDepth = 4,
                    RotateAndStraighten = false,
                    DetectWhiteTextOnDarkBackgrounds = false,
                    ReadBarCodes = false,
                    Strategy = AdvancedOcr.OcrStrategy.Advanced,
                    InputImageType = AdvancedOcr.InputTypes.Document
                };

                bool b = true;

                while (b)
                {
                    backgroundWorker1.ReportProgress(0);
                    progressBar1.BeginInvoke(new Action(() => { this.progressBar1.Maximum = 100; }));

                    dic = new List<Dicionary>();
                    Rectangle r = new Rectangle(300, 0, 500, 300);
                    foreach (var file in files)
                    {
                        pb4 += 100 / (decimal)files.Count;
                        pb5 = (int)Math.Round(pb4, 0);

                        backgroundWorker1.ReportProgress(pb5);
                    erro: try
                        {
                            Result = Ocr.ReadPdf(file, r, 1);
                            er = Regex.Match(Result.Text, @"\d{4}");
                            dic.Add(new Dicionary
                            {
                                path = file,
                                op = er.Value.Trim()
                            });

                            if (files.Count <= dic.Count)
                            {
                                b = false;
                                backgroundWorker1.ReportProgress(100);
                            }
                        }
                        catch (Exception e)
                        {
                            goto erro;

                        }

                    }

                }
                LeitorPDF(dic[0].path);
                path = dic[0].path;
                txtOP.BeginInvoke(new Action(() => { txtOP.Text = dic[0].op; }));

                if (files.Count != dic.Count)
                {
                    MessageBox.Show("ERRO OCR-002: A quantidade de Arquivos nao é igual a quantidade de OCRs, \n" +
                        "Não Avançar\n" +
                        "Refaça a operação", "ATENÇÃO");
                }
                lblCount.BeginInvoke(new Action(() => { lblCount.Text = dic.Count + " PDFs"; }));
            ir:;
            }
            else
            {
                lblParaFragmentar.BeginInvoke(new Action(() =>
                {
                    lblParaFragmentar.Text = "Para Fragmentar = " + paraFragmentar + "\nArquivosObtidos = " + files.Count;
                }));

                MessageBox.Show("ERRO 772: A QTD de Fragmentação não está igual a quantidade de arquivos obtidos\n" +
                     "Para Fragmentar = " + paraFragmentar + "\nArquivos Obtidos = " + files.Count
                    , "Erro 772");
            }
        }

        private void LeitorPDF(string f)
        {
            Ler(f);
        }

        private void Ler(string f)
        {
            webBrowser1.Navigate(string.Format("file://" + f, Application.StartupPath));
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            Proximo();
        }

        private void Proximo()
        {
            txtOP.Clear();
            if ((dic.Count() - 1) > i)
            {
                i++;
                LeitorPDF(dic[i].path);
                path = dic[i].path;
                txtOP.Text = dic[i].op;

                lblCount.Text = i + 1 + " de " + dic.Count;
                FIM = true;
            }
            else
            {
                FIM = false;
                if (MessageBox.Show("Trabalho concluido com sucesso!\nDeseja excluir os arquivos temporarios?","EXCLUIR ARQUIVOS REMPORARIOS",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Limpar();
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int colecao = dic.Count();
            if (i > 0)
            {
                i--;
                LeitorPDF(dic[i].path);
                txtOP.Text = dic[i].op;

                lblCount.Text = i + 1 + " de " + dic.Count;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtOP.TextLength >= 4)
            {
                if (FIM)
                {
                    if (File.Exists($@"Z:\Cid\OPs scaneadas\{txtOP.Text}.pdf"))
                    {
                        var bits = File.ReadAllBytes(dic[i].path);
                        File.WriteAllBytes($@"Z:\Cid\OPs scaneadas\{txtOP.Text + " " + DateTime.Now.ToString("hhmmss")}.pdf", bits);
                    }
                    else
                    {
                        var bits = File.ReadAllBytes(dic[i].path);
                        File.WriteAllBytes($@"Z:\Cid\OPs scaneadas\{txtOP.Text}.pdf", bits);
                    }

                    Proximo();
                }
            }
        }

        private void Limpar()
        {

            if (MessageBox.Show("Pode excluir os arquivos temporarios?", "Excluir arquivos temporarios", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                webBrowser1.Dispose();
                var files = Directory.GetFiles(@"Z:\Cid\OPs scaneadas\SCAN", "*.*", SearchOption.TopDirectoryOnly).ToList();
                foreach (var item in files)
                {
                    File.Delete(item);
                    
                }
                label2.Text = label1.Text = "PDFs Excluidos!!";
            }

        }

        private void btnLimparArquivosTemporarios_Click(object sender, EventArgs e)
        {
            Limpar();
        }


        private void Fragmentar()
        {

            using (DocumentSplitter splitter = new DocumentSplitter())
            {
                HashSet<string> ParaDeletar = new HashSet<string>();
                splitter.OptimizeSplittedDocuments = true;
                Lotes = Directory.GetFiles(@"Z:\Cid\OPs scaneadas\SCAN", "*.pdf", SearchOption.TopDirectoryOnly).ToList();
                paraFragmentar = 0;
                backgroundWorker1.ReportProgress(0);
                pb2 = 100 / (decimal)Lotes.Count;
                foreach (var file in Lotes)
                {
                    backgroundWorker1.ReportProgress(0);
                    progressBar1.BeginInvoke(new Action(() => { this.progressBar1.Maximum = 100; }));
                    pb6 += pb2;
                    this.backgroundWorker1.ReportProgress((int)Math.Floor(pb6));
                    lote = splitter.GetPageCount(file);
                    paraFragmentar += lote;
                    if (lote > 1)
                    {
                        progressBar1.BeginInvoke(new Action(() => { progressBar1.Maximum = 100; }));


                        pb1 = 100 / (decimal)lote;
                        for (int i = 1; i <= lote; i++)
                        {
                            pb7 += pb1;
                            this.backgroundWorker1.ReportProgress((int)Math.Floor(pb7));
                            splitter.Split(file, $"{i}", $@"Z:\Cid\OPs scaneadas\SCAN");
                            ParaDeletar.Add(file);
                        }
                        pb1 = 0;
                        pb7 = 0;
                        this.backgroundWorker1.ReportProgress(100);
                    }

                }
                this.backgroundWorker1.ReportProgress(100);
                pb2 = 0;
                pb6 = 0;
                backgroundWorker1.ReportProgress(0);
                if (ParaDeletar.Count > 0)
                {

                    progressBar1.BeginInvoke(new Action(() => { this.progressBar1.Maximum = 100; }));
                    rp1 = 0;
                    pb3 = 100 / (decimal)ParaDeletar.Count;
                    Decimal pb8 = 0;
                    foreach (var file in ParaDeletar)
                    {
                        pb8 += pb3;
                        this.backgroundWorker1.ReportProgress((int)Math.Floor(pb3));
                        Thread.Sleep(1000);
                        File.Delete(file);
                    }
                    pb3 = 0;
                    pb8 = 0;
                }
                lblParaFragmentar.BeginInvoke(new Action(() => { lblParaFragmentar.Text = "Para Fragmentar: " + paraFragmentar; }));
            }
            this.backgroundWorker1.ReportProgress(100);
            lblCount.BeginInvoke(new Action(() => { lblScanOK.Text = "Scan Ok"; }));
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Fragmenta_E_Ler();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            //Incrementa o valor da progressbar com o valor
            //atual do progresso da tarefa.
            progressBar1.Value = e.ProgressPercentage;

            //informa o percentual na forma de texto.
            label1.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //caso a operação seja cancelada, informa ao usuario.
                label2.Text = "Operação Cancelada pelo Usuário!";

                //habilita o Botao cancelar
                //                                  btnCancelar.Enabled = true;
                //limpa a label
                label1.Text = string.Empty;
            }
            else if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                label2.Text = "Aconteceu um erro durante a execução do processo!";
            }
            else
            {
                //informa que a tarefa foi concluida com sucesso.
                label2.Text = "Tarefa Concluida com sucesso!";

            }
        }
    }
    public class Dicionary
    {
        public string path { get; set; }
        public string op { get; set; }
    }
}
