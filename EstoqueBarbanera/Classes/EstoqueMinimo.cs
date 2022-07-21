using System.Data;
using System.Windows.Forms;
using Estoque.DAO;
using MySql.Data.MySqlClient;


namespace Estoque.Classes
{
    internal class EstoqueMinimo
    {

        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlConnection Con = new MySqlConnection();


        public DataSet ds;

        MySqlConnection Con2 = new MySqlConnection();

        MySqlConnection Con3 = new MySqlConnection();

        public DataSet estoqueMinimo2()
        {

            return Atualizar();

        }

        private DataSet Atualizar()
        {
            try
            {
                Con = new MySqlConnection(StringConexao.sCon()); // inicializa uma nova instancia da classe system.data.sqlcliente.sqlconnection onde recebe uma string que contem a connection string
                Con.Open();// abre a conexão4

                string commando = "SELECT e.Produto, e.Descricao, e.Unid, e.SaldoAtual, e.PedCompras, e.PrevFabric, e.EstqMinimo, e.ConsuPrevOs, e.EstqMaximo, e.Prateleira,  " +
                  "e.Grupo, e.DiasSemMovimento,   " +

                "case   " +
                   "WHEN(e.Grupo = '12000000')  and(e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1)) < e.EstqMinimo then " +

                        "concat('Min: ', round(abs(e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1) -e.EstqMinimo) ,3),   " +
                               "';Max: ',round(abs(e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1) -e.EstqMaximo) ,3))   " +

                    "WHEN(e.Grupo = '10000000' OR e.Grupo = '11000000') and e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1) < e.EstqMinimo then " +

                        "concat('Min: ', round((e.EstqMinimo) - (e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1)) ,3),   " +
                            "';Max: ',round((e.EstqMaximo) - (e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1)) ,3))   " +

                    "WHEN(e.Grupo = '15000000' OR e.Grupo = '16000000' OR e.Grupo = '20000000')  and(e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1)) < e.EstqMinimo then " +

                        "concat('Min: ', round(abs(e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1) -e.EstqMinimo) ,3),   " +
                               "';Max: ',round(abs(e.Disponivel + (select if (sum(QTD) is null, 0, sum(QTD)) from solicitacao where Produto = e.Produto and FimStatus = 'AGUARD' order by id desc limit 1) -e.EstqMaximo) ,3) ) " +
                "end AS PEDIR,     " +

                "s.ID, s.QTD AS QTD_Pedida, s.OP, s.DataHora,   " +
                "IF(e.Grupo <> '11000000' and e.Grupo <> '10000000', concat(date_format(p.Entrega, '%d/%m'), '_', p.Pedido, '_', p.Saldo), concat('PrevFabric-', e.PrevFabric)) as Prazo_Pedido_QTD,   " +

                "IF(s.Andamento = 'AGUARD', 'NA', concat('PCP: ', substring(s.andamento, 1, 5))) AS Andamento, " +

                     "s.FimStatus,   " +

                "if (e.SaldoAtual >= (e.EstqMinimo + e.ConsuPrevOs), 'NF OK?','') AS NF_OK, " +

               "IF (((e.SaldoAtual + (select sum(qtd) from solicitacao as ss where ss.FimStatus = 'AGUARD'  and ss.produto = e.Produto ) +e.PrevFabric ) -(e.EstqMinimo + e.ConsuPrevOs)) < 0 ,   " +

                        "if ((e.SaldoAtual + e.PedCompras + e.PrevFabric) < (e.EstqMinimo + e.ProdPrevOS),round(((e.SaldoAtual + (select sum(qtd) from solicitacao as ss where ss.FimStatus = 'AGUARD'  and ss.produto = e.Produto) + e.PrevFabric ) -(e.EstqMinimo + e.ConsuPrevOs)) *(-1) ,3),''),'')  as PedirMais,    " +

                "if (p.Entrega < current_date,'ATRAZADO','') as Atrazado, e.Disponivel, e.PedVendas " +

                "FROM saldos as e LEFT JOIN Solicitacao as s ON e.Produto = s.Produto " +
                "AND s.FimStatus = 'AGUARD' " +
                "LEFT JOIN pedidodecompra as p ON e.Produto = p.Produto " +
                "WHERE((e.Disponivel < e.EstqMinimo OR(e.Disponivel + (select sum(qtd) from solicitacao as ss where ss.FimStatus = 'AGUARD'  and ss.produto = e.Produto)) < (e.EstqMinimo + e.ConsuPrevOs)) and e.EstqMinimo > 0 OR s.FimStatus = 'AGUARD' ) " +

                "ORDER BY s.ID ASC"; 


                MySqlCommand cmd = new MySqlCommand(commando, Con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();

                da.Fill(ds);
                Con.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            return ds;
        }

        public void estoqueMinimo()
        {
            //it.importTXT();
            //ie.importExcel();

            try// verifica erros no bloco
            {


                Con = new MySqlConnection(StringConexao.sCon()); // inicializa uma nova instancia da classe system.data.sqlcliente.sqlconnection onde recebe uma string que contem a connection string
                Con.Open();// abre a conexão4

                string commando = " SELECT " +
                    // "Quantidade_Atual AS QTD_Suprimentos from EstoqueSuprimentos where Quantidade_Atual <> 0";

                    "Estoque_e_Cadastro.Cod_Produto AS Código, " +
                    "Estoque_e_Cadastro.Produto_MatPrima AS Produto, " +
                    "Estoque_e_Cadastro.Unidade AS UND, " +
                    "Estoque_e_Cadastro.Endereco AS Endereço, " +
                    "Estoque_e_Cadastro.Quantidade_Atual AS QTD_Estoque, " +
                    "EstoqueSuprimentos.Quantidade_Atual AS QTD_Suprimentos, " +
                    "Estoque_e_Cadastro.Quantidade_Minima AS QTD_Mínima, " +
                    "pedcompra.PedCompra AS PedCompra, " +
                    "IF (SUBSTRING_INDEX(Estoque_e_Cadastro.Produto_MatPrima, ' ', 1) = 'CORDOALHA' ,NULL, ROUND(Estoque_e_Cadastro.QTD_Metro_Atual,  3)) AS QTD_Metros_Atual, " +
                    "IF (SUBSTRING_INDEX(Estoque_e_Cadastro.Produto_MatPrima, ' ', 1) = 'CORDOALHA' ,NULL, ROUND(Estoque_e_Cadastro.QTD_Metro_Minima, 3)) AS QTD_Metros_Minimo, " +


                     "  IF (  Estoque_e_Cadastro.Quantidade_Minima + EstoqueSuprimentos.Quantidade_Atual + IF(Estoque_e_Cadastro.Quantidade_Atual < 0,(-1 * Estoque_e_Cadastro.Quantidade_Atual)," +
                     "(-Estoque_e_Cadastro.Quantidade_Atual) -pedcompra.PedCompra) > 0, " +
                     "CONCAT('',ROUND(Estoque_e_Cadastro.Quantidade_Minima + EstoqueSuprimentos.Quantidade_Atual + " +
                     "IF(Estoque_e_Cadastro.Quantidade_Atual < 0,(-1 * Estoque_e_Cadastro.Quantidade_Atual)," +
                     "(-Estoque_e_Cadastro.Quantidade_Atual))-pedcompra.PedCompra, 0),' ', Estoque_e_Cadastro.Unidade), '' ) AS PEDIR________ " +

                      " FROM Estoque_e_Cadastro " +
                    "INNER JOIN EstoqueSuprimentos " +
                    "INNER JOIN pedcompra " +
                    "ON EstoqueSuprimentos.Cod_Produto = Estoque_e_Cadastro.Cod_Produto " +
                    "AND pedcompra.Cod_Produto = Estoque_e_Cadastro.Cod_Produto " +
                    "WHERE Estoque_e_Cadastro.Quantidade_Minima > Estoque_e_Cadastro.Quantidade_Atual " +
                    "OR EstoqueSuprimentos.Quantidade_Atual > Estoque_e_Cadastro.Quantidade_Atual " +
                    //"WHERE Estoque_e_Cadastro.Quantidade_Minima <> 0 " +
                    //"AND EstoqueSuprimentos.Quantidade_Atual < 0 " +
                    //"AND Estoque_e_Cadastro.Quantidade_Minima >= EstoqueSuprimentos.Quantidade_Atual " +
                    "ORDER BY Estoque_e_Cadastro.Endereco ASC ";


                MySqlCommand cmd = new MySqlCommand(commando, Con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet(); // cria um novo objeto dataset
                da.Fill(ds); // preenche o dataset com o dataadapter,
                             //frmEstoque_e_Cadastro frm = new frmEstoque_e_Cadastro();



                // o datagridview é preenchida com a tabala 0 do dataset
                Con.Close();//Fecha a conexão // fecha a conexão
            } // fim do bloco verificador de erros
            catch (MySqlException ex) // procura o tipo de erro
            {
                MessageBox.Show(ex.Message); // se houver algum erro uma mensagem é exibida
                Con.Close();//Fecha a conexão// e fecha a conexão
            }


        }
    }
}