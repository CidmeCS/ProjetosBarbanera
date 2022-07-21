namespace ConsultasERP.Views
{
    partial class ConsultaERP
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
            this.btnLogInAlt = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnConsultarPV = new System.Windows.Forms.Button();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.dgvDetalhes = new System.Windows.Forms.DataGridView();
            this.btnConsultaProdutos = new System.Windows.Forms.Button();
            this.btnNFsVendas = new System.Windows.Forms.Button();
            this.btnCadClientes = new System.Windows.Forms.Button();
            this.btnVendedores = new System.Windows.Forms.Button();
            this.btnVinculoProduto = new System.Windows.Forms.Button();
            this.btnInsDadosInteg = new System.Windows.Forms.Button();
            this.btnGetStatusInteg = new System.Windows.Forms.Button();
            this.btnGetDadosInteg = new System.Windows.Forms.Button();
            this.btnMarcaExpPedidoVendaProc = new System.Windows.Forms.Button();
            this.btnGetSaldoProdutosECommerce = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnCheckSession = new System.Windows.Forms.Button();
            this.btnGetServerHealth = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetExpPedidosVenda = new System.Windows.Forms.Button();
            this.btnGetExpProdutosECommerce = new System.Windows.Forms.Button();
            this.btnMarcaExpProdutosECommerceProc = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSelect2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogInAlt
            // 
            this.btnLogInAlt.Location = new System.Drawing.Point(23, 25);
            this.btnLogInAlt.Name = "btnLogInAlt";
            this.btnLogInAlt.Size = new System.Drawing.Size(75, 23);
            this.btnLogInAlt.TabIndex = 0;
            this.btnLogInAlt.Text = "LogInAlt";
            this.btnLogInAlt.UseVisualStyleBackColor = true;
            this.btnLogInAlt.Click += new System.EventHandler(this.btnLogInAlt_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(23, 54);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnConsultarPV
            // 
            this.btnConsultarPV.Location = new System.Drawing.Point(23, 246);
            this.btnConsultarPV.Name = "btnConsultarPV";
            this.btnConsultarPV.Size = new System.Drawing.Size(109, 23);
            this.btnConsultarPV.TabIndex = 2;
            this.btnConsultarPV.Text = "GetPedidosVenda";
            this.btnConsultarPV.UseVisualStyleBackColor = true;
            this.btnConsultarPV.Click += new System.EventHandler(this.btnConsultarPV_Click);
            // 
            // dgvMaster
            // 
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Location = new System.Drawing.Point(12, 465);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.Size = new System.Drawing.Size(748, 172);
            this.dgvMaster.TabIndex = 7;
            // 
            // dgvDetalhes
            // 
            this.dgvDetalhes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalhes.Location = new System.Drawing.Point(766, 465);
            this.dgvDetalhes.Name = "dgvDetalhes";
            this.dgvDetalhes.Size = new System.Drawing.Size(666, 172);
            this.dgvDetalhes.TabIndex = 8;
            // 
            // btnConsultaProdutos
            // 
            this.btnConsultaProdutos.Location = new System.Drawing.Point(23, 304);
            this.btnConsultaProdutos.Name = "btnConsultaProdutos";
            this.btnConsultaProdutos.Size = new System.Drawing.Size(109, 23);
            this.btnConsultaProdutos.TabIndex = 9;
            this.btnConsultaProdutos.Text = "GetCadProdutos";
            this.btnConsultaProdutos.UseVisualStyleBackColor = true;
            this.btnConsultaProdutos.Click += new System.EventHandler(this.btnConsultaProdutos_Click);
            // 
            // btnNFsVendas
            // 
            this.btnNFsVendas.Location = new System.Drawing.Point(23, 275);
            this.btnNFsVendas.Name = "btnNFsVendas";
            this.btnNFsVendas.Size = new System.Drawing.Size(109, 23);
            this.btnNFsVendas.TabIndex = 11;
            this.btnNFsVendas.Text = "GetNotasVenda";
            this.btnNFsVendas.UseVisualStyleBackColor = true;
            this.btnNFsVendas.Click += new System.EventHandler(this.btnNFsVendas_Click);
            // 
            // btnCadClientes
            // 
            this.btnCadClientes.Location = new System.Drawing.Point(23, 333);
            this.btnCadClientes.Name = "btnCadClientes";
            this.btnCadClientes.Size = new System.Drawing.Size(109, 23);
            this.btnCadClientes.TabIndex = 12;
            this.btnCadClientes.Text = "GetCadClientes";
            this.btnCadClientes.UseVisualStyleBackColor = true;
            this.btnCadClientes.Click += new System.EventHandler(this.btnCadClientes_Click);
            // 
            // btnVendedores
            // 
            this.btnVendedores.Location = new System.Drawing.Point(23, 362);
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Size = new System.Drawing.Size(109, 23);
            this.btnVendedores.TabIndex = 14;
            this.btnVendedores.Text = "GetCadVendedores";
            this.btnVendedores.UseVisualStyleBackColor = true;
            this.btnVendedores.Click += new System.EventHandler(this.btnVendedores_Click);
            // 
            // btnVinculoProduto
            // 
            this.btnVinculoProduto.Location = new System.Drawing.Point(23, 391);
            this.btnVinculoProduto.Name = "btnVinculoProduto";
            this.btnVinculoProduto.Size = new System.Drawing.Size(109, 23);
            this.btnVinculoProduto.TabIndex = 15;
            this.btnVinculoProduto.Text = "GetVinculoProduto";
            this.btnVinculoProduto.UseVisualStyleBackColor = true;
            this.btnVinculoProduto.Click += new System.EventHandler(this.btnVinculoProduto_Click);
            // 
            // btnInsDadosInteg
            // 
            this.btnInsDadosInteg.Location = new System.Drawing.Point(342, 188);
            this.btnInsDadosInteg.Name = "btnInsDadosInteg";
            this.btnInsDadosInteg.Size = new System.Drawing.Size(133, 23);
            this.btnInsDadosInteg.TabIndex = 17;
            this.btnInsDadosInteg.Text = "InsDadosInteg - ERRO";
            this.btnInsDadosInteg.UseVisualStyleBackColor = true;
            this.btnInsDadosInteg.Click += new System.EventHandler(this.btnInsDadosInteg_Click);
            // 
            // btnGetStatusInteg
            // 
            this.btnGetStatusInteg.Location = new System.Drawing.Point(342, 217);
            this.btnGetStatusInteg.Name = "btnGetStatusInteg";
            this.btnGetStatusInteg.Size = new System.Drawing.Size(133, 23);
            this.btnGetStatusInteg.TabIndex = 18;
            this.btnGetStatusInteg.Text = "GetStatusInteg";
            this.btnGetStatusInteg.UseVisualStyleBackColor = true;
            this.btnGetStatusInteg.Click += new System.EventHandler(this.btnGetStatusInteg_Click);
            // 
            // btnGetDadosInteg
            // 
            this.btnGetDadosInteg.Location = new System.Drawing.Point(342, 246);
            this.btnGetDadosInteg.Name = "btnGetDadosInteg";
            this.btnGetDadosInteg.Size = new System.Drawing.Size(133, 23);
            this.btnGetDadosInteg.TabIndex = 19;
            this.btnGetDadosInteg.Text = "GetDadosInteg";
            this.btnGetDadosInteg.UseVisualStyleBackColor = true;
            this.btnGetDadosInteg.Click += new System.EventHandler(this.btnGetDadosInteg_Click);
            // 
            // btnMarcaExpPedidoVendaProc
            // 
            this.btnMarcaExpPedidoVendaProc.Location = new System.Drawing.Point(342, 304);
            this.btnMarcaExpPedidoVendaProc.Name = "btnMarcaExpPedidoVendaProc";
            this.btnMarcaExpPedidoVendaProc.Size = new System.Drawing.Size(150, 23);
            this.btnMarcaExpPedidoVendaProc.TabIndex = 21;
            this.btnMarcaExpPedidoVendaProc.Text = "MarcaExpPedidoVendaProc";
            this.btnMarcaExpPedidoVendaProc.UseVisualStyleBackColor = true;
            this.btnMarcaExpPedidoVendaProc.Click += new System.EventHandler(this.btnMarcaExpPedidoVendaProc_Click);
            // 
            // btnGetSaldoProdutosECommerce
            // 
            this.btnGetSaldoProdutosECommerce.Location = new System.Drawing.Point(23, 420);
            this.btnGetSaldoProdutosECommerce.Name = "btnGetSaldoProdutosECommerce";
            this.btnGetSaldoProdutosECommerce.Size = new System.Drawing.Size(158, 23);
            this.btnGetSaldoProdutosECommerce.TabIndex = 23;
            this.btnGetSaldoProdutosECommerce.Text = "GetSaldoProdutosECommerce";
            this.btnGetSaldoProdutosECommerce.UseVisualStyleBackColor = true;
            this.btnGetSaldoProdutosECommerce.Click += new System.EventHandler(this.btnGetSaldoProdutosECommerce_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "IWTpIntegrVendas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "IWTpBase";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(23, 83);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(118, 23);
            this.btnLogIn.TabIndex = 26;
            this.btnLogIn.Text = "LogIn Não Funciona";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnCheckSession
            // 
            this.btnCheckSession.Location = new System.Drawing.Point(23, 112);
            this.btnCheckSession.Name = "btnCheckSession";
            this.btnCheckSession.Size = new System.Drawing.Size(118, 23);
            this.btnCheckSession.TabIndex = 27;
            this.btnCheckSession.Text = "CheckSession";
            this.btnCheckSession.UseVisualStyleBackColor = true;
            this.btnCheckSession.Click += new System.EventHandler(this.btnCheckSession_Click);
            // 
            // btnGetServerHealth
            // 
            this.btnGetServerHealth.Location = new System.Drawing.Point(23, 141);
            this.btnGetServerHealth.Name = "btnGetServerHealth";
            this.btnGetServerHealth.Size = new System.Drawing.Size(118, 23);
            this.btnGetServerHealth.TabIndex = 28;
            this.btnGetServerHealth.Text = "GetServerHealth";
            this.btnGetServerHealth.UseVisualStyleBackColor = true;
            this.btnGetServerHealth.Click += new System.EventHandler(this.btnGetServerHealth_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "IWTpIntegradoras";
            // 
            // btnGetExpPedidosVenda
            // 
            this.btnGetExpPedidosVenda.Location = new System.Drawing.Point(342, 275);
            this.btnGetExpPedidosVenda.Name = "btnGetExpPedidosVenda";
            this.btnGetExpPedidosVenda.Size = new System.Drawing.Size(150, 23);
            this.btnGetExpPedidosVenda.TabIndex = 30;
            this.btnGetExpPedidosVenda.Text = "GetExpPedidosVenda";
            this.btnGetExpPedidosVenda.UseVisualStyleBackColor = true;
            this.btnGetExpPedidosVenda.Click += new System.EventHandler(this.btnGetExpPedidosVenda_Click);
            // 
            // btnGetExpProdutosECommerce
            // 
            this.btnGetExpProdutosECommerce.Location = new System.Drawing.Point(342, 333);
            this.btnGetExpProdutosECommerce.Name = "btnGetExpProdutosECommerce";
            this.btnGetExpProdutosECommerce.Size = new System.Drawing.Size(150, 23);
            this.btnGetExpProdutosECommerce.TabIndex = 31;
            this.btnGetExpProdutosECommerce.Text = "GetExpProdutosECommerce";
            this.btnGetExpProdutosECommerce.UseVisualStyleBackColor = true;
            this.btnGetExpProdutosECommerce.Click += new System.EventHandler(this.btnGetExpProdutosECommerce_Click);
            // 
            // btnMarcaExpProdutosECommerceProc
            // 
            this.btnMarcaExpProdutosECommerceProc.Location = new System.Drawing.Point(342, 362);
            this.btnMarcaExpProdutosECommerceProc.Name = "btnMarcaExpProdutosECommerceProc";
            this.btnMarcaExpProdutosECommerceProc.Size = new System.Drawing.Size(150, 23);
            this.btnMarcaExpProdutosECommerceProc.TabIndex = 32;
            this.btnMarcaExpProdutosECommerceProc.Text = "MarcaExpProdutosECommerceProc";
            this.btnMarcaExpProdutosECommerceProc.UseVisualStyleBackColor = true;
            this.btnMarcaExpProdutosECommerceProc.Click += new System.EventHandler(this.btnMarcaExpProdutosECommerceProc_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(342, 391);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(150, 23);
            this.btnSelect.TabIndex = 33;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSelect2
            // 
            this.btnSelect2.Location = new System.Drawing.Point(342, 420);
            this.btnSelect2.Name = "btnSelect2";
            this.btnSelect2.Size = new System.Drawing.Size(150, 23);
            this.btnSelect2.TabIndex = 34;
            this.btnSelect2.Text = "Select2";
            this.btnSelect2.UseVisualStyleBackColor = true;
            this.btnSelect2.Click += new System.EventHandler(this.btnSelect2_Click);
            // 
            // ConsultaERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 649);
            this.Controls.Add(this.btnSelect2);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnMarcaExpProdutosECommerceProc);
            this.Controls.Add(this.btnGetExpProdutosECommerce);
            this.Controls.Add(this.btnGetExpPedidosVenda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGetServerHealth);
            this.Controls.Add(this.btnCheckSession);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetSaldoProdutosECommerce);
            this.Controls.Add(this.btnMarcaExpPedidoVendaProc);
            this.Controls.Add(this.btnGetDadosInteg);
            this.Controls.Add(this.btnGetStatusInteg);
            this.Controls.Add(this.btnInsDadosInteg);
            this.Controls.Add(this.btnVinculoProduto);
            this.Controls.Add(this.btnVendedores);
            this.Controls.Add(this.btnCadClientes);
            this.Controls.Add(this.btnNFsVendas);
            this.Controls.Add(this.btnConsultaProdutos);
            this.Controls.Add(this.dgvDetalhes);
            this.Controls.Add(this.dgvMaster);
            this.Controls.Add(this.btnConsultarPV);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLogInAlt);
            this.Name = "ConsultaERP";
            this.Text = "ConsultasERP";
            this.Load += new System.EventHandler(this.ConsultasERP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogInAlt;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnConsultarPV;
        private System.Windows.Forms.DataGridView dgvMaster;
        private System.Windows.Forms.DataGridView dgvDetalhes;
        private System.Windows.Forms.Button btnConsultaProdutos;
        private System.Windows.Forms.Button btnNFsVendas;
        private System.Windows.Forms.Button btnCadClientes;
        private System.Windows.Forms.Button btnVendedores;
        private System.Windows.Forms.Button btnVinculoProduto;
        private System.Windows.Forms.Button btnInsDadosInteg;
        private System.Windows.Forms.Button btnGetStatusInteg;
        private System.Windows.Forms.Button btnGetDadosInteg;
        private System.Windows.Forms.Button btnMarcaExpPedidoVendaProc;
        private System.Windows.Forms.Button btnGetSaldoProdutosECommerce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnCheckSession;
        private System.Windows.Forms.Button btnGetServerHealth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetExpPedidosVenda;
        private System.Windows.Forms.Button btnGetExpProdutosECommerce;
        private System.Windows.Forms.Button btnMarcaExpProdutosECommerceProc;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSelect2;
    }
}

