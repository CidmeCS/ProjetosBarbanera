namespace Estoque.Views
{
    partial class RFID_Inventario
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnObterLinks = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnAddIP = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnVisuaizaCompareInventario = new System.Windows.Forms.Button();
            this.lblLinkCarregadp = new System.Windows.Forms.Label();
            this.brnImprimirDivergentes = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimirComparacao = new System.Windows.Forms.Button();
            this.dgvFaltouLer = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnListaDeCartoes = new System.Windows.Forms.Button();
            this.btnAtualizaListaDeCartoes = new System.Windows.Forms.Button();
            this.btnVisaizaComarDivergentes = new System.Windows.Forms.Button();
            this.btnEnviaParaApontamentoAcerto = new System.Windows.Forms.Button();
            this.btnEliminaMomentaneamente = new System.Windows.Forms.Button();
            this.btnLimpaLinha = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltouLer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(10, 41);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(426, 447);
            this.webBrowser1.TabIndex = 307;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wbNavegado_Click);
            // 
            // btnObterLinks
            // 
            this.btnObterLinks.Location = new System.Drawing.Point(508, 78);
            this.btnObterLinks.Name = "btnObterLinks";
            this.btnObterLinks.Size = new System.Drawing.Size(75, 23);
            this.btnObterLinks.TabIndex = 308;
            this.btnObterLinks.Text = "Obter Links";
            this.btnObterLinks.UseVisualStyleBackColor = true;
            this.btnObterLinks.Click += new System.EventHandler(this.btnObterLinks_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 310;
            this.label1.Text = "IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(508, 24);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(97, 20);
            this.txtIP.TabIndex = 311;
            this.txtIP.Text = "192.168.0.";
            // 
            // btnAddIP
            // 
            this.btnAddIP.Location = new System.Drawing.Point(611, 22);
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Size = new System.Drawing.Size(75, 23);
            this.btnAddIP.TabIndex = 312;
            this.btnAddIP.Text = "Add IP";
            this.btnAddIP.UseVisualStyleBackColor = true;
            this.btnAddIP.Click += new System.EventHandler(this.btnAddIP_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(472, 139);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(960, 420);
            this.dgvResult.TabIndex = 317;
            this.dgvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.acertoDoubleClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(10, 12);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 318;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnVisuaizaCompareInventario
            // 
            this.btnVisuaizaCompareInventario.BackColor = System.Drawing.Color.Coral;
            this.btnVisuaizaCompareInventario.Location = new System.Drawing.Point(638, 51);
            this.btnVisuaizaCompareInventario.Name = "btnVisuaizaCompareInventario";
            this.btnVisuaizaCompareInventario.Size = new System.Drawing.Size(76, 52);
            this.btnVisuaizaCompareInventario.TabIndex = 319;
            this.btnVisuaizaCompareInventario.Text = "Visualiza Compare Inventário";
            this.btnVisuaizaCompareInventario.UseVisualStyleBackColor = false;
            this.btnVisuaizaCompareInventario.Click += new System.EventHandler(this.btnCompareInventario_Click);
            // 
            // lblLinkCarregadp
            // 
            this.lblLinkCarregadp.AutoSize = true;
            this.lblLinkCarregadp.Location = new System.Drawing.Point(469, 123);
            this.lblLinkCarregadp.Name = "lblLinkCarregadp";
            this.lblLinkCarregadp.Size = new System.Drawing.Size(11, 13);
            this.lblLinkCarregadp.TabIndex = 321;
            this.lblLinkCarregadp.Text = "*";
            // 
            // brnImprimirDivergentes
            // 
            this.brnImprimirDivergentes.BackColor = System.Drawing.Color.SandyBrown;
            this.brnImprimirDivergentes.Location = new System.Drawing.Point(1130, 68);
            this.brnImprimirDivergentes.Name = "brnImprimirDivergentes";
            this.brnImprimirDivergentes.Size = new System.Drawing.Size(75, 34);
            this.brnImprimirDivergentes.TabIndex = 322;
            this.brnImprimirDivergentes.Text = "Imprimir Divergentes";
            this.brnImprimirDivergentes.UseVisualStyleBackColor = false;
            this.brnImprimirDivergentes.Click += new System.EventHandler(this.brnImprimirDivergentes_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown1.Location = new System.Drawing.Point(858, 69);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            196608});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 323;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(855, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 324;
            this.label2.Text = "Máximo Divergente";
            // 
            // btnImprimirComparacao
            // 
            this.btnImprimirComparacao.BackColor = System.Drawing.Color.Coral;
            this.btnImprimirComparacao.Location = new System.Drawing.Point(735, 67);
            this.btnImprimirComparacao.Name = "btnImprimirComparacao";
            this.btnImprimirComparacao.Size = new System.Drawing.Size(75, 34);
            this.btnImprimirComparacao.TabIndex = 325;
            this.btnImprimirComparacao.Text = "Imprimir Comparação";
            this.btnImprimirComparacao.UseVisualStyleBackColor = false;
            this.btnImprimirComparacao.Click += new System.EventHandler(this.btnImprimirComparacao_Click);
            // 
            // dgvFaltouLer
            // 
            this.dgvFaltouLer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaltouLer.Location = new System.Drawing.Point(1482, 145);
            this.dgvFaltouLer.Name = "dgvFaltouLer";
            this.dgvFaltouLer.Size = new System.Drawing.Size(297, 674);
            this.dgvFaltouLer.TabIndex = 326;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1479, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 327;
            this.label3.Text = "Faltou Ler";
            // 
            // btnListaDeCartoes
            // 
            this.btnListaDeCartoes.Location = new System.Drawing.Point(1482, 12);
            this.btnListaDeCartoes.Name = "btnListaDeCartoes";
            this.btnListaDeCartoes.Size = new System.Drawing.Size(75, 34);
            this.btnListaDeCartoes.TabIndex = 328;
            this.btnListaDeCartoes.Text = "Lista de Cartões";
            this.btnListaDeCartoes.UseVisualStyleBackColor = true;
            this.btnListaDeCartoes.Click += new System.EventHandler(this.btnListaDeCartoes_Click);
            // 
            // btnAtualizaListaDeCartoes
            // 
            this.btnAtualizaListaDeCartoes.Enabled = false;
            this.btnAtualizaListaDeCartoes.Location = new System.Drawing.Point(1615, 102);
            this.btnAtualizaListaDeCartoes.Name = "btnAtualizaListaDeCartoes";
            this.btnAtualizaListaDeCartoes.Size = new System.Drawing.Size(82, 34);
            this.btnAtualizaListaDeCartoes.TabIndex = 329;
            this.btnAtualizaListaDeCartoes.Text = "Atualiza Lista de Cartões";
            this.btnAtualizaListaDeCartoes.UseVisualStyleBackColor = true;
            this.btnAtualizaListaDeCartoes.Click += new System.EventHandler(this.btnAtualizaListaDeCartoes_Click);
            // 
            // btnVisaizaComarDivergentes
            // 
            this.btnVisaizaComarDivergentes.BackColor = System.Drawing.Color.SandyBrown;
            this.btnVisaizaComarDivergentes.Location = new System.Drawing.Point(1005, 50);
            this.btnVisaizaComarDivergentes.Name = "btnVisaizaComarDivergentes";
            this.btnVisaizaComarDivergentes.Size = new System.Drawing.Size(75, 55);
            this.btnVisaizaComarDivergentes.TabIndex = 330;
            this.btnVisaizaComarDivergentes.Text = "Visualiza Compare Divergentes";
            this.btnVisaizaComarDivergentes.UseVisualStyleBackColor = false;
            this.btnVisaizaComarDivergentes.Click += new System.EventHandler(this.btnVisaizaComarDivergentes_Click);
            // 
            // btnEnviaParaApontamentoAcerto
            // 
            this.btnEnviaParaApontamentoAcerto.BackColor = System.Drawing.Color.SandyBrown;
            this.btnEnviaParaApontamentoAcerto.Location = new System.Drawing.Point(1307, 577);
            this.btnEnviaParaApontamentoAcerto.Name = "btnEnviaParaApontamentoAcerto";
            this.btnEnviaParaApontamentoAcerto.Size = new System.Drawing.Size(125, 55);
            this.btnEnviaParaApontamentoAcerto.TabIndex = 331;
            this.btnEnviaParaApontamentoAcerto.Text = "Envia para Apontamento/Acerto";
            this.btnEnviaParaApontamentoAcerto.UseVisualStyleBackColor = false;
            this.btnEnviaParaApontamentoAcerto.Click += new System.EventHandler(this.btnEnviaParaApontamentoAcerto_Click);
            // 
            // btnEliminaMomentaneamente
            // 
            this.btnEliminaMomentaneamente.BackColor = System.Drawing.Color.SandyBrown;
            this.btnEliminaMomentaneamente.Location = new System.Drawing.Point(480, 577);
            this.btnEliminaMomentaneamente.Name = "btnEliminaMomentaneamente";
            this.btnEliminaMomentaneamente.Size = new System.Drawing.Size(125, 55);
            this.btnEliminaMomentaneamente.TabIndex = 332;
            this.btnEliminaMomentaneamente.Text = "Elimina Momentaneamente";
            this.btnEliminaMomentaneamente.UseVisualStyleBackColor = false;
            this.btnEliminaMomentaneamente.Click += new System.EventHandler(this.btnEliminaMomentaneamente_Click);
            // 
            // btnLimpaLinha
            // 
            this.btnLimpaLinha.BackColor = System.Drawing.Color.SandyBrown;
            this.btnLimpaLinha.Location = new System.Drawing.Point(621, 577);
            this.btnLimpaLinha.Name = "btnLimpaLinha";
            this.btnLimpaLinha.Size = new System.Drawing.Size(125, 55);
            this.btnLimpaLinha.TabIndex = 333;
            this.btnLimpaLinha.Text = "LimpaLinha";
            this.btnLimpaLinha.UseVisualStyleBackColor = false;
            this.btnLimpaLinha.Click += new System.EventHandler(this.LimpaLinha_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "NoCorte",
            "NF"});
            this.comboBox1.Location = new System.Drawing.Point(480, 638);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 21);
            this.comboBox1.TabIndex = 334;
            this.comboBox1.Text = "Selecione";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(472, 665);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(960, 332);
            this.dataGridView1.TabIndex = 335;
            // 
            // RFID_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1791, 1011);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnLimpaLinha);
            this.Controls.Add(this.btnEliminaMomentaneamente);
            this.Controls.Add(this.btnEnviaParaApontamentoAcerto);
            this.Controls.Add(this.btnVisaizaComarDivergentes);
            this.Controls.Add(this.btnAtualizaListaDeCartoes);
            this.Controls.Add(this.btnListaDeCartoes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvFaltouLer);
            this.Controls.Add(this.btnImprimirComparacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.brnImprimirDivergentes);
            this.Controls.Add(this.lblLinkCarregadp);
            this.Controls.Add(this.btnVisuaizaCompareInventario);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.btnAddIP);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnObterLinks);
            this.Controls.Add(this.webBrowser1);
            this.Name = "RFID_Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFID";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RFID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltouLer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnObterLinks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnAddIP;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnVisuaizaCompareInventario;
        private System.Windows.Forms.Label lblLinkCarregadp;
        private System.Windows.Forms.Button brnImprimirDivergentes;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImprimirComparacao;
        private System.Windows.Forms.DataGridView dgvFaltouLer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnListaDeCartoes;
        private System.Windows.Forms.Button btnAtualizaListaDeCartoes;
        private System.Windows.Forms.Button btnVisaizaComarDivergentes;
        private System.Windows.Forms.Button btnEnviaParaApontamentoAcerto;
        private System.Windows.Forms.Button btnEliminaMomentaneamente;
        private System.Windows.Forms.Button btnLimpaLinha;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}