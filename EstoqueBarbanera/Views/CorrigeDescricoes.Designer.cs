
namespace Estoque.Views
{
    partial class CorrigeDescricoes
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
            this.btnDosOutrosSetores = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblLinhas = new System.Windows.Forms.Label();
            this.btnListaParaCorrigir = new System.Windows.Forms.Button();
            this.btnCorrigeDoGrid = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbCorrecao = new System.Windows.Forms.TextBox();
            this.tbBusca = new System.Windows.Forms.TextBox();
            this.btnAjudaGrid = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDosOutrosSetores
            // 
            this.btnDosOutrosSetores.Location = new System.Drawing.Point(55, 100);
            this.btnDosOutrosSetores.Name = "btnDosOutrosSetores";
            this.btnDosOutrosSetores.Size = new System.Drawing.Size(97, 54);
            this.btnDosOutrosSetores.TabIndex = 0;
            this.btnDosOutrosSetores.Text = "Corrige Descriçoes dos outros setores";
            this.btnDosOutrosSetores.UseVisualStyleBackColor = true;
            this.btnDosOutrosSetores.Click += new System.EventHandler(this.btnDosOutrosSetores_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 309);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 204);
            this.dataGridView1.TabIndex = 1;
            // 
            // lblLinhas
            // 
            this.lblLinhas.AutoSize = true;
            this.lblLinhas.Location = new System.Drawing.Point(323, 141);
            this.lblLinhas.Name = "lblLinhas";
            this.lblLinhas.Size = new System.Drawing.Size(11, 13);
            this.lblLinhas.TabIndex = 256;
            this.lblLinhas.Text = "*";
            // 
            // btnListaParaCorrigir
            // 
            this.btnListaParaCorrigir.Location = new System.Drawing.Point(248, 62);
            this.btnListaParaCorrigir.Name = "btnListaParaCorrigir";
            this.btnListaParaCorrigir.Size = new System.Drawing.Size(97, 38);
            this.btnListaParaCorrigir.TabIndex = 257;
            this.btnListaParaCorrigir.Text = "1 Pesquisar";
            this.btnListaParaCorrigir.UseVisualStyleBackColor = true;
            this.btnListaParaCorrigir.Click += new System.EventHandler(this.btnListaParaCorrigir_Click);
            // 
            // btnCorrigeDoGrid
            // 
            this.btnCorrigeDoGrid.Location = new System.Drawing.Point(767, 54);
            this.btnCorrigeDoGrid.Name = "btnCorrigeDoGrid";
            this.btnCorrigeDoGrid.Size = new System.Drawing.Size(97, 54);
            this.btnCorrigeDoGrid.TabIndex = 258;
            this.btnCorrigeDoGrid.Text = "3 Corrigir no ERP";
            this.btnCorrigeDoGrid.UseVisualStyleBackColor = true;
            this.btnCorrigeDoGrid.Click += new System.EventHandler(this.btnCorrigeDoGrid_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1443, 819);
            this.tabControl1.TabIndex = 259;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btnDosOutrosSetores);
            this.tabPage1.Controls.Add(this.lblLinhas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1435, 793);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.tbCorrecao);
            this.tabPage2.Controls.Add(this.tbBusca);
            this.tabPage2.Controls.Add(this.btnAjudaGrid);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnCorrigeDoGrid);
            this.tabPage2.Controls.Add(this.btnListaParaCorrigir);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1435, 793);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "12000000",
            "15000000",
            "16000000",
            "17000000",
            "20000000"});
            this.comboBox1.Location = new System.Drawing.Point(9, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 265;
            // 
            // tbCorrecao
            // 
            this.tbCorrecao.Location = new System.Drawing.Point(396, 46);
            this.tbCorrecao.Name = "tbCorrecao";
            this.tbCorrecao.Size = new System.Drawing.Size(214, 20);
            this.tbCorrecao.TabIndex = 264;
            // 
            // tbBusca
            // 
            this.tbBusca.Location = new System.Drawing.Point(9, 43);
            this.tbBusca.Name = "tbBusca";
            this.tbBusca.Size = new System.Drawing.Size(214, 20);
            this.tbBusca.TabIndex = 263;
            // 
            // btnAjudaGrid
            // 
            this.btnAjudaGrid.Location = new System.Drawing.Point(513, 72);
            this.btnAjudaGrid.Name = "btnAjudaGrid";
            this.btnAjudaGrid.Size = new System.Drawing.Size(97, 36);
            this.btnAjudaGrid.TabIndex = 262;
            this.btnAjudaGrid.Text = "2 Substitua por";
            this.btnAjudaGrid.UseVisualStyleBackColor = true;
            this.btnAjudaGrid.Click += new System.EventHandler(this.btnAjudaGrid_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(139, 95);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(84, 20);
            this.numericUpDown1.TabIndex = 261;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Produto,
            this.Descricao,
            this.Desc1,
            this.Desc2});
            this.dataGridView2.Location = new System.Drawing.Point(6, 143);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1423, 624);
            this.dataGridView2.TabIndex = 259;
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEndEdit);
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descricao";
            this.Descricao.MaxInputLength = 50;
            this.Descricao.Name = "Descricao";
            // 
            // Desc1
            // 
            this.Desc1.HeaderText = "Desc1";
            this.Desc1.MaxInputLength = 25;
            this.Desc1.Name = "Desc1";
            // 
            // Desc2
            // 
            this.Desc2.HeaderText = "Desc2";
            this.Desc2.MaxInputLength = 25;
            this.Desc2.Name = "Desc2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 260;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 266;
            this.label2.Text = "Selecione o Grupo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 267;
            this.label3.Text = "Desc a pesquisar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 268;
            this.label4.Text = "Substitua por";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 269;
            this.label5.Text = "Qtd a pesquisar";
            // 
            // CorrigeDescricoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 843);
            this.Controls.Add(this.tabControl1);
            this.Name = "CorrigeDescricoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CorrigeDescricoes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDosOutrosSetores;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblLinhas;
        private System.Windows.Forms.Button btnListaParaCorrigir;
        private System.Windows.Forms.Button btnCorrigeDoGrid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc2;
        private System.Windows.Forms.Button btnAjudaGrid;
        private System.Windows.Forms.TextBox tbCorrecao;
        private System.Windows.Forms.TextBox tbBusca;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}