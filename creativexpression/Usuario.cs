
using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace creativexpression
{
    internal class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string data_nascimento { get; set; }
        public int sexo { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string cep { get; set; }

        Conexao conexao { get; set; }

        public Usuario()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {
            string query = $"INSERT INTO usuarios (nome, data_nascimento, sexo, email, senha, cpf, telefone, cep ) VALUES ( '{nome}', '{data_nascimento}', '{sexo}', '{email}', '{senha}', '{cpf}', '{telefone}', '{cep}' );";
            conexao.ExecutaComando(query);
            Console.WriteLine("Usuario inserido com sucesso!");
        }

        public List<Usuario> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM usuarios;");

            List<Usuario> lista = new List<Usuario>();

            foreach (DataRow linha in dt.Rows)
            {
                Usuario u = new Usuario();

                u.id = int.Parse(linha["id"].ToString());
                u.nome = linha["nome"].ToString();
                u.data_nascimento = linha["data_nascimento"].ToString();
                u.sexo = int.Parse(linha["sexo"].ToString());
                u.email = linha["email"].ToString();
                u.senha = linha["senha"].ToString();
                u.cpf = linha["cpf"].ToString();
                u.telefone = linha["telefone"].ToString();
                u.cep = linha["cep"].ToString();


                lista.Add(u);

            }

            return lista;
        }



    }
}

