
namespace Estoque.Views
{
    partial class PCP
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
            this.dgvPCP = new System.Windows.Forms.DataGridView();
            this.btnEliminaTudo = new System.Windows.Forms.Button();
            this.btnEliminaLinha = new System.Windows.Forms.Button();
            this.btnAtualiza = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPCP
            // 
            this.dgvPCP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPCP.Location = new System.Drawing.Point(12, 169);
            this.dgvPCP.Name = "dgvPCP";
            this.dgvPCP.Size = new System.Drawing.Size(1793, 654);
            this.dgvPCP.TabIndex = 0;
            // 
            // btnEliminaTudo
            // 
            this.btnEliminaTudo.BackColor = System.Drawing.Color.Coral;
            this.btnEliminaTudo.Location = new System.Drawing.Point(1173, 109);
            this.btnEliminaTudo.Name = "btnEliminaTudo";
            this.btnEliminaTudo.Size = new System.Drawing.Size(77, 40);
            this.btnEliminaTudo.TabIndex = 4;
            this.btnEliminaTudo.Text = "Elimina Tudo";
            this.btnEliminaTudo.UseVisualStyleBackColor = false;
            this.btnEliminaTudo.Click += new System.EventHandler(this.btnEliminaTudo_Click);
            // 
            // btnEliminaLinha
            // 
            this.btnEliminaLinha.BackColor = System.Drawing.Color.Gold;
            this.btnEliminaLinha.Location = new System.Drawing.Point(67, 109);
            this.btnEliminaLinha.Name = "btnEliminaLinha";
            this.btnEliminaLinha.Size = new System.Drawing.Size(77, 40);
            this.btnEliminaLinha.TabIndex = 3;
            this.btnEliminaLinha.Text = "Elimina Linha";
            this.btnEliminaLinha.UseVisualStyleBackColor = false;
            this.btnEliminaLinha.Click += new System.EventHandler(this.btnEliminaLinha_Click);
            // 
            // btnAtualiza
            // 
            this.btnAtualiza.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAtualiza.Location = new System.Drawing.Point(650, 109);
            this.btnAtualiza.Name = "btnAtualiza";
            this.btnAtualiza.Size = new System.Drawing.Size(77, 40);
            this.btnAtualiza.TabIndex = 5;
            this.btnAtualiza.Text = "Atualiza";
            this.btnAtualiza.UseVisualStyleBackColor = false;
            this.btnAtualiza.Click += new System.EventHandler(this.btnAtualiza_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(715, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Materiais dos Grupos 10 e 11 com saldo positivo e sem prateleiras";
            // 
            // PCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 835);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtualiza);
            this.Controls.Add(this.btnEliminaTudo);
            this.Controls.Add(this.btnEliminaLinha);
            this.Controls.Add(this.dgvPCP);
            this.Name = "PCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCP";
            this.Load += new System.EventHandler(this.PCP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPCP;
        private System.Windows.Forms.Button btnEliminaTudo;
        private System.Windows.Forms.Button btnEliminaLinha;
        private System.Windows.Forms.Button btnAtualiza;
        private System.Windows.Forms.Label label1;
    }
}