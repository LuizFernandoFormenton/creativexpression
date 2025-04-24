using System;
using System.Collections.Generic;
using System.Data;

namespace creativexpression
{
    class Produto
    {
        public int id {get; set;}

        public string nome_do_produto {get; set;}

        public float preco {get; set;}
        
        public string tamanho { get; set; }

        Conexao conexao { get; set; }

        public Produto()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {
            string query = $" INSERT INTO produtos (nome_do_produto, preco, tamanho) VALUES ( '{nome_do_produto}', {preco.ToString().Replace(",",".")}, '{tamanho}' ); ";
            conexao.ExecutaComando(query);
            Console.WriteLine(" Produto inserido com sucesso! ");
        }

        public List<Produto> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM produtos;");

            List<Produto> lista = new List<Produto>();

            foreach (DataRow Linha in dt.Rows)
            {
                Produto produto = new Produto();

                produto.id = int.Parse(Linha["id"].ToString());
                produto.nome_do_produto = Linha["nome_do_produto"].ToString();
                produto.preco = float.Parse(Linha["preco"].ToString());
                produto.tamanho = (Linha["tamanho"].ToString());

                lista.Add(produto);
            }

            return lista;
        }


    }
}