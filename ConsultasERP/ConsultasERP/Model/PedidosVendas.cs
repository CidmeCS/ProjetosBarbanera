using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsultasERP.Model

{
	[XmlRoot(ElementName = "result")]
	public class PedidosVendas : List<VEPM>
	{
		[XmlElement(ElementName = "VEPM")]
		public VEPM VEPM { get; set; }
	}
	public class VEPM
	{
		[XmlElement(ElementName = "emp_fil")]
		public string Emp_fil { get; set; }
		[XmlElement(ElementName = "cliente")]
		public string Cliente { get; set; }
		[XmlElement(ElementName = "dt_ped")]
		public string Dt_ped { get; set; }
		[XmlElement(ElementName = "dt_min_fatur")]
		public string Dt_min_fatur { get; set; }
		[XmlElement(ElementName = "texto_int")]
		public string Texto_int { get; set; }
		[XmlElement(ElementName = "dt_incl")]
		public string Dt_incl { get; set; }
		[XmlElement(ElementName = "numero")]
		public string Numero { get; set; }
		[XmlElement(ElementName = "operador")]
		public string Operador { get; set; }
		[XmlElement(ElementName = "data_alter")]
		public string Data_alter { get; set; }
		[XmlElement(ElementName = "pedido_cli")]
		public string Pedido_cli { get; set; }
		[XmlElement(ElementName = "dt_ped_cli")]
		public string Dt_ped_cli { get; set; }
		[XmlElement(ElementName = "bloqueado")]
		public string Bloqueado { get; set; }
		[XmlElement(ElementName = "tipo_movto")]
		public string Tipo_movto { get; set; }
		[XmlElement(ElementName = "estab")]
		public string Estab { get; set; }
		[XmlElement(ElementName = "deposito")]
		public string Deposito { get; set; }
		[XmlElement(ElementName = "frete_pg_a")]
		public string Frete_pg_a { get; set; }
		[XmlElement(ElementName = "emissao")]
		public string Emissao { get; set; }
		[XmlElement(ElementName = "faturar")]
		public string Faturar { get; set; }
		[XmlElement(ElementName = "st_saldo")]
		public string St_saldo { get; set; }
		[XmlElement(ElementName = "vendedor")]
		public string Vendedor { get; set; }
		[XmlElement(ElementName = "dt_entrega")]
		public string Dt_entrega { get; set; }
		[XmlElement(ElementName = "cond_pagto")]
		public string Cond_pagto { get; set; }
		[XmlElement(ElementName = "vlr_frete")]
		public string Vlr_frete { get; set; }
		[XmlElement(ElementName = "porc_icm")]
		public string Porc_icm { get; set; }
		[XmlElement(ElementName = "z_franca_desc")]
		public string Z_franca_desc { get; set; }
		[XmlElement(ElementName = "porc_desc_cli")]
		public string Porc_desc_cli { get; set; }
		[XmlElement(ElementName = "vlr_descont")]
		public string Vlr_descont { get; set; }
		[XmlElement(ElementName = "vlr_seguro")]
		public string Vlr_seguro { get; set; }
		[XmlElement(ElementName = "vlr_adicional")]
		public string Vlr_adicional { get; set; }
		[XmlElement(ElementName = "vlr_embal")]
		public string Vlr_embal { get; set; }
		[XmlElement(ElementName = "porc_icm_1")]
		public string Porc_icm_1 { get; set; }
		[XmlElement(ElementName = "porc_comissao")]
		public string Porc_comissao { get; set; }
		[XmlElement(ElementName = "VEPD")]
		public List<VEPD> VEPD { get; set; }
		[XmlAttribute(AttributeName = "idx")]
		public string Idx { get; set; }
	}

	public class VEPD  
	{
		[XmlElement(ElementName = "emp_fil")]
		public string Emp_fil { get; set; }
		[XmlElement(ElementName = "numero")]
		public string Numero { get; set; }
		[XmlElement(ElementName = "sequencia")]
		public string Sequencia { get; set; }
		[XmlElement(ElementName = "cliente")]
		public string Cliente { get; set; }
		[XmlElement(ElementName = "estab")]
		public string Estab { get; set; }
		[XmlElement(ElementName = "deposito")]
		public string Deposito { get; set; }
		[XmlElement(ElementName = "c_prod")]
		public string C_prod { get; set; }
		[XmlElement(ElementName = "tipo_movto")]
		public string Tipo_movto { get; set; }
		[XmlElement(ElementName = "dt_pedido")]
		public string Dt_pedido { get; set; }
		[XmlElement(ElementName = "dt_entrega")]
		public string Dt_entrega { get; set; }
		[XmlElement(ElementName = "dt_vencto")]
		public string Dt_vencto { get; set; }
		[XmlElement(ElementName = "cond_pagto")]
		public string Cond_pagto { get; set; }
		[XmlElement(ElementName = "peso_liq")]
		public string Peso_liq { get; set; }
		[XmlElement(ElementName = "peso_bruto")]
		public string Peso_bruto { get; set; }
		[XmlElement(ElementName = "unidade")]
		public string Unidade { get; set; }
		[XmlElement(ElementName = "qtde")]
		public string Qtde { get; set; }
		[XmlElement(ElementName = "qt_faturar")]
		public string Qt_faturar { get; set; }
		[XmlElement(ElementName = "qt_empenho")]
		public string Qt_empenho { get; set; }
		[XmlElement(ElementName = "saldo")]
		public string Saldo { get; set; }
		[XmlElement(ElementName = "qtde_alter")]
		public string Qtde_alter { get; set; }
		[XmlElement(ElementName = "qt_alt_fat")]
		public string Qt_alt_fat { get; set; }
		[XmlElement(ElementName = "qt_alt_emp")]
		public string Qt_alt_emp { get; set; }
		[XmlElement(ElementName = "vlr_unit")]
		public string Vlr_unit { get; set; }
		[XmlElement(ElementName = "porc_desc")]
		public string Porc_desc { get; set; }
		[XmlElement(ElementName = "bonif")]
		public string Bonif { get; set; }
		[XmlElement(ElementName = "faturar")]
		public string Faturar { get; set; }
		[XmlElement(ElementName = "st_fat")]
		public string St_fat { get; set; }
		[XmlElement(ElementName = "motivos_st_fat")]
		public string Motivos_st_fat { get; set; }
		[XmlElement(ElementName = "interdp")]
		public string Interdp { get; set; }
		[XmlElement(ElementName = "nro_os")]
		public string Nro_os { get; set; }
		[XmlElement(ElementName = "operacao")]
		public string Operacao { get; set; }
		[XmlElement(ElementName = "doc_envio")]
		public string Doc_envio { get; set; }
		[XmlElement(ElementName = "cod_trib")]
		public string Cod_trib { get; set; }
		[XmlElement(ElementName = "cfo")]
		public string Cfo { get; set; }
		[XmlElement(ElementName = "trat_fisc")]
		public string Trat_fisc { get; set; }
		[XmlElement(ElementName = "porc_ipi")]
		public string Porc_ipi { get; set; }
		[XmlElement(ElementName = "porc_icm")]
		public string Porc_icm { get; set; }
		[XmlElement(ElementName = "cod_serv")]
		public string Cod_serv { get; set; }
		[XmlElement(ElementName = "cod_embal")]
		public string Cod_embal { get; set; }
		[XmlElement(ElementName = "rfie")]
		public string Rfie { get; set; }
		[XmlElement(ElementName = "nro_rfie")]
		public string Nro_rfie { get; set; }
		[XmlElement(ElementName = "empenh_emi")]
		public string Empenh_emi { get; set; }
		[XmlElement(ElementName = "texto_esp")]
		public string Texto_esp { get; set; }
		[XmlElement(ElementName = "texto_gen")]
		public string Texto_gen { get; set; }
		[XmlElement(ElementName = "ref_lote")]
		public string Ref_lote { get; set; }
		[XmlElement(ElementName = "ref_unid")]
		public string Ref_unid { get; set; }
		[XmlElement(ElementName = "ref_local")]
		public string Ref_local { get; set; }
		[XmlElement(ElementName = "tab_preco")]
		public string Tab_preco { get; set; }
		[XmlElement(ElementName = "p_comis_vend")]
		public string P_comis_vend { get; set; }
		[XmlElement(ElementName = "p_comis_sup")]
		public string P_comis_sup { get; set; }
		[XmlElement(ElementName = "p_comis_ger")]
		public string P_comis_ger { get; set; }
		[XmlElement(ElementName = "p_com_lq_vend")]
		public string P_com_lq_vend { get; set; }
		[XmlElement(ElementName = "p_com_lq_sup")]
		public string P_com_lq_sup { get; set; }
		[XmlElement(ElementName = "p_com_lq_ger")]
		public string P_com_lq_ger { get; set; }
		[XmlElement(ElementName = "programado")]
		public string Programado { get; set; }
		[XmlElement(ElementName = "emp_fil_tr")]
		public string Emp_fil_tr { get; set; }
		[XmlElement(ElementName = "empr_dest")]
		public string Empr_dest { get; set; }
		[XmlElement(ElementName = "fili_dest")]
		public string Fili_dest { get; set; }
		[XmlElement(ElementName = "estb_dest")]
		public string Estb_dest { get; set; }
		[XmlElement(ElementName = "deps_dest")]
		public string Deps_dest { get; set; }
		[XmlElement(ElementName = "sequ_dest")]
		public string Sequ_dest { get; set; }
		[XmlElement(ElementName = "ja_distrib")]
		public string Ja_distrib { get; set; }
		[XmlElement(ElementName = "conta")]
		public string Conta { get; set; }
		[XmlElement(ElementName = "dg_conta")]
		public string Dg_conta { get; set; }
		[XmlElement(ElementName = "conta2")]
		public string Conta2 { get; set; }
		[XmlElement(ElementName = "dg_conta2")]
		public string Dg_conta2 { get; set; }
		[XmlElement(ElementName = "c_custo")]
		public string C_custo { get; set; }
		[XmlElement(ElementName = "dg_ccusto")]
		public string Dg_ccusto { get; set; }
		[XmlElement(ElementName = "c_custo2")]
		public string C_custo2 { get; set; }
		[XmlElement(ElementName = "dg_ccusto2")]
		public string Dg_ccusto2 { get; set; }
		[XmlElement(ElementName = "local_cc")]
		public string Local_cc { get; set; }
		[XmlElement(ElementName = "nr_transf_cg")]
		public string Nr_transf_cg { get; set; }
		[XmlElement(ElementName = "nop")]
		public string Nop { get; set; }
		[XmlElement(ElementName = "vlr_materiais")]
		public string Vlr_materiais { get; set; }
		[XmlElement(ElementName = "vlr_sub_empr")]
		public string Vlr_sub_empr { get; set; }
		[XmlElement(ElementName = "alt_estq_terc")]
		public string Alt_estq_terc { get; set; }
		[XmlElement(ElementName = "porc_desc2")]
		public string Porc_desc2 { get; set; }
		[XmlElement(ElementName = "porc_desc_cpag")]
		public string Porc_desc_cpag { get; set; }
		[XmlElement(ElementName = "porc_desc_cli")]
		public string Porc_desc_cli { get; set; }
		[XmlElement(ElementName = "dt_prv_fat")]
		public string Dt_prv_fat { get; set; }
		[XmlElement(ElementName = "vlr_livre")]
		public string Vlr_livre { get; set; }
		[XmlElement(ElementName = "operador")]
		public string Operador { get; set; }
		[XmlElement(ElementName = "data_alter")]
		public string Data_alter { get; set; }
		[XmlElement(ElementName = "hora_alter")]
		public string Hora_alter { get; set; }
		[XmlElement(ElementName = "time_stamp")]
		public string Time_stamp { get; set; }
		[XmlElement(ElementName = "reservado_01")]
		public string Reservado_01 { get; set; }
		[XmlElement(ElementName = "reservado_02")]
		public string Reservado_02 { get; set; }
		[XmlElement(ElementName = "reservado_03")]
		public string Reservado_03 { get; set; }
		[XmlElement(ElementName = "reservado_04")]
		public string Reservado_04 { get; set; }
		[XmlElement(ElementName = "reservado_05")]
		public string Reservado_05 { get; set; }
		[XmlElement(ElementName = "reservado_06")]
		public string Reservado_06 { get; set; }
		[XmlElement(ElementName = "reservado_07")]
		public string Reservado_07 { get; set; }
		[XmlElement(ElementName = "reservado_08")]
		public string Reservado_08 { get; set; }
		[XmlElement(ElementName = "reservado_09")]
		public string Reservado_09 { get; set; }
		[XmlElement(ElementName = "reservado_10")]
		public string Reservado_10 { get; set; }
		[XmlElement(ElementName = "reservado_11")]
		public string Reservado_11 { get; set; }
		[XmlElement(ElementName = "reservado_12")]
		public string Reservado_12 { get; set; }
		[XmlElement(ElementName = "reservado_13")]
		public string Reservado_13 { get; set; }
		[XmlAttribute(AttributeName = "idx")]
		public string Idx { get; set; }
	}



}
