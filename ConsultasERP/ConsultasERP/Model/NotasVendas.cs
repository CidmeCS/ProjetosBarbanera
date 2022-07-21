using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsultasERP.Model
{
   
	[XmlRoot(ElementName = "result")]
	public class NotasVendas : List<NFME>
	{
		[XmlElement(ElementName = "NFME")]
		public NFME NFME { get; set; }
	}

	[XmlRoot(ElementName = "NFME")]
	public class NFME
	{
		[XmlElement(ElementName = "emp_fil")]
		public string Emp_fil { get; set; }
		[XmlElement(ElementName = "operador")]
		public string Operador { get; set; }
		[XmlElement(ElementName = "dt_movto")]
		public string Dt_movto { get; set; }
		[XmlElement(ElementName = "operador_1")]
		public string Operador_1 { get; set; }
		[XmlElement(ElementName = "data_alter")]
		public string Data_alter { get; set; }
		[XmlElement(ElementName = "id_cancel")]
		public string Id_cancel { get; set; }
		[XmlElement(ElementName = "fornec")]
		public string Fornec { get; set; }
		[XmlElement(ElementName = "dt_movto_1")]
		public string Dt_movto_1 { get; set; }
		[XmlElement(ElementName = "dt_emissao")]
		public string Dt_emissao { get; set; }
		[XmlElement(ElementName = "n_fiscal")]
		public string N_fiscal { get; set; }
		[XmlElement(ElementName = "serie")]
		public string Serie { get; set; }
		[XmlElement(ElementName = "nro_pedido")]
		public string Nro_pedido { get; set; }
		[XmlElement(ElementName = "vlr_n_fisc")]
		public string Vlr_n_fisc { get; set; }
		[XmlElement(ElementName = "tipo_movto")]
		public string Tipo_movto { get; set; }
		[XmlElement(ElementName = "natureza")]
		public string Natureza { get; set; }
		[XmlElement(ElementName = "estab")]
		public string Estab { get; set; }
		[XmlElement(ElementName = "depos")]
		public string Depos { get; set; }
		[XmlElement(ElementName = "dt_pedido")]
		public string Dt_pedido { get; set; }
		[XmlElement(ElementName = "vendedor")]
		public string Vendedor { get; set; }
		[XmlElement(ElementName = "vlr_icm")]
		public string Vlr_icm { get; set; }
		[XmlElement(ElementName = "vlr_ipi")]
		public string Vlr_ipi { get; set; }
		[XmlElement(ElementName = "porc_icm")]
		public string Porc_icm { get; set; }
		[XmlElement(ElementName = "porc_icm_subst")]
		public string Porc_icm_subst { get; set; }
		[XmlElement(ElementName = "zona_franca")]
		public string Zona_franca { get; set; }
		[XmlElement(ElementName = "porc_z_franca")]
		public string Porc_z_franca { get; set; }
		[XmlElement(ElementName = "z_franca_desc")]
		public string Z_franca_desc { get; set; }
		[XmlElement(ElementName = "frete_pg_a")]
		public string Frete_pg_a { get; set; }
		[XmlElement(ElementName = "NFDE")]
		public List<NFDE> NFDE { get; set; }
		[XmlAttribute(AttributeName = "idx")]
		public string Idx { get; set; }
	}


	[XmlRoot(ElementName = "NFDE")]
	public class NFDE
	{
		[XmlElement(ElementName = "emp_fil")]
		public string Emp_fil { get; set; }
		[XmlElement(ElementName = "n_fiscal")]
		public string N_fiscal { get; set; }
		[XmlElement(ElementName = "serie")]
		public string Serie { get; set; }
		[XmlElement(ElementName = "fornec")]
		public string Fornec { get; set; }
		[XmlElement(ElementName = "tipo_movto")]
		public string Tipo_movto { get; set; }
		[XmlElement(ElementName = "linha")]
		public string Linha { get; set; }
		[XmlElement(ElementName = "com_ven")]
		public string Com_ven { get; set; }
		[XmlElement(ElementName = "entr_said")]
		public string Entr_said { get; set; }
		[XmlElement(ElementName = "icm_sp")]
		public string Icm_sp { get; set; }
		[XmlElement(ElementName = "dt_movto")]
		public string Dt_movto { get; set; }
		[XmlElement(ElementName = "tipo_movto_estq")]
		public string Tipo_movto_estq { get; set; }
		[XmlElement(ElementName = "estab")]
		public string Estab { get; set; }
		[XmlElement(ElementName = "depos")]
		public string Depos { get; set; }
		[XmlElement(ElementName = "c_prod")]
		public string C_prod { get; set; }
		[XmlElement(ElementName = "inf_trad")]
		public string Inf_trad { get; set; }
		[XmlElement(ElementName = "tem_nfda")]
		public string Tem_nfda { get; set; }
		[XmlElement(ElementName = "unidade")]
		public string Unidade { get; set; }
		[XmlElement(ElementName = "base_unit")]
		public string Base_unit { get; set; }
		[XmlElement(ElementName = "dt_vencto")]
		public string Dt_vencto { get; set; }
		[XmlElement(ElementName = "cond_pgto")]
		public string Cond_pgto { get; set; }
		[XmlElement(ElementName = "qtde")]
		public string Qtde { get; set; }
		[XmlElement(ElementName = "qtde_rec")]
		public string Qtde_rec { get; set; }
		[XmlElement(ElementName = "qtde_alter")]
		public string Qtde_alter { get; set; }
		[XmlElement(ElementName = "qt_alt_rec")]
		public string Qt_alt_rec { get; set; }
		[XmlElement(ElementName = "peso_liq")]
		public string Peso_liq { get; set; }
		[XmlElement(ElementName = "peso_bruto")]
		public string Peso_bruto { get; set; }
		[XmlElement(ElementName = "tab_preco")]
		public string Tab_preco { get; set; }
		[XmlElement(ElementName = "cod_embal")]
		public string Cod_embal { get; set; }
		[XmlElement(ElementName = "vlr_unit")]
		public string Vlr_unit { get; set; }
		[XmlElement(ElementName = "vlr_total")]
		public string Vlr_total { get; set; }
		[XmlElement(ElementName = "vlr_ad_fin")]
		public string Vlr_ad_fin { get; set; }
		[XmlElement(ElementName = "vlr_desc")]
		public string Vlr_desc { get; set; }
		[XmlElement(ElementName = "vlr_embal")]
		public string Vlr_embal { get; set; }
		[XmlElement(ElementName = "vlr_frete")]
		public string Vlr_frete { get; set; }
		[XmlElement(ElementName = "vlr_icm")]
		public string Vlr_icm { get; set; }
		[XmlElement(ElementName = "vlr_icm_subst")]
		public string Vlr_icm_subst { get; set; }
		[XmlElement(ElementName = "vlr_dif_aliq_icms")]
		public string Vlr_dif_aliq_icms { get; set; }
		[XmlElement(ElementName = "porc_iss")]
		public string Porc_iss { get; set; }
		[XmlElement(ElementName = "vlr_repasse")]
		public string Vlr_repasse { get; set; }
		[XmlElement(ElementName = "vlr_ipi")]
		public string Vlr_ipi { get; set; }
		[XmlElement(ElementName = "vlr_iss")]
		public string Vlr_iss { get; set; }
		[XmlElement(ElementName = "vlr_pis")]
		public string Vlr_pis { get; set; }
		[XmlElement(ElementName = "vlr_cofins")]
		public string Vlr_cofins { get; set; }
		[XmlElement(ElementName = "vlr_seguro")]
		public string Vlr_seguro { get; set; }
		[XmlElement(ElementName = "ir_percent")]
		public string Ir_percent { get; set; }
		[XmlElement(ElementName = "ir_retido")]
		public string Ir_retido { get; set; }
		[XmlElement(ElementName = "adic_ir_percent")]
		public string Adic_ir_percent { get; set; }
		[XmlElement(ElementName = "adic_ir")]
		public string Adic_ir { get; set; }
		[XmlElement(ElementName = "trat_fisc")]
		public string Trat_fisc { get; set; }
		[XmlElement(ElementName = "cod_trib")]
		public string Cod_trib { get; set; }
		[XmlElement(ElementName = "cfo")]
		public string Cfo { get; set; }
		[XmlElement(ElementName = "pos_fisc")]
		public string Pos_fisc { get; set; }
		[XmlElement(ElementName = "porc_ipi")]
		public string Porc_ipi { get; set; }
		[XmlElement(ElementName = "porc_icm")]
		public string Porc_icm { get; set; }
		[XmlElement(ElementName = "porc_icm_s_frete")]
		public string Porc_icm_s_frete { get; set; }
		[XmlElement(ElementName = "porc_ipi_s_frete")]
		public string Porc_ipi_s_frete { get; set; }
		[XmlElement(ElementName = "base_icm")]
		public string Base_icm { get; set; }
		[XmlElement(ElementName = "base_icm_subst")]
		public string Base_icm_subst { get; set; }
		[XmlElement(ElementName = "icm_s_frete")]
		public string Icm_s_frete { get; set; }
		[XmlElement(ElementName = "ipi_s_frete")]
		public string Ipi_s_frete { get; set; }
		[XmlElement(ElementName = "base_icm_s_frete")]
		public string Base_icm_s_frete { get; set; }
		[XmlElement(ElementName = "base_ipi_s_frete")]
		public string Base_ipi_s_frete { get; set; }
		[XmlElement(ElementName = "base_ipi")]
		public string Base_ipi { get; set; }
		[XmlElement(ElementName = "bonif")]
		public string Bonif { get; set; }
		[XmlElement(ElementName = "z_franca_desc")]
		public string Z_franca_desc { get; set; }
		[XmlElement(ElementName = "doc_envio")]
		public string Doc_envio { get; set; }
		[XmlElement(ElementName = "nro_os")]
		public string Nro_os { get; set; }
		[XmlElement(ElementName = "operacao")]
		public string Operacao { get; set; }
		[XmlElement(ElementName = "nro_pedido")]
		public string Nro_pedido { get; set; }
		[XmlElement(ElementName = "item_ped")]
		public string Item_ped { get; set; }
		[XmlElement(ElementName = "id_custo")]
		public string Id_custo { get; set; }
		[XmlElement(ElementName = "alt_estq")]
		public string Alt_estq { get; set; }
		[XmlElement(ElementName = "alt_estq_terc")]
		public string Alt_estq_terc { get; set; }
		[XmlElement(ElementName = "alt_custo")]
		public string Alt_custo { get; set; }
		[XmlElement(ElementName = "ja_proc")]
		public string Ja_proc { get; set; }
		[XmlElement(ElementName = "porc_comis")]
		public string Porc_comis { get; set; }
		[XmlElement(ElementName = "porc_com_sup")]
		public string Porc_com_sup { get; set; }
		[XmlElement(ElementName = "porc_com_ger")]
		public string Porc_com_ger { get; set; }
		[XmlElement(ElementName = "vr_com_vend")]
		public string Vr_com_vend { get; set; }
		[XmlElement(ElementName = "vr_com_sup")]
		public string Vr_com_sup { get; set; }
		[XmlElement(ElementName = "vr_com_ger")]
		public string Vr_com_ger { get; set; }
		[XmlElement(ElementName = "vr_com_lq_vend")]
		public string Vr_com_lq_vend { get; set; }
		[XmlElement(ElementName = "vr_com_lq_sup")]
		public string Vr_com_lq_sup { get; set; }
		[XmlElement(ElementName = "vr_com_lq_ger")]
		public string Vr_com_lq_ger { get; set; }
		[XmlElement(ElementName = "nf_ult_compra")]
		public string Nf_ult_compra { get; set; }
		[XmlElement(ElementName = "sr_ult_compra")]
		public string Sr_ult_compra { get; set; }
		[XmlElement(ElementName = "forn_ult_compra")]
		public string Forn_ult_compra { get; set; }
		[XmlElement(ElementName = "pr_ult_compra")]
		public string Pr_ult_compra { get; set; }
		[XmlElement(ElementName = "texto_esp")]
		public string Texto_esp { get; set; }
		[XmlElement(ElementName = "texto_gen")]
		public string Texto_gen { get; set; }
		[XmlElement(ElementName = "exporta_mv")]
		public string Exporta_mv { get; set; }
		[XmlElement(ElementName = "serv_oficina")]
		public string Serv_oficina { get; set; }
		[XmlElement(ElementName = "ref_lote")]
		public string Ref_lote { get; set; }
		[XmlElement(ElementName = "ref_unid")]
		public string Ref_unid { get; set; }
		[XmlElement(ElementName = "ref_local")]
		public string Ref_local { get; set; }
		[XmlElement(ElementName = "nop")]
		public string Nop { get; set; }
		[XmlElement(ElementName = "cod_serv")]
		public string Cod_serv { get; set; }
		[XmlElement(ElementName = "n_fis_orig")]
		public string N_fis_orig { get; set; }
		[XmlElement(ElementName = "sr_nf_orig")]
		public string Sr_nf_orig { get; set; }
		[XmlElement(ElementName = "local_cc")]
		public string Local_cc { get; set; }
		[XmlElement(ElementName = "livre")]
		public string Livre { get; set; }
		[XmlElement(ElementName = "conta")]
		public string Conta { get; set; }
		[XmlElement(ElementName = "dg_conta")]
		public string Dg_conta { get; set; }
		[XmlElement(ElementName = "conta2")]
		public string Conta2 { get; set; }
		[XmlElement(ElementName = "dg_conta2")]
		public string Dg_conta2 { get; set; }
		[XmlElement(ElementName = "cc_dest")]
		public string Cc_dest { get; set; }
		[XmlElement(ElementName = "dg_cc_dest")]
		public string Dg_cc_dest { get; set; }
		[XmlElement(ElementName = "c_custo2")]
		public string C_custo2 { get; set; }
		[XmlElement(ElementName = "dg_c_custo2")]
		public string Dg_c_custo2 { get; set; }
		[XmlElement(ElementName = "tipo_contab")]
		public string Tipo_contab { get; set; }
		[XmlElement(ElementName = "nr_transf_cg")]
		public string Nr_transf_cg { get; set; }
		[XmlElement(ElementName = "cod_erro1")]
		public string Cod_erro1 { get; set; }
		[XmlElement(ElementName = "cod_erro2")]
		public string Cod_erro2 { get; set; }
		[XmlElement(ElementName = "cod_erro3")]
		public string Cod_erro3 { get; set; }
		[XmlElement(ElementName = "vlr_materiais")]
		public string Vlr_materiais { get; set; }
		[XmlElement(ElementName = "vlr_sub_empr")]
		public string Vlr_sub_empr { get; set; }
		[XmlElement(ElementName = "porc_pis")]
		public string Porc_pis { get; set; }
		[XmlElement(ElementName = "porc_cofins")]
		public string Porc_cofins { get; set; }
		[XmlElement(ElementName = "porc_desc_pv")]
		public string Porc_desc_pv { get; set; }
		[XmlElement(ElementName = "porc_adf_pv")]
		public string Porc_adf_pv { get; set; }
		[XmlElement(ElementName = "num_di")]
		public string Num_di { get; set; }
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
