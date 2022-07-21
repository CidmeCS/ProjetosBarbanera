
namespace Estoque.Views
{
    partial class G11SemPrateleiraComSaldo
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
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnEliminaLinha = new System.Windows.Forms.Button();
            this.btnEliminaTudo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(30, 179);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(1234, 411);
            this.dgvResult.TabIndex = 0;
            // 
            // btnEliminaLinha
            // 
            this.btnEliminaLinha.Location = new System.Drawing.Point(30, 124);
            this.btnEliminaLinha.Name = "btnEliminaLinha";
            this.btnEliminaLinha.Size = new System.Drawing.Size(77, 40);
            this.btnEliminaLinha.TabIndex = 1;
            this.btnEliminaLinha.Text = "Elimina Linha";
            this.btnEliminaLinha.UseVisualStyleBackColor = true;
            this.btnEliminaLinha.Click += new System.EventHandler(this.btnEliminaLinha_Click);
            // 
            // btnEliminaTudo
            // 
            this.btnEliminaTudo.Location = new System.Drawing.Point(1187, 124);
            this.btnEliminaTudo.Name = "btnEliminaTudo";
            this.btnEliminaTudo.Size = new System.Drawing.Size(77, 40);
            this.btnEliminaTudo.TabIndex = 2;
            this.btnEliminaTudo.Text = "Elimina Tudo";
            this.btnEliminaTudo.UseVisualStyleBackColor = true;
            this.btnEliminaTudo.Click += new System.EventHandler(this.btnEliminaTudo_Click);
            // 
            // G11SemPrateleiraComSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 621);
            this.Controls.Add(this.btnEliminaTudo);
            this.Controls.Add(this.btnEliminaLinha);
            this.Controls.Add(this.dgvResult);
            this.Name = "G11SemPrateleiraComSaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G11SemPrateleiraComSaldo";
            this.Load += new System.EventHandler(this.G11SemPrateleiraComSaldo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnEliminaLinha;
        private System.Windows.Forms.Button btnEliminaTudo;
    }
}