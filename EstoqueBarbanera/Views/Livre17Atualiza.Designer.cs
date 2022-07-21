
namespace Estoque.Views
{
    partial class Livre17Atualiza
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
            this.btnLimparTudo = new System.Windows.Forms.Button();
            this.btnLimparLinha = new System.Windows.Forms.Button();
            this.btnAlteraNoERP = new System.Windows.Forms.Button();
            this.dgvLivre17 = new System.Windows.Forms.DataGridView();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Livre17Atual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Livre17New = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPersonalizado = new System.Windows.Forms.Button();
            this.btnAlteraETQ = new System.Windows.Forms.Button();
            this.btnAlteraSaldo = new System.Windows.Forms.Button();
            this.btnAlteraSaldoEtq = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivre17)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimparTudo
            // 
            this.btnLimparTudo.Location = new System.Drawing.Point(1142, 365);
            this.btnLimparTudo.Name = "btnLimparTudo";
            this.btnLimparTudo.Size = new System.Drawing.Size(105, 23);
            this.btnLimparTudo.TabIndex = 7;
            this.btnLimparTudo.Text = "Limpar Tudo";
            this.btnLimparTudo.UseVisualStyleBackColor = true;
            this.btnLimparTudo.Click += new System.EventHandler(this.btnLimparTudo_Click_1);
            // 
            // btnLimparLinha
            // 
            this.btnLimparLinha.Location = new System.Drawing.Point(1142, 307);
            this.btnLimparLinha.Name = "btnLimparLinha";
            this.btnLimparLinha.Size = new System.Drawing.Size(105, 23);
            this.btnLimparLinha.TabIndex = 6;
            this.btnLimparLinha.Text = "Limpar Linha";
            this.btnLimparLinha.UseVisualStyleBackColor = true;
            this.btnLimparLinha.Click += new System.EventHandler(this.btnLimparLinha_Click_1);
            // 
            // btnAlteraNoERP
            // 
            this.btnAlteraNoERP.Location = new System.Drawing.Point(954, 199);
            this.btnAlteraNoERP.Name = "btnAlteraNoERP";
            this.btnAlteraNoERP.Size = new System.Drawing.Size(105, 37);
            this.btnAlteraNoERP.TabIndex = 5;
            this.btnAlteraNoERP.Text = "Alterar no ERP, Saldo e ETQ";
            this.btnAlteraNoERP.UseVisualStyleBackColor = true;
            this.btnAlteraNoERP.Click += new System.EventHandler(this.btnAlteraNoERP_Click_1);
            // 
            // dgvLivre17
            // 
            this.dgvLivre17.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivre17.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Produto,
            this.Descricao,
            this.Livre17Atual,
            this.Livre17New});
            this.dgvLivre17.Location = new System.Drawing.Point(69, 176);
            this.dgvLivre17.Name = "dgvLivre17";
            this.dgvLivre17.Size = new System.Drawing.Size(852, 281);
            this.dgvLivre17.TabIndex = 4;
            this.dgvLivre17.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivre17_CellEndEdit);
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto";
            this.Produto.MaxInputLength = 14;
            this.Produto.Name = "Produto";
            // 
            // Descricao
            // 
            this.Descricao.FillWeight = 500F;
            this.Descricao.HeaderText = "Descricao";
            this.Descricao.MaxInputLength = 50;
            this.Descricao.Name = "Descricao";
            // 
            // Livre17Atual
            // 
            this.Livre17Atual.HeaderText = "Livre17Atual";
            this.Livre17Atual.MaxInputLength = 11;
            this.Livre17Atual.Name = "Livre17Atual";
            // 
            // Livre17New
            // 
            this.Livre17New.HeaderText = "Livre17New";
            this.Livre17New.MaxInputLength = 11;
            this.Livre17New.Name = "Livre17New";
            // 
            // btnPersonalizado
            // 
            this.btnPersonalizado.Enabled = false;
            this.btnPersonalizado.Location = new System.Drawing.Point(787, 65);
            this.btnPersonalizado.Name = "btnPersonalizado";
            this.btnPersonalizado.Size = new System.Drawing.Size(105, 23);
            this.btnPersonalizado.TabIndex = 8;
            this.btnPersonalizado.Text = "Personalizado";
            this.btnPersonalizado.UseVisualStyleBackColor = true;
            this.btnPersonalizado.Click += new System.EventHandler(this.btnPersonalizado_Click);
            // 
            // btnAlteraETQ
            // 
            this.btnAlteraETQ.Location = new System.Drawing.Point(1335, 199);
            this.btnAlteraETQ.Name = "btnAlteraETQ";
            this.btnAlteraETQ.Size = new System.Drawing.Size(105, 23);
            this.btnAlteraETQ.TabIndex = 9;
            this.btnAlteraETQ.Text = "Alterar no ETQ";
            this.btnAlteraETQ.UseVisualStyleBackColor = true;
            this.btnAlteraETQ.Click += new System.EventHandler(this.btnAlteraETQ_Click);
            // 
            // btnAlteraSaldo
            // 
            this.btnAlteraSaldo.Location = new System.Drawing.Point(1201, 199);
            this.btnAlteraSaldo.Name = "btnAlteraSaldo";
            this.btnAlteraSaldo.Size = new System.Drawing.Size(105, 23);
            this.btnAlteraSaldo.TabIndex = 10;
            this.btnAlteraSaldo.Text = "Alterar no Saldo";
            this.btnAlteraSaldo.UseVisualStyleBackColor = true;
            this.btnAlteraSaldo.Click += new System.EventHandler(this.btnAlteraSaldo_Click);
            // 
            // btnAlteraSaldoEtq
            // 
            this.btnAlteraSaldoEtq.Location = new System.Drawing.Point(1078, 199);
            this.btnAlteraSaldoEtq.Name = "btnAlteraSaldoEtq";
            this.btnAlteraSaldoEtq.Size = new System.Drawing.Size(105, 37);
            this.btnAlteraSaldoEtq.TabIndex = 11;
            this.btnAlteraSaldoEtq.Text = "Alterar no Saldo e ETQ";
            this.btnAlteraSaldoEtq.UseVisualStyleBackColor = true;
            this.btnAlteraSaldoEtq.Click += new System.EventHandler(this.btnAlteraSaldoEtq_Click);
            // 
            // Livre17Atualiza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 636);
            this.Controls.Add(this.btnAlteraSaldoEtq);
            this.Controls.Add(this.btnAlteraSaldo);
            this.Controls.Add(this.btnAlteraETQ);
            this.Controls.Add(this.btnPersonalizado);
            this.Controls.Add(this.btnLimparTudo);
            this.Controls.Add(this.btnLimparLinha);
            this.Controls.Add(this.btnAlteraNoERP);
            this.Controls.Add(this.dgvLivre17);
            this.Name = "Livre17Atualiza";
            this.Text = "Livre17Atualiza";
            this.Load += new System.EventHandler(this.Livre17Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivre17)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimparTudo;
        private System.Windows.Forms.Button btnLimparLinha;
        private System.Windows.Forms.Button btnAlteraNoERP;
        private System.Windows.Forms.DataGridView dgvLivre17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Livre17Atual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Livre17New;
        private System.Windows.Forms.Button btnPersonalizado;
        private System.Windows.Forms.Button btnAlteraETQ;
        private System.Windows.Forms.Button btnAlteraSaldo;
        private System.Windows.Forms.Button btnAlteraSaldoEtq;
    }
}