using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    public class DeDataGridViewParaList
    {
        public static List<ClassParaExcell> InventarioMovimento(DataGridView dgv)
        {
            List<ClassParaExcell> lcpe = new List<ClassParaExcell>();
            ClassParaExcell cpe = new ClassParaExcell();
            foreach (DataGridViewRow dr in dgv.Rows)
            {

                cpe.Codigo = dr.Cells["Codigo"].Value.ToString();

                MessageBox.Show("Falta implementar o resto");
                return null;

                lcpe.Add(cpe);
            }

            return lcpe;

        }
    }
}
