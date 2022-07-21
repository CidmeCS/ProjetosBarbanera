using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Classes
{
    public class PrateleirasPermitidas
    {
         static  Crud c = new Crud();
        /// <summary>
        /// Obtem as Siglas iniciais
        /// </summary>
        /// <returns></returns>
        public static List<string> ObterListaSiglas()
        {
            List<string> ListaPrateleiras = new List<string>{"BL-","PR-"};
            return ListaPrateleiras;
        }

        /// <summary>
        /// Obtem uma lista de objetos
        /// </summary>
        /// <returns></returns>
        public static List<Saldo> ObterListaSaldos()
        {
            var ol = ObterListaSiglas();
            List<Saldo> saldo = new List<Saldo>();
            foreach (var i in ol)
            {

                var s = (from ll in c.ListaSaldo()
                         where ll.Prateleira.StartsWith(i)
                         select ll );


                saldo.AddRange(s);
            }

            return saldo;
        }


        /// <summary>
        /// Obtem uma lista de prateleiras
        /// </summary>
        /// <returns></returns>
        public static List<string> ObterListaPrateleiras()
        {
            var Prateleiras = ObterListaSaldos().Select(p=>p.Prateleira).ToList();
            return Prateleiras;
        }


    }

}
