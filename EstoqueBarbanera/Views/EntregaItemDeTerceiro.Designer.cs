namespace Estoque.Views
{
    partial class EntregaItemDeTerceiro
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtEntreguePara = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnZeradosMasEntregues = new System.Windows.Forms.Button();
            this.btnLiberarEntregas = new System.Windows.Forms.Button();
            this.btnRemoveEntregaUnitario = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbbPesquisar = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(699, 557);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descricao";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quantidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Entregue para: ";
            // 
            // txtProduto
            // 
            this.txtProduto.Enabled = false;
            this.txtProduto.Location = new System.Drawing.Point(146, 16);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(186, 20);
            this.txtProduto.TabIndex = 6;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Location = new System.Drawing.Point(146, 48);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(565, 20);
            this.txtDescricao.TabIndex = 7;
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(146, 84);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(186, 20);
            this.txtCliente.TabIndex = 8;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(146, 126);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(100, 20);
            this.txtQuantidade.TabIndex = 9;
            // 
            // txtEntreguePara
            // 
            this.txtEntreguePara.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntreguePara.Location = new System.Drawing.Point(146, 171);
            this.txtEntreguePara.Name = "txtEntreguePara";
            this.txtEntreguePara.Size = new System.Drawing.Size(357, 20);
            this.txtEntreguePara.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(449, 84);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(262, 20);
            this.txtData.TabIndex = 12;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(730, 269);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(699, 557);
            this.dataGridView2.TabIndex = 13;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // btnEntregar
            // 
            this.btnEntregar.Location = new System.Drawing.Point(47, 210);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(75, 23);
            this.btnEntregar.TabIndex = 14;
            this.btnEntregar.Text = "Entregar";
            this.btnEntregar.UseVisualStyleBackColor = true;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(777, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 15;
            this.button1.Text = "1 - Lista";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnZeradosMasEntregues
            // 
            this.btnZeradosMasEntregues.BackColor = System.Drawing.Color.Tomato;
            this.btnZeradosMasEntregues.Location = new System.Drawing.Point(1302, 36);
            this.btnZeradosMasEntregues.Name = "btnZeradosMasEntregues";
            this.btnZeradosMasEntregues.Size = new System.Drawing.Size(98, 42);
            this.btnZeradosMasEntregues.TabIndex = 16;
            this.btnZeradosMasEntregues.Text = "1 - Lista Zerados Mas Entregues";
            this.btnZeradosMasEntregues.UseVisualStyleBackColor = false;
            this.btnZeradosMasEntregues.Click += new System.EventHandler(this.btnZeradosMasEntregues_Click);
            // 
            // btnLiberarEntregas
            // 
            this.btnLiberarEntregas.BackColor = System.Drawing.Color.Tomato;
            this.btnLiberarEntregas.Location = new System.Drawing.Point(1302, 91);
            this.btnLiberarEntregas.Name = "btnLiberarEntregas";
            this.btnLiberarEntregas.Size = new System.Drawing.Size(98, 42);
            this.btnLiberarEntregas.TabIndex = 17;
            this.btnLiberarEntregas.Text = "2 - Liberar Entregas";
            this.btnLiberarEntregas.UseVisualStyleBackColor = false;
            this.btnLiberarEntregas.Click += new System.EventHandler(this.btnLiberarEntregas_Click);
            // 
            // btnRemoveEntregaUnitario
            // 
            this.btnRemoveEntregaUnitario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRemoveEntregaUnitario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRemoveEntregaUnitario.Location = new System.Drawing.Point(874, 199);
            this.btnRemoveEntregaUnitario.Name = "btnRemoveEntregaUnitario";
            this.btnRemoveEntregaUnitario.Size = new System.Drawing.Size(92, 44);
            this.btnRemoveEntregaUnitario.TabIndex = 18;
            this.btnRemoveEntregaUnitario.Text = "2 - Remove Entrega Unitario";
            this.btnRemoveEntregaUnitario.UseVisualStyleBackColor = false;
            this.btnRemoveEntregaUnitario.Click += new System.EventHandler(this.btnRemoveEntregaUnitario_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(426, 209);
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
            this.txtPesquisar.Location = new System.Drawing.Point(320, 212);
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
            this.cbbPesquisar.Location = new System.Drawing.Point(193, 212);
            this.cbbPesquisar.Name = "cbbPesquisar";
            this.cbbPesquisar.Size = new System.Drawing.Size(121, 21);
            this.cbbPesquisar.TabIndex = 162;
            this.cbbPesquisar.Text = "Descricao";
            // 
            // EntregaItemDeTerceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1444, 874);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.cbbPesquisar);
            this.Controls.Add(this.btnRemoveEntregaUnitario);
            this.Controls.Add(this.btnLiberarEntregas);
            this.Controls.Add(this.btnZeradosMasEntregues);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEntregar);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEntreguePara);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1460, 913);
            this.Name = "EntregaItemDeTerceiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EntregaItemDeTerceiro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtEntreguePara;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnZeradosMasEntregues;
        private System.Windows.Forms.Button btnLiberarEntregas;
        private System.Windows.Forms.Button btnRemoveEntregaUnitario;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbbPesquisar;
    }
}