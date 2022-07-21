
namespace Estoque.Views
{
    partial class ForaDeEstoqueForm
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
            this.dgvForaDeEstoque = new System.Windows.Forms.DataGridView();
            this.btnEnviaEmail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForaDeEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvForaDeEstoque
            // 
            this.dgvForaDeEstoque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvForaDeEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForaDeEstoque.Location = new System.Drawing.Point(12, 25);
            this.dgvForaDeEstoque.Name = "dgvForaDeEstoque";
            this.dgvForaDeEstoque.Size = new System.Drawing.Size(944, 692);
            this.dgvForaDeEstoque.TabIndex = 0;
            // 
            // btnEnviaEmail
            // 
            this.btnEnviaEmail.Location = new System.Drawing.Point(1068, 83);
            this.btnEnviaEmail.Name = "btnEnviaEmail";
            this.btnEnviaEmail.Size = new System.Drawing.Size(75, 23);
            this.btnEnviaEmail.TabIndex = 1;
            this.btnEnviaEmail.Text = "Envia E-Mail";
            this.btnEnviaEmail.UseVisualStyleBackColor = true;
            this.btnEnviaEmail.Click += new System.EventHandler(this.btnEnviaEmail_Click);
            // 
            // ForaDeEstoqueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 729);
            this.Controls.Add(this.btnEnviaEmail);
            this.Controls.Add(this.dgvForaDeEstoque);
            this.Name = "ForaDeEstoqueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForaDeEstoqueForm";
            this.Load += new System.EventHandler(this.ForaDeEstoqueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForaDeEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvForaDeEstoque;
        private System.Windows.Forms.Button btnEnviaEmail;
    }
}