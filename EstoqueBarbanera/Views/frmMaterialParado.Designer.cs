namespace Estoque.Views
{
    partial class frmMaterialParado
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
            this.btnProdutos = new System.Windows.Forms.Button();
            this.lblLinhas = new System.Windows.Forms.Label();
            this.btnSemiAcabados = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1243, 633);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnProdutos
            // 
            this.btnProdutos.Location = new System.Drawing.Point(12, 12);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(75, 23);
            this.btnProdutos.TabIndex = 1;
            this.btnProdutos.Text = "Produtos Acabados";
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.ProdutosAcabados);
            // 
            // lblLinhas
            // 
            this.lblLinhas.AutoSize = true;
            this.lblLinhas.Location = new System.Drawing.Point(340, 95);
            this.lblLinhas.Name = "lblLinhas";
            this.lblLinhas.Size = new System.Drawing.Size(11, 13);
            this.lblLinhas.TabIndex = 256;
            this.lblLinhas.Text = "*";
            // 
            // btnSemiAcabados
            // 
            this.btnSemiAcabados.Location = new System.Drawing.Point(12, 41);
            this.btnSemiAcabados.Name = "btnSemiAcabados";
            this.btnSemiAcabados.Size = new System.Drawing.Size(92, 23);
            this.btnSemiAcabados.TabIndex = 257;
            this.btnSemiAcabados.Text = "Semi Acabados";
            this.btnSemiAcabados.UseVisualStyleBackColor = true;
            this.btnSemiAcabados.Click += new System.EventHandler(this.SemiAcabados_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(171, 29);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 23);
            this.btnImprimir.TabIndex = 258;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.Imprimir);
            // 
            // frmMaterialParado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 874);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSemiAcabados);
            this.Controls.Add(this.lblLinhas);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmMaterialParado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Parado";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Label lblLinhas;
        private System.Windows.Forms.Button btnSemiAcabados;
        private System.Windows.Forms.Button btnImprimir;
    }
}