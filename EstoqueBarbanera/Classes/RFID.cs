using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Classes
{
    public class RFID
    {
        public void ObterTxts()
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile("http://www.susep.gov.br/download/menumercado/Comissao/contabil/2009/ATACC032009RES.pdf", "c:\\RFID\\Inventarios\\RFID1.pdf");
                    client.DownloadFile("http://www.susep.gov.br/download/menumercado/Comissao/contabil/2009/ATACC032009.pdf", "c:\\RFID\\Inventarios\\RFID2.pdf");
                    var page = client.OpenRead("http://www.susep.gov.br/download/menumercado/Comissao/contabil");
                    var page2 = client.DownloadString("http://www.susep.gov.br/download/menumercado/Comissao/contabil");
                    StreamReader sr = new StreamReader(page,Encoding.Default);
                    var t = sr.ReadToEnd();
                    StreamWriter sw = new StreamWriter("c:\\RFID\\Inventarios\\RFID4.html",true);
                    sw.Write(t);

                    
                }
                catch (Exception e)
                {
                }
            }
        }
    }
}
