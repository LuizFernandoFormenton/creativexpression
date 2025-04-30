using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creativexpression
{
    internal class Venda
    {
        public int id_transacao { get; set; }
        public int id_produto { get; set; }
        public int quantidade { get; set; }
        public string nome_do_produto { get; set; }
        public DateTime data { get; set; }

        Conexao conexao { get; set; }

        public Venda()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {
            string query = $"INSERT INTO vendas (id_transacao, id_produto, quantidade) VALUES( '{id_transacao}', {id_produto},'{quantidade}');";
            conexao.ExecutaComando(query);
            Console.WriteLine("Produto inserido com sucesso");
        }

        public List<Venda> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT vendas.quantidade, produtos.nome_do_produto, vendas.id_transacao, vendas.data FROM vendas JOIN produtos ON vendas.id_produto = produtos.id;");

            List<Venda> lista = new List<Venda>();

            foreach (DataRow linha in dt.Rows)
            {
                Venda v = new Venda();
                v.id_transacao = int.Parse(linha["id_transacao"].ToString());

                v.nome_do_produto = linha["nome_do_produto"].ToString();

                v.quantidade = int.Parse(linha["quantidade"].ToString());

                v.data = DateTime.Parse(linha["data"].ToString());

                lista.Add(v);
            }

            return lista;

        }
    }
}
