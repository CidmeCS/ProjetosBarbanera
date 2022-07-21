using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasERP.Controller
{
    public class WExtraInfo
    {
        // 0: não tem mais registros; 1: tem mais registros pra buscar na página seguinte.
        public int maisRegistros { get; set; } = 0;
    }
}
