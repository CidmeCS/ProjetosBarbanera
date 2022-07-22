namespace SincronizaProjetosEstoque
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSincroniza = new System.Windows.Forms.Button();
            this.lbList = new System.Windows.Forms.ListBox();
            this.btnImportExport = new System.Windows.Forms.Button();
            this.btnSincGeral = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSincroniza
            // 
            this.btnSincroniza.Location = new System.Drawing.Point(116, 141);
            this.btnSincroniza.Name = "btnSincroniza";
            this.btnSincroniza.Size = new System.Drawing.Size(115, 23);
            this.btnSincroniza.TabIndex = 0;
            this.btnSincroniza.Text = "Sincroniza Tudo";
            this.btnSincroniza.UseVisualStyleBackColor = true;
            this.btnSincroniza.Click += new System.EventHandler(this.btnSincroniza_Click);
            // 
            // lbList
            // 
            this.lbList.FormattingEnabled = true;
            this.lbList.Location = new System.Drawing.Point(299, 141);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(314, 173);
            this.lbList.TabIndex = 1;
            // 
            // btnImportExport
            // 
            this.btnImportExport.Location = new System.Drawing.Point(116, 212);
            this.btnImportExport.Name = "btnImportExport";
            this.btnImportExport.Size = new System.Drawing.Size(139, 23);
            this.btnImportExport.TabIndex = 2;
            this.btnImportExport.Text = "Sincroniza ImportExport";
            this.btnImportExport.UseVisualStyleBackColor = true;
            this.btnImportExport.Click += new System.EventHandler(this.btnImportExport_Click);
            // 
            // btnSincGeral
            // 
            this.btnSincGeral.Location = new System.Drawing.Point(116, 291);
            this.btnSincGeral.Name = "btnSincGeral";
            this.btnSincGeral.Size = new System.Drawing.Size(152, 23);
            this.btnSincGeral.TabIndex = 3;
            this.btnSincGeral.Text = "Sincroniza EstoqGerenciador";
            this.btnSincGeral.UseVisualStyleBackColor = true;
            this.btnSincGeral.Click += new System.EventHandler(this.btnSincGeral_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSincGeral);
            this.Controls.Add(this.btnImportExport);
            this.Controls.Add(this.lbList);
            this.Controls.Add(this.btnSincroniza);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSincroniza;
        private System.Windows.Forms.ListBox lbList;
        private System.Windows.Forms.Button btnImportExport;
        private System.Windows.Forms.Button btnSincGeral;
    }
}

