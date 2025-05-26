using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace creativexpression
{
    class Conexao
    {
        
        string dadosConexao = "server=10.60.44.28;user=root;database=creative_xpression;port=3306;password=senac123;";

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


        public DataTable ExecutaSelect(string query)
        {
            //Cria e abre conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataAdapter dados = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            dados.Fill(dt);
            conexao.Close();

            return dt;
        }

       


    }
}