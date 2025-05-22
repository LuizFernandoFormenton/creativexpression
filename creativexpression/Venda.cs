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
        public int id { get; set; }
        public DateTime data { get; set; }
        public int usuario_id { get; set; }

        Conexao conexao { get; set; }

        public Venda()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {
            string query = $"INSERT INTO vendas (id, usuario_id) VALUES( '{id}', '{usuario_id}');";
            conexao.ExecutaComando(query);
            Console.WriteLine("Produto inserido com sucesso");
        }

        public List<Venda> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT produto.nome, venda.id_transacao, venda.data FROM venda JOIN produtos ON venda.usuario.id = produto.id;");

            List<Venda> lista = new List<Venda>();

            foreach (DataRow linha in dt.Rows)
            {
                Venda v = new Venda();
                v.id = int.Parse(linha["id"].ToString());

                v.usuario_id = int.Parse(linha["usuario_id"].ToString());

                v.data = DateTime.Parse(linha["data"].ToString());


                lista.Add(v);
            }

            return lista;

        }
    }
}
