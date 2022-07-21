namespace Estoque.Views
{
    partial class Verificar_OPs_Liberadas
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
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnSoManutencao = new System.Windows.Forms.Button();
            this.lblStatistica = new System.Windows.Forms.Label();
            this.txtOP = new System.Windows.Forms.TextBox();
            this.btnPdfFake = new System.Windows.Forms.Button();
            this.txtPdfFake = new System.Windows.Forms.TextBox();
            this.lblFake = new System.Windows.Forms.Label();
            this.txtPDFFakeLista = new System.Windows.Forms.TextBox();
            this.btnPdfFakeLista = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPDFNaoFakeLista = new System.Windows.Forms.TextBox();
            this.btnPdfNaoFakeLista = new System.Windows.Forms.Button();
            this.btnSoLiberadas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(962, 564);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_Click);
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(12, 59);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(75, 23);
            this.btnTodos.TabIndex = 1;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnSoManutencao
            // 
            this.btnSoManutencao.Location = new System.Drawing.Point(213, 60);
            this.btnSoManutencao.Name = "btnSoManutencao";
            this.btnSoManutencao.Size = new System.Drawing.Size(94, 23);
            this.btnSoManutencao.TabIndex = 2;
            this.btnSoManutencao.Text = "Só Manutenção";
            this.btnSoManutencao.UseVisualStyleBackColor = true;
            this.btnSoManutencao.Click += new System.EventHandler(this.btnSoManutencao_Click);
            // 
            // lblStatistica
            // 
            this.lblStatistica.AutoSize = true;
            this.lblStatistica.Location = new System.Drawing.Point(349, 29);
            this.lblStatistica.Name = "lblStatistica";
            this.lblStatistica.Size = new System.Drawing.Size(13, 13);
            this.lblStatistica.TabIndex = 3;
            this.lblStatistica.Text = "+";
            // 
            // txtOP
            // 
            this.txtOP.Location = new System.Drawing.Point(107, 62);
            this.txtOP.Name = "txtOP";
            this.txtOP.Size = new System.Drawing.Size(100, 20);
            this.txtOP.TabIndex = 4;
            this.txtOP.Text = "1";
            // 
            // btnPdfFake
            // 
            this.btnPdfFake.Location = new System.Drawing.Point(722, 62);
            this.btnPdfFake.Name = "btnPdfFake";
            this.btnPdfFake.Size = new System.Drawing.Size(75, 34);
            this.btnPdfFake.TabIndex = 5;
            this.btnPdfFake.Text = "PDF Fake Unitário";
            this.btnPdfFake.UseVisualStyleBackColor = true;
            this.btnPdfFake.Click += new System.EventHandler(this.btnPdfFake_Click);
            // 
            // txtPdfFake
            // 
            this.txtPdfFake.Location = new System.Drawing.Point(602, 62);
            this.txtPdfFake.Name = "txtPdfFake";
            this.txtPdfFake.Size = new System.Drawing.Size(100, 20);
            this.txtPdfFake.TabIndex = 6;
            // 
            // lblFake
            // 
            this.lblFake.AutoSize = true;
            this.lblFake.Location = new System.Drawing.Point(599, 18);
            this.lblFake.Name = "lblFake";
            this.lblFake.Size = new System.Drawing.Size(13, 13);
            this.lblFake.TabIndex = 7;
            this.lblFake.Text = "+";
            // 
            // txtPDFFakeLista
            // 
            this.txtPDFFakeLista.Location = new System.Drawing.Point(12, 131);
            this.txtPDFFakeLista.Name = "txtPDFFakeLista";
            this.txtPDFFakeLista.Size = new System.Drawing.Size(690, 20);
            this.txtPDFFakeLista.TabIndex = 9;
            this.txtPDFFakeLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPDFFakeLista_Click);
            // 
            // btnPdfFakeLista
            // 
            this.btnPdfFakeLista.Location = new System.Drawing.Point(722, 123);
            this.btnPdfFakeLista.Name = "btnPdfFakeLista";
            this.btnPdfFakeLista.Size = new System.Drawing.Size(75, 34);
            this.btnPdfFakeLista.TabIndex = 8;
            this.btnPdfFakeLista.Text = "PDF NÃO Fake Lista";
            this.btnPdfFakeLista.UseVisualStyleBackColor = true;
            this.btnPdfFakeLista.Click += new System.EventHandler(this.btnPdfFakeLista_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "O grid abaixo serao fakes, exceto os listados aqui. Liste os que NÃO serão FAKES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Lista de itens  FAKES, apenas os desta lista serao fakes";
            // 
            // txtPDFNaoFakeLista
            // 
            this.txtPDFNaoFakeLista.Location = new System.Drawing.Point(12, 203);
            this.txtPDFNaoFakeLista.Name = "txtPDFNaoFakeLista";
            this.txtPDFNaoFakeLista.Size = new System.Drawing.Size(690, 20);
            this.txtPDFNaoFakeLista.TabIndex = 12;
            this.txtPDFNaoFakeLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPDFFakeLista_Click);
            // 
            // btnPdfNaoFakeLista
            // 
            this.btnPdfNaoFakeLista.Location = new System.Drawing.Point(722, 195);
            this.btnPdfNaoFakeLista.Name = "btnPdfNaoFakeLista";
            this.btnPdfNaoFakeLista.Size = new System.Drawing.Size(75, 34);
            this.btnPdfNaoFakeLista.TabIndex = 11;
            this.btnPdfNaoFakeLista.Text = "PDF Fake Lista";
            this.btnPdfNaoFakeLista.UseVisualStyleBackColor = true;
            this.btnPdfNaoFakeLista.Click += new System.EventHandler(this.btnPdfNaoFakeLista_Click);
            // 
            // btnSoLiberadas
            // 
            this.btnSoLiberadas.Location = new System.Drawing.Point(12, 29);
            this.btnSoLiberadas.Name = "btnSoLiberadas";
            this.btnSoLiberadas.Size = new System.Drawing.Size(88, 23);
            this.btnSoLiberadas.TabIndex = 14;
            this.btnSoLiberadas.Text = "Só Liberadas";
            this.btnSoLiberadas.UseVisualStyleBackColor = true;
            this.btnSoLiberadas.Click += new System.EventHandler(this.btnSoLiberadas_Click);
            // 
            // Verificar_OPs_Liberadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 811);
            this.Controls.Add(this.btnSoLiberadas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPDFNaoFakeLista);
            this.Controls.Add(this.btnPdfNaoFakeLista);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPDFFakeLista);
            this.Controls.Add(this.btnPdfFakeLista);
            this.Controls.Add(this.lblFake);
            this.Controls.Add(this.txtPdfFake);
            this.Controls.Add(this.btnPdfFake);
            this.Controls.Add(this.txtOP);
            this.Controls.Add(this.lblStatistica);
            this.Controls.Add(this.btnSoManutencao);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Verificar_OPs_Liberadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificar OPs Liberadas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnSoManutencao;
        private System.Windows.Forms.Label lblStatistica;
        public System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.Button btnPdfFake;
        public System.Windows.Forms.TextBox txtPdfFake;
        private System.Windows.Forms.Label lblFake;
        public System.Windows.Forms.TextBox txtPDFFakeLista;
        private System.Windows.Forms.Button btnPdfFakeLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtPDFNaoFakeLista;
        private System.Windows.Forms.Button btnPdfNaoFakeLista;
        private System.Windows.Forms.Button btnSoLiberadas;
    }
}