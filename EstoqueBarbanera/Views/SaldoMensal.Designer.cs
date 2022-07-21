namespace Estoque.Views
{
    partial class SaldoMensal
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
            this.btnSaldoMensal = new System.Windows.Forms.Button();
            this.brnVerificaPPs = new System.Windows.Forms.Button();
            this.btnAplicaPPs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAplicarNoERP = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblStatusBotao = new System.Windows.Forms.Label();
            this.btnEnviarEmailPietro = new System.Windows.Forms.Button();
            this.btnVerificaGrupo10 = new System.Windows.Forms.Button();
            this.btnVerificaG12SemItemSpedOuErroPfiscal = new System.Windows.Forms.Button();
            this.btnVerificaGrupoRelItemSPED = new System.Windows.Forms.Button();
            this.btnVerificaGrupo11 = new System.Windows.Forms.Button();
            this.btnGruposEstranhos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaldoMensal
            // 
            this.btnSaldoMensal.BackColor = System.Drawing.Color.Tomato;
            this.btnSaldoMensal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaldoMensal.Location = new System.Drawing.Point(958, 40);
            this.btnSaldoMensal.Name = "btnSaldoMensal";
            this.btnSaldoMensal.Size = new System.Drawing.Size(75, 36);
            this.btnSaldoMensal.TabIndex = 241;
            this.btnSaldoMensal.Text = "Saldo Mensal";
            this.btnSaldoMensal.UseVisualStyleBackColor = false;
            this.btnSaldoMensal.Click += new System.EventHandler(this.btnSaldoMensal_Click);
            // 
            // brnVerificaPPs
            // 
            this.brnVerificaPPs.BackColor = System.Drawing.Color.IndianRed;
            this.brnVerificaPPs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnVerificaPPs.Location = new System.Drawing.Point(6, 19);
            this.brnVerificaPPs.Name = "brnVerificaPPs";
            this.brnVerificaPPs.Size = new System.Drawing.Size(123, 36);
            this.brnVerificaPPs.TabIndex = 242;
            this.brnVerificaPPs.Text = "Verificar PPs";
            this.brnVerificaPPs.UseVisualStyleBackColor = false;
            this.brnVerificaPPs.Click += new System.EventHandler(this.brnVerificaPPs_Click);
            // 
            // btnAplicaPPs
            // 
            this.btnAplicaPPs.BackColor = System.Drawing.Color.IndianRed;
            this.btnAplicaPPs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicaPPs.Location = new System.Drawing.Point(6, 112);
            this.btnAplicaPPs.Name = "btnAplicaPPs";
            this.btnAplicaPPs.Size = new System.Drawing.Size(123, 41);
            this.btnAplicaPPs.TabIndex = 243;
            this.btnAplicaPPs.Text = "Aplica Valorização np BancoDados";
            this.btnAplicaPPs.UseVisualStyleBackColor = false;
            this.btnAplicaPPs.Click += new System.EventHandler(this.btnAplicaPPs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAplicarNoERP);
            this.groupBox1.Controls.Add(this.brnVerificaPPs);
            this.groupBox1.Controls.Add(this.btnAplicaPPs);
            this.groupBox1.Location = new System.Drawing.Point(39, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 168);
            this.groupBox1.TabIndex = 244;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valoriza PPs";
            // 
            // btnAplicarNoERP
            // 
            this.btnAplicarNoERP.BackColor = System.Drawing.Color.IndianRed;
            this.btnAplicarNoERP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarNoERP.Location = new System.Drawing.Point(8, 64);
            this.btnAplicarNoERP.Name = "btnAplicarNoERP";
            this.btnAplicarNoERP.Size = new System.Drawing.Size(123, 41);
            this.btnAplicarNoERP.TabIndex = 244;
            this.btnAplicarNoERP.Text = "Aplica Valorização no ERP";
            this.btnAplicarNoERP.UseVisualStyleBackColor = false;
            this.btnAplicarNoERP.Click += new System.EventHandler(this.btnAplicarNoERP_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(12, 244);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1047, 387);
            this.dataGridView1.TabIndex = 245;
            // 
            // lblStatusBotao
            // 
            this.lblStatusBotao.AutoSize = true;
            this.lblStatusBotao.Location = new System.Drawing.Point(42, 214);
            this.lblStatusBotao.Name = "lblStatusBotao";
            this.lblStatusBotao.Size = new System.Drawing.Size(11, 13);
            this.lblStatusBotao.TabIndex = 246;
            this.lblStatusBotao.Text = "*";
            // 
            // btnEnviarEmailPietro
            // 
            this.btnEnviarEmailPietro.BackColor = System.Drawing.Color.Tomato;
            this.btnEnviarEmailPietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarEmailPietro.Location = new System.Drawing.Point(948, 102);
            this.btnEnviarEmailPietro.Name = "btnEnviarEmailPietro";
            this.btnEnviarEmailPietro.Size = new System.Drawing.Size(85, 36);
            this.btnEnviarEmailPietro.TabIndex = 247;
            this.btnEnviarEmailPietro.Text = "Enviar Email Pietro";
            this.btnEnviarEmailPietro.UseVisualStyleBackColor = false;
            this.btnEnviarEmailPietro.Click += new System.EventHandler(this.btnEnviarEmailPietro_Click);
            // 
            // btnVerificaGrupo10
            // 
            this.btnVerificaGrupo10.BackColor = System.Drawing.Color.IndianRed;
            this.btnVerificaGrupo10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificaGrupo10.Location = new System.Drawing.Point(259, 12);
            this.btnVerificaGrupo10.Name = "btnVerificaGrupo10";
            this.btnVerificaGrupo10.Size = new System.Drawing.Size(123, 55);
            this.btnVerificaGrupo10.TabIndex = 245;
            this.btnVerificaGrupo10.Text = "Verifica Grupo 10 Sem ItemSped ou erro PosiçãoFiscal";
            this.btnVerificaGrupo10.UseVisualStyleBackColor = false;
            this.btnVerificaGrupo10.Click += new System.EventHandler(this.btnVerificaGrupo10SemItemSpedouPosiFiscal_Click);
            // 
            // btnVerificaG12SemItemSpedOuErroPfiscal
            // 
            this.btnVerificaG12SemItemSpedOuErroPfiscal.BackColor = System.Drawing.Color.IndianRed;
            this.btnVerificaG12SemItemSpedOuErroPfiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificaG12SemItemSpedOuErroPfiscal.Location = new System.Drawing.Point(259, 133);
            this.btnVerificaG12SemItemSpedOuErroPfiscal.Name = "btnVerificaG12SemItemSpedOuErroPfiscal";
            this.btnVerificaG12SemItemSpedOuErroPfiscal.Size = new System.Drawing.Size(123, 51);
            this.btnVerificaG12SemItemSpedOuErroPfiscal.TabIndex = 248;
            this.btnVerificaG12SemItemSpedOuErroPfiscal.Text = "Verifica Demais Grupos  erro PosiçãoFiscal";
            this.btnVerificaG12SemItemSpedOuErroPfiscal.UseVisualStyleBackColor = false;
            this.btnVerificaG12SemItemSpedOuErroPfiscal.Click += new System.EventHandler(this.btnVerificaG12ErroPfiscal_Click);
            // 
            // btnVerificaGrupoRelItemSPED
            // 
            this.btnVerificaGrupoRelItemSPED.BackColor = System.Drawing.Color.IndianRed;
            this.btnVerificaGrupoRelItemSPED.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificaGrupoRelItemSPED.Location = new System.Drawing.Point(477, 16);
            this.btnVerificaGrupoRelItemSPED.Name = "btnVerificaGrupoRelItemSPED";
            this.btnVerificaGrupoRelItemSPED.Size = new System.Drawing.Size(123, 51);
            this.btnVerificaGrupoRelItemSPED.TabIndex = 249;
            this.btnVerificaGrupoRelItemSPED.Text = "Verifica Demais Grupos em relação a ItemSPED";
            this.btnVerificaGrupoRelItemSPED.UseVisualStyleBackColor = false;
            this.btnVerificaGrupoRelItemSPED.Click += new System.EventHandler(this.btnVerificaGrupoRelItemSPED_Click);
            // 
            // btnVerificaGrupo11
            // 
            this.btnVerificaGrupo11.BackColor = System.Drawing.Color.IndianRed;
            this.btnVerificaGrupo11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificaGrupo11.Location = new System.Drawing.Point(259, 76);
            this.btnVerificaGrupo11.Name = "btnVerificaGrupo11";
            this.btnVerificaGrupo11.Size = new System.Drawing.Size(123, 51);
            this.btnVerificaGrupo11.TabIndex = 250;
            this.btnVerificaGrupo11.Text = "Verifica Grupo 11 sem ItemSPED ou Pos.Fiscal";
            this.btnVerificaGrupo11.UseVisualStyleBackColor = false;
            this.btnVerificaGrupo11.Click += new System.EventHandler(this.btnVerificaGrupo11_Click);
            // 
            // btnGruposEstranhos
            // 
            this.btnGruposEstranhos.BackColor = System.Drawing.Color.IndianRed;
            this.btnGruposEstranhos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGruposEstranhos.Location = new System.Drawing.Point(477, 76);
            this.btnGruposEstranhos.Name = "btnGruposEstranhos";
            this.btnGruposEstranhos.Size = new System.Drawing.Size(123, 51);
            this.btnGruposEstranhos.TabIndex = 251;
            this.btnGruposEstranhos.Text = "Grupos Estranhos";
            this.btnGruposEstranhos.UseVisualStyleBackColor = false;
            this.btnGruposEstranhos.Click += new System.EventHandler(this.btnGruposEstranhos_Click);
            // 
            // SaldoMensal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 643);
            this.Controls.Add(this.btnGruposEstranhos);
            this.Controls.Add(this.btnVerificaGrupo11);
            this.Controls.Add(this.btnVerificaGrupoRelItemSPED);
            this.Controls.Add(this.btnVerificaG12SemItemSpedOuErroPfiscal);
            this.Controls.Add(this.btnVerificaGrupo10);
            this.Controls.Add(this.btnEnviarEmailPietro);
            this.Controls.Add(this.lblStatusBotao);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaldoMensal);
            this.Name = "SaldoMensal";
            this.Text = "SaldoMensal";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaldoMensal;
        private System.Windows.Forms.Button brnVerificaPPs;
        private System.Windows.Forms.Button btnAplicaPPs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblStatusBotao;
        private System.Windows.Forms.Button btnAplicarNoERP;
        private System.Windows.Forms.Button btnEnviarEmailPietro;
        private System.Windows.Forms.Button btnVerificaGrupo10;
        private System.Windows.Forms.Button btnVerificaG12SemItemSpedOuErroPfiscal;
        private System.Windows.Forms.Button btnVerificaGrupoRelItemSPED;
        private System.Windows.Forms.Button btnVerificaGrupo11;
        private System.Windows.Forms.Button btnGruposEstranhos;
    }
}