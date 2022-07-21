namespace Estoque.Views
{
    partial class DigitalizaOPs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblScanOK = new System.Windows.Forms.Label();
            this.btnLimparArquivosTemporarios = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.txtOP = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblParaFragmentar = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblScanOK
            // 
            this.lblScanOK.AutoSize = true;
            this.lblScanOK.Location = new System.Drawing.Point(147, 59);
            this.lblScanOK.Name = "lblScanOK";
            this.lblScanOK.Size = new System.Drawing.Size(12, 13);
            this.lblScanOK.TabIndex = 19;
            this.lblScanOK.Text = "*";
            // 
            // btnLimparArquivosTemporarios
            // 
            this.btnLimparArquivosTemporarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparArquivosTemporarios.Location = new System.Drawing.Point(147, 278);
            this.btnLimparArquivosTemporarios.Name = "btnLimparArquivosTemporarios";
            this.btnLimparArquivosTemporarios.Size = new System.Drawing.Size(94, 49);
            this.btnLimparArquivosTemporarios.TabIndex = 18;
            this.btnLimparArquivosTemporarios.Text = "3 - Limpar Arquivos Temporarios";
            this.btnLimparArquivosTemporarios.UseVisualStyleBackColor = true;
            this.btnLimparArquivosTemporarios.Click += new System.EventHandler(this.btnLimparArquivosTemporarios_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(147, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "2 - OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(247, 174);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(12, 13);
            this.lblCount.TabIndex = 16;
            this.lblCount.Text = "*";
            // 
            // btnProximo
            // 
            this.btnProximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProximo.Location = new System.Drawing.Point(241, 203);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(108, 23);
            this.btnProximo.TabIndex = 14;
            this.btnProximo.Text = "Proximo >>";
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(14, 203);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(103, 23);
            this.btnAnterior.TabIndex = 13;
            this.btnAnterior.Text = " << Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // txtOP
            // 
            this.txtOP.Location = new System.Drawing.Point(93, 167);
            this.txtOP.Name = "txtOP";
            this.txtOP.Size = new System.Drawing.Size(116, 20);
            this.txtOP.TabIndex = 12;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(357, 21);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(23, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1075, 420);
            this.webBrowser1.TabIndex = 15;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(29, 54);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(87, 23);
            this.btnIniciar.TabIndex = 11;
            this.btnIniciar.Text = "1 - Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblParaFragmentar
            // 
            this.lblParaFragmentar.AutoSize = true;
            this.lblParaFragmentar.Location = new System.Drawing.Point(147, 21);
            this.lblParaFragmentar.Name = "lblParaFragmentar";
            this.lblParaFragmentar.Size = new System.Drawing.Size(12, 13);
            this.lblParaFragmentar.TabIndex = 20;
            this.lblParaFragmentar.Text = "*";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(29, 390);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "label1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // DigitalizaOPs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 462);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblParaFragmentar);
            this.Controls.Add(this.lblScanOK);
            this.Controls.Add(this.btnLimparArquivosTemporarios);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.txtOP);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnIniciar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DigitalizaOPs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indexação de OPs Digitalizadas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScanOK;
        private System.Windows.Forms.Button btnLimparArquivosTemporarios;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblParaFragmentar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}