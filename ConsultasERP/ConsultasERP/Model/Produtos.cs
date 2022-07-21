using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsultasERP.Model
{
	[XmlRoot(ElementName = "result")]
	public class Produtos  : List<ESTQ>
	{
		[XmlElement(ElementName = "ESTQ")]
		public ESTQ ESTQ { get; set; }
	}

	[XmlRoot(ElementName = "ESTQ")]
	public class ESTQ
	{
		[XmlElement(ElementName = "emp_fil")]
		public string Emp_fil { get; set; }
		[XmlElement(ElementName = "c_prod")]
		public string C_prod { get; set; }
		[XmlElement(ElementName = "estab")]
		public string Estab { get; set; }
		[XmlElement(ElementName = "deposito")]
		public string Deposito { get; set; }
		[XmlElement(ElementName = "dt_cadastr")]
		public string Dt_cadastr { get; set; }
		[XmlElement(ElementName = "grupo")]
		public string Grupo { get; set; }
		[XmlElement(ElementName = "qt_alt_obr")]
		public string Qt_alt_obr { get; set; }
		[XmlElement(ElementName = "operador")]
		public string Operador { get; set; }
		[XmlElement(ElementName = "data_alter")]
		public string Data_alter { get; set; }
		[XmlElement(ElementName = "descr_1")]
		public string Descr_1 { get; set; }
		[XmlElement(ElementName = "descr_2")]
		public string Descr_2 { get; set; }
		[XmlElement(ElementName = "c_med_teor")]
		public string C_med_teor { get; set; }
		[XmlElement(ElementName = "custo_med")]
		public string Custo_med { get; set; }
		[XmlElement(ElementName = "unidade")]
		public string Unidade { get; set; }
		[XmlElement(ElementName = "c_custo")]
		public string C_custo { get; set; }
		[XmlElement(ElementName = "dg_c_custo")]
		public string Dg_c_custo { get; set; }
		[XmlElement(ElementName = "unid_alt")]
		public string Unid_alt { get; set; }
		[XmlElement(ElementName = "fator_uni")]
		public string Fator_uni { get; set; }
		[XmlElement(ElementName = "peso_br_p_unid")]
		public string Peso_br_p_unid { get; set; }
		[XmlElement(ElementName = "peso_por_unid")]
		public string Peso_por_unid { get; set; }
		[XmlElement(ElementName = "lote_obr")]
		public string Lote_obr { get; set; }
		[XmlElement(ElementName = "proceden")]
		public string Proceden { get; set; }
		[XmlElement(ElementName = "porc_ipi")]
		public string Porc_ipi { get; set; }
		[XmlElement(ElementName = "pos_fisc")]
		public string Pos_fisc { get; set; }
		[XmlElement(ElementName = "livre_18")]
		public string Livre_18 { get; set; }
		[XmlElement(ElementName = "livre_19")]
		public string Livre_19 { get; set; }
		[XmlElement(ElementName = "saldo_inic")]
		public string Saldo_inic { get; set; }
		[XmlElement(ElementName = "entradas")]
		public string Entradas { get; set; }
		[XmlElement(ElementName = "saidas")]
		public string Saidas { get; set; }
		[XmlElement(ElementName = "ped_compra")]
		public string Ped_compra { get; set; }
		[XmlElement(ElementName = "ped_venda")]
		public string Ped_venda { get; set; }
		[XmlElement(ElementName = "qt_compra_consig")]
		public string Qt_compra_consig { get; set; }
		[XmlElement(ElementName = "qt_env_consig")]
		public string Qt_env_consig { get; set; }
		[XmlElement(ElementName = "qt_rec_consig")]
		public string Qt_rec_consig { get; set; }
		[XmlElement(ElementName = "qt_fora")]
		public string Qt_fora { get; set; }
		[XmlElement(ElementName = "qt_compra_futura")]
		public string Qt_compra_futura { get; set; }
		[XmlElement(ElementName = "qt_venda_futura")]
		public string Qt_venda_futura { get; set; }
		[XmlElement(ElementName = "qt_terceiros")]
		public string Qt_terceiros { get; set; }
		[XmlElement(ElementName = "qt_em_trans")]
		public string Qt_em_trans { get; set; }
		[XmlAttribute(AttributeName = "idx")]
		public string Idx { get; set; }
	}

	
}
