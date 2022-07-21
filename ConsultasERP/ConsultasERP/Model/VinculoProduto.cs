using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsultasERP.Model
{
	[XmlRoot(ElementName = "result")]
	public class VinculoProduto	 : List<VECP>
	{
		[XmlElement(ElementName = "VECP")]
		public List<VECP> VECP { get; set; }
	}

	[XmlRoot(ElementName = "VECP")]
	public class VECP
	{
		[XmlElement(ElementName = "emp_fil")]
		public string Emp_fil { get; set; }
		[XmlElement(ElementName = "cliente")]
		public string Cliente { get; set; }
		[XmlElement(ElementName = "c_prod")]
		public string C_prod { get; set; }
		[XmlElement(ElementName = "estab")]
		public string Estab { get; set; }
		[XmlElement(ElementName = "deposito")]
		public string Deposito { get; set; }
		[XmlElement(ElementName = "c_prod_clien")]
		public string C_prod_clien { get; set; }
		[XmlElement(ElementName = "descr_1")]
		public string Descr_1 { get; set; }
		[XmlElement(ElementName = "descr_2")]
		public string Descr_2 { get; set; }
		[XmlElement(ElementName = "unid_alt")]
		public string Unid_alt { get; set; }
		[XmlElement(ElementName = "fator_uni")]
		public string Fator_uni { get; set; }
		[XmlElement(ElementName = "mult_div_fator")]
		public string Mult_div_fator { get; set; }
		[XmlAttribute(AttributeName = "idx")]
		public string Idx { get; set; }
	}
}
