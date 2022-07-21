namespace Estoque.Views
{
    partial class ManutencaoBarrasLongas
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
            this.lblCriterio = new System.Windows.Forms.Label();
            this.btnAtualiza = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCarregarExcelPreenchido = new System.Windows.Forms.Button();
            this.btnAlteraPrateleira = new System.Windows.Forms.Button();
            this.txtMetros = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1006, 434);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(49, 43);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(35, 13);
            this.lblCriterio.TabIndex = 1;
            this.lblCriterio.Text = "label1";
            // 
            // btnAtualiza
            // 
            this.btnAtualiza.Location = new System.Drawing.Point(241, 49);
            this.btnAtualiza.Name = "btnAtualiza";
            this.btnAtualiza.Size = new System.Drawing.Size(75, 23);
            this.btnAtualiza.TabIndex = 2;
            this.btnAtualiza.Text = "Atualiza";
            this.btnAtualiza.UseVisualStyleBackColor = true;
            this.btnAtualiza.Click += new System.EventHandler(this.btnAtualiza_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(348, 49);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCarregarExcelPreenchido
            // 
            this.btnCarregarExcelPreenchido.BackColor = System.Drawing.Color.Orange;
            this.btnCarregarExcelPreenchido.Location = new System.Drawing.Point(582, 43);
            this.btnCarregarExcelPreenchido.Name = "btnCarregarExcelPreenchido";
            this.btnCarregarExcelPreenchido.Size = new System.Drawing.Size(100, 44);
            this.btnCarregarExcelPreenchido.TabIndex = 269;
            this.btnCarregarExcelPreenchido.Text = "3- Carregar Excel Preenchido";
            this.btnCarregarExcelPreenchido.UseVisualStyleBackColor = false;
            this.btnCarregarExcelPreenchido.Click += new System.EventHandler(this.btnCarregarExcelPreenchido_Click);
            // 
            // btnAlteraPrateleira
            // 
            this.btnAlteraPrateleira.BackColor = System.Drawing.Color.Orange;
            this.btnAlteraPrateleira.Location = new System.Drawing.Point(582, 91);
            this.btnAlteraPrateleira.Name = "btnAlteraPrateleira";
            this.btnAlteraPrateleira.Size = new System.Drawing.Size(100, 44);
            this.btnAlteraPrateleira.TabIndex = 270;
            this.btnAlteraPrateleira.Text = "4- Altera Prateleira";
            this.btnAlteraPrateleira.UseVisualStyleBackColor = false;
            this.btnAlteraPrateleira.Click += new System.EventHandler(this.btnAlteraPrateleira_Click);
            // 
            // txtMetros
            // 
            this.txtMetros.Location = new System.Drawing.Point(241, 165);
            this.txtMetros.Name = "txtMetros";
            this.txtMetros.Size = new System.Drawing.Size(100, 20);
            this.txtMetros.TabIndex = 271;
            this.txtMetros.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 272;
            this.label1.Text = "Metros <= a:";
            // 
            // ManutencaoBarrasLongas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 656);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMetros);
            this.Controls.Add(this.btnCarregarExcelPreenchido);
            this.Controls.Add(this.btnAlteraPrateleira);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnAtualiza);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManutencaoBarrasLongas";
            this.Text = "ManutencaoBarrasLongas";
            this.Load += new System.EventHandler(this.Load_);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Button btnAtualiza;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCarregarExcelPreenchido;
        private System.Windows.Forms.Button btnAlteraPrateleira;
        private System.Windows.Forms.TextBox txtMetros;
        private System.Windows.Forms.Label label1;
    }
}