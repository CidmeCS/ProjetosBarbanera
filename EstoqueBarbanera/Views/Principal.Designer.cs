namespace Estoque
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnExports = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbbPesquisar = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblMedidas = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnTabConvExcel = new System.Windows.Forms.Button();
            this.btnCriarKgM = new System.Windows.Forms.Button();
            this.txtKg_Metro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProduto_MatPrima = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod_Produto = new System.Windows.Forms.TextBox();
            this.btnSaldoMensal = new System.Windows.Forms.Button();
            this.btnCalculos = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnEstoqueMinimoComPrevisao = new System.Windows.Forms.Button();
            this.lblLinhas = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMaterialParado = new System.Windows.Forms.Button();
            this.btnInativarItensParados = new System.Windows.Forms.Button();
            this.btnEntregaDeTerceiro = new System.Windows.Forms.Button();
            this.btnDigitalizaOPsScaneadas = new System.Windows.Forms.Button();
            this.btnVerificaOPsLiberadas = new System.Windows.Forms.Button();
            this.btnRFIDManutencao = new System.Windows.Forms.Button();
            this.btnReceberNFs = new System.Windows.Forms.Button();
            this.btnCalcularOPs = new System.Windows.Forms.Button();
            this.btnObterDadosDasOPs = new System.Windows.Forms.Button();
            this.btnRFIDInventario = new System.Windows.Forms.Button();
            this.btnApontamentos = new System.Windows.Forms.Button();
            this.btnTeste = new System.Windows.Forms.Button();
            this.btnCarregaAtualizacoes = new System.Windows.Forms.Button();
            this.btnManutencaoDescricao = new System.Windows.Forms.Button();
            this.btnManutemcaoBarrasLongas = new System.Windows.Forms.Button();
            this.btnSequenciaCodigo = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnPrateleiraAtualiza = new System.Windows.Forms.Button();
            this.btnAtualizaEtiqueta = new System.Windows.Forms.Button();
            this.btnLivre17Atualiza = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnG11SemPrateleiraComSaldo = new System.Windows.Forms.Button();
            this.btnPCP = new System.Windows.Forms.Button();
            this.lblMaquina = new System.Windows.Forms.Label();
            this.btnForaEstoque = new System.Windows.Forms.Button();
            this.lblBackUP = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExports
            // 
            this.btnExports.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnExports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExports.Location = new System.Drawing.Point(1044, 12);
            this.btnExports.Name = "btnExports";
            this.btnExports.Size = new System.Drawing.Size(75, 31);
            this.btnExports.TabIndex = 7;
            this.btnExports.Text = "Exports";
            this.btnExports.UseVisualStyleBackColor = false;
            this.btnExports.Click += new System.EventHandler(this.btnExports_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisar.Location = new System.Drawing.Point(847, 141);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(100, 20);
            this.txtPesquisar.TabIndex = 159;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            this.txtPesquisar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pesquisar_KeyPress);
            // 
            // cbbPesquisar
            // 
            this.cbbPesquisar.FormattingEnabled = true;
            this.cbbPesquisar.Items.AddRange(new object[] {
            "Produto",
            "Descricao",
            "Unid",
            "SaldoAtual",
            "EstqMinimo",
            "EstqMaximo",
            "Prateleira",
            "PedCompras",
            "Grupo",
            "DiasSemMovimento"});
            this.cbbPesquisar.Location = new System.Drawing.Point(720, 141);
            this.cbbPesquisar.Name = "cbbPesquisar";
            this.cbbPesquisar.Size = new System.Drawing.Size(121, 21);
            this.cbbPesquisar.TabIndex = 158;
            this.cbbPesquisar.Text = "Descricao";
            this.cbbPesquisar.SelectedIndexChanged += new System.EventHandler(this.cbbPesquisar_SelectedIndexChanged);
            this.cbbPesquisar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pesquisar_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1416, 633);
            this.dataGridView1.TabIndex = 160;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(953, 138);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 161;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pesquisar_KeyPress);
            // 
            // lblMedidas
            // 
            this.lblMedidas.AutoSize = true;
            this.lblMedidas.Location = new System.Drawing.Point(846, 174);
            this.lblMedidas.Name = "lblMedidas";
            this.lblMedidas.Size = new System.Drawing.Size(47, 13);
            this.lblMedidas.TabIndex = 219;
            this.lblMedidas.Text = "Medidas";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1/32",
            "1/16",
            "3/32",
            "1/8",
            "5/32",
            "3/16",
            "7/32",
            "1/4",
            "9/32",
            "5/16",
            "11/32",
            "3/8",
            "13/32",
            "7/16",
            "15/32",
            "1/2",
            "17/32",
            "9/16",
            "19/32",
            "5/8",
            "21/32",
            "11/16",
            "23/32",
            "3/4",
            "25/32",
            "13/16",
            "27/32",
            "7/8",
            "29/32",
            "15/16",
            "31/32",
            "1\'",
            "1.1/32",
            "1.1/16",
            "1.3/32",
            "1.1/8",
            "1.5/32",
            "1.3/16",
            "1.7/32",
            "1.1/4",
            "1.9/32",
            "1.5/16",
            "1.11/32",
            "1.3/8",
            "1.13/32",
            "1.7/16",
            "1.15/32",
            "1.1/2",
            "1.17/32",
            "1.9/16",
            "1.19/32",
            "1.5/8",
            "1.21/32",
            "1.11/16",
            "1.23/32",
            "1.3/4",
            "1.25/32",
            "1.13/16",
            "1.27/32",
            "1.7/8",
            "1.29/32",
            "1.15/16",
            "1.31/32",
            "2\'",
            "2.1/16",
            "2.1/8",
            "2.3/16",
            "2.1/4",
            "2.5/16",
            "2.3/8",
            "2.7/16",
            "2.1/2",
            "2.9/16",
            "2.5/8",
            "2.11/16",
            "2.3/4",
            "2.13/16",
            "2.7/8",
            "2.15/16",
            "3\'",
            "3.1/8",
            "3.1/4",
            "3.3/8",
            "3.1/2",
            "3.5/8",
            "3.3/4",
            "3.7/8",
            "4\'",
            "4.1/4",
            "4.1/2",
            "4.3/4",
            "5\'",
            "5.1/4",
            "5.1/2",
            "5.3/4",
            "6\'",
            "6.1/4",
            "6.1/2",
            "6.3/4",
            "7\'",
            "7.1/4",
            "7.1/2",
            "7.3/4",
            "8\'",
            "8.1/4",
            "8.1/2",
            "8.3/4",
            "9\'",
            "9.1/4",
            "9.1/2",
            "9.3/4",
            "10\'",
            "10.1/4",
            "10.1/2",
            "10.3/4",
            "11\'",
            "11.1/4",
            "11.1/2",
            "11.3/4",
            "12\'",
            "12.1/4",
            "12.1/2",
            "12.3/4",
            "13\'",
            "13.1/4",
            "13.1/2",
            "13.3/4",
            "14\'",
            "14.1/4",
            "14.1/2",
            "14.3/4",
            "15\'",
            "15.1/4",
            "15.1/2",
            "15.3/4",
            "16\'",
            "16.1/4",
            "16.1/2",
            "16.3/4",
            "17\'",
            "17.1/4",
            "17.1/2",
            "17.3/4",
            "18\'",
            "18.1/4",
            "18.1/2",
            "18.3/4",
            "19\'",
            "19.1/4",
            "19.1/2",
            "19.3/4",
            "20\'",
            "20.1/4",
            "20.1/2",
            "20.3/4",
            "21\'",
            "21.1/4",
            "21.1/2",
            "21.3/4",
            "22\'",
            "22.1/4",
            "22.1/2",
            "22.3/4",
            "23\'"});
            this.comboBox1.Location = new System.Drawing.Point(720, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 218;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.cbbMedidas);
            // 
            // btnTabConvExcel
            // 
            this.btnTabConvExcel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTabConvExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabConvExcel.Location = new System.Drawing.Point(801, 86);
            this.btnTabConvExcel.Name = "btnTabConvExcel";
            this.btnTabConvExcel.Size = new System.Drawing.Size(75, 36);
            this.btnTabConvExcel.TabIndex = 234;
            this.btnTabConvExcel.Text = "TabConv Excel";
            this.btnTabConvExcel.UseVisualStyleBackColor = false;
            this.btnTabConvExcel.Click += new System.EventHandler(this.btnTabConvExcel_Click);
            // 
            // btnCriarKgM
            // 
            this.btnCriarKgM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarKgM.Location = new System.Drawing.Point(720, 86);
            this.btnCriarKgM.Name = "btnCriarKgM";
            this.btnCriarKgM.Size = new System.Drawing.Size(75, 23);
            this.btnCriarKgM.TabIndex = 233;
            this.btnCriarKgM.Text = "Criar Kg/M";
            this.btnCriarKgM.UseVisualStyleBackColor = true;
            this.btnCriarKgM.Click += new System.EventHandler(this.btnCriarKgM_Click);
            // 
            // txtKg_Metro
            // 
            this.txtKg_Metro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKg_Metro.Location = new System.Drawing.Point(720, 63);
            this.txtKg_Metro.MaxLength = 30;
            this.txtKg_Metro.Name = "txtKg_Metro";
            this.txtKg_Metro.Size = new System.Drawing.Size(146, 20);
            this.txtKg_Metro.TabIndex = 232;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 236;
            this.label2.Text = "Produto/Mat.Prima";
            // 
            // txtProduto_MatPrima
            // 
            this.txtProduto_MatPrima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProduto_MatPrima.Location = new System.Drawing.Point(16, 154);
            this.txtProduto_MatPrima.MaxLength = 100;
            this.txtProduto_MatPrima.Multiline = true;
            this.txtProduto_MatPrima.Name = "txtProduto_MatPrima";
            this.txtProduto_MatPrima.Size = new System.Drawing.Size(287, 32);
            this.txtProduto_MatPrima.TabIndex = 235;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 238;
            this.label1.Text = "Código";
            // 
            // txtCod_Produto
            // 
            this.txtCod_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCod_Produto.Location = new System.Drawing.Point(16, 102);
            this.txtCod_Produto.MaxLength = 10;
            this.txtCod_Produto.Name = "txtCod_Produto";
            this.txtCod_Produto.Size = new System.Drawing.Size(100, 20);
            this.txtCod_Produto.TabIndex = 237;
            // 
            // btnSaldoMensal
            // 
            this.btnSaldoMensal.BackColor = System.Drawing.Color.Tomato;
            this.btnSaldoMensal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaldoMensal.Location = new System.Drawing.Point(1125, 90);
            this.btnSaldoMensal.Name = "btnSaldoMensal";
            this.btnSaldoMensal.Size = new System.Drawing.Size(75, 36);
            this.btnSaldoMensal.TabIndex = 240;
            this.btnSaldoMensal.Text = "Saldo Mensal";
            this.btnSaldoMensal.UseVisualStyleBackColor = false;
            this.btnSaldoMensal.Click += new System.EventHandler(this.btnSaldoMensal_Click);
            // 
            // btnCalculos
            // 
            this.btnCalculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculos.Location = new System.Drawing.Point(1125, 132);
            this.btnCalculos.Name = "btnCalculos";
            this.btnCalculos.Size = new System.Drawing.Size(75, 30);
            this.btnCalculos.TabIndex = 241;
            this.btnCalculos.Text = "Calculos";
            this.btnCalculos.UseVisualStyleBackColor = true;
            this.btnCalculos.Click += new System.EventHandler(this.btnCalculos_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Location = new System.Drawing.Point(1125, 7);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(84, 36);
            this.btnInventario.TabIndex = 242;
            this.btnInventario.Text = "Inventarios";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnEstoqueMinimoComPrevisao
            // 
            this.btnEstoqueMinimoComPrevisao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEstoqueMinimoComPrevisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoqueMinimoComPrevisao.Location = new System.Drawing.Point(1125, 46);
            this.btnEstoqueMinimoComPrevisao.Name = "btnEstoqueMinimoComPrevisao";
            this.btnEstoqueMinimoComPrevisao.Size = new System.Drawing.Size(75, 37);
            this.btnEstoqueMinimoComPrevisao.TabIndex = 243;
            this.btnEstoqueMinimoComPrevisao.Text = "Estoque Mínimo";
            this.btnEstoqueMinimoComPrevisao.UseVisualStyleBackColor = false;
            this.btnEstoqueMinimoComPrevisao.Click += new System.EventHandler(this.EstoqueMinimoComPrevisao);
            // 
            // lblLinhas
            // 
            this.lblLinhas.AutoSize = true;
            this.lblLinhas.Location = new System.Drawing.Point(467, 154);
            this.lblLinhas.Name = "lblLinhas";
            this.lblLinhas.Size = new System.Drawing.Size(11, 13);
            this.lblLinhas.TabIndex = 255;
            this.lblLinhas.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 257;
            this.label3.Text = "Kg/M";
            // 
            // btnMaterialParado
            // 
            this.btnMaterialParado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterialParado.Location = new System.Drawing.Point(1044, 49);
            this.btnMaterialParado.Name = "btnMaterialParado";
            this.btnMaterialParado.Size = new System.Drawing.Size(75, 34);
            this.btnMaterialParado.TabIndex = 258;
            this.btnMaterialParado.Text = "Material Parado";
            this.btnMaterialParado.UseVisualStyleBackColor = true;
            this.btnMaterialParado.Click += new System.EventHandler(this.btnMaterialParado_Click);
            // 
            // btnInativarItensParados
            // 
            this.btnInativarItensParados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInativarItensParados.Location = new System.Drawing.Point(922, 14);
            this.btnInativarItensParados.Name = "btnInativarItensParados";
            this.btnInativarItensParados.Size = new System.Drawing.Size(91, 34);
            this.btnInativarItensParados.TabIndex = 259;
            this.btnInativarItensParados.Text = "Inativar Itens Parados";
            this.btnInativarItensParados.UseVisualStyleBackColor = true;
            this.btnInativarItensParados.Click += new System.EventHandler(this.btnInativarItensParados_Click);
            // 
            // btnEntregaDeTerceiro
            // 
            this.btnEntregaDeTerceiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEntregaDeTerceiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregaDeTerceiro.Location = new System.Drawing.Point(1220, 6);
            this.btnEntregaDeTerceiro.Name = "btnEntregaDeTerceiro";
            this.btnEntregaDeTerceiro.Size = new System.Drawing.Size(86, 37);
            this.btnEntregaDeTerceiro.TabIndex = 260;
            this.btnEntregaDeTerceiro.Text = "Entrega DeTerceiro";
            this.btnEntregaDeTerceiro.UseVisualStyleBackColor = false;
            this.btnEntregaDeTerceiro.Click += new System.EventHandler(this.btnEntregaDeTerceiro_Click);
            // 
            // btnDigitalizaOPsScaneadas
            // 
            this.btnDigitalizaOPsScaneadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDigitalizaOPsScaneadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDigitalizaOPsScaneadas.Location = new System.Drawing.Point(1220, 48);
            this.btnDigitalizaOPsScaneadas.Name = "btnDigitalizaOPsScaneadas";
            this.btnDigitalizaOPsScaneadas.Size = new System.Drawing.Size(106, 37);
            this.btnDigitalizaOPsScaneadas.TabIndex = 261;
            this.btnDigitalizaOPsScaneadas.Text = "Indexação de OPs Scaneadas";
            this.btnDigitalizaOPsScaneadas.UseVisualStyleBackColor = false;
            this.btnDigitalizaOPsScaneadas.Click += new System.EventHandler(this.btnDigitalizaOPsScaneadas_Click);
            // 
            // btnVerificaOPsLiberadas
            // 
            this.btnVerificaOPsLiberadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVerificaOPsLiberadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificaOPsLiberadas.Location = new System.Drawing.Point(1220, 89);
            this.btnVerificaOPsLiberadas.Name = "btnVerificaOPsLiberadas";
            this.btnVerificaOPsLiberadas.Size = new System.Drawing.Size(106, 37);
            this.btnVerificaOPsLiberadas.TabIndex = 262;
            this.btnVerificaOPsLiberadas.Text = "Verificação de OPs Liberadas";
            this.btnVerificaOPsLiberadas.UseVisualStyleBackColor = false;
            this.btnVerificaOPsLiberadas.Click += new System.EventHandler(this.btnVerificaOPsLiberadas_Click);
            // 
            // btnRFIDManutencao
            // 
            this.btnRFIDManutencao.BackColor = System.Drawing.Color.Goldenrod;
            this.btnRFIDManutencao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRFIDManutencao.Location = new System.Drawing.Point(241, 25);
            this.btnRFIDManutencao.Name = "btnRFIDManutencao";
            this.btnRFIDManutencao.Size = new System.Drawing.Size(89, 37);
            this.btnRFIDManutencao.TabIndex = 263;
            this.btnRFIDManutencao.Text = "RFID Manutencao";
            this.btnRFIDManutencao.UseVisualStyleBackColor = false;
            this.btnRFIDManutencao.Click += new System.EventHandler(this.btnRFID_Click);
            // 
            // btnReceberNFs
            // 
            this.btnReceberNFs.BackColor = System.Drawing.Color.Goldenrod;
            this.btnReceberNFs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceberNFs.Location = new System.Drawing.Point(1321, 138);
            this.btnReceberNFs.Name = "btnReceberNFs";
            this.btnReceberNFs.Size = new System.Drawing.Size(80, 37);
            this.btnReceberNFs.TabIndex = 264;
            this.btnReceberNFs.Text = "Receber NFs";
            this.btnReceberNFs.UseVisualStyleBackColor = false;
            this.btnReceberNFs.Click += new System.EventHandler(this.btnReceberNFs_Click);
            // 
            // btnCalcularOPs
            // 
            this.btnCalcularOPs.BackColor = System.Drawing.Color.IndianRed;
            this.btnCalcularOPs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularOPs.Location = new System.Drawing.Point(1332, 89);
            this.btnCalcularOPs.Name = "btnCalcularOPs";
            this.btnCalcularOPs.Size = new System.Drawing.Size(80, 37);
            this.btnCalcularOPs.TabIndex = 265;
            this.btnCalcularOPs.Text = "Calcular OPs";
            this.btnCalcularOPs.UseVisualStyleBackColor = false;
            this.btnCalcularOPs.Click += new System.EventHandler(this.btnCalcularOPs_Click);
            // 
            // btnObterDadosDasOPs
            // 
            this.btnObterDadosDasOPs.BackColor = System.Drawing.Color.IndianRed;
            this.btnObterDadosDasOPs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObterDadosDasOPs.Location = new System.Drawing.Point(1341, 14);
            this.btnObterDadosDasOPs.Name = "btnObterDadosDasOPs";
            this.btnObterDadosDasOPs.Size = new System.Drawing.Size(91, 37);
            this.btnObterDadosDasOPs.TabIndex = 266;
            this.btnObterDadosDasOPs.Text = "Obter Dados Das OPs";
            this.btnObterDadosDasOPs.UseVisualStyleBackColor = false;
            this.btnObterDadosDasOPs.Click += new System.EventHandler(this.btnObterDadosDasOPs_Click);
            // 
            // btnRFIDInventario
            // 
            this.btnRFIDInventario.BackColor = System.Drawing.Color.Goldenrod;
            this.btnRFIDInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRFIDInventario.Location = new System.Drawing.Point(241, 72);
            this.btnRFIDInventario.Name = "btnRFIDInventario";
            this.btnRFIDInventario.Size = new System.Drawing.Size(89, 37);
            this.btnRFIDInventario.TabIndex = 268;
            this.btnRFIDInventario.Text = "RFID Inventario";
            this.btnRFIDInventario.UseVisualStyleBackColor = false;
            this.btnRFIDInventario.Click += new System.EventHandler(this.btnRFIDInventario_Click);
            // 
            // btnApontamentos
            // 
            this.btnApontamentos.BackColor = System.Drawing.Color.Orange;
            this.btnApontamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApontamentos.Location = new System.Drawing.Point(365, 25);
            this.btnApontamentos.Name = "btnApontamentos";
            this.btnApontamentos.Size = new System.Drawing.Size(99, 37);
            this.btnApontamentos.TabIndex = 269;
            this.btnApontamentos.Text = "Apontamentos";
            this.btnApontamentos.UseVisualStyleBackColor = false;
            this.btnApontamentos.Click += new System.EventHandler(this.btnApontamentos_Click);
            // 
            // btnTeste
            // 
            this.btnTeste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeste.Location = new System.Drawing.Point(470, 32);
            this.btnTeste.Name = "btnTeste";
            this.btnTeste.Size = new System.Drawing.Size(75, 23);
            this.btnTeste.TabIndex = 256;
            this.btnTeste.Text = "TESTE";
            this.btnTeste.UseVisualStyleBackColor = true;
            this.btnTeste.Click += new System.EventHandler(this.btnTeste_Click);
            // 
            // btnCarregaAtualizacoes
            // 
            this.btnCarregaAtualizacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregaAtualizacoes.Location = new System.Drawing.Point(309, 154);
            this.btnCarregaAtualizacoes.Name = "btnCarregaAtualizacoes";
            this.btnCarregaAtualizacoes.Size = new System.Drawing.Size(89, 35);
            this.btnCarregaAtualizacoes.TabIndex = 270;
            this.btnCarregaAtualizacoes.Text = "Carrega Atualizações";
            this.btnCarregaAtualizacoes.UseVisualStyleBackColor = true;
            this.btnCarregaAtualizacoes.Click += new System.EventHandler(this.btnCarregaAtualizacoes_Click);
            // 
            // btnManutencaoDescricao
            // 
            this.btnManutencaoDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManutencaoDescricao.Location = new System.Drawing.Point(606, 21);
            this.btnManutencaoDescricao.Name = "btnManutencaoDescricao";
            this.btnManutencaoDescricao.Size = new System.Drawing.Size(85, 34);
            this.btnManutencaoDescricao.TabIndex = 271;
            this.btnManutencaoDescricao.Text = "Descriçãoes Manutenção";
            this.btnManutencaoDescricao.UseVisualStyleBackColor = true;
            this.btnManutencaoDescricao.Click += new System.EventHandler(this.btnManutencaoDescricao_Click);
            // 
            // btnManutemcaoBarrasLongas
            // 
            this.btnManutemcaoBarrasLongas.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnManutemcaoBarrasLongas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManutemcaoBarrasLongas.Location = new System.Drawing.Point(470, 72);
            this.btnManutemcaoBarrasLongas.Name = "btnManutemcaoBarrasLongas";
            this.btnManutemcaoBarrasLongas.Size = new System.Drawing.Size(99, 37);
            this.btnManutemcaoBarrasLongas.TabIndex = 272;
            this.btnManutemcaoBarrasLongas.Text = "Manutenção Barras Longas";
            this.btnManutemcaoBarrasLongas.UseVisualStyleBackColor = false;
            this.btnManutemcaoBarrasLongas.Click += new System.EventHandler(this.btnManutemcaoBarrasLongas_Click);
            // 
            // btnSequenciaCodigo
            // 
            this.btnSequenciaCodigo.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSequenciaCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSequenciaCodigo.Location = new System.Drawing.Point(606, 81);
            this.btnSequenciaCodigo.Name = "btnSequenciaCodigo";
            this.btnSequenciaCodigo.Size = new System.Drawing.Size(75, 41);
            this.btnSequenciaCodigo.TabIndex = 273;
            this.btnSequenciaCodigo.Text = "Sequencia Código";
            this.btnSequenciaCodigo.UseVisualStyleBackColor = false;
            this.btnSequenciaCodigo.Click += new System.EventHandler(this.btnSequenciaCodigo_Click);
            // 
            // btnPrateleiraAtualiza
            // 
            this.btnPrateleiraAtualiza.BackColor = System.Drawing.Color.LightGreen;
            this.btnPrateleiraAtualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrateleiraAtualiza.Location = new System.Drawing.Point(1718, 15);
            this.btnPrateleiraAtualiza.Name = "btnPrateleiraAtualiza";
            this.btnPrateleiraAtualiza.Size = new System.Drawing.Size(85, 34);
            this.btnPrateleiraAtualiza.TabIndex = 274;
            this.btnPrateleiraAtualiza.Text = "Prateleira Atualiza";
            this.btnPrateleiraAtualiza.UseVisualStyleBackColor = false;
            this.btnPrateleiraAtualiza.Click += new System.EventHandler(this.btnPrateleiraAtualiza_Click);
            // 
            // btnAtualizaEtiqueta
            // 
            this.btnAtualizaEtiqueta.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAtualizaEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizaEtiqueta.Location = new System.Drawing.Point(1718, 93);
            this.btnAtualizaEtiqueta.Name = "btnAtualizaEtiqueta";
            this.btnAtualizaEtiqueta.Size = new System.Drawing.Size(89, 37);
            this.btnAtualizaEtiqueta.TabIndex = 275;
            this.btnAtualizaEtiqueta.Text = "Atualiza Etiqueta";
            this.btnAtualizaEtiqueta.UseVisualStyleBackColor = false;
            this.btnAtualizaEtiqueta.Click += new System.EventHandler(this.btnAtualizaEtiqueta_Click);
            // 
            // btnLivre17Atualiza
            // 
            this.btnLivre17Atualiza.BackColor = System.Drawing.Color.LightGreen;
            this.btnLivre17Atualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLivre17Atualiza.Location = new System.Drawing.Point(1718, 55);
            this.btnLivre17Atualiza.Name = "btnLivre17Atualiza";
            this.btnLivre17Atualiza.Size = new System.Drawing.Size(85, 34);
            this.btnLivre17Atualiza.TabIndex = 276;
            this.btnLivre17Atualiza.Text = "Livre17 Atualiza";
            this.btnLivre17Atualiza.UseVisualStyleBackColor = false;
            this.btnLivre17Atualiza.Click += new System.EventHandler(this.btnLivre17Atualiza_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(174, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 239;
            this.pictureBox2.TabStop = false;
            // 
            // btnG11SemPrateleiraComSaldo
            // 
            this.btnG11SemPrateleiraComSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnG11SemPrateleiraComSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnG11SemPrateleiraComSaldo.Location = new System.Drawing.Point(1679, 244);
            this.btnG11SemPrateleiraComSaldo.Name = "btnG11SemPrateleiraComSaldo";
            this.btnG11SemPrateleiraComSaldo.Size = new System.Drawing.Size(124, 51);
            this.btnG11SemPrateleiraComSaldo.TabIndex = 277;
            this.btnG11SemPrateleiraComSaldo.Text = "G11 S/ Prateleiras C/ Saldo";
            this.btnG11SemPrateleiraComSaldo.UseVisualStyleBackColor = false;
            this.btnG11SemPrateleiraComSaldo.Click += new System.EventHandler(this.btnG11SemPrateleiraComSaldo_Click);
            // 
            // btnPCP
            // 
            this.btnPCP.BackColor = System.Drawing.Color.LightGreen;
            this.btnPCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPCP.Location = new System.Drawing.Point(1718, 301);
            this.btnPCP.Name = "btnPCP";
            this.btnPCP.Size = new System.Drawing.Size(85, 34);
            this.btnPCP.TabIndex = 278;
            this.btnPCP.Text = "PCP";
            this.btnPCP.UseVisualStyleBackColor = false;
            this.btnPCP.Click += new System.EventHandler(this.btnPCP_Click);
            // 
            // lblMaquina
            // 
            this.lblMaquina.AutoSize = true;
            this.lblMaquina.Location = new System.Drawing.Point(238, 119);
            this.lblMaquina.Name = "lblMaquina";
            this.lblMaquina.Size = new System.Drawing.Size(11, 13);
            this.lblMaquina.TabIndex = 279;
            this.lblMaquina.Text = "*";
            // 
            // btnForaEstoque
            // 
            this.btnForaEstoque.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnForaEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForaEstoque.Location = new System.Drawing.Point(1700, 341);
            this.btnForaEstoque.Name = "btnForaEstoque";
            this.btnForaEstoque.Size = new System.Drawing.Size(103, 34);
            this.btnForaEstoque.TabIndex = 280;
            this.btnForaEstoque.Text = "ForaDeEstoque";
            this.btnForaEstoque.UseVisualStyleBackColor = false;
            this.btnForaEstoque.Click += new System.EventHandler(this.btnForaEstoque_Click);
            // 
            // lblBackUP
            // 
            this.lblBackUP.AutoSize = true;
            this.lblBackUP.Location = new System.Drawing.Point(238, 138);
            this.lblBackUP.Name = "lblBackUP";
            this.lblBackUP.Size = new System.Drawing.Size(11, 13);
            this.lblBackUP.TabIndex = 281;
            this.lblBackUP.Text = "*";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1815, 874);
            this.Controls.Add(this.lblBackUP);
            this.Controls.Add(this.btnForaEstoque);
            this.Controls.Add(this.lblMaquina);
            this.Controls.Add(this.btnPCP);
            this.Controls.Add(this.btnG11SemPrateleiraComSaldo);
            this.Controls.Add(this.btnLivre17Atualiza);
            this.Controls.Add(this.btnAtualizaEtiqueta);
            this.Controls.Add(this.btnPrateleiraAtualiza);
            this.Controls.Add(this.btnSequenciaCodigo);
            this.Controls.Add(this.btnManutemcaoBarrasLongas);
            this.Controls.Add(this.btnManutencaoDescricao);
            this.Controls.Add(this.btnCarregaAtualizacoes);
            this.Controls.Add(this.btnApontamentos);
            this.Controls.Add(this.btnRFIDInventario);
            this.Controls.Add(this.btnObterDadosDasOPs);
            this.Controls.Add(this.btnCalcularOPs);
            this.Controls.Add(this.btnReceberNFs);
            this.Controls.Add(this.btnRFIDManutencao);
            this.Controls.Add(this.btnVerificaOPsLiberadas);
            this.Controls.Add(this.btnDigitalizaOPsScaneadas);
            this.Controls.Add(this.btnEntregaDeTerceiro);
            this.Controls.Add(this.btnInativarItensParados);
            this.Controls.Add(this.btnMaterialParado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTeste);
            this.Controls.Add(this.lblLinhas);
            this.Controls.Add(this.btnEstoqueMinimoComPrevisao);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.btnCalculos);
            this.Controls.Add(this.btnSaldoMensal);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCod_Produto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProduto_MatPrima);
            this.Controls.Add(this.btnTabConvExcel);
            this.Controls.Add(this.btnCriarKgM);
            this.Controls.Add(this.txtKg_Metro);
            this.Controls.Add(this.lblMedidas);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.cbbPesquisar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExports);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExports;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbbPesquisar;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblMedidas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnTabConvExcel;
        private System.Windows.Forms.Button btnCriarKgM;
        private System.Windows.Forms.TextBox txtKg_Metro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProduto_MatPrima;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCod_Produto;
        private System.Windows.Forms.Button btnSaldoMensal;
        private System.Windows.Forms.Button btnCalculos;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnEstoqueMinimoComPrevisao;
        private System.Windows.Forms.Label lblLinhas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMaterialParado;
        private System.Windows.Forms.Button btnInativarItensParados;
        private System.Windows.Forms.Button btnEntregaDeTerceiro;
        private System.Windows.Forms.Button btnDigitalizaOPsScaneadas;
        private System.Windows.Forms.Button btnVerificaOPsLiberadas;
        private System.Windows.Forms.Button btnRFIDManutencao;
        private System.Windows.Forms.Button btnReceberNFs;
        private System.Windows.Forms.Button btnCalcularOPs;
        private System.Windows.Forms.Button btnObterDadosDasOPs;
        private System.Windows.Forms.Button btnRFIDInventario;
        private System.Windows.Forms.Button btnApontamentos;
        private System.Windows.Forms.Button btnTeste;
        private System.Windows.Forms.Button btnCarregaAtualizacoes;
        private System.Windows.Forms.Button btnManutencaoDescricao;
        private System.Windows.Forms.Button btnManutemcaoBarrasLongas;
        private System.Windows.Forms.Button btnSequenciaCodigo;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnPrateleiraAtualiza;
        private System.Windows.Forms.Button btnAtualizaEtiqueta;
        private System.Windows.Forms.Button btnLivre17Atualiza;
        private System.Windows.Forms.Button btnG11SemPrateleiraComSaldo;
        private System.Windows.Forms.Button btnPCP;
        public System.Windows.Forms.Label lblMaquina;
        private System.Windows.Forms.Button btnForaEstoque;
        public System.Windows.Forms.Label lblBackUP;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

