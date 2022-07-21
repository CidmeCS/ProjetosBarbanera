using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportExportERP.Classes
{
    class Mensagerias
    {
        public static RichTextBox rtbMensagens;

        public Mensagerias(RichTextBox rtbMensagens)
        {
            Mensagerias.rtbMensagens = rtbMensagens;
        }

        public static void Send(string mensagem)
        {
            rtbMensagens.BeginInvoke(new Action(async () =>
            {
                rtbMensagens.AppendText($"{mensagem}\n");
                rtbMensagens.ScrollToCaret();
            }));

        }
    }
}
