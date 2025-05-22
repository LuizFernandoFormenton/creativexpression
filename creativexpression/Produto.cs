using System;
using System.Collections.Generic;
using System.Data;

namespace creativexpression
{
    class Produto
    {
        public int id {get; set;}

        public string nome {get; set;}

        public float preco {get; set;}

        public string imagem {get; set;}
        
        public string tamanho { get; set; }

        Conexao conexao { get; set; }

        public Produto()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {
            string query = $" INSERT INTO produtos (nome, preco, imagem, tamanho) VALUES ( '{nome}', {preco.ToString().Replace(",",".")}, '{imagem}', '{tamanho}' ); ";
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
                produto.nome = Linha["nome"].ToString();
                produto.preco = float.Parse(Linha["preco"].ToString());
                produto.imagem = Linha["imagem"].ToString();
                produto.tamanho = (Linha["tamanho"].ToString());

                lista.Add(produto);
            }

            return lista;
        }


    }
}