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
        public string usuario_nome { get; set; }
        public string produto_nome { get; set; }
        public int quantidade_vendida { get; set;  }

        Conexao conexao { get; set; }

        public Venda()
        {
            conexao = new Conexao();
        }

        public List<Venda> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("""
                SELECT 
                    v.id AS id,
                    v.data AS `data`,
                    u.nome AS usuario_nome, -- nome do usuário
                    p.nome AS produto_nome, -- nome do produto (presumindo que a tabela 'produto' tenha a coluna 'nome')
                    t.quantidade AS quantidade_vendida -- quantidade da transação
                FROM 
                    vendas v
                JOIN 
                    usuarios u ON v.usuario_id = u.id
                JOIN 
                    transacao t ON t.venda_id = v.id
                JOIN 
                    produtos p ON t.produto_id = p.id;
                
                """);

            List<Venda> lista = new List<Venda>();

            foreach (DataRow linha in dt.Rows)
            {
                Venda v = new Venda();
                v.id = int.Parse(linha["id"].ToString());

                v.usuario_nome = linha["usuario_nome"].ToString();

                v.produto_nome = linha["produto_nome"].ToString();

                v.quantidade_vendida = int.Parse( linha["quantidade_vendida"].ToString() );

                v.data = DateTime.Parse(linha["data"].ToString());


                lista.Add(v);
            }

            return lista;

        }
    }
}
