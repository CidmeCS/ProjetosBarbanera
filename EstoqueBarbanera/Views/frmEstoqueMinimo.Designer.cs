namespace Estoque.Views
{
    partial class frmEstoqueMinimo
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
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbbPesquisar = new System.Windows.Forms.ComboBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnEstoqueMinimo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSelecionar.Location = new System.Drawing.Point(1016, 65);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(84, 36);
            this.btnSelecionar.TabIndex = 241;
            this.btnSelecionar.Text = "SELECIONAR";
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.Red;
            this.btnDeletar.Location = new System.Drawing.Point(927, 19);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 36);
            this.btnDeletar.TabIndex = 240;
            this.btnDeletar.Text = "DELETAR";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 239;
            this.label2.Text = "ID";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(39, 87);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(47, 13);
            this.lblID.TabIndex = 238;
            this.lblID.Text = "ID Vázio";
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAlterar.Location = new System.Drawing.Point(846, 19);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 36);
            this.btnAlterar.TabIndex = 237;
            this.btnAlterar.Text = "ALTERAR";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(15, 35);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(248, 20);
            this.txtPesquisar.TabIndex = 236;
            // 
            // cbbPesquisar
            // 
            this.cbbPesquisar.FormattingEnabled = true;
            this.cbbPesquisar.Items.AddRange(new object[] {
            "ID ",
            "Produto ",
            "Descricao ",
            "QTD ",
            "UND ",
            "OP ",
            "DataHora ",
            "PrazoSolicitado ",
            "Andamento ",
            "FimStatus"});
            this.cbbPesquisar.Location = new System.Drawing.Point(269, 34);
            this.cbbPesquisar.Name = "cbbPesquisar";
            this.cbbPesquisar.Size = new System.Drawing.Size(121, 21);
            this.cbbPesquisar.TabIndex = 235;
            this.cbbPesquisar.Text = "Descricao";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(546, 34);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 30);
            this.btnAtualizar.TabIndex = 234;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(396, 34);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 30);
            this.btnPesquisar.TabIndex = 233;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button6.Location = new System.Drawing.Point(1183, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 36);
            this.button6.TabIndex = 231;
            this.button6.Text = "FINALIZAR";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnFinalizar);
            // 
            // btnEstoqueMinimo
            // 
            this.btnEstoqueMinimo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnEstoqueMinimo.Location = new System.Drawing.Point(1102, 19);
            this.btnEstoqueMinimo.Name = "btnEstoqueMinimo";
            this.btnEstoqueMinimo.Size = new System.Drawing.Size(75, 36);
            this.btnEstoqueMinimo.TabIndex = 230;
            this.btnEstoqueMinimo.Text = "SOLICITAR";
            this.btnEstoqueMinimo.UseVisualStyleBackColor = false;
            this.btnEstoqueMinimo.Click += new System.EventHandler(this.btnEstoqueMinimo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1243, 598);
            this.dataGridView1.TabIndex = 232;
            // 
            // frmEstoqueMinimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 725);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.cbbPesquisar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnEstoqueMinimo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmEstoqueMinimo";
            this.Text = "frmEstoqueMinimo";
            this.Load += new System.EventHandler(this.EstoqueMinima_Load);
            this.Click += new System.EventHandler(this.EstoqueMinima_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbbPesquisar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnEstoqueMinimo;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}