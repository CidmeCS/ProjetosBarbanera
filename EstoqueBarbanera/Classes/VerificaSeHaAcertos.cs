using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    class VerificaSeHaAcertos
    {
        internal static List<Acerto> VerificarObter(DataGridView dgv)
        {
            List<Acerto> la = new List<Acerto>();
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                try
                {
                    if (Convert.ToDecimal(dr.Cells["Acerto"].Value.ToString()) != 0)
                    {
                        la.Add(new Acerto
                        {
                            TM = (Convert.ToDecimal(dr.Cells["Acerto"].Value.ToString()) > 0 ? "260" : "560"),
                            Data = DateTime.Today.ToString("dd/MM/yyyy"),
                            Doc = DateTime.Today.ToString("yyMMdd"),
                            Produto = dr.Cells["Produto"].Value.ToString(),
                            Quantidade = (Convert.ToDecimal(dr.Cells["Acerto"].Value.ToString()) < 0 ? (dr.Cells["Acerto"].Value.ToString()).Remove(0,1) : dr.Cells["Acerto"].Value.ToString()),
                            Obs = "Acerto " + DateTime.Today.ToString("dd/MM/yyyy")

                        });
                    }

                }
                catch (NullReferenceException e)
                {
                }
            }
            return la;
        }
    }
}
