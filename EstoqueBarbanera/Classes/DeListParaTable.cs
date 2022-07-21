using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estoque.Entidade;
using FastMember;
using static Estoque.Classes.Inventario;
using static Estoque.Views.EntregaItemDeTerceiro;
using static Estoque.Views.Verificar_OPs_Liberadas;

namespace Estoque.Classes
{
    public class DeListParaTable
    {
        public DataTable InventariarForaDeEstoqueComSaldo(List<ForaDeEstoque2> ir)
        {
            // New table.
            DataTable table = new DataTable("InventariarForaDeEstoqueComSaldo");

            table.Columns.Add("Produto", typeof(String));
            table.Columns.Add("Descricao", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("Unid: Saldo", typeof(String));
            table.Columns.Add("ForaEstoque", typeof(Double));
            table.Columns.Add("Inventario", typeof(String));
            table.Columns.Add("NomeFantasia", typeof(String));
            table.Columns.Add("NotaFiscal", typeof(String));
            table.Columns.Add("TM", typeof(String));
            table.Columns.Add("Data", typeof(DateTime));

            // Add rows.
            DataRow row;
            foreach (var item in ir/*.OrderByDescending(c => c.ForaDeEstoque).OrderBy(c => c.Produto)*/)
            {
                row = table.NewRow();

                row[0] = item.Produto;
                row[1] = item.Descricao;
                row[2] = item.Prateleira;
                row[3] = item.Unidade + ": " + item.SaldoFisico;
                row[4] = item.ForaDeEstoque;
                row[5] = "";
                row[6] = item.NomeFantasia;
                row[7] = item.DocFiscal;
                row[8] = item.TM;
                row[9] = item.Data;

                table.Rows.Add(row);
            }
            return table;
        }

        internal List<object> OrdensDeProducao(List<NovasOPs> lista)
        {
            var s = Directory.GetFiles(@"Z:\Cid\OPs scaneadas", "*.pdf", SearchOption.TopDirectoryOnly);

            List<NovasOPs> OPs = new List<NovasOPs>();
            foreach (var i in s)
            {
                var d = Convert.ToInt32(i.Remove(0, 21).Split(' ', '.').First());
                OPs.Add(new NovasOPs { OPs = d });
            }

            List<NovasOPs> odp = new List<NovasOPs>();

            foreach (var l in lista)
            {
                foreach (var i in OPs)
                {
                    if (l.OPs == i.OPs)
                    {
                        odp.Add(l);
                    }
                }
            }

            var tt = lista.Except(odp).ToList();

            var cd = (from lib in tt where lib.Status == "Cancelada" select lib).Count();
            var ed = (from lib in tt where lib.Status == "Encerrada" select lib).Count();




            // New table.
            DataTable table = new DataTable("OrdensDeProducao");

            table.Columns.Add("OP", typeof(Int16));
            table.Columns.Add("STATUS", typeof(String));
            table.Columns.Add("Data", typeof(String));
            table.Columns.Add("AÇÃO", typeof(String));
            table.Columns.Add("Cod, QTD, Data, TM", typeof(String));



            // Add rows.
            DataRow row;
            foreach (var item in tt)
            {
                row = table.NewRow();



                row[0] = item.OPs;
                row[1] = item.Status;
                row[2] = item.Data;
                row[3] = item.Acao;
                row[4] = item.Movimentacoes;


                table.Rows.Add(row);
            }
            List<object> ob = new List<object>();
            ob.Add(table);
            ob.Add(cd);
            ob.Add(ed);
            ob.Add(odp.Count);
            ob.Add(tt);

            return ob;
        }

        internal DataTable OrdensDeProducaoTudo(List<OrdensDeProducao> lista)
        {
            // New table.
            DataTable table = new DataTable("OrdensDeProducao");

            table.Columns.Add("OP", typeof(Int16));
            table.Columns.Add("STATUS", typeof(String));
            table.Columns.Add("DataEncerramento", typeof(String));
            table.Columns.Add("DataCancelamento", typeof(String));
            table.Columns.Add("DataLiberação", typeof(String));
            table.Columns.Add("AÇÃO", typeof(String));

            // Add rows.
            DataRow row;
            foreach (var item in lista.OrderByDescending(c => c.NroOP))
            {
                row = table.NewRow();

                row[0] = item.NroOP;
                row[1] = item.StatusOP;
                row[2] = item.DtEncerramento;
                row[3] = item.DtCancelamento;
                row[4] = item.DtLiberacao;
                row[5] = (item.DtEncerramento.Length > 0 | item.DtCancelamento.Length > 0) == true ? "RETIRAR DA CAIXA" : null;


                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable ConvertListToDataTable(List<RegistroInventario> ir)
        {
            var id = ir.Select(p => p.Id).First();
            if (id == 0)
            {
                //Nao ordena como no banco de dados na ordem das colunas. as colulunas sao ordenadas em ordem alfabetica
                DataTable table = new DataTable();
                using (
                    var reader = ObjectReader.Create(ir)
                    )
                {
                    table.Load(reader);
                }
                return table;
            }
            else
            {
                // New table.
                DataTable table = new DataTable("InventarioRotativo");
                DataColumn workCol = table.Columns.Add("Id", typeof(int));
                workCol.AllowDBNull = false;
                workCol.Unique = true;

                table.Columns.Add("Produto", typeof(String));
                table.Columns.Add("Descricao", typeof(String));
                table.Columns.Add("Prateleira", typeof(String));
                table.Columns.Add("Unid", typeof(String));
                table.Columns.Add("SaldoAtual", typeof(Double));
                table.Columns.Add("ValorConvertido", typeof(Double));

                table.Columns.Add("Inventario", typeof(Double));
                table.Columns.Add("DiaInventario", typeof(DateTime));
                table.Columns.Add("DiasMov", typeof(String));
                table.Columns.Add("Acerto", typeof(Double));

                // Add rows.
                DataRow row;
                foreach (var item in ir.OrderBy(c => c.Prateleira))
                {
                    row = table.NewRow();

                    row[0] = item.Id;
                    row[1] = item.Produto;
                    row[2] = item.Descricao;
                    row[3] = item.Prateleira;
                    row[4] = item.Unid;
                    row[5] = item.SaldoAtual;
                    row[6] = item.ValorConvertido;
                    row[7] = item.Inventario;
                    row[8] = item.DiaInventario;
                    row[9] = item.DiasMov;
                    row[10] = item.Acerto;

                    table.Rows.Add(row);
                }
                return table;
            }
        }

        internal object ConvertListToDataTable(List<ListaCartoes> faltou)
        {
            DataTable table = new DataTable("FaltouLer");

            table.Columns.Add("UID", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("Status", typeof(String));

            // Add rows.
            DataRow row;
            foreach (var item in faltou)
            {
                row = table.NewRow();

                row[0] = item.UID;
                row[1] = item.Prateleira;
                row[2] = item.Status;
                table.Rows.Add(row);
            }
            return table;
        }

        internal object ConvertListToDataTable(List<Leituras> leituras)
        {

            DataTable table = new DataTable("Leituras");

            table.Columns.Add("Seq", typeof(String));
            table.Columns.Add("Data", typeof(DateTime));
            table.Columns.Add("ID", typeof(String));
            table.Columns.Add("Codigo", typeof(String));
            table.Columns.Add("Descricao", typeof(String));
            table.Columns.Add("UND", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("Quantidade", typeof(decimal));
            table.Columns.Add("Conversor", typeof(decimal));
            table.Columns.Add("Convertido", typeof(decimal));

            // Add rows.
            DataRow row;
            foreach (var item in leituras)
            {
                row = table.NewRow();

                row[0] = item.Seq;
                row[1] = item.Data;
                row[2] = item.ID;
                row[3] = item.Produto;
                row[4] = item.Descricao;
                row[5] = item.Unid;
                row[6] = item.Prateleira;
                row[7] = item.SaldoAtual;
                row[8] = item.Livre17;
                row[9] = item.Convertido;

                table.Rows.Add(row);
            }
            return table;
        }

       

        public DataTable ConvertListToDataTableListString(List<String> ir)
        {
            DataTable table = new DataTable("Links");
            //Nao ordena como no banco de dados na ordem das colunas. as colulunas sao ordenadas em ordem alfabetica

            table.Columns.Add("Links", typeof(String));
            DataRow row;
            foreach (var item in ir)
            {
                row = table.NewRow();

                row[0] = item;

                table.Rows.Add(row);
            }
            return table;

        }

        internal DataTable InventarioDepositosDeTerceiro(List<SaldoDeTerceiro> iddt)
        {
            // New table.
            DataTable table = new DataTable("InventarioDepositosDeTerceiro");

            table.Columns.Add("Produto", typeof(String));
            table.Columns.Add("Descricao", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("Unid/Saldo", typeof(String));
            table.Columns.Add("DeTerceiros", typeof(Double));
            table.Columns.Add("Inventario", typeof(String));
            table.Columns.Add("Deposito", typeof(String));
            table.Columns.Add("Entrega", typeof(String));
            table.Columns.Add("Data", typeof(String));
            table.Columns.Add("DocFiscal", typeof(String));

            // Add rows.
            DataRow row;
            foreach (var item in iddt.OrderBy(c => c.Prateleira))
            {
                row = table.NewRow();

                row[0] = item.Produto;
                row[1] = item.Descricao;
                row[2] = item.Prateleira;
                row[3] = item.Unid + ": " + item.SaldoAtual;
                row[4] = item.DeTerceiros;
                row[5] = "";
                row[6] = item.DEPOSITO;
                row[7] = item.Descricao2;
                row[8] = item.Data;
                row[9] = item.DESCR_2;


                table.Rows.Add(row);
            }
            return table;
        }

        internal DataTable RotativoSmart(List<RegistroInventario> ir)
        {
            // New table.
            DataTable table = new DataTable("RotativoSmart");

            table.Columns.Add("Produto", typeof(String));
            table.Columns.Add("Descricao", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("Unid: SaldoAtual", typeof(String));
            //table.Columns.Add("SaldoAtual", typeof(Double));
            table.Columns.Add("ValorConvertido", typeof(Double));
            table.Columns.Add("Inventario", typeof(String));


            // Add rows.
            DataRow row;
            foreach (var item in ir)
            {
                row = table.NewRow();

                row[0] = item.Produto;
                row[1] = item.Descricao;
                row[2] = item.Prateleira.Length == 0 & item.Livre17 == 0 ? "" : item.Prateleira + " C-" + item.Livre17;
                row[3] = item.Unid + ": " + item.SaldoAtual;
                //row[4] = item.SaldoAtual;
                row[4] = item.ValorConvertido;
                row[5] = "";

                table.Rows.Add(row);
            }
            return table;
        }

        internal DataTable InventarioPersonalizado(List<RegistroInventario> ri)
        {
            // New table.
            DataTable table = new DataTable("InventarioPersonalizado");

            table.Columns.Add("Produto", typeof(String));
            table.Columns.Add("Descricao", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("SaldoAtual", typeof(String));
            table.Columns.Add("ValorConvertido", typeof(Double));
            table.Columns.Add("Inventario", typeof(string));

            // Add rows.
            DataRow row;
            foreach (var item in ri.OrderBy(c => c.Prateleira))
            {
                row = table.NewRow();

                row[0] = item.Produto;
                row[1] = item.Descricao;
                row[2] = item.Prateleira + (item.Livre17 > 0d ? " C-" + item.Livre17 : "");
                row[3] = item.Unid + ": " + item.SaldoAtual;
                row[4] = item.ValorConvertido;
                row[5] = "";

                table.Rows.Add(row);
            }
            return table;
        }

        internal DataTable RegistroInventarioSaldoDeTerceiro(List<RegistroInventarioSaldoDeTerceiro> l)
        {
            // New table.
            DataTable table = new DataTable("RegistroInventarioSaldoDeTerceiro");


            table.Columns.Add("Id", typeof(String));
            table.Columns.Add("Produto", typeof(String));
            table.Columns.Add("Descricao", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("Unid", typeof(String));
            table.Columns.Add("SaldoAtual", typeof(Double));
            table.Columns.Add("DeTerceiro", typeof(Double));
            table.Columns.Add("Inventario", typeof(string));
            table.Columns.Add("DiaInventario", typeof(string));

            // Add rows.
            DataRow row;
            foreach (var item in l.OrderBy(c => c.Prateleira))
            {
                row = table.NewRow();

                row.SetField("Id", item.Id);
                row.SetField("Produto", item.Produto);
                row[2] = item.Descricao;
                row[3] = item.Prateleira;
                row[4] = item.Unid;
                row[5] = item.SaldoAtual;
                row[6] = item.DeTerceiro;
                row[7] = item.Inventario;
                row[8] = item.DiaInventario;

                table.Rows.Add(row);
            }
            return table;
        }

        internal DataTable Pesquisa(List<RegistroInventario> reg)
        {
            // New table.
            DataTable table = new DataTable("Pesquisa");


            table.Columns.Add("Id", typeof(String));
            table.Columns.Add("Produto", typeof(String));
            table.Columns.Add("Descricao", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("Unid", typeof(String));
            table.Columns.Add("SaldoAtual", typeof(Double));
            table.Columns.Add("ValorConvertido", typeof(Double));
            table.Columns.Add("Inventario", typeof(Double));
            table.Columns.Add("DiaInventario", typeof(DateTime));
            table.Columns.Add("DiasMov", typeof(String));
            table.Columns.Add("Acerto", typeof(Double));
            table.Columns.Add("Livre17", typeof(string));

            // Add rows.
            DataRow row;
            foreach (var item in reg.OrderBy(c => c.Produto))
            {
                row = table.NewRow();

                row.SetField("Id", item.Id);
                row.SetField("Produto", item.Produto);
                row.SetField("Descricao", item.Descricao);
                row.SetField("Prateleira", item.Prateleira);
                row.SetField("Unid", item.Unid);
                row.SetField("SaldoAtual", item.SaldoAtual);
                row.SetField("ValorConvertido", item.ValorConvertido);
                row.SetField("Inventario", item.Inventario);
                row.SetField("DiaInventario", item.DiaInventario);
                row.SetField("DiasMov", item.DiasMov);
                row.SetField("Acerto", item.Acerto);
                row.SetField("Livre17", item.Livre17);

                table.Rows.Add(row);
            }
            return table;
        }


        internal DataTable InventarioDiario(List<RegistroInventario2> ri)
        {
            // New table.
            DataTable table = new DataTable("InventarioDiario");

            table.Columns.Add("Produto", typeof(String));
            table.Columns.Add("Descricao", typeof(String));
            table.Columns.Add("Prateleira", typeof(String));
            table.Columns.Add("SaldoAtual", typeof(String));
            table.Columns.Add("ValorConvertido", typeof(Double));
            table.Columns.Add("Inventario", typeof(string));
            table.Columns.Add("OperadorInclusao", typeof(string));

            // Add rows.
            DataRow row;
            foreach (var item in ri.OrderBy(c => c.Prateleira))
            {
                row = table.NewRow();

                row[0] = item.Produto;
                row[1] = item.Descricao;
                row[2] = item.Prateleira + (item.Livre17 > 0d ? " C-" + item.Livre17 : "");
                row[3] = item.Unid + ": " + item.SaldoAtual;
                row[4] = item.ValorConvertido;
                row[5] = "";
                row[6] = item.OperadorInclusao;

                table.Rows.Add(row);
            }
            return table;
        }public static DataTable ConvertListToTableGeneric<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }
            return table;
        }
        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor prop in properties)
            {
               table.Columns.Add(prop.Name, prop.PropertyType);
            }
            return table;
        }

        public static DataSet ToDataSet<T>(IList<T> list)
        {
            var elementType = typeof(T);
            var ds = new DataSet();
            var t = new DataTable();
            ds.Tables.Add(t);

            if (elementType.IsValueType)
            {
                var colType = Nullable.GetUnderlyingType(elementType) ?? elementType;
                t.Columns.Add(elementType.Name, colType);

            }
            else
            {
                //add a column to table for each public property on T
                foreach (var propInfo in elementType.GetProperties())
                {
                    var colType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                    t.Columns.Add(propInfo.Name, colType);
                }
            }

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                var row = t.NewRow();

                if (elementType.IsValueType)
                {
                    row[elementType.Name] = item;
                }
                else
                {
                    foreach (var propInfo in elementType.GetProperties())
                    {
                        row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                    }
                }
                t.Rows.Add(row);
            }

            return ds;
        }
    }
}
