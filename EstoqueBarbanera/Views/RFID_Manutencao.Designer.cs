using System;
using System.Windows.Forms;

namespace Estoque.Views
{
    partial class RFID_Manutencao
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
            this.txtPrateleira = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbbPesquisar = new System.Windows.Forms.ComboBox();
            this.lblLinhas = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnAplicaPrateleira = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.lblUIDCard = new System.Windows.Forms.Label();
            this.txtUIDCard = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscaUID = new System.Windows.Forms.TextBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnInclui1Item = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInclui1Item = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgvMovimentos2 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prateleira = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultadoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atualiza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpaTudo = new System.Windows.Forms.Button();
            this.btnLimpalinha = new System.Windows.Forms.Button();
            this.btnSendCartoesES = new System.Windows.Forms.Button();
            this.btnAddCards = new System.Windows.Forms.Button();
            this.btnSendCards = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAlteraPrateleira = new System.Windows.Forms.Button();
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.btnRecuperaGrid = new System.Windows.Forms.Button();
            this.btnDeletaLinha = new System.Windows.Forms.Button();
            this.dgvAddCards = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSelecionaTudo = new System.Windows.Forms.Button();
            this.btnObterListaDeArquivosESP32 = new System.Windows.Forms.Button();
            this.btnDeletarSelecao = new System.Windows.Forms.Button();
            this.clbArquivosESP32 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentos2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddCards)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrateleira
            // 
            this.txtPrateleira.Location = new System.Drawing.Point(217, 191);
            this.txtPrateleira.Name = "txtPrateleira";
            this.txtPrateleira.Size = new System.Drawing.Size(100, 20);
            this.txtPrateleira.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(15, 298);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1409, 316);
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoubleClick_DClick);
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellValueChange_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1251, 252);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 164;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisar.Location = new System.Drawing.Point(1145, 255);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(100, 20);
            this.txtPesquisar.TabIndex = 163;
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
            this.cbbPesquisar.Location = new System.Drawing.Point(1018, 255);
            this.cbbPesquisar.Name = "cbbPesquisar";
            this.cbbPesquisar.Size = new System.Drawing.Size(121, 21);
            this.cbbPesquisar.TabIndex = 162;
            this.cbbPesquisar.Text = "Descricao";
            // 
            // lblLinhas
            // 
            this.lblLinhas.AutoSize = true;
            this.lblLinhas.Location = new System.Drawing.Point(661, 262);
            this.lblLinhas.Name = "lblLinhas";
            this.lblLinhas.Size = new System.Drawing.Size(11, 13);
            this.lblLinhas.TabIndex = 256;
            this.lblLinhas.Text = "*";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 16);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(492, 124);
            this.checkedListBox1.TabIndex = 260;
            this.checkedListBox1.DoubleClick += new System.EventHandler(this.CheckBoxList_DClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 261;
            this.label1.Text = "Prateleira";
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSaveFile.ForeColor = System.Drawing.Color.Black;
            this.btnSaveFile.Location = new System.Drawing.Point(568, 23);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFile.TabIndex = 262;
            this.btnSaveFile.Text = "1- Save File";
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnAplicaPrateleira
            // 
            this.btnAplicaPrateleira.BackColor = System.Drawing.Color.Aqua;
            this.btnAplicaPrateleira.ForeColor = System.Drawing.Color.Black;
            this.btnAplicaPrateleira.Location = new System.Drawing.Point(223, 217);
            this.btnAplicaPrateleira.Name = "btnAplicaPrateleira";
            this.btnAplicaPrateleira.Size = new System.Drawing.Size(94, 23);
            this.btnAplicaPrateleira.TabIndex = 263;
            this.btnAplicaPrateleira.Text = "Aplica Prateleira";
            this.btnAplicaPrateleira.UseVisualStyleBackColor = false;
            this.btnAplicaPrateleira.Click += new System.EventHandler(this.btnAplicaPrateleira_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSendFile.ForeColor = System.Drawing.Color.Black;
            this.btnSendFile.Location = new System.Drawing.Point(568, 65);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 264;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // lblUIDCard
            // 
            this.lblUIDCard.AutoSize = true;
            this.lblUIDCard.Location = new System.Drawing.Point(345, 234);
            this.lblUIDCard.Name = "lblUIDCard";
            this.lblUIDCard.Size = new System.Drawing.Size(51, 13);
            this.lblUIDCard.TabIndex = 266;
            this.lblUIDCard.Text = "UID Card";
            // 
            // txtUIDCard
            // 
            this.txtUIDCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtUIDCard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUIDCard.Location = new System.Drawing.Point(402, 230);
            this.txtUIDCard.MaxLength = 8;
            this.txtUIDCard.Name = "txtUIDCard";
            this.txtUIDCard.Size = new System.Drawing.Size(66, 20);
            this.txtUIDCard.TabIndex = 265;
            this.txtUIDCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UIDCard_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(651, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 268;
            this.label2.Text = "UID Card";
            // 
            // txtBuscaUID
            // 
            this.txtBuscaUID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscaUID.Enabled = false;
            this.txtBuscaUID.Location = new System.Drawing.Point(708, 67);
            this.txtBuscaUID.MaxLength = 8;
            this.txtBuscaUID.Name = "txtBuscaUID";
            this.txtBuscaUID.Size = new System.Drawing.Size(66, 20);
            this.txtBuscaUID.TabIndex = 267;
            this.txtBuscaUID.TextChanged += new System.EventHandler(this.BuscaFiles_Changes);
            this.txtBuscaUID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UIDCard_KeyPress);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Busca um item",
            "Seleciona no grid",
            "UID Card = Hexa do UID Card",
            "btn  1- Save Card"});
            this.checkedListBox2.Location = new System.Drawing.Point(15, 198);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox2.TabIndex = 269;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(568, 94);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(359, 95);
            this.listBox1.TabIndex = 270;
            this.listBox1.DoubleClick += new System.EventHandler(this.ListBox_DClixk);
            // 
            // btnInclui1Item
            // 
            this.btnInclui1Item.BackColor = System.Drawing.Color.PaleGreen;
            this.btnInclui1Item.ForeColor = System.Drawing.Color.Black;
            this.btnInclui1Item.Location = new System.Drawing.Point(571, 217);
            this.btnInclui1Item.Name = "btnInclui1Item";
            this.btnInclui1Item.Size = new System.Drawing.Size(75, 23);
            this.btnInclui1Item.TabIndex = 277;
            this.btnInclui1Item.Text = "Inclui 1 Item";
            this.btnInclui1Item.UseVisualStyleBackColor = false;
            this.btnInclui1Item.Click += new System.EventHandler(this.btnInclui1Item_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(652, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 279;
            this.label5.Text = "UID Card";
            // 
            // txtInclui1Item
            // 
            this.txtInclui1Item.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInclui1Item.Location = new System.Drawing.Point(709, 219);
            this.txtInclui1Item.MaxLength = 8;
            this.txtInclui1Item.Name = "txtInclui1Item";
            this.txtInclui1Item.Size = new System.Drawing.Size(66, 20);
            this.txtInclui1Item.TabIndex = 278;
            this.txtInclui1Item.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UIDCard_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "DISPONIVEL",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(781, 218);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 21);
            this.comboBox1.TabIndex = 280;
            this.comboBox1.Text = "POSICAO";
            // 
            // dgvMovimentos2
            // 
            this.dgvMovimentos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimentos2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descricao,
            this.SaldoAtual,
            this.Prateleira,
            this.Saida,
            this.Entrada,
            this.SaldoES,
            this.ResultadoFinal,
            this.Atualiza});
            this.dgvMovimentos2.Location = new System.Drawing.Point(11, 14);
            this.dgvMovimentos2.Name = "dgvMovimentos2";
            this.dgvMovimentos2.Size = new System.Drawing.Size(943, 316);
            this.dgvMovimentos2.TabIndex = 281;
            this.dgvMovimentos2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEndEdit2);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descricao";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // SaldoAtual
            // 
            this.SaldoAtual.HeaderText = "SaldoAtual M";
            this.SaldoAtual.Name = "SaldoAtual";
            this.SaldoAtual.ReadOnly = true;
            // 
            // Prateleira
            // 
            this.Prateleira.HeaderText = "Prateleira";
            this.Prateleira.Name = "Prateleira";
            this.Prateleira.ReadOnly = true;
            // 
            // Saida
            // 
            this.Saida.HeaderText = "Saida(-) M";
            this.Saida.Name = "Saida";
            // 
            // Entrada
            // 
            this.Entrada.HeaderText = "Entrada(+) M";
            this.Entrada.Name = "Entrada";
            // 
            // SaldoES
            // 
            this.SaldoES.HeaderText = "SaldoES M";
            this.SaldoES.Name = "SaldoES";
            this.SaldoES.ReadOnly = true;
            // 
            // ResultadoFinal
            // 
            this.ResultadoFinal.HeaderText = "ResultadoFinal M";
            this.ResultadoFinal.Name = "ResultadoFinal";
            this.ResultadoFinal.ReadOnly = true;
            // 
            // Atualiza
            // 
            this.Atualiza.HeaderText = "Atualiza M";
            this.Atualiza.Name = "Atualiza";
            // 
            // btnLimpaTudo
            // 
            this.btnLimpaTudo.Location = new System.Drawing.Point(985, 145);
            this.btnLimpaTudo.Name = "btnLimpaTudo";
            this.btnLimpaTudo.Size = new System.Drawing.Size(75, 23);
            this.btnLimpaTudo.TabIndex = 282;
            this.btnLimpaTudo.Text = "Limpa Tudo";
            this.btnLimpaTudo.UseVisualStyleBackColor = true;
            this.btnLimpaTudo.Click += new System.EventHandler(this.btnLimpaTudo_Click);
            // 
            // btnLimpalinha
            // 
            this.btnLimpalinha.Location = new System.Drawing.Point(985, 90);
            this.btnLimpalinha.Name = "btnLimpalinha";
            this.btnLimpalinha.Size = new System.Drawing.Size(75, 23);
            this.btnLimpalinha.TabIndex = 283;
            this.btnLimpalinha.Text = "Limpa Linha";
            this.btnLimpalinha.UseVisualStyleBackColor = true;
            this.btnLimpalinha.Click += new System.EventHandler(this.btnLimpalinha_Click);
            // 
            // btnSendCartoesES
            // 
            this.btnSendCartoesES.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSendCartoesES.Location = new System.Drawing.Point(985, 202);
            this.btnSendCartoesES.Name = "btnSendCartoesES";
            this.btnSendCartoesES.Size = new System.Drawing.Size(97, 36);
            this.btnSendCartoesES.TabIndex = 284;
            this.btnSendCartoesES.Text = "Send Cartões Entrada/Saida";
            this.btnSendCartoesES.UseVisualStyleBackColor = false;
            this.btnSendCartoesES.Click += new System.EventHandler(this.btnSendCartaoES_Click);
            // 
            // btnAddCards
            // 
            this.btnAddCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddCards.ForeColor = System.Drawing.Color.Black;
            this.btnAddCards.Location = new System.Drawing.Point(355, 187);
            this.btnAddCards.Name = "btnAddCards";
            this.btnAddCards.Size = new System.Drawing.Size(94, 35);
            this.btnAddCards.TabIndex = 288;
            this.btnAddCards.Text = "Add Cards no Grid";
            this.btnAddCards.UseVisualStyleBackColor = false;
            this.btnAddCards.Click += new System.EventHandler(this.btnAddCard_Click);
            // 
            // btnSendCards
            // 
            this.btnSendCards.BackColor = System.Drawing.Color.Aqua;
            this.btnSendCards.ForeColor = System.Drawing.Color.Black;
            this.btnSendCards.Location = new System.Drawing.Point(1315, 747);
            this.btnSendCards.Name = "btnSendCards";
            this.btnSendCards.Size = new System.Drawing.Size(94, 23);
            this.btnSendCards.TabIndex = 289;
            this.btnSendCards.Text = "Send Cards";
            this.btnSendCards.UseVisualStyleBackColor = false;
            this.btnSendCards.Click += new System.EventHandler(this.btnSendCards_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1443, 822);
            this.tabControl1.TabIndex = 290;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLimpalinha);
            this.tabPage1.Controls.Add(this.btnLimpaTudo);
            this.tabPage1.Controls.Add(this.btnSendCartoesES);
            this.tabPage1.Controls.Add(this.dgvMovimentos2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1435, 796);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manutencao Diaria";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAlteraPrateleira);
            this.tabPage2.Controls.Add(this.btnClearGrid);
            this.tabPage2.Controls.Add(this.btnRecuperaGrid);
            this.tabPage2.Controls.Add(this.btnDeletaLinha);
            this.tabPage2.Controls.Add(this.dgvAddCards);
            this.tabPage2.Controls.Add(this.checkedListBox1);
            this.tabPage2.Controls.Add(this.dgv);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.btnSendCards);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.checkedListBox2);
            this.tabPage2.Controls.Add(this.txtInclui1Item);
            this.tabPage2.Controls.Add(this.btnAddCards);
            this.tabPage2.Controls.Add(this.btnInclui1Item);
            this.tabPage2.Controls.Add(this.txtUIDCard);
            this.tabPage2.Controls.Add(this.btnAplicaPrateleira);
            this.tabPage2.Controls.Add(this.btnSaveFile);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblLinhas);
            this.tabPage2.Controls.Add(this.btnSendFile);
            this.tabPage2.Controls.Add(this.btnPesquisar);
            this.tabPage2.Controls.Add(this.lblUIDCard);
            this.tabPage2.Controls.Add(this.txtPesquisar);
            this.tabPage2.Controls.Add(this.txtBuscaUID);
            this.tabPage2.Controls.Add(this.cbbPesquisar);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtPrateleira);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1435, 796);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cria Cartoes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAlteraPrateleira
            // 
            this.btnAlteraPrateleira.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAlteraPrateleira.ForeColor = System.Drawing.Color.Black;
            this.btnAlteraPrateleira.Location = new System.Drawing.Point(1315, 678);
            this.btnAlteraPrateleira.Name = "btnAlteraPrateleira";
            this.btnAlteraPrateleira.Size = new System.Drawing.Size(109, 23);
            this.btnAlteraPrateleira.TabIndex = 294;
            this.btnAlteraPrateleira.Text = "Altera Prateleira";
            this.btnAlteraPrateleira.UseVisualStyleBackColor = false;
            this.btnAlteraPrateleira.Click += new System.EventHandler(this.btnAlteraPrateleira_Click);
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearGrid.Location = new System.Drawing.Point(1315, 649);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(109, 23);
            this.btnClearGrid.TabIndex = 293;
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.UseVisualStyleBackColor = true;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // btnRecuperaGrid
            // 
            this.btnRecuperaGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperaGrid.Location = new System.Drawing.Point(1315, 707);
            this.btnRecuperaGrid.Name = "btnRecuperaGrid";
            this.btnRecuperaGrid.Size = new System.Drawing.Size(109, 23);
            this.btnRecuperaGrid.TabIndex = 292;
            this.btnRecuperaGrid.Text = "Recupera Grid";
            this.btnRecuperaGrid.UseVisualStyleBackColor = true;
            this.btnRecuperaGrid.Click += new System.EventHandler(this.btnRecuperaGrid_Click);
            // 
            // btnDeletaLinha
            // 
            this.btnDeletaLinha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletaLinha.Location = new System.Drawing.Point(1315, 620);
            this.btnDeletaLinha.Name = "btnDeletaLinha";
            this.btnDeletaLinha.Size = new System.Drawing.Size(90, 23);
            this.btnDeletaLinha.TabIndex = 291;
            this.btnDeletaLinha.Text = "Deleta Linha";
            this.btnDeletaLinha.UseVisualStyleBackColor = true;
            this.btnDeletaLinha.Click += new System.EventHandler(this.btnDeletaLinha_Click);
            // 
            // dgvAddCards
            // 
            this.dgvAddCards.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvAddCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddCards.Location = new System.Drawing.Point(15, 620);
            this.dgvAddCards.Name = "dgvAddCards";
            this.dgvAddCards.Size = new System.Drawing.Size(1270, 150);
            this.dgvAddCards.TabIndex = 290;
            this.dgvAddCards.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellEndEdit);
            this.dgvAddCards.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddCards_CellValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSelecionaTudo);
            this.tabPage3.Controls.Add(this.btnObterListaDeArquivosESP32);
            this.tabPage3.Controls.Add(this.btnDeletarSelecao);
            this.tabPage3.Controls.Add(this.clbArquivosESP32);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1435, 796);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Deleta Files ESP32";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSelecionaTudo
            // 
            this.btnSelecionaTudo.BackColor = System.Drawing.Color.Aqua;
            this.btnSelecionaTudo.ForeColor = System.Drawing.Color.Black;
            this.btnSelecionaTudo.Location = new System.Drawing.Point(12, 101);
            this.btnSelecionaTudo.Name = "btnSelecionaTudo";
            this.btnSelecionaTudo.Size = new System.Drawing.Size(109, 38);
            this.btnSelecionaTudo.TabIndex = 292;
            this.btnSelecionaTudo.Text = "Seleciona Tudo";
            this.btnSelecionaTudo.UseVisualStyleBackColor = false;
            this.btnSelecionaTudo.Click += new System.EventHandler(this.btnSelecionaTudo_Click);
            // 
            // btnObterListaDeArquivosESP32
            // 
            this.btnObterListaDeArquivosESP32.BackColor = System.Drawing.Color.Aqua;
            this.btnObterListaDeArquivosESP32.ForeColor = System.Drawing.Color.Black;
            this.btnObterListaDeArquivosESP32.Location = new System.Drawing.Point(12, 23);
            this.btnObterListaDeArquivosESP32.Name = "btnObterListaDeArquivosESP32";
            this.btnObterListaDeArquivosESP32.Size = new System.Drawing.Size(109, 38);
            this.btnObterListaDeArquivosESP32.TabIndex = 288;
            this.btnObterListaDeArquivosESP32.Text = "Obter Lista de Arquivos";
            this.btnObterListaDeArquivosESP32.UseVisualStyleBackColor = false;
            this.btnObterListaDeArquivosESP32.Click += new System.EventHandler(this.btnObterListaDeArquivosESP32_Click);
            // 
            // btnDeletarSelecao
            // 
            this.btnDeletarSelecao.BackColor = System.Drawing.Color.Aqua;
            this.btnDeletarSelecao.ForeColor = System.Drawing.Color.Black;
            this.btnDeletarSelecao.Location = new System.Drawing.Point(12, 190);
            this.btnDeletarSelecao.Name = "btnDeletarSelecao";
            this.btnDeletarSelecao.Size = new System.Drawing.Size(109, 38);
            this.btnDeletarSelecao.TabIndex = 291;
            this.btnDeletarSelecao.Text = "Deletar Seleção";
            this.btnDeletarSelecao.UseVisualStyleBackColor = false;
            this.btnDeletarSelecao.Click += new System.EventHandler(this.btnDeletarSelecao_Click);
            // 
            // clbArquivosESP32
            // 
            this.clbArquivosESP32.FormattingEnabled = true;
            this.clbArquivosESP32.Location = new System.Drawing.Point(151, 18);
            this.clbArquivosESP32.Name = "clbArquivosESP32";
            this.clbArquivosESP32.Size = new System.Drawing.Size(350, 544);
            this.clbArquivosESP32.TabIndex = 290;
            // 
            // RFID_Manutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 846);
            this.Controls.Add(this.tabControl1);
            this.Name = "RFID_Manutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFID_Manutencao";
            this.Load += new System.EventHandler(this.Load_L);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentos2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddCards)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

      

        #endregion

        private System.Windows.Forms.TextBox txtPrateleira;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbbPesquisar;
        private System.Windows.Forms.Label lblLinhas;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnAplicaPrateleira;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Label lblUIDCard;
        private System.Windows.Forms.TextBox txtUIDCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscaUID;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnInclui1Item;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInclui1Item;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgvMovimentos2;
        private Button btnLimpaTudo;
        private Button btnLimpalinha;
        private Button btnSendCartoesES;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn SaldoAtual;
        private DataGridViewTextBoxColumn Prateleira;
        private DataGridViewTextBoxColumn Saida;
        private DataGridViewTextBoxColumn Entrada;
        private DataGridViewTextBoxColumn SaldoES;
        private DataGridViewTextBoxColumn ResultadoFinal;
        private DataGridViewTextBoxColumn Atualiza;
        private Button btnAddCards;
        private Button btnSendCards;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button btnObterListaDeArquivosESP32;
        private Button btnDeletarSelecao;
        private CheckedListBox clbArquivosESP32;
        private Button btnSelecionaTudo;
        private DataGridView dgvAddCards;
        private Button btnDeletaLinha;
        private Button btnRecuperaGrid;
        private Button btnClearGrid;
        private Button btnAlteraPrateleira;

        public EventHandler Load_ { get; private set; }
    }
}