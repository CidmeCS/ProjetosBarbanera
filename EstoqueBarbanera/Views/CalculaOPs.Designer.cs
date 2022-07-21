namespace Estoque.Views
{
    partial class CalculaOPs
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
            this.btnBuscaOP = new System.Windows.Forms.Button();
            this.txtOP = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscaOP
            // 
            this.btnBuscaOP.Location = new System.Drawing.Point(230, 73);
            this.btnBuscaOP.Name = "btnBuscaOP";
            this.btnBuscaOP.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaOP.TabIndex = 0;
            this.btnBuscaOP.Text = "Busca";
            this.btnBuscaOP.UseVisualStyleBackColor = true;
            this.btnBuscaOP.Click += new System.EventHandler(this.btnBuscaOP_Click);
            // 
            // txtOP
            // 
            this.txtOP.Location = new System.Drawing.Point(68, 73);
            this.txtOP.Name = "txtOP";
            this.txtOP.Size = new System.Drawing.Size(100, 20);
            this.txtOP.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1069, 329);
            this.dataGridView1.TabIndex = 2;
            // 
            // CalculaOPs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 651);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtOP);
            this.Controls.Add(this.btnBuscaOP);
            this.Name = "CalculaOPs";
            this.Text = "CalculaOPs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscaOP;
        private System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}