
namespace Estoque.Views
{
    partial class InativarExcluirItens
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
            this.btnListarParaExcel = new System.Windows.Forms.Button();
            this.btnAbrePlanilha = new System.Windows.Forms.Button();
            this.btnCarregaPlanilha = new System.Windows.Forms.Button();
            this.btnExcluiItens = new System.Windows.Forms.Button();
            this.btnInativaItens = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnListarParaExcel
            // 
            this.btnListarParaExcel.Location = new System.Drawing.Point(12, 192);
            this.btnListarParaExcel.Name = "btnListarParaExcel";
            this.btnListarParaExcel.Size = new System.Drawing.Size(127, 52);
            this.btnListarParaExcel.TabIndex = 0;
            this.btnListarParaExcel.Text = "1- Listar para Excel";
            this.btnListarParaExcel.UseVisualStyleBackColor = true;
            this.btnListarParaExcel.Click += new System.EventHandler(this.btnListarParaExcel_Click);
            // 
            // btnAbrePlanilha
            // 
            this.btnAbrePlanilha.Location = new System.Drawing.Point(145, 192);
            this.btnAbrePlanilha.Name = "btnAbrePlanilha";
            this.btnAbrePlanilha.Size = new System.Drawing.Size(127, 52);
            this.btnAbrePlanilha.TabIndex = 2;
            this.btnAbrePlanilha.Text = "2- Deixar apenas os itens para serem Inativados ou Excluidos";
            this.btnAbrePlanilha.UseVisualStyleBackColor = true;
            this.btnAbrePlanilha.Click += new System.EventHandler(this.btnAbrePlanilha_Click);
            // 
            // btnCarregaPlanilha
            // 
            this.btnCarregaPlanilha.Location = new System.Drawing.Point(278, 192);
            this.btnCarregaPlanilha.Name = "btnCarregaPlanilha";
            this.btnCarregaPlanilha.Size = new System.Drawing.Size(127, 52);
            this.btnCarregaPlanilha.TabIndex = 3;
            this.btnCarregaPlanilha.Text = "3- Carregar PlanilhaExcel";
            this.btnCarregaPlanilha.UseVisualStyleBackColor = true;
            this.btnCarregaPlanilha.Click += new System.EventHandler(this.btnCarregaPlanilha_Click);
            // 
            // btnExcluiItens
            // 
            this.btnExcluiItens.Location = new System.Drawing.Point(454, 150);
            this.btnExcluiItens.Name = "btnExcluiItens";
            this.btnExcluiItens.Size = new System.Drawing.Size(127, 52);
            this.btnExcluiItens.TabIndex = 4;
            this.btnExcluiItens.Text = "10- Executar Excluir Item";
            this.btnExcluiItens.UseVisualStyleBackColor = true;
            this.btnExcluiItens.Click += new System.EventHandler(this.btnExcluiItens_Click);
            // 
            // btnInativaItens
            // 
            this.btnInativaItens.Location = new System.Drawing.Point(454, 235);
            this.btnInativaItens.Name = "btnInativaItens";
            this.btnInativaItens.Size = new System.Drawing.Size(127, 52);
            this.btnInativaItens.TabIndex = 5;
            this.btnInativaItens.Text = "20 - Executar Inativar Item";
            this.btnInativaItens.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(454, 111);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(235, 33);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Cada planilha poderar tomar apenas uma acao. Ou Excluir ou Inativar. Ou btn 10 ou" +
    " btn 20";
            // 
            // InativarExcluirItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnInativaItens);
            this.Controls.Add(this.btnExcluiItens);
            this.Controls.Add(this.btnCarregaPlanilha);
            this.Controls.Add(this.btnAbrePlanilha);
            this.Controls.Add(this.btnListarParaExcel);
            this.Name = "InativarExcluirItens";
            this.Text = "InativarExcluirItens";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListarParaExcel;
        private System.Windows.Forms.Button btnAbrePlanilha;
        private System.Windows.Forms.Button btnCarregaPlanilha;
        private System.Windows.Forms.Button btnExcluiItens;
        private System.Windows.Forms.Button btnInativaItens;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}