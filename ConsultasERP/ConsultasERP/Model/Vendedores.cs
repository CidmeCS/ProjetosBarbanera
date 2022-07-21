using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsultasERP.Model
{

	[XmlRoot(ElementName = "result")]
	public class Vendedores	: List<CRVN>
	{
		[XmlElement(ElementName = "CRVN")]
		public List<CRVN> CRVN { get; set; }
	}

	[XmlRoot(ElementName = "CRVN")]
	public class CRVN
	{
		[XmlElement(ElementName = "emp_fil")]
		public string Emp_fil { get; set; }
		[XmlElement(ElementName = "vendedor")]
		public string Vendedor { get; set; }
		[XmlElement(ElementName = "gerente")]
		public string Gerente { get; set; }
		[XmlElement(ElementName = "supervisor")]
		public string Supervisor { get; set; }
		[XmlElement(ElementName = "nome")]
		public string Nome { get; set; }
		[XmlElement(ElementName = "nome_conh")]
		public string Nome_conh { get; set; }
		[XmlElement(ElementName = "porc_comissao")]
		public string Porc_comissao { get; set; }
		[XmlElement(ElementName = "cidade")]
		public string Cidade { get; set; }
		[XmlElement(ElementName = "endereco")]
		public string Endereco { get; set; }
		[XmlElement(ElementName = "bairro")]
		public string Bairro { get; set; }
		[XmlElement(ElementName = "estado")]
		public string Estado { get; set; }
		[XmlElement(ElementName = "cep")]
		public string Cep { get; set; }
		[XmlElement(ElementName = "cxa_postal")]
		public string Cxa_postal { get; set; }
		[XmlElement(ElementName = "ddd")]
		public string Ddd { get; set; }
		[XmlElement(ElementName = "telefax")]
		public string Telefax { get; set; }
		[XmlElement(ElementName = "telefone")]
		public string Telefone { get; set; }
		[XmlElement(ElementName = "ddd_celular")]
		public string Ddd_celular { get; set; }
		[XmlElement(ElementName = "celular")]
		public string Celular { get; set; }
		[XmlElement(ElementName = "e_mail")]
		public string E_mail { get; set; }
		[XmlAttribute(AttributeName = "idx")]
		public string Idx { get; set; }
	}


}

