namespace Estoque.Views
{
    partial class frmEstoqueMinimoComPrevisao
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
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbbPesquisar = new System.Windows.Forms.ComboBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnFinaliza = new System.Windows.Forms.Button();
            this.btnEstoqueMinimo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblLinhas = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblUnidade = new System.Windows.Forms.Label();
            this.lblConsuPrevOs = new System.Windows.Forms.Label();
            this.lblEstqMinimo = new System.Windows.Forms.Label();
            this.lblPrevFabric = new System.Windows.Forms.Label();
            this.lblPedCompras = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblDiasSemMov = new System.Windows.Forms.Label();
            this.lblQtdPedida = new System.Windows.Forms.Label();
            this.lblSaldoAtual = new System.Windows.Forms.Label();
            this.lblPrateleira = new System.Windows.Forms.Label();
            this.lblEstoqMaximo = new System.Windows.Forms.Label();
            this.lblOP = new System.Windows.Forms.Label();
            this.lblPrazoPedidoQTD = new System.Windows.Forms.Label();
            this.lblAndamento = new System.Windows.Forms.Label();
            this.lblAtrazado = new System.Windows.Forms.Label();
            this.lblPedir = new System.Windows.Forms.Label();
            this.lblPedirMais = new System.Windows.Forms.Label();
            this.lblNFOK = new System.Windows.Forms.Label();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.lblFimStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblqtd2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnSelecionar.Location = new System.Drawing.Point(1091, 154);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(84, 36);
            this.btnSelecionar.TabIndex = 253;
            this.btnSelecionar.Text = "SELECIONAR";
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.Red;
            this.btnDeletar.Enabled = false;
            this.btnDeletar.Location = new System.Drawing.Point(1183, 66);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 36);
            this.btnDeletar.TabIndex = 252;
            this.btnDeletar.Text = "DELETAR";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(1183, 20);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 36);
            this.btnAlterar.TabIndex = 249;
            this.btnAlterar.Text = "ALTERAR";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(15, 171);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(248, 20);
            this.txtPesquisar.TabIndex = 248;
            // 
            // cbbPesquisar
            // 
            this.cbbPesquisar.FormattingEnabled = true;
            this.cbbPesquisar.Items.AddRange(new object[] {
            "ID ",
            "Produto ",
            "Descricao ",
            "QTD ",
            "UND ",
            "OP ",
            "DataHora ",
            "PrazoSolicitado ",
            "Andamento ",
            "FimStatus"});
            this.cbbPesquisar.Location = new System.Drawing.Point(269, 170);
            this.cbbPesquisar.Name = "cbbPesquisar";
            this.cbbPesquisar.Size = new System.Drawing.Size(121, 21);
            this.cbbPesquisar.TabIndex = 247;
            this.cbbPesquisar.Text = "Descricao ";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(1181, 154);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 36);
            this.btnAtualizar.TabIndex = 246;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(396, 164);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 30);
            this.btnPesquisar.TabIndex = 245;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnFinaliza
            // 
            this.btnFinaliza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnFinaliza.Enabled = false;
            this.btnFinaliza.Location = new System.Drawing.Point(1102, 20);
            this.btnFinaliza.Name = "btnFinaliza";
            this.btnFinaliza.Size = new System.Drawing.Size(75, 36);
            this.btnFinaliza.TabIndex = 243;
            this.btnFinaliza.Text = "FINALIZAR";
            this.btnFinaliza.UseVisualStyleBackColor = false;
            this.btnFinaliza.Click += new System.EventHandler(this.btnFinalizar);
            // 
            // btnEstoqueMinimo
            // 
            this.btnEstoqueMinimo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnEstoqueMinimo.Enabled = false;
            this.btnEstoqueMinimo.Location = new System.Drawing.Point(1102, 66);
            this.btnEstoqueMinimo.Name = "btnEstoqueMinimo";
            this.btnEstoqueMinimo.Size = new System.Drawing.Size(75, 36);
            this.btnEstoqueMinimo.TabIndex = 242;
            this.btnEstoqueMinimo.Text = "SOLICITAR";
            this.btnEstoqueMinimo.UseVisualStyleBackColor = false;
            this.btnEstoqueMinimo.Click += new System.EventHandler(this.btnSolicitar);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 195);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1243, 640);
            this.dataGridView1.TabIndex = 244;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblLinhas
            // 
            this.lblLinhas.AutoSize = true;
            this.lblLinhas.Location = new System.Drawing.Point(807, 176);
            this.lblLinhas.Name = "lblLinhas";
            this.lblLinhas.Size = new System.Drawing.Size(0, 13);
            this.lblLinhas.TabIndex = 254;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(562, 72);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 250;
            this.lblID.Text = "ID: ";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(12, 20);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(50, 13);
            this.lblProduto.TabIndex = 255;
            this.lblProduto.Text = "Produto: ";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(1, 112);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(61, 13);
            this.lblDescricao.TabIndex = 256;
            this.lblDescricao.Text = "Descricao: ";
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Location = new System.Drawing.Point(9, 72);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(53, 13);
            this.lblUnidade.TabIndex = 257;
            this.lblUnidade.Text = "Unidade: ";
            // 
            // lblConsuPrevOs
            // 
            this.lblConsuPrevOs.AutoSize = true;
            this.lblConsuPrevOs.Location = new System.Drawing.Point(372, 48);
            this.lblConsuPrevOs.Name = "lblConsuPrevOs";
            this.lblConsuPrevOs.Size = new System.Drawing.Size(78, 13);
            this.lblConsuPrevOs.TabIndex = 258;
            this.lblConsuPrevOs.Text = "ConsuPrevOs: ";
            // 
            // lblEstqMinimo
            // 
            this.lblEstqMinimo.AutoSize = true;
            this.lblEstqMinimo.Location = new System.Drawing.Point(365, 20);
            this.lblEstqMinimo.Name = "lblEstqMinimo";
            this.lblEstqMinimo.Size = new System.Drawing.Size(85, 13);
            this.lblEstqMinimo.TabIndex = 259;
            this.lblEstqMinimo.Text = "EstoqueMinimo: ";
            // 
            // lblPrevFabric
            // 
            this.lblPrevFabric.AutoSize = true;
            this.lblPrevFabric.Location = new System.Drawing.Point(255, 72);
            this.lblPrevFabric.Name = "lblPrevFabric";
            this.lblPrevFabric.Size = new System.Drawing.Size(64, 13);
            this.lblPrevFabric.TabIndex = 260;
            this.lblPrevFabric.Text = "PrevFabric: ";
            // 
            // lblPedCompras
            // 
            this.lblPedCompras.AutoSize = true;
            this.lblPedCompras.Location = new System.Drawing.Point(246, 48);
            this.lblPedCompras.Name = "lblPedCompras";
            this.lblPedCompras.Size = new System.Drawing.Size(73, 13);
            this.lblPedCompras.TabIndex = 261;
            this.lblPedCompras.Text = "PedCompras: ";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(408, 122);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(42, 13);
            this.lblGrupo.TabIndex = 262;
            this.lblGrupo.Text = "Grupo: ";
            // 
            // lblDiasSemMov
            // 
            this.lblDiasSemMov.AutoSize = true;
            this.lblDiasSemMov.Location = new System.Drawing.Point(519, 20);
            this.lblDiasSemMov.Name = "lblDiasSemMov";
            this.lblDiasSemMov.Size = new System.Drawing.Size(67, 13);
            this.lblDiasSemMov.TabIndex = 263;
            this.lblDiasSemMov.Text = "DiasS/Mov: ";
            // 
            // lblQtdPedida
            // 
            this.lblQtdPedida.AutoSize = true;
            this.lblQtdPedida.Location = new System.Drawing.Point(523, 96);
            this.lblQtdPedida.Name = "lblQtdPedida";
            this.lblQtdPedida.Size = new System.Drawing.Size(63, 13);
            this.lblQtdPedida.TabIndex = 264;
            this.lblQtdPedida.Text = "QtdPedida: ";
            // 
            // lblSaldoAtual
            // 
            this.lblSaldoAtual.AutoSize = true;
            this.lblSaldoAtual.Location = new System.Drawing.Point(255, 20);
            this.lblSaldoAtual.Name = "lblSaldoAtual";
            this.lblSaldoAtual.Size = new System.Drawing.Size(64, 13);
            this.lblSaldoAtual.TabIndex = 265;
            this.lblSaldoAtual.Text = "SaldoAtual: ";
            // 
            // lblPrateleira
            // 
            this.lblPrateleira.AutoSize = true;
            this.lblPrateleira.Location = new System.Drawing.Point(393, 96);
            this.lblPrateleira.Name = "lblPrateleira";
            this.lblPrateleira.Size = new System.Drawing.Size(57, 13);
            this.lblPrateleira.TabIndex = 266;
            this.lblPrateleira.Text = "Prateleira: ";
            // 
            // lblEstoqMaximo
            // 
            this.lblEstoqMaximo.AutoSize = true;
            this.lblEstoqMaximo.Location = new System.Drawing.Point(374, 72);
            this.lblEstoqMaximo.Name = "lblEstoqMaximo";
            this.lblEstoqMaximo.Size = new System.Drawing.Size(76, 13);
            this.lblEstoqMaximo.TabIndex = 267;
            this.lblEstoqMaximo.Text = "EstoqMaximo: ";
            // 
            // lblOP
            // 
            this.lblOP.AutoSize = true;
            this.lblOP.Location = new System.Drawing.Point(560, 130);
            this.lblOP.Name = "lblOP";
            this.lblOP.Size = new System.Drawing.Size(82, 13);
            this.lblOP.TabIndex = 268;
            this.lblOP.Text = "OP: EstqMinimo";
            // 
            // lblPrazoPedidoQTD
            // 
            this.lblPrazoPedidoQTD.AutoSize = true;
            this.lblPrazoPedidoQTD.Location = new System.Drawing.Point(651, 48);
            this.lblPrazoPedidoQTD.Name = "lblPrazoPedidoQTD";
            this.lblPrazoPedidoQTD.Size = new System.Drawing.Size(82, 13);
            this.lblPrazoPedidoQTD.TabIndex = 269;
            this.lblPrazoPedidoQTD.Text = "PrazoPedQTD: ";
            // 
            // lblAndamento
            // 
            this.lblAndamento.AutoSize = true;
            this.lblAndamento.Location = new System.Drawing.Point(666, 72);
            this.lblAndamento.Name = "lblAndamento";
            this.lblAndamento.Size = new System.Drawing.Size(67, 13);
            this.lblAndamento.TabIndex = 270;
            this.lblAndamento.Text = "Andamento: ";
            // 
            // lblAtrazado
            // 
            this.lblAtrazado.AutoSize = true;
            this.lblAtrazado.Location = new System.Drawing.Point(841, 48);
            this.lblAtrazado.Name = "lblAtrazado";
            this.lblAtrazado.Size = new System.Drawing.Size(60, 13);
            this.lblAtrazado.TabIndex = 271;
            this.lblAtrazado.Text = "Atrazados: ";
            // 
            // lblPedir
            // 
            this.lblPedir.AutoSize = true;
            this.lblPedir.Location = new System.Drawing.Point(549, 48);
            this.lblPedir.Name = "lblPedir";
            this.lblPedir.Size = new System.Drawing.Size(37, 13);
            this.lblPedir.TabIndex = 272;
            this.lblPedir.Text = "Pedir: ";
            // 
            // lblPedirMais
            // 
            this.lblPedirMais.AutoSize = true;
            this.lblPedirMais.Location = new System.Drawing.Point(841, 20);
            this.lblPedirMais.Name = "lblPedirMais";
            this.lblPedirMais.Size = new System.Drawing.Size(59, 13);
            this.lblPedirMais.TabIndex = 273;
            this.lblPedirMais.Text = "PedirMais: ";
            // 
            // lblNFOK
            // 
            this.lblNFOK.AutoSize = true;
            this.lblNFOK.Location = new System.Drawing.Point(685, 130);
            this.lblNFOK.Name = "lblNFOK";
            this.lblNFOK.Size = new System.Drawing.Size(48, 13);
            this.lblNFOK.TabIndex = 274;
            this.lblNFOK.Text = "NF_OK: ";
            // 
            // lblDataHora
            // 
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.Location = new System.Drawing.Point(674, 20);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(59, 13);
            this.lblDataHora.TabIndex = 275;
            this.lblDataHora.Text = "DataHora: ";
            // 
            // lblFimStatus
            // 
            this.lblFimStatus.AutoSize = true;
            this.lblFimStatus.Location = new System.Drawing.Point(674, 96);
            this.lblFimStatus.Name = "lblFimStatus";
            this.lblFimStatus.Size = new System.Drawing.Size(59, 13);
            this.lblFimStatus.TabIndex = 276;
            this.lblFimStatus.Text = "FimStatus: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 277;
            this.button1.Text = "teste";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblqtd2
            // 
            this.lblqtd2.AutoSize = true;
            this.lblqtd2.Location = new System.Drawing.Point(1088, 130);
            this.lblqtd2.Name = "lblqtd2";
            this.lblqtd2.Size = new System.Drawing.Size(87, 13);
            this.lblqtd2.TabIndex = 278;
            this.lblqtd2.Text = "QTD selecionar: ";
            // 
            // frmEstoqueMinimoComPrevisao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1248, 716);
            this.Controls.Add(this.lblqtd2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFimStatus);
            this.Controls.Add(this.lblDataHora);
            this.Controls.Add(this.lblNFOK);
            this.Controls.Add(this.lblPedirMais);
            this.Controls.Add(this.lblPedir);
            this.Controls.Add(this.lblAtrazado);
            this.Controls.Add(this.lblAndamento);
            this.Controls.Add(this.lblPrazoPedidoQTD);
            this.Controls.Add(this.lblOP);
            this.Controls.Add(this.lblEstoqMaximo);
            this.Controls.Add(this.lblPrateleira);
            this.Controls.Add(this.lblSaldoAtual);
            this.Controls.Add(this.lblQtdPedida);
            this.Controls.Add(this.lblDiasSemMov);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.lblPedCompras);
            this.Controls.Add(this.lblPrevFabric);
            this.Controls.Add(this.lblEstqMinimo);
            this.Controls.Add(this.lblConsuPrevOs);
            this.Controls.Add(this.lblUnidade);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.lblLinhas);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.cbbPesquisar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnFinaliza);
            this.Controls.Add(this.btnEstoqueMinimo);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmEstoqueMinimoComPrevisao";
            this.Text = "frmEstoqueMinimoComPrevisao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EstoqueMinima_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbbPesquisar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnFinaliza;
        private System.Windows.Forms.Button btnEstoqueMinimo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblLinhas;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.Label lblConsuPrevOs;
        private System.Windows.Forms.Label lblEstqMinimo;
        private System.Windows.Forms.Label lblPrevFabric;
        private System.Windows.Forms.Label lblPedCompras;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblDiasSemMov;
        private System.Windows.Forms.Label lblQtdPedida;
        private System.Windows.Forms.Label lblSaldoAtual;
        private System.Windows.Forms.Label lblPrateleira;
        private System.Windows.Forms.Label lblEstoqMaximo;
        private System.Windows.Forms.Label lblOP;
        private System.Windows.Forms.Label lblPrazoPedidoQTD;
        private System.Windows.Forms.Label lblAndamento;
        private System.Windows.Forms.Label lblAtrazado;
        private System.Windows.Forms.Label lblPedir;
        private System.Windows.Forms.Label lblPedirMais;
        private System.Windows.Forms.Label lblNFOK;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.Label lblFimStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblqtd2;
    }
}