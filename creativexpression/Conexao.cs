using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace creativexpression
{
    class Conexao
    {

        string dadosConexao = "server=localhost;user=root;database=creativexpression;port=3306;password=";

        public int ExecutaComando(string query)
        {
            //Cria e abre conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            //Rodar a query dentro do banco
            MySqlCommand comando = new MySqlCommand(query, conexao);
            int LinhasAfetadas = comando.ExecuteNonQuery();
            conexao.Close();

            return LinhasAfetadas;
        }


        public DataTable ExecutaSelect( string query )
        {
            //Cria e abre conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataAdapter dados = new MySqlDataAdapter (comando);
            DataTable dt = new DataTable();
            dados.Fill (dt);

            conexao.Close();

            return dt;
        }

        public List<Produto> BuscaProdutos()
        {

            //Abrir conexão com o BD
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            Console.WriteLine("Conexão realizada com sucesso!");

            //Rodar o sql dentro do banco
            string sql = "SELECT * FROM produtos;";
            MySqlCommand comando = new MySqlCommand(sql, conexao );
            MySqlDataReader dados = comando.ExecuteReader();


            List<Produto>lista = new List<Produto>();


            while (dados.Read())
            {
                // Console.WriteLine(" ID: " + dados[0] + " Nome: " + dados[1] + " Preço: " + dados[2] + " Data: " + dados[3] );

                Produto p = new Produto();
                p.id = dados.GetInt32("id");
                p.nome_do_produto = dados.GetString("nome_do_produto");
                p.preco = dados.GetFloat("preco");
                p.tamanho = dados.GetString("tamanho");
                lista.Add(p);
            }


            conexao.Close();

            return lista;

        }


    }
}