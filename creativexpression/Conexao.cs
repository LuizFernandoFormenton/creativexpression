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
            //cria conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            // Rodar a query dentro do banco
            MySqlCommand comando = new MySqlCommand(query, conexao);
            int LinhasAfetadas = comando.ExecuteNonQuery();
            conexao.Close();

            return LinhasAfetadas;
        }
       
       
        public DataTable ExecutaSelect(string query)
        {
            //cria conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            // Rodar a query dentro do banco
            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataAdapter dados = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            dados.Fill(dt);
            conexao.Close();

            return dt;
        }

        public List<Venda> BuscaVendas()
        {

            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            // Abrir conexão com o banco
            Console.WriteLine("Conexão realizada com sucesso!");

            // Rodar o SQL dentro do banco
            string sql = "SELECT * FROM vendas;";
            MySqlCommand comando = new MySqlCommand( sql, conexao );
            MySqlDataReader dados = comando.ExecuteReader();

            List<Venda> lista = new List<Venda>();
            while( dados.Read() )
            {

                Venda p = new Venda();

                p.id_transacao = dados.GetInt32("id_transacao");
                p.id_produto = dados.GetInt32("id_produto");
                p.quantidade = dados.GetInt32("quantidade");

                lista.Add(p);

            }

            conexao.Close();

            return lista;

        }

    }
}