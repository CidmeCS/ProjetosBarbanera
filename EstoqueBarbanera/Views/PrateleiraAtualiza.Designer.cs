
namespace Estoque.Views
{
    partial class PrateleiraAtualiza
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
            this.dgvPrateleira = new System.Windows.Forms.DataGridView();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrateleiraAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrateleiraNova = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAlteraNoERP = new System.Windows.Forms.Button();
            this.btnLimparLinha = new System.Windows.Forms.Button();
            this.btnLimparTudo = new System.Windows.Forms.Button();
            this.btnAlteraSaldos = new System.Windows.Forms.Button();
            this.btnAlteraETQ = new System.Windows.Forms.Button();
            this.btnAlteraSaldoEtq = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrateleira)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrateleira
            // 
            this.dgvPrateleira.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrateleira.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Produto,
            this.Descricao,
            this.PrateleiraAtual,
            this.PrateleiraNova});
            this.dgvPrateleira.Location = new System.Drawing.Point(12, 189);
            this.dgvPrateleira.Name = "dgvPrateleira";
            this.dgvPrateleira.Size = new System.Drawing.Size(852, 281);
            this.dgvPrateleira.TabIndex = 0;
            this.dgvPrateleira.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellEndEdit);
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
            // PrateleiraAtual
            // 
            this.PrateleiraAtual.HeaderText = "PrateleiraAtual";
            this.PrateleiraAtual.MaxInputLength = 11;
            this.PrateleiraAtual.Name = "PrateleiraAtual";
            // 
            // PrateleiraNova
            // 
            this.PrateleiraNova.HeaderText = "PrateleiraNova";
            this.PrateleiraNova.MaxInputLength = 11;
            this.PrateleiraNova.Name = "PrateleiraNova";
            // 
            // btnAlteraNoERP
            // 
            this.btnAlteraNoERP.Location = new System.Drawing.Point(930, 200);
            this.btnAlteraNoERP.Name = "btnAlteraNoERP";
            this.btnAlteraNoERP.Size = new System.Drawing.Size(105, 38);
            this.btnAlteraNoERP.TabIndex = 1;
            this.btnAlteraNoERP.Text = "Alterar no ERP, Saldos e ETQ";
            this.btnAlteraNoERP.UseVisualStyleBackColor = true;
            this.btnAlteraNoERP.Click += new System.EventHandler(this.btnAlteraNoERP_Click);
            // 
            // btnLimparLinha
            // 
            this.btnLimparLinha.Location = new System.Drawing.Point(930, 318);
            this.btnLimparLinha.Name = "btnLimparLinha";
            this.btnLimparLinha.Size = new System.Drawing.Size(105, 23);
            this.btnLimparLinha.TabIndex = 2;
            this.btnLimparLinha.Text = "Limpar Linha";
            this.btnLimparLinha.UseVisualStyleBackColor = true;
            this.btnLimparLinha.Click += new System.EventHandler(this.btnLimparLinha_Click);
            // 
            // btnLimparTudo
            // 
            this.btnLimparTudo.Location = new System.Drawing.Point(930, 376);
            this.btnLimparTudo.Name = "btnLimparTudo";
            this.btnLimparTudo.Size = new System.Drawing.Size(105, 23);
            this.btnLimparTudo.TabIndex = 3;
            this.btnLimparTudo.Text = "Limpar Tudo";
            this.btnLimparTudo.UseVisualStyleBackColor = true;
            this.btnLimparTudo.Click += new System.EventHandler(this.btnLimparTudo_Click);
            // 
            // btnAlteraSaldos
            // 
            this.btnAlteraSaldos.Location = new System.Drawing.Point(1186, 200);
            this.btnAlteraSaldos.Name = "btnAlteraSaldos";
            this.btnAlteraSaldos.Size = new System.Drawing.Size(105, 23);
            this.btnAlteraSaldos.TabIndex = 4;
            this.btnAlteraSaldos.Text = "Alterar no Saldos";
            this.btnAlteraSaldos.UseVisualStyleBackColor = true;
            this.btnAlteraSaldos.Click += new System.EventHandler(this.btnAlteraSaldos_Click);
            // 
            // btnAlteraETQ
            // 
            this.btnAlteraETQ.Location = new System.Drawing.Point(1313, 200);
            this.btnAlteraETQ.Name = "btnAlteraETQ";
            this.btnAlteraETQ.Size = new System.Drawing.Size(105, 23);
            this.btnAlteraETQ.TabIndex = 5;
            this.btnAlteraETQ.Text = "Alterar na ETQ";
            this.btnAlteraETQ.UseVisualStyleBackColor = true;
            this.btnAlteraETQ.Click += new System.EventHandler(this.btnAlteraETQ_Click);
            // 
            // btnAlteraSaldoEtq
            // 
            this.btnAlteraSaldoEtq.Location = new System.Drawing.Point(1057, 200);
            this.btnAlteraSaldoEtq.Name = "btnAlteraSaldoEtq";
            this.btnAlteraSaldoEtq.Size = new System.Drawing.Size(105, 38);
            this.btnAlteraSaldoEtq.TabIndex = 6;
            this.btnAlteraSaldoEtq.Text = "Alterar no Saldos e ETQ";
            this.btnAlteraSaldoEtq.UseVisualStyleBackColor = true;
            this.btnAlteraSaldoEtq.Click += new System.EventHandler(this.btnAlteraSaldoEtq_Click);
            // 
            // PrateleiraAtualiza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 837);
            this.Controls.Add(this.btnAlteraSaldoEtq);
            this.Controls.Add(this.btnAlteraETQ);
            this.Controls.Add(this.btnAlteraSaldos);
            this.Controls.Add(this.btnLimparTudo);
            this.Controls.Add(this.btnLimparLinha);
            this.Controls.Add(this.btnAlteraNoERP);
            this.Controls.Add(this.dgvPrateleira);
            this.Name = "PrateleiraAtualiza";
            this.Text = "PrateleiraAtualiza";
            this.Load += new System.EventHandler(this.PateleiraLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrateleira)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrateleira;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrateleiraAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrateleiraNova;
        private System.Windows.Forms.Button btnAlteraNoERP;
        private System.Windows.Forms.Button btnLimparLinha;
        private System.Windows.Forms.Button btnLimparTudo;
        private System.Windows.Forms.Button btnAlteraSaldos;
        private System.Windows.Forms.Button btnAlteraETQ;
        private System.Windows.Forms.Button btnAlteraSaldoEtq;
    }
}