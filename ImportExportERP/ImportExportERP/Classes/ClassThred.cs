using System;
using System.Collections.Generic;
using System.Threading;
using ImportExportERP.Entidade;
using ImportExportERP.Views;
using System.Windows.Forms;

namespace ImportExportERP.Classes
{
    internal class ClassThred : Principal
    {
        internal void ListBoxx(List<Saldo> p)
        {
            new Thread(ListBox).Start(p);
        }

        public void ListBox(object obj)
        {
            if (listBox1.InvokeRequired)
            {
                foreach (var it in (List<Saldo>)obj)
                {
                    Invoke((MethodInvoker)(() => listBox1.Items.Add(it.Produto)));
                    Invoke((MethodInvoker)(() => listBox1.Items.Add(it.Descricao)));
                }
            }
        }
    }
}