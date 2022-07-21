namespace Estoque.Views
{
    partial class ReceberNFs
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
            this.btnReceberNFs = new System.Windows.Forms.Button();
            this.btnOPsComSaldo = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbbPesquisar = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnListaCompras = new System.Windows.Forms.Button();
            this.lblAcao = new System.Windows.Forms.Label();
            this.btnPesquisar2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNFs2 = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.rtbNFs = new System.Windows.Forms.RichTextBox();
            this.btnLimpaLista = new System.Windows.Forms.Button();
            this.brnGeraListaExcel = new System.Windows.Forms.Button();
            this.btnObterRetornoDeCompras = new System.Windows.Forms.Button();
            this.btnZerarSaldos = new System.Windows.Forms.Button();
            this.txtCodBarras = new System.Windows.Forms.TextBox();
            this.btnLimpaLinhaSelecionada = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReceberNFs
            // 
            this.btnReceberNFs.BackColor = System.Drawing.Color.Goldenrod;
            this.btnReceberNFs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceberNFs.Location = new System.Drawing.Point(1279, 94);
            this.btnReceberNFs.Name = "btnReceberNFs";
            this.btnReceberNFs.Size = new System.Drawing.Size(80, 37);
            this.btnReceberNFs.TabIndex = 270;
            this.btnReceberNFs.Text = "Receber NFs";
            this.btnReceberNFs.UseVisualStyleBackColor = false;
            this.btnReceberNFs.Click += new System.EventHandler(this.btnReceberNFs_Click);
            // 
            // btnOPsComSaldo
            // 
            this.btnOPsComSaldo.BackColor = System.Drawing.Color.Goldenrod;
            this.btnOPsComSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPsComSaldo.Location = new System.Drawing.Point(15, 75);
            this.btnOPsComSaldo.Name = "btnOPsComSaldo";
            this.btnOPsComSaldo.Size = new System.Drawing.Size(100, 67);
            this.btnOPsComSaldo.TabIndex = 269;
            this.btnOPsComSaldo.Text = "1-Gerar Compras Com Saldos Para Eliminar";
            this.btnOPsComSaldo.UseVisualStyleBackColor = false;
            this.btnOPsComSaldo.Click += new System.EventHandler(this.btnOPsComSaldo_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(1177, 94);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(76, 37);
            this.btnPesquisar.TabIndex = 268;
            this.btnPesquisar.Text = "Pesquisar NFs";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisar.Location = new System.Drawing.Point(1071, 104);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(101, 20);
            this.txtPesquisar.TabIndex = 266;
            // 
            // cbbPesquisar
            // 
            this.cbbPesquisar.FormattingEnabled = true;
            this.cbbPesquisar.Items.AddRange(new object[] {
            "NotaFiscal",
            "NomeFantasia",
            "Fornecedor",
            "Estabelecimento",
            "Deposito",
            "Produto",
            "DescricaodoProduto",
            "Quantidade",
            "TipoMovto",
            "DataMovimento",
            "DatadeEmissao",
            "Pedido",
            "DescricaoTipoMovimento"});
            this.cbbPesquisar.Location = new System.Drawing.Point(944, 104);
            this.cbbPesquisar.Name = "cbbPesquisar";
            this.cbbPesquisar.Size = new System.Drawing.Size(122, 21);
            this.cbbPesquisar.TabIndex = 265;
            this.cbbPesquisar.Text = "NotaFiscal";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1416, 633);
            this.dataGridView1.TabIndex = 267;
            // 
            // btnListaCompras
            // 
            this.btnListaCompras.BackColor = System.Drawing.Color.Goldenrod;
            this.btnListaCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaCompras.Location = new System.Drawing.Point(14, 12);
            this.btnListaCompras.Name = "btnListaCompras";
            this.btnListaCompras.Size = new System.Drawing.Size(80, 37);
            this.btnListaCompras.TabIndex = 271;
            this.btnListaCompras.Text = "Lista De Compras";
            this.btnListaCompras.UseVisualStyleBackColor = false;
            this.btnListaCompras.Click += new System.EventHandler(this.btnListaCompras_Click);
            // 
            // lblAcao
            // 
            this.lblAcao.AutoSize = true;
            this.lblAcao.Location = new System.Drawing.Point(770, 68);
            this.lblAcao.Name = "lblAcao";
            this.lblAcao.Size = new System.Drawing.Size(11, 13);
            this.lblAcao.TabIndex = 272;
            this.lblAcao.Text = "*";
            // 
            // btnPesquisar2
            // 
            this.btnPesquisar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar2.Location = new System.Drawing.Point(772, 11);
            this.btnPesquisar2.Name = "btnPesquisar2";
            this.btnPesquisar2.Size = new System.Drawing.Size(76, 37);
            this.btnPesquisar2.TabIndex = 274;
            this.btnPesquisar2.Text = "Pesquisar várias NFs";
            this.btnPesquisar2.UseVisualStyleBackColor = true;
            this.btnPesquisar2.Click += new System.EventHandler(this.btnPesquisar2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 275;
            this.label1.Text = "Notas Fiscais";
            // 
            // txtNFs2
            // 
            this.txtNFs2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNFs2.Location = new System.Drawing.Point(772, 84);
            this.txtNFs2.MaxLength = 50;
            this.txtNFs2.Name = "txtNFs2";
            this.txtNFs2.Size = new System.Drawing.Size(101, 20);
            this.txtNFs2.TabIndex = 277;
            this.txtNFs2.TextChanged += new System.EventHandler(this.txtNFs);
            this.txtNFs2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myTextBox_KeyPress);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(769, 112);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(11, 13);
            this.lblDescricao.TabIndex = 278;
            this.lblDescricao.Text = "*";
            // 
            // rtbNFs
            // 
            this.rtbNFs.Location = new System.Drawing.Point(612, 12);
            this.rtbNFs.Name = "rtbNFs";
            this.rtbNFs.Size = new System.Drawing.Size(152, 130);
            this.rtbNFs.TabIndex = 279;
            this.rtbNFs.Text = "";
            // 
            // btnLimpaLista
            // 
            this.btnLimpaLista.BackColor = System.Drawing.Color.LightCoral;
            this.btnLimpaLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpaLista.Location = new System.Drawing.Point(854, 11);
            this.btnLimpaLista.Name = "btnLimpaLista";
            this.btnLimpaLista.Size = new System.Drawing.Size(76, 37);
            this.btnLimpaLista.TabIndex = 280;
            this.btnLimpaLista.Text = "Limpa Lista";
            this.btnLimpaLista.UseVisualStyleBackColor = false;
            this.btnLimpaLista.Click += new System.EventHandler(this.btnLimpaLista_Click);
            // 
            // brnGeraListaExcel
            // 
            this.brnGeraListaExcel.BackColor = System.Drawing.Color.Goldenrod;
            this.brnGeraListaExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnGeraListaExcel.Location = new System.Drawing.Point(227, 75);
            this.brnGeraListaExcel.Name = "brnGeraListaExcel";
            this.brnGeraListaExcel.Size = new System.Drawing.Size(100, 50);
            this.brnGeraListaExcel.TabIndex = 281;
            this.brnGeraListaExcel.Text = "2-Gerar Lista Excel";
            this.brnGeraListaExcel.UseVisualStyleBackColor = false;
            this.brnGeraListaExcel.Click += new System.EventHandler(this.brnGeraListaExcel_Click);
            // 
            // btnObterRetornoDeCompras
            // 
            this.btnObterRetornoDeCompras.BackColor = System.Drawing.Color.Goldenrod;
            this.btnObterRetornoDeCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObterRetornoDeCompras.Location = new System.Drawing.Point(333, 75);
            this.btnObterRetornoDeCompras.Name = "btnObterRetornoDeCompras";
            this.btnObterRetornoDeCompras.Size = new System.Drawing.Size(100, 50);
            this.btnObterRetornoDeCompras.TabIndex = 282;
            this.btnObterRetornoDeCompras.Text = "3-Obter Retorno de Compras";
            this.btnObterRetornoDeCompras.UseVisualStyleBackColor = false;
            this.btnObterRetornoDeCompras.Click += new System.EventHandler(this.btnObterRetornoDeCompras_Click);
            // 
            // btnZerarSaldos
            // 
            this.btnZerarSaldos.BackColor = System.Drawing.Color.Goldenrod;
            this.btnZerarSaldos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZerarSaldos.Location = new System.Drawing.Point(439, 74);
            this.btnZerarSaldos.Name = "btnZerarSaldos";
            this.btnZerarSaldos.Size = new System.Drawing.Size(100, 50);
            this.btnZerarSaldos.TabIndex = 283;
            this.btnZerarSaldos.Text = "4-Zerar Saldos";
            this.btnZerarSaldos.UseVisualStyleBackColor = false;
            this.btnZerarSaldos.Click += new System.EventHandler(this.btnZerarSaldos_Click);
            // 
            // txtCodBarras
            // 
            this.txtCodBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodBarras.Location = new System.Drawing.Point(944, 42);
            this.txtCodBarras.MaxLength = 44;
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.Size = new System.Drawing.Size(285, 20);
            this.txtCodBarras.TabIndex = 0;
            this.txtCodBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarregaXYZ);
            // 
            // btnLimpaLinhaSelecionada
            // 
            this.btnLimpaLinhaSelecionada.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnLimpaLinhaSelecionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpaLinhaSelecionada.Location = new System.Drawing.Point(121, 74);
            this.btnLimpaLinhaSelecionada.Name = "btnLimpaLinhaSelecionada";
            this.btnLimpaLinhaSelecionada.Size = new System.Drawing.Size(100, 50);
            this.btnLimpaLinhaSelecionada.TabIndex = 284;
            this.btnLimpaLinhaSelecionada.Text = "Limpa Linha Selecionada";
            this.btnLimpaLinhaSelecionada.UseVisualStyleBackColor = false;
            this.btnLimpaLinhaSelecionada.Click += new System.EventHandler(this.btnLimpaLinhaSelecionada_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 285;
            this.label2.Text = "Notas Fiscais";
            // 
            // ReceberNFs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 874);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLimpaLinhaSelecionada);
            this.Controls.Add(this.txtCodBarras);
            this.Controls.Add(this.btnZerarSaldos);
            this.Controls.Add(this.btnObterRetornoDeCompras);
            this.Controls.Add(this.brnGeraListaExcel);
            this.Controls.Add(this.btnLimpaLista);
            this.Controls.Add(this.rtbNFs);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNFs2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPesquisar2);
            this.Controls.Add(this.lblAcao);
            this.Controls.Add(this.btnListaCompras);
            this.Controls.Add(this.btnReceberNFs);
            this.Controls.Add(this.btnOPsComSaldo);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.cbbPesquisar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReceberNFs";
            this.Text = "ReceberNFs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReceberNFs;
        private System.Windows.Forms.Button btnOPsComSaldo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbbPesquisar;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnListaCompras;
        private System.Windows.Forms.Label lblAcao;
        private System.Windows.Forms.Button btnPesquisar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNFs2;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.RichTextBox rtbNFs;
        private System.Windows.Forms.Button btnLimpaLista;
        private System.Windows.Forms.Button brnGeraListaExcel;
        private System.Windows.Forms.Button btnObterRetornoDeCompras;
        private System.Windows.Forms.Button btnZerarSaldos;
        private System.Windows.Forms.TextBox txtCodBarras;
        private System.Windows.Forms.Button btnLimpaLinhaSelecionada;
        private System.Windows.Forms.Label label2;
    }
}