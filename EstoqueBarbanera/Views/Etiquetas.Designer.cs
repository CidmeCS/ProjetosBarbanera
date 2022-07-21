
namespace Estoque.Views
{
    partial class Etiquetas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MovimentacaoDiaria = new System.Windows.Forms.TabPage();
            this.btnLimpalinha = new System.Windows.Forms.Button();
            this.btnLimpaTudo = new System.Windows.Forms.Button();
            this.btnAtualizaEtiqueta = new System.Windows.Forms.Button();
            this.dgvMovimentos2 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Convertido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prateleira = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atualiza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewSaldoAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewConvertido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Livre17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimentos = new System.Windows.Forms.TabPage();
            this.btnEstornar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCampo = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn50Ultimos = new System.Windows.Forms.Button();
            this.dgvMovimentos = new System.Windows.Forms.DataGridView();
            this.Gerenciamento = new System.Windows.Forms.TabPage();
            this.nupAddLinhas = new System.Windows.Forms.NumericUpDown();
            this.btnAddLinhas = new System.Windows.Forms.Button();
            this.btnAplicaEtiquetas = new System.Windows.Forms.Button();
            this.dgvGerenciamento = new System.Windows.Forms.DataGridView();
            this.OpcaoG = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CodigoG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UndG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrateleiraG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoAtualG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConvertidoG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Livre17G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCriaListaApartirDeSaldo = new System.Windows.Forms.Button();
            this.Inventario = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.nupDias = new System.Windows.Forms.NumericUpDown();
            this.btnAcertarSistema = new System.Windows.Forms.Button();
            this.btnAcetarETQ = new System.Windows.Forms.Button();
            this.btnEnviaParaAcerto = new System.Windows.Forms.Button();
            this.btnExcluiTodosOBSs = new System.Windows.Forms.Button();
            this.btnExcluirOBS = new System.Windows.Forms.Button();
            this.dgvSaldoDivergente = new System.Windows.Forms.DataGridView();
            this.btnObservacoes = new System.Windows.Forms.Button();
            this.brnImprimirDivergentes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dgvDivergentes = new System.Windows.Forms.DataGridView();
            this.btnObterDivergentes = new System.Windows.Forms.Button();
            this.Saude = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSend = new System.Windows.Forms.Label();
            this.AddTodosGerenciamneto = new System.Windows.Forms.Button();
            this.AddGerenciamento = new System.Windows.Forms.Button();
            this.lblListaStatus = new System.Windows.Forms.Label();
            this.lblListaParaCriarEtiquetas = new System.Windows.Forms.Label();
            this.dgvSaude = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.MovimentacaoDiaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentos2)).BeginInit();
            this.Movimentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentos)).BeginInit();
            this.Gerenciamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAddLinhas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGerenciamento)).BeginInit();
            this.Inventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldoDivergente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivergentes)).BeginInit();
            this.Saude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaude)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MovimentacaoDiaria);
            this.tabControl1.Controls.Add(this.Movimentos);
            this.tabControl1.Controls.Add(this.Gerenciamento);
            this.tabControl1.Controls.Add(this.Inventario);
            this.tabControl1.Controls.Add(this.Saude);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1699, 822);
            this.tabControl1.TabIndex = 291;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // MovimentacaoDiaria
            // 
            this.MovimentacaoDiaria.Controls.Add(this.btnLimpalinha);
            this.MovimentacaoDiaria.Controls.Add(this.btnLimpaTudo);
            this.MovimentacaoDiaria.Controls.Add(this.btnAtualizaEtiqueta);
            this.MovimentacaoDiaria.Controls.Add(this.dgvMovimentos2);
            this.MovimentacaoDiaria.Location = new System.Drawing.Point(4, 22);
            this.MovimentacaoDiaria.Name = "MovimentacaoDiaria";
            this.MovimentacaoDiaria.Padding = new System.Windows.Forms.Padding(3);
            this.MovimentacaoDiaria.Size = new System.Drawing.Size(1691, 796);
            this.MovimentacaoDiaria.TabIndex = 0;
            this.MovimentacaoDiaria.Text = "Movimentacao Diaria";
            this.MovimentacaoDiaria.UseVisualStyleBackColor = true;
            // 
            // btnLimpalinha
            // 
            this.btnLimpalinha.Location = new System.Drawing.Point(1314, 97);
            this.btnLimpalinha.Name = "btnLimpalinha";
            this.btnLimpalinha.Size = new System.Drawing.Size(75, 23);
            this.btnLimpalinha.TabIndex = 283;
            this.btnLimpalinha.Text = "Limpa Linha";
            this.btnLimpalinha.UseVisualStyleBackColor = true;
            this.btnLimpalinha.Click += new System.EventHandler(this.btnLimpalinha_Click);
            // 
            // btnLimpaTudo
            // 
            this.btnLimpaTudo.Location = new System.Drawing.Point(1314, 152);
            this.btnLimpaTudo.Name = "btnLimpaTudo";
            this.btnLimpaTudo.Size = new System.Drawing.Size(75, 23);
            this.btnLimpaTudo.TabIndex = 282;
            this.btnLimpaTudo.Text = "Limpa Tudo";
            this.btnLimpaTudo.UseVisualStyleBackColor = true;
            this.btnLimpaTudo.Click += new System.EventHandler(this.btnLimpaTudo_Click);
            // 
            // btnAtualizaEtiqueta
            // 
            this.btnAtualizaEtiqueta.BackColor = System.Drawing.Color.SandyBrown;
            this.btnAtualizaEtiqueta.Location = new System.Drawing.Point(1314, 209);
            this.btnAtualizaEtiqueta.Name = "btnAtualizaEtiqueta";
            this.btnAtualizaEtiqueta.Size = new System.Drawing.Size(97, 36);
            this.btnAtualizaEtiqueta.TabIndex = 284;
            this.btnAtualizaEtiqueta.Text = "Atualiza Etiqueta";
            this.btnAtualizaEtiqueta.UseVisualStyleBackColor = false;
            this.btnAtualizaEtiqueta.Click += new System.EventHandler(this.btnAtualizaEtiqueta_Click);
            // 
            // dgvMovimentos2
            // 
            this.dgvMovimentos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimentos2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descricao,
            this.UND,
            this.SaldoAtual,
            this.Convertido,
            this.Prateleira,
            this.Saida,
            this.Entrada,
            this.Atualiza,
            this.NewSaldoAtual,
            this.NewConvertido,
            this.Livre17});
            this.dgvMovimentos2.Location = new System.Drawing.Point(11, 14);
            this.dgvMovimentos2.Name = "dgvMovimentos2";
            this.dgvMovimentos2.Size = new System.Drawing.Size(1281, 738);
            this.dgvMovimentos2.TabIndex = 281;
            this.dgvMovimentos2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellEndEdite);
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
            // UND
            // 
            this.UND.HeaderText = "UND";
            this.UND.Name = "UND";
            // 
            // SaldoAtual
            // 
            this.SaldoAtual.HeaderText = "SaldoAtual";
            this.SaldoAtual.Name = "SaldoAtual";
            this.SaldoAtual.ReadOnly = true;
            // 
            // Convertido
            // 
            this.Convertido.HeaderText = "Convertido";
            this.Convertido.Name = "Convertido";
            // 
            // Prateleira
            // 
            this.Prateleira.HeaderText = "Prateleira";
            this.Prateleira.Name = "Prateleira";
            this.Prateleira.ReadOnly = true;
            // 
            // Saida
            // 
            this.Saida.HeaderText = "Saida(-)";
            this.Saida.Name = "Saida";
            // 
            // Entrada
            // 
            this.Entrada.HeaderText = "Entrada(+)";
            this.Entrada.Name = "Entrada";
            // 
            // Atualiza
            // 
            this.Atualiza.HeaderText = "Atualiza";
            this.Atualiza.Name = "Atualiza";
            // 
            // NewSaldoAtual
            // 
            this.NewSaldoAtual.HeaderText = "NewSaldoAtual";
            this.NewSaldoAtual.Name = "NewSaldoAtual";
            this.NewSaldoAtual.ReadOnly = true;
            // 
            // NewConvertido
            // 
            this.NewConvertido.HeaderText = "NewConvertido";
            this.NewConvertido.Name = "NewConvertido";
            // 
            // Livre17
            // 
            this.Livre17.HeaderText = "Livre17";
            this.Livre17.Name = "Livre17";
            // 
            // Movimentos
            // 
            this.Movimentos.Controls.Add(this.btnEstornar);
            this.Movimentos.Controls.Add(this.btnPesquisar);
            this.Movimentos.Controls.Add(this.txtCampo);
            this.Movimentos.Controls.Add(this.comboBox1);
            this.Movimentos.Controls.Add(this.btn50Ultimos);
            this.Movimentos.Controls.Add(this.dgvMovimentos);
            this.Movimentos.Location = new System.Drawing.Point(4, 22);
            this.Movimentos.Name = "Movimentos";
            this.Movimentos.Padding = new System.Windows.Forms.Padding(3);
            this.Movimentos.Size = new System.Drawing.Size(1691, 796);
            this.Movimentos.TabIndex = 2;
            this.Movimentos.Text = "Movimentos";
            this.Movimentos.UseVisualStyleBackColor = true;
            // 
            // btnEstornar
            // 
            this.btnEstornar.Location = new System.Drawing.Point(1105, 83);
            this.btnEstornar.Name = "btnEstornar";
            this.btnEstornar.Size = new System.Drawing.Size(148, 40);
            this.btnEstornar.TabIndex = 5;
            this.btnEstornar.Text = "Limpar Movimento e Restaurar Valor na Etiqueta";
            this.btnEstornar.UseVisualStyleBackColor = true;
            this.btnEstornar.Click += new System.EventHandler(this.btnEstornar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(866, 83);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCampo
            // 
            this.txtCampo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCampo.Location = new System.Drawing.Point(729, 83);
            this.txtCampo.Name = "txtCampo";
            this.txtCampo.Size = new System.Drawing.Size(100, 20);
            this.txtCampo.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Id",
            "Codigo",
            "Descricao",
            "Operacao",
            "ValorMovimento",
            "SaldoAtual",
            "Prateleira",
            "Livre17",
            "Convertido",
            "UND",
            "NewConvewtido",
            "NewSaldoAtual"});
            this.comboBox1.Location = new System.Drawing.Point(579, 83);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // btn50Ultimos
            // 
            this.btn50Ultimos.Location = new System.Drawing.Point(17, 22);
            this.btn50Ultimos.Name = "btn50Ultimos";
            this.btn50Ultimos.Size = new System.Drawing.Size(75, 23);
            this.btn50Ultimos.TabIndex = 1;
            this.btn50Ultimos.Text = "50 Ultimos";
            this.btn50Ultimos.UseVisualStyleBackColor = true;
            this.btn50Ultimos.Click += new System.EventHandler(this.btn50Ultimos_Click);
            // 
            // dgvMovimentos
            // 
            this.dgvMovimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimentos.Location = new System.Drawing.Point(6, 173);
            this.dgvMovimentos.Name = "dgvMovimentos";
            this.dgvMovimentos.Size = new System.Drawing.Size(1423, 617);
            this.dgvMovimentos.TabIndex = 0;
            // 
            // Gerenciamento
            // 
            this.Gerenciamento.Controls.Add(this.nupAddLinhas);
            this.Gerenciamento.Controls.Add(this.btnAddLinhas);
            this.Gerenciamento.Controls.Add(this.btnAplicaEtiquetas);
            this.Gerenciamento.Controls.Add(this.dgvGerenciamento);
            this.Gerenciamento.Controls.Add(this.btnCriaListaApartirDeSaldo);
            this.Gerenciamento.Location = new System.Drawing.Point(4, 22);
            this.Gerenciamento.Name = "Gerenciamento";
            this.Gerenciamento.Padding = new System.Windows.Forms.Padding(3);
            this.Gerenciamento.Size = new System.Drawing.Size(1691, 796);
            this.Gerenciamento.TabIndex = 3;
            this.Gerenciamento.Text = "Gerenciamento";
            this.Gerenciamento.UseVisualStyleBackColor = true;
            // 
            // nupAddLinhas
            // 
            this.nupAddLinhas.Location = new System.Drawing.Point(491, 49);
            this.nupAddLinhas.Name = "nupAddLinhas";
            this.nupAddLinhas.Size = new System.Drawing.Size(120, 20);
            this.nupAddLinhas.TabIndex = 6;
            // 
            // btnAddLinhas
            // 
            this.btnAddLinhas.Location = new System.Drawing.Point(632, 35);
            this.btnAddLinhas.Name = "btnAddLinhas";
            this.btnAddLinhas.Size = new System.Drawing.Size(91, 45);
            this.btnAddLinhas.TabIndex = 5;
            this.btnAddLinhas.Text = "Add Linhas";
            this.btnAddLinhas.UseVisualStyleBackColor = true;
            this.btnAddLinhas.Click += new System.EventHandler(this.btnAddLinhas_Click);
            // 
            // btnAplicaEtiquetas
            // 
            this.btnAplicaEtiquetas.Location = new System.Drawing.Point(15, 136);
            this.btnAplicaEtiquetas.Name = "btnAplicaEtiquetas";
            this.btnAplicaEtiquetas.Size = new System.Drawing.Size(91, 45);
            this.btnAplicaEtiquetas.TabIndex = 4;
            this.btnAplicaEtiquetas.Text = "Aplica Etiquetas";
            this.btnAplicaEtiquetas.UseVisualStyleBackColor = true;
            this.btnAplicaEtiquetas.Click += new System.EventHandler(this.btnAplicaEtiquetas_Click);
            // 
            // dgvGerenciamento
            // 
            this.dgvGerenciamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGerenciamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OpcaoG,
            this.CodigoG,
            this.DescricaoG,
            this.UndG,
            this.PrateleiraG,
            this.SaldoAtualG,
            this.ConvertidoG,
            this.Livre17G,
            this.GrupoG});
            this.dgvGerenciamento.Location = new System.Drawing.Point(6, 212);
            this.dgvGerenciamento.Name = "dgvGerenciamento";
            this.dgvGerenciamento.Size = new System.Drawing.Size(1423, 578);
            this.dgvGerenciamento.TabIndex = 1;
            this.dgvGerenciamento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellEndEdit);
            // 
            // OpcaoG
            // 
            this.OpcaoG.HeaderText = "Opcao";
            this.OpcaoG.Items.AddRange(new object[] {
            "Antecipar",
            "Criar",
            "Alterar",
            "Deletar"});
            this.OpcaoG.Name = "OpcaoG";
            this.OpcaoG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OpcaoG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OpcaoG.Width = 80;
            // 
            // CodigoG
            // 
            this.CodigoG.HeaderText = "Codigo";
            this.CodigoG.MaxInputLength = 14;
            this.CodigoG.Name = "CodigoG";
            this.CodigoG.Width = 200;
            // 
            // DescricaoG
            // 
            this.DescricaoG.HeaderText = "Descricao";
            this.DescricaoG.MaxInputLength = 50;
            this.DescricaoG.Name = "DescricaoG";
            this.DescricaoG.Width = 500;
            // 
            // UndG
            // 
            this.UndG.HeaderText = "UND";
            this.UndG.MaxInputLength = 2;
            this.UndG.Name = "UndG";
            this.UndG.Width = 50;
            // 
            // PrateleiraG
            // 
            this.PrateleiraG.HeaderText = "Prateleira";
            this.PrateleiraG.MaxInputLength = 11;
            this.PrateleiraG.Name = "PrateleiraG";
            // 
            // SaldoAtualG
            // 
            this.SaldoAtualG.HeaderText = "SaldoAtual";
            this.SaldoAtualG.MaxInputLength = 18;
            this.SaldoAtualG.Name = "SaldoAtualG";
            // 
            // ConvertidoG
            // 
            this.ConvertidoG.HeaderText = "Convertido";
            this.ConvertidoG.MaxInputLength = 18;
            this.ConvertidoG.Name = "ConvertidoG";
            // 
            // Livre17G
            // 
            this.Livre17G.HeaderText = "Livre17";
            this.Livre17G.MaxInputLength = 18;
            this.Livre17G.Name = "Livre17G";
            // 
            // GrupoG
            // 
            this.GrupoG.HeaderText = "Grupo";
            this.GrupoG.MaxInputLength = 8;
            this.GrupoG.Name = "GrupoG";
            this.GrupoG.Width = 150;
            // 
            // btnCriaListaApartirDeSaldo
            // 
            this.btnCriaListaApartirDeSaldo.Enabled = false;
            this.btnCriaListaApartirDeSaldo.Location = new System.Drawing.Point(960, 67);
            this.btnCriaListaApartirDeSaldo.Name = "btnCriaListaApartirDeSaldo";
            this.btnCriaListaApartirDeSaldo.Size = new System.Drawing.Size(91, 45);
            this.btnCriaListaApartirDeSaldo.TabIndex = 0;
            this.btnCriaListaApartirDeSaldo.Text = "Cria Etiquetas Apartir de Saldo";
            this.btnCriaListaApartirDeSaldo.UseVisualStyleBackColor = true;
            this.btnCriaListaApartirDeSaldo.Click += new System.EventHandler(this.btnCriaListaApartirDeSaldo_Click);
            // 
            // Inventario
            // 
            this.Inventario.Controls.Add(this.label1);
            this.Inventario.Controls.Add(this.nupDias);
            this.Inventario.Controls.Add(this.btnAcertarSistema);
            this.Inventario.Controls.Add(this.btnAcetarETQ);
            this.Inventario.Controls.Add(this.btnEnviaParaAcerto);
            this.Inventario.Controls.Add(this.btnExcluiTodosOBSs);
            this.Inventario.Controls.Add(this.btnExcluirOBS);
            this.Inventario.Controls.Add(this.dgvSaldoDivergente);
            this.Inventario.Controls.Add(this.btnObservacoes);
            this.Inventario.Controls.Add(this.brnImprimirDivergentes);
            this.Inventario.Controls.Add(this.label2);
            this.Inventario.Controls.Add(this.numericUpDown1);
            this.Inventario.Controls.Add(this.dgvDivergentes);
            this.Inventario.Controls.Add(this.btnObterDivergentes);
            this.Inventario.Location = new System.Drawing.Point(4, 22);
            this.Inventario.Name = "Inventario";
            this.Inventario.Padding = new System.Windows.Forms.Padding(3);
            this.Inventario.Size = new System.Drawing.Size(1691, 796);
            this.Inventario.TabIndex = 4;
            this.Inventario.Text = "Inventario";
            this.Inventario.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1439, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 336;
            this.label1.Text = "Dias Maximo";
            // 
            // nupDias
            // 
            this.nupDias.Location = new System.Drawing.Point(1442, 105);
            this.nupDias.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nupDias.Minimum = new decimal(new int[] {
            31,
            0,
            0,
            -2147483648});
            this.nupDias.Name = "nupDias";
            this.nupDias.Size = new System.Drawing.Size(54, 20);
            this.nupDias.TabIndex = 335;
            this.nupDias.ThousandsSeparator = true;
            this.nupDias.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            // 
            // btnAcertarSistema
            // 
            this.btnAcertarSistema.BackColor = System.Drawing.Color.SpringGreen;
            this.btnAcertarSistema.Location = new System.Drawing.Point(706, 89);
            this.btnAcertarSistema.Name = "btnAcertarSistema";
            this.btnAcertarSistema.Size = new System.Drawing.Size(98, 77);
            this.btnAcertarSistema.TabIndex = 334;
            this.btnAcertarSistema.Text = "Acertar Sistema (Saldo e Envia para Acerto) Conforme ETQ";
            this.btnAcertarSistema.UseVisualStyleBackColor = false;
            this.btnAcertarSistema.Click += new System.EventHandler(this.btnAcertarSistema_Click);
            // 
            // btnAcetarETQ
            // 
            this.btnAcetarETQ.BackColor = System.Drawing.Color.Tomato;
            this.btnAcetarETQ.Location = new System.Drawing.Point(599, 89);
            this.btnAcetarETQ.Name = "btnAcetarETQ";
            this.btnAcetarETQ.Size = new System.Drawing.Size(101, 48);
            this.btnAcetarETQ.TabIndex = 333;
            this.btnAcetarETQ.Text = "Acertar ETQ Conforme Sistema";
            this.btnAcetarETQ.UseVisualStyleBackColor = false;
            this.btnAcetarETQ.Click += new System.EventHandler(this.btnAcertarConformeSistema_Click);
            // 
            // btnEnviaParaAcerto
            // 
            this.btnEnviaParaAcerto.BackColor = System.Drawing.Color.SandyBrown;
            this.btnEnviaParaAcerto.Location = new System.Drawing.Point(1173, 118);
            this.btnEnviaParaAcerto.Name = "btnEnviaParaAcerto";
            this.btnEnviaParaAcerto.Size = new System.Drawing.Size(75, 34);
            this.btnEnviaParaAcerto.TabIndex = 332;
            this.btnEnviaParaAcerto.Text = "Envia para Acerto";
            this.btnEnviaParaAcerto.UseVisualStyleBackColor = false;
            this.btnEnviaParaAcerto.Click += new System.EventHandler(this.btnEnviaParaAcerto_Click);
            // 
            // btnExcluiTodosOBSs
            // 
            this.btnExcluiTodosOBSs.Location = new System.Drawing.Point(745, 668);
            this.btnExcluiTodosOBSs.Name = "btnExcluiTodosOBSs";
            this.btnExcluiTodosOBSs.Size = new System.Drawing.Size(75, 37);
            this.btnExcluiTodosOBSs.TabIndex = 331;
            this.btnExcluiTodosOBSs.Text = "Excluir Todos OBSs";
            this.btnExcluiTodosOBSs.UseVisualStyleBackColor = true;
            this.btnExcluiTodosOBSs.Click += new System.EventHandler(this.btnExcluiTodosOBSs_Click);
            // 
            // btnExcluirOBS
            // 
            this.btnExcluirOBS.Location = new System.Drawing.Point(745, 625);
            this.btnExcluirOBS.Name = "btnExcluirOBS";
            this.btnExcluirOBS.Size = new System.Drawing.Size(75, 37);
            this.btnExcluirOBS.TabIndex = 330;
            this.btnExcluirOBS.Text = "Excluir OBS";
            this.btnExcluirOBS.UseVisualStyleBackColor = true;
            this.btnExcluirOBS.Click += new System.EventHandler(this.btnExcluirOBS_Click);
            // 
            // dgvSaldoDivergente
            // 
            this.dgvSaldoDivergente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldoDivergente.Location = new System.Drawing.Point(6, 602);
            this.dgvSaldoDivergente.Name = "dgvSaldoDivergente";
            this.dgvSaldoDivergente.Size = new System.Drawing.Size(708, 188);
            this.dgvSaldoDivergente.TabIndex = 329;
            // 
            // btnObservacoes
            // 
            this.btnObservacoes.BackColor = System.Drawing.Color.SandyBrown;
            this.btnObservacoes.Location = new System.Drawing.Point(996, 118);
            this.btnObservacoes.Name = "btnObservacoes";
            this.btnObservacoes.Size = new System.Drawing.Size(75, 34);
            this.btnObservacoes.TabIndex = 328;
            this.btnObservacoes.Text = "Atualizar Obsrvações";
            this.btnObservacoes.UseVisualStyleBackColor = false;
            this.btnObservacoes.Click += new System.EventHandler(this.btnObservacoes_Click);
            // 
            // brnImprimirDivergentes
            // 
            this.brnImprimirDivergentes.BackColor = System.Drawing.Color.SandyBrown;
            this.brnImprimirDivergentes.Location = new System.Drawing.Point(996, 41);
            this.brnImprimirDivergentes.Name = "brnImprimirDivergentes";
            this.brnImprimirDivergentes.Size = new System.Drawing.Size(75, 34);
            this.brnImprimirDivergentes.TabIndex = 327;
            this.brnImprimirDivergentes.Text = "Imprimir Divergentes";
            this.brnImprimirDivergentes.UseVisualStyleBackColor = false;
            this.brnImprimirDivergentes.Click += new System.EventHandler(this.brnImprimirDivergentes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(763, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 326;
            this.label2.Text = "Máximo Divergente";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown1.Location = new System.Drawing.Point(766, 50);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            196608});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 325;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // dgvDivergentes
            // 
            this.dgvDivergentes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDivergentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDivergentes.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDivergentes.Location = new System.Drawing.Point(6, 185);
            this.dgvDivergentes.Name = "dgvDivergentes";
            this.dgvDivergentes.Size = new System.Drawing.Size(1658, 411);
            this.dgvDivergentes.TabIndex = 1;
            this.dgvDivergentes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDivergentes_CellEndEdit);
            // 
            // btnObterDivergentes
            // 
            this.btnObterDivergentes.Location = new System.Drawing.Point(598, 34);
            this.btnObterDivergentes.Name = "btnObterDivergentes";
            this.btnObterDivergentes.Size = new System.Drawing.Size(75, 39);
            this.btnObterDivergentes.TabIndex = 0;
            this.btnObterDivergentes.Text = "Obter Divergentes";
            this.btnObterDivergentes.UseVisualStyleBackColor = true;
            this.btnObterDivergentes.Click += new System.EventHandler(this.btnObterDivergentes_Click);
            // 
            // Saude
            // 
            this.Saude.Controls.Add(this.button1);
            this.Saude.Controls.Add(this.lblSend);
            this.Saude.Controls.Add(this.AddTodosGerenciamneto);
            this.Saude.Controls.Add(this.AddGerenciamento);
            this.Saude.Controls.Add(this.lblListaStatus);
            this.Saude.Controls.Add(this.lblListaParaCriarEtiquetas);
            this.Saude.Controls.Add(this.dgvSaude);
            this.Saude.Location = new System.Drawing.Point(4, 22);
            this.Saude.Name = "Saude";
            this.Saude.Size = new System.Drawing.Size(1691, 796);
            this.Saude.TabIndex = 5;
            this.Saude.Text = "Saude";
            this.Saude.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.Location = new System.Drawing.Point(403, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Gerenciamneto";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(654, 121);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(11, 13);
            this.lblSend.TabIndex = 5;
            this.lblSend.Text = "*";
            // 
            // AddTodosGerenciamneto
            // 
            this.AddTodosGerenciamneto.BackColor = System.Drawing.Color.GreenYellow;
            this.AddTodosGerenciamneto.Location = new System.Drawing.Point(657, 192);
            this.AddTodosGerenciamneto.Name = "AddTodosGerenciamneto";
            this.AddTodosGerenciamneto.Size = new System.Drawing.Size(90, 40);
            this.AddTodosGerenciamneto.TabIndex = 4;
            this.AddTodosGerenciamneto.Text = "Add Todos Gerenciamento";
            this.AddTodosGerenciamneto.UseVisualStyleBackColor = false;
            this.AddTodosGerenciamneto.Click += new System.EventHandler(this.AddTodosGerenciamneto_Click);
            // 
            // AddGerenciamento
            // 
            this.AddGerenciamento.BackColor = System.Drawing.Color.Khaki;
            this.AddGerenciamento.Location = new System.Drawing.Point(657, 82);
            this.AddGerenciamento.Name = "AddGerenciamento";
            this.AddGerenciamento.Size = new System.Drawing.Size(90, 36);
            this.AddGerenciamento.TabIndex = 3;
            this.AddGerenciamento.Text = "Add Gerenciamneto";
            this.AddGerenciamento.UseVisualStyleBackColor = false;
            this.AddGerenciamento.Click += new System.EventHandler(this.AddGerenciamento_Click);
            // 
            // lblListaStatus
            // 
            this.lblListaStatus.AutoSize = true;
            this.lblListaStatus.Location = new System.Drawing.Point(12, 56);
            this.lblListaStatus.Name = "lblListaStatus";
            this.lblListaStatus.Size = new System.Drawing.Size(200, 13);
            this.lblListaStatus.TabIndex = 2;
            this.lblListaStatus.Text = "Lista de Saldos Porém não tem Etiquetas";
            // 
            // lblListaParaCriarEtiquetas
            // 
            this.lblListaParaCriarEtiquetas.AutoSize = true;
            this.lblListaParaCriarEtiquetas.Location = new System.Drawing.Point(12, 34);
            this.lblListaParaCriarEtiquetas.Name = "lblListaParaCriarEtiquetas";
            this.lblListaParaCriarEtiquetas.Size = new System.Drawing.Size(125, 13);
            this.lblListaParaCriarEtiquetas.TabIndex = 1;
            this.lblListaParaCriarEtiquetas.Text = "Lista Para Criar Etiquetas";
            // 
            // dgvSaude
            // 
            this.dgvSaude.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaude.Location = new System.Drawing.Point(15, 82);
            this.dgvSaude.Name = "dgvSaude";
            this.dgvSaude.Size = new System.Drawing.Size(598, 150);
            this.dgvSaude.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Etiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1831, 847);
            this.Controls.Add(this.tabControl1);
            this.Name = "Etiquetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualiza Etiquetas";
            this.Load += new System.EventHandler(this.Load_AE);
            this.tabControl1.ResumeLayout(false);
            this.MovimentacaoDiaria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentos2)).EndInit();
            this.Movimentos.ResumeLayout(false);
            this.Movimentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentos)).EndInit();
            this.Gerenciamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupAddLinhas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGerenciamento)).EndInit();
            this.Inventario.ResumeLayout(false);
            this.Inventario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldoDivergente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivergentes)).EndInit();
            this.Saude.ResumeLayout(false);
            this.Saude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaude)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MovimentacaoDiaria;
        private System.Windows.Forms.Button btnLimpalinha;
        private System.Windows.Forms.Button btnLimpaTudo;
        private System.Windows.Forms.Button btnAtualizaEtiqueta;
        private System.Windows.Forms.DataGridView dgvMovimentos2;
        private System.Windows.Forms.TabPage Movimentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UND;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Convertido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prateleira;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Atualiza;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewSaldoAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewConvertido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Livre17;
        private System.Windows.Forms.DataGridView dgvMovimentos;
        private System.Windows.Forms.Button btn50Ultimos;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtCampo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage Gerenciamento;
        private System.Windows.Forms.Button btnCriaListaApartirDeSaldo;
        private System.Windows.Forms.DataGridView dgvGerenciamento;
        private System.Windows.Forms.Button btnAplicaEtiquetas;
        private System.Windows.Forms.DataGridViewComboBoxColumn OpcaoG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoG;
        private System.Windows.Forms.DataGridViewTextBoxColumn UndG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrateleiraG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoAtualG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConvertidoG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Livre17G;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoG;
        private System.Windows.Forms.TabPage Inventario;
        private System.Windows.Forms.DataGridView dgvDivergentes;
        private System.Windows.Forms.Button btnObterDivergentes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button brnImprimirDivergentes;
        private System.Windows.Forms.Button btnEstornar;
        private System.Windows.Forms.NumericUpDown nupAddLinhas;
        private System.Windows.Forms.Button btnAddLinhas;
        private System.Windows.Forms.Button btnObservacoes;
        private System.Windows.Forms.DataGridView dgvSaldoDivergente;
        private System.Windows.Forms.Button btnExcluirOBS;
        private System.Windows.Forms.Button btnExcluiTodosOBSs;
        private System.Windows.Forms.Button btnEnviaParaAcerto;
        private System.Windows.Forms.Button btnAcetarETQ;
        private System.Windows.Forms.Button btnAcertarSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupDias;
        private System.Windows.Forms.TabPage Saude;
        private System.Windows.Forms.DataGridView dgvSaude;
        private System.Windows.Forms.Label lblListaStatus;
        private System.Windows.Forms.Label lblListaParaCriarEtiquetas;
        private System.Windows.Forms.Button AddTodosGerenciamneto;
        private System.Windows.Forms.Button AddGerenciamento;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}