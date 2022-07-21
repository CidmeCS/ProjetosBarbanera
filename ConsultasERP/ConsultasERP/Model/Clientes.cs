using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsultasERP.Model
{
   

	[XmlRoot(ElementName = "result")]
	public class Clientes  : List<CRCL>
	{
		[XmlElement(ElementName = "CRCL")]
		public List<CRCL> CRCL { get; set; }
	}

	[XmlRoot(ElementName = "CRCL")]
	public class CRCL
	{
		[XmlElement(ElementName = "emp_fil")]
		public string Emp_fil { get; set; }
		[XmlElement(ElementName = "cliente")]
		public string Cliente { get; set; }
		[XmlElement(ElementName = "cod_grupo")]
		public string Cod_grupo { get; set; }
		[XmlElement(ElementName = "raz_social")]
		public string Raz_social { get; set; }
		[XmlElement(ElementName = "complem_rz")]
		public string Complem_rz { get; set; }
		[XmlElement(ElementName = "nom_fantas")]
		public string Nom_fantas { get; set; }
		[XmlElement(ElementName = "endereco")]
		public string Endereco { get; set; }
		[XmlElement(ElementName = "numero")]
		public string Numero { get; set; }
		[XmlElement(ElementName = "tipo")]
		public string Tipo { get; set; }
		[XmlElement(ElementName = "compl_end")]
		public string Compl_end { get; set; }
		[XmlElement(ElementName = "cep")]
		public string Cep { get; set; }
		[XmlElement(ElementName = "bairro")]
		public string Bairro { get; set; }
		[XmlElement(ElementName = "cidade")]
		public string Cidade { get; set; }
		[XmlElement(ElementName = "estado")]
		public string Estado { get; set; }
		[XmlElement(ElementName = "cxa_postal")]
		public string Cxa_postal { get; set; }
		[XmlElement(ElementName = "contato")]
		public string Contato { get; set; }
		[XmlElement(ElementName = "ddd")]
		public string Ddd { get; set; }
		[XmlElement(ElementName = "telefone")]
		public string Telefone { get; set; }
		[XmlElement(ElementName = "telefax")]
		public string Telefax { get; set; }
		[XmlElement(ElementName = "ddd_telex")]
		public string Ddd_telex { get; set; }
		[XmlElement(ElementName = "telex")]
		public string Telex { get; set; }
		[XmlElement(ElementName = "fis_jurid")]
		public string Fis_jurid { get; set; }
		[XmlElement(ElementName = "cgc_cpf")]
		public string Cgc_cpf { get; set; }
		[XmlElement(ElementName = "dig_cgc_cpf")]
		public string Dig_cgc_cpf { get; set; }
		[XmlElement(ElementName = "inscr_estad")]
		public string Inscr_estad { get; set; }
		[XmlElement(ElementName = "inscr_munic")]
		public string Inscr_munic { get; set; }
		[XmlElement(ElementName = "suframa")]
		public string Suframa { get; set; }
		[XmlElement(ElementName = "lm_credito")]
		public string Lm_credito { get; set; }
		[XmlElement(ElementName = "suspenso")]
		public string Suspenso { get; set; }
		[XmlElement(ElementName = "motiv_susp")]
		public string Motiv_susp { get; set; }
		[XmlElement(ElementName = "dt_susp")]
		public string Dt_susp { get; set; }
		[XmlElement(ElementName = "vendedor")]
		public string Vendedor { get; set; }
		[XmlAttribute(AttributeName = "idx")]
		public string Idx { get; set; }
	}

	
}
