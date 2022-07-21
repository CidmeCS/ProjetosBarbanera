using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Classes
{
    [Serializable]
    public class GridApontamento
    {
        public string Status { get; set; }
        public string SeqOper { get; set; }
        public string Estab { get; set; }
        public string Depos { get; set; }
        public string Componente { get; set; }
        public string Traducao { get; set; }
        public string Unid { get; set; }
        public string TipoMovto { get; set; }
        public string QtdePrev { get; set; }
        public string QtdeReal { get; set; }
        public string QtdePrevSemPerda { get; set; }
        public string PerdaPrev { get; set; }
        public string QtdeRealSemPerda { get; set; }
        public string PerdaReal { get; set; }
        public string DataMovto { get; set; }
        public string HoraMovto { get; set; }
        public string DescricaComponente { get; set; }
        public int SeqApontamento { get; set; }
        public string SeqEstorno { get; set; }
    }
}
