using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Estoque.DAO;
using Estoque.Entidade;

namespace Estoque.Classes
{
    public class Conversor
    {
        internal static void Start(DataGridViewRow row, string Kg_MetroNew)
        {
            if (Kg_MetroNew.Length > 0 & Kg_MetroNew != "0")
            {


                bool atualizado = AtualizaConvercao(row, Kg_MetroNew);
                if (!atualizado)
                {
                    if (MessageBox.Show("Deseja Criar novo Kg/M?", "Kg/M", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {

                        var produto = row.Cells[0].Value.ToString();
                        var Descric = row.Cells[1].Value.ToString();
                        var Und = row.Cells[2].Value.ToString();
                        var M_Kg = Kg_MetroNew.Replace(",", ".");

                        Crud.InsertUpdateDelete($"INSERT INTO conversor (Produto, Descricao, und, m_kg) VALUES ('{produto}', '{Descric}', '{Und}', '{M_Kg}')");
                    }
                }
            }
            else
            {
                MessageBox.Show("Valor Incorreto");
            }
        }

        private static bool AtualizaConvercao(DataGridViewRow row, string Kg_MetroNew)
        {
            DataSet ds = new DataSet();
            ds = Crud.Select($"SELECT * FROM estoque.conversor where Produto = '{row.Cells[0].Value.ToString()}'");
            if (ds.Tables[0].Rows.Count == 1)
            {
                Crud.InsertUpdateDelete($"UPDATE conversor SET m_kg = '{Kg_MetroNew.Replace(",", ".")}' where Produto = '{row.Cells[0].Value.ToString()}' ");
                MessageBox.Show("Valor Alterado com sucesso");
                return true;
            }
            else
                return false;

        }

        public static Etiqueta Converte(Etiqueta e, decimal valor, string operacao)
        {
            // operacao : Livre17 * Convertido
            if (e.Grupo == "12000000" & e.Livre17 > 0 & e.UND == "KG")
            {
                List<string> descricoes = new List<string>() { "BARRA ", "TUBO ", "PERFIL ", "BUCHA " };
                foreach (var i in descricoes)
                {
                    bool b = e.Descricao.StartsWith(i);
                    if (b)
                    {
                        if (operacao == "+")
                        {
                            e.Convertido += valor;
                        }
                        if (operacao == "-")
                        {
                            e.Convertido -= valor;
                        }
                        if (operacao == "A")
                        {
                            e.Convertido = valor;
                        }
                        e.SaldoAtual = Math.Round(e.Convertido * e.Livre17,3);
                    }
                }
                return e;
            }

            if (e.Livre17 > 0)
            {
                if (operacao == "+")
                {
                    e.SaldoAtual += valor;
                }
                if (operacao == "-")
                {
                    e.SaldoAtual -= valor;

                }
                if (operacao == "A")
                {
                    e.SaldoAtual = valor;

                }
                e.Convertido = Math.Round(e.SaldoAtual * e.Livre17,2);
                return e;
            }

            if (e.Livre17 == 0)
            {
                if (operacao == "+")
                {
                    e.SaldoAtual += valor;
                }
                if (operacao == "-")
                {
                    e.SaldoAtual -= valor;
                }
                if (operacao == "A")
                {
                    e.SaldoAtual = valor;
                }
                return e;
            }

            return null;
        }
        public static Etiqueta GetConvertido(Etiqueta e)
        {
            // operacao : Livre17 * Convertido
            if (e.Grupo == "12000000" & e.Livre17 > 0 & e.UND == "KG")
            {
                List<string> descricoes = new List<string>() { "BARRA ", "TUBO ", "PERFIL ", "BUCHA " };
                foreach (var i in descricoes)
                {
                    bool b = e.Descricao.StartsWith(i);
                    if (b)
                    {
                        e.Convertido = Math.Round(e.SaldoAtual / e.Livre17, 2);
                    }
                }
                return e;
            }

            if (e.Livre17 > 0)
            {

                e.Convertido = Math.Round(e.SaldoAtual * e.Livre17, 2);
                return e;
            }

            if (e.Livre17 == 0)
            {
                return e;
            }

            return null;
        }
        public static Etiqueta GetSaldoAtual(Etiqueta e)
        {
            // operacao : Livre17 * Convertido
            if (e.Grupo == "12000000" & e.Livre17 > 0 & e.UND == "KG")
            {
                List<string> descricoes = new List<string>() { "BARRA ", "TUBO ", "PERFIL ", "BUCHA " };
                foreach (var i in descricoes)
                {
                    bool b = e.Descricao.StartsWith(i);
                    if (b)
                    {
                        e.SaldoAtual = Math.Round(e.Convertido * e.Livre17, 3);
                    }
                }
                return e;
            }

            if (e.Livre17 > 0)
            {

                e.SaldoAtual = Math.Round(e.Convertido / e.Livre17, 3);
                return e;
            }

            if (e.Livre17 == 0)
            {
                return e;
            }

            return null;
        }
    }
}