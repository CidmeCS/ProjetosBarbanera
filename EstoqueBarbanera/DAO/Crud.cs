
using Estoque.Entidade;
using Estoque.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Estoque.Classes;
using System.Threading.Tasks;

namespace Estoque.DAO
{
    internal class Crud :  IRegistroInventario ,IDisposable, ISaldoDeTerceiro, IDepositoDeTerceiro, IForaDeEstoque, IDeTerceiro,
        IItensDeEstoque, ISaldo, IAdicionaRegistroInventarioSaldoDeTerceiro, IMovimento, IEntregaDeTerceiro, IOrdensDeProducao, IPedidoDeCompra, 
        INotasFiscaisDinamicaProduto, IPedidoDeVenda, IAtualizacao, IDataBackUP, IAnotacaoRFID, IEtiqueta, IEtiquetaMovimentos, ISaldoDivergente
    {
        public static EstoqueContext ContextoEstoque;

        public Crud()
        {
            ContextoEstoque = new EstoqueContext();
        }
       
        internal static string TruncateTable(string tabela)
        {
            MySqlConnection connection2 = new MySqlConnection(StringConexao.sCon());
            try
            {
                MySqlCommand command2 = new MySqlCommand("TRUNCATE TABLE " + tabela + " ", connection2);
                connection2.Open();
                command2.ExecuteNonQuery();
                connection2.Close();
                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine(">> ERROR " + e.Message + " >> ERROR");
                connection2.Close();
                return e.Message;
            }
        }

        internal static string UltimoInventario()
        {
            try
            {
            DataSet ds = Select("SELECT DiaInventario, DiasMov FROM registrosinventario order by DiaInventario desc limit 1");
            DateTime dia = (DateTime)ds.Tables[0].Rows[0].ItemArray[0];
            var diam = ds.Tables[0].Rows[0].ItemArray[1].ToString();

            return $"Ultimo Inventario >> \n NO DIA {dia.ToShortDateString()}, \n DOS DIAS {diam}";

            }
            catch (Exception)
            {
            }
            return null;
        }

       

        internal static string InsertUpdateDelete(string query)
        {
            MySqlConnection connection = new MySqlConnection(StringConexao.sCon());
            try
            {
                MySqlCommand command2 = new MySqlCommand(query, connection);
                connection.Open();
                command2.ExecuteNonQuery();
                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine(">> ERROR " + e.Message + " >> ERROR");
                MessageBox.Show("Erro LK600");
                return e.Message;
            }
            finally {
                connection.Close();
            }
            
        }

        internal static DataSet Select(string query)
        {

            DataSet ds = new DataSet();
            DataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection Con = new MySqlConnection(StringConexao.sCon());
            string commando = query;
            cmd = new MySqlCommand(commando, Con);
            Con.Open();
            cmd.ExecuteReader();
            Con.Close();
            da = new MySqlDataAdapter(commando, StringConexao.sCon());
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        internal static DataSet Select_100(string query)
        {
            DataSet ds = new DataSet();
            DataAdapter da;
            MySqlCommand cmd = new MySqlCommand();


            MySqlConnection Con = new MySqlConnection(StringConexao.SC_100());
            string commando = query;
            cmd = new MySqlCommand(commando, Con);
            Con.Open();
            cmd.ExecuteReader();
            Con.Close();
            da = new MySqlDataAdapter(commando, StringConexao.SC_100());
            ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        public void Dispose()
        {
            ContextoEstoque.Dispose();

        }

        public void AdicionaRegistroInventario(List<RegistroInventario> ri)
        {
            ContextoEstoque.RegistrosInventario.AddRange(ri);
            ContextoEstoque.SaveChanges();
        }

        public List<RegistroInventario> ListaRegistroInventario(int inicial, int qtd)
        {
            return ContextoEstoque.RegistrosInventario.Where(p => p.Id >= inicial).Take(qtd).OrderByDescending(p => p.Id).ToList();
        }

        public List<RegistroInventario> ListaRegistroInventario(int count)
        {
            return ContextoEstoque.RegistrosInventario.OrderByDescending(p => p.Id).Take(count).ToList();
        }

        public List<RegistroInventario> ListaRegistroInventario()
        {
            return ContextoEstoque.RegistrosInventario.ToList();
        }

        public void RemoverRegistroInventario(RegistroInventario ri)
        {
            ContextoEstoque.RegistrosInventario.Remove(ri);
            ContextoEstoque.SaveChanges();

        }

        public void AdicionaSaldoDeTerceiro(List<SaldoDeTerceiro> st)
        {
            ContextoEstoque.SaldoDeTerceiros.AddRange(st);
            ContextoEstoque.SaveChanges();

        }

        public void AdicionaDepositoDeTerceiro(List<DepositoDeTerceiro> dt)
        {
            ContextoEstoque.DepositoDeTerceiros.AddRange(dt);
            ContextoEstoque.SaveChanges();
        }

        public void TruncateSaldoDeTerceiro()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE SaldoDeTerceiros");
        }

        public void TruncateDepositoDeTerceiro()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE DepositoDeTerceiros");
        }

        public void RemoveEntregaDeTerceiro(List<EntregaDeTerceiro> lista)
        {
            ContextoEstoque.EntregaDeTerceiros.RemoveRange(lista);
            ContextoEstoque.SaveChanges();
        }

        internal void AlterarLivre17Etiqueta(string produto, string livre17New)
        {
            var item = ListarEtiqueta().Where(p => p.Codigo == produto).First();
            livre17New = livre17New == "" ? "0" : livre17New;
            item.Livre17 = Convert.ToDecimal(livre17New);

            ContextoEstoque.Update(item);
            ContextoEstoque.SaveChanges();
        }

        internal void AlterarLivre17Saldo(string produto, string livre17New)
        {
            var item = ListaSaldo().Where(p=>p.Produto == produto).First();
            livre17New = livre17New == "" ? "0" : livre17New;
            item.Livre17 = Convert.ToDecimal(livre17New);

            ContextoEstoque.Update(item);
            ContextoEstoque.SaveChanges();

        }

        public List<SaldoDeTerceiro> ListaSaldoDeTerceiro()
        {
            return ContextoEstoque.SaldoDeTerceiros.ToList();
        }

        public List<DepositoDeTerceiro> ListaDepositoDeTerceiro()
        {
            return ContextoEstoque.DepositoDeTerceiros.ToList();
        }

        //ForaDeEstoque
        public void AdicionaForaDeEstoque(List<ForaDeEstoque> dt)
        {
            ContextoEstoque.ForaDeEstoques.AddRange(dt);
            ContextoEstoque.SaveChanges();
        }

        public void TruncateForaDeEstoque()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE foradeestoques");
        }

        public IList<ForaDeEstoque> ListaForaDeEstoque()
        {
            return ContextoEstoque.ForaDeEstoques.ToList();
        }

        //DeTerceiro
        public void AdicionaDeTerceiro(List<DeTerceiro> dt)
        {
            ContextoEstoque.DeTerceiros.AddRange(dt);
            ContextoEstoque.SaveChanges();
        }

        

        public void TruncateDeTerceiro()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE deterceiros");
        }

        public IList<DeTerceiro> ListaDeTerceiro()
        {
            return ContextoEstoque.DeTerceiros.ToList();
        }

        //ItensDeEstoque

        public void AlterarItensDeEstoque(List<ItensDeEstoque> lista)
        {
            ContextoEstoque.UpdateRange(lista);
            ContextoEstoque.SaveChanges();
        }

        public void AlteraSaldo(Saldo itemSaldo)
        {
            ContextoEstoque.Update(itemSaldo);
            ContextoEstoque.SaveChanges();
        }

        public void AdicionaItensDeEstoque(List<ItensDeEstoque> dt)
        {
            ContextoEstoque.ItensDeEstoques.AddRange(dt);
            ContextoEstoque.SaveChanges();
        }

        public void TruncateItensDeEstoque()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE itensdeestoques");
        }

        public List<ItensDeEstoque> ListaItensDeEstoque()
        {
            return ContextoEstoque.ItensDeEstoques.ToList();
        }

        public void AlterarPrateleiraItensDeEstoque(List<string> l)
        {
            var lista = ListaItensDeEstoque().Where(f => l.Contains(f.Codigo)).ToList();
            lista.ForEach(a =>
            {
                a.Prateleira = "";

            });

            ContextoEstoque.UpdateRange(lista);
            ContextoEstoque.SaveChanges();
        }

        internal void AlterarItensDeEstoque(ItensDeEstoque item)
        {
            ContextoEstoque.Update(item);
            ContextoEstoque.SaveChanges();
        }

        public void AlterarPrateleiraItensDeSaldoDeTerceiro(string s)
        {
            var lista = ListaSaldoDeTerceiro().Where(f => f.Produto == s).ToList();
            lista.ForEach(a =>
            {
                a.Prateleira = "";

            });

            ContextoEstoque.UpdateRange(lista);
            ContextoEstoque.SaveChanges();
        }
        internal void AlteraItemsDeEstoque(List<string> l)
        {
            foreach (var item in l)
            {
                var codigo = item.Split('\t').First();
                double customedio = Convert.ToDouble(item.Split('\t').Last().Replace(",",".")) ;

                var lista = ListaItensDeEstoque().Where(f => f.Codigo ==  codigo).ToList();
                lista.ForEach(a =>
                {
                    a.CustoMedio = customedio;

                });

                ContextoEstoque.UpdateRange(lista);
                ContextoEstoque.SaveChanges();
            }
        }

        //Saldo
        public void AdicionaSaldo(List<Saldo> dt)
        {
            ContextoEstoque.Saldos.AddRange(dt);
            ContextoEstoque.SaveChanges();
        }


        public void TruncateSaldo()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE Saldos");
        }

        public List<Saldo> ListaSaldo()
        {
            return ContextoEstoque.Saldos.ToList();
        }

        public void AlterarPrateleiraSaldo(List<string> l)
        {
            var lista = ListaSaldo().Where(f => l.Contains(f.Produto)).ToList();
            lista.ForEach(a =>
            {
                a.Prateleira = "";

            });

            ContextoEstoque.UpdateRange(lista);
            ContextoEstoque.SaveChanges();
        }

        public void AlterarPrateleiraSaldo(string produto, string prateleiraNova)
        {
            var lista = ListaSaldo().Where(p=>p.Produto == produto).First();
            lista.Prateleira = prateleiraNova;

            ContextoEstoque.UpdateRange(lista);
            ContextoEstoque.SaveChanges();
        }


        //RegistroInventarioSaldoDeTerceiro
        public void AdicionaRegistroInventarioSaldoDeTerceiro(List<RegistroInventarioSaldoDeTerceiro> list)
        {
            ContextoEstoque.RegistrosInventarioSaldoDeTerceiro.AddRange(list);
            ContextoEstoque.SaveChanges();
        }

        public List<RegistroInventarioSaldoDeTerceiro> ListaRegistroInventarioSaldoDeTerceiro(int count)
        {
            return ContextoEstoque.RegistrosInventarioSaldoDeTerceiro.OrderByDescending(p => p.Id).Take(count).ToList();
        }

        public void AlterarPrateleiraEtiqueta(string produto, string prateleiraNova)
        {
            var lista = ListarEtiqueta().Where(p => p.Codigo == produto).First();
            lista.Prateleira = prateleiraNova;

            ContextoEstoque.UpdateRange(lista);
            ContextoEstoque.SaveChanges();
        }

        public List<RegistroInventarioSaldoDeTerceiro> ListaRegistroInventarioSaldoDeTerceiro(int id, int count)
        {
            return ContextoEstoque.RegistrosInventarioSaldoDeTerceiro.Where(p => p.Id >= id).Take(count).OrderByDescending(p => p.Id).ToList();
            
        }

        public void RemoverRegistroInventarioSaldoDeTerceiro(RegistroInventarioSaldoDeTerceiro list)
        {
            ContextoEstoque.RegistrosInventarioSaldoDeTerceiro.Remove(list);
            ContextoEstoque.SaveChanges();
        }

        //Movimento
        public List<Movimento> ListaMovimento()
        {
            return ContextoEstoque.Movimentos.ToList();
        }

        
        //Entrega DeTerceiro
       
        public void AdicionarItemEntregaDeTerceiro(List<EntregaDeTerceiro> entrega)
        {
            ContextoEstoque.EntregaDeTerceiros.AddRange(entrega);
            ContextoEstoque.SaveChanges();
        }

        public List<EntregaDeTerceiro> ListaItemEntregaDeTerceiro()
        {
            return ContextoEstoque.EntregaDeTerceiros.ToList();
        }

        //OrdensDeProducao
        public List<OrdensDeProducao> ListaOrdensDeProducao()
        {
            return ContextoEstoque.OrdensDeProducoes.ToList();
        }

        public IList<PedidoDeCompra> ListPedidoDeCompra()
        {
            return ContextoEstoque.PedidosDeCompra.ToList();
        }

        public IList<NotasFiscaisDinamicaProduto> ListaNotasFiscaisDinamicaProduto()
        {
            return ContextoEstoque.NotasFiscaisDinamicaProdutos.ToList();
        }

        public IList<PedidoDeVenda> ListPedidoDeVenda()
        {
            return  ContextoEstoque.PedidosDeVenda.ToList();
        }

        public List<Entidade.Atualizacao> ListaAtualizacao()
        {
            return ContextoEstoque.Atualizacoes.OrderByDescending(p=>p.Data).ToList();
        }

        public void DeletaPedidoDeCompra(List<PedidoDeCompra> pca)
        {
            ContextoEstoque.PedidosDeCompra.RemoveRange(pca);
            ContextoEstoque.SaveChanges();
        }

        public List<DataBackUP> ListaDataBackUP()
        {
            return ContextoEstoque.DataBackUP.ToList();
        }
        public void AlteraDataBackUP(DataBackUP db)
        {
            ContextoEstoque.Update(db);
            ContextoEstoque.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arfid"></param>

        public void AdicionaAnotacaoRFID(List<AnotacaoRFID> arfid)
        {
            ContextoEstoque.AddRange(arfid);
            ContextoEstoque.SaveChanges();
        }
       
        public void ExcluiTudoAnotacaoRFID()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE AnotacaoRFIDs");
        }

        public List<AnotacaoRFID> ListaAnotacaoRFID()
        {
            return ContextoEstoque.AnotacaoRFIDs.ToList();
        }

        public List<Etiqueta> ListarEtiqueta()
        {
            return ContextoEstoque.Etiquetas.ToList();
        }

        public void AdicionaEtiquetaMovimentos(List<EtiquetaMovimentos> em)
        {
            ContextoEstoque.AddRange(em);
            ContextoEstoque.SaveChanges();
        }

        public void AlterarEtiquetas(List<Etiqueta> le)
        {
            ContextoEstoque.UpdateRange(le);
            ContextoEstoque.SaveChanges();
        }

        public List<EtiquetaMovimentos> ListaEtiquetaMovimentos()
        {
            return ContextoEstoque.EtiquetaMovimentos.ToList();
        }

        public void AdicionarEtiquetas(List<Etiqueta> le)
        {
            ContextoEstoque.AddRange(le);
            ContextoEstoque.SaveChanges();
        }

        public void DeletarEtiquetas(List<Etiqueta> leD)
        {
            ContextoEstoque.RemoveRange(leD);
            ContextoEstoque.SaveChanges();
        }

        public void TruncateEtiquetas()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE Etiquetas");
        }

        public void DeletarEtiquetaMovimento(EtiquetaMovimentos emt)
        {
            ContextoEstoque.Remove(emt);
            ContextoEstoque.SaveChanges();
        }

       //
        public List<SaldoDivergente> ListarSaldoDivergente()
        {
            return ContextoEstoque.SaldoDivergente.ToList();
        }

        public void AlterarSaldoDivergente(List<SaldoDivergente> le)
        {
            ContextoEstoque.UpdateRange(le);
            ContextoEstoque.SaveChanges();
        }

        public void AdicionarSaldoDivergente(List<SaldoDivergente> le)
        {
            ContextoEstoque.AddRange(le);
            ContextoEstoque.SaveChanges();
        }

        public void DeletarSaldoDivergente(List<SaldoDivergente> leD)
        {
            ContextoEstoque.RemoveRange(leD);
            ContextoEstoque.SaveChanges();
        }

        public void TruncateSaldoDivergente()
        {
            ContextoEstoque.Database.ExecuteSqlCommand("TRUNCATE TABLE SaldoDivergente");
        }

        public void AlteraSaldo(List<Saldo> saldos)
        {
            ContextoEstoque.UpdateRange(saldos);
            ContextoEstoque.SaveChanges();
        }


        /////
        ///

    }
}