
using PCP.Entidade;
using PCP.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PCP.DAO
{
    internal class Crud : IDisposable, ISaldo, IAtualizacao
    {
        private static EstoqueContext ContextoEstoque;

        public Crud()
        {
            ContextoEstoque = new EstoqueContext();
        }
        public void Dispose()
        {
            ContextoEstoque.Dispose();

        }

        //Saldo
        public void AlteraSaldo(Saldo itemSaldo)
        {
            ContextoEstoque.Update(itemSaldo);
            ContextoEstoque.SaveChanges();
        }

        public List<Saldo> ListaSaldo()
        {
            return ContextoEstoque.Saldos.ToList();
        }


        public void AlteraSaldo(List<Saldo> saldos)
        {
            ContextoEstoque.UpdateRange(saldos);
            ContextoEstoque.SaveChanges();
        }

        public string ListaAtualizacao()
        {

            return "Atualizado em: " + ContextoEstoque.Atualizacoes.Where(p => p.Entidade == "ExportSaldo.txt").First().Data.ToString("dd/MM/yyyy HH:mm");
        }


        /////
        ///

    }
}