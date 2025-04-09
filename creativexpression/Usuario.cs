using Java.Sql;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace creativexpression
{
    internal class Usuario
    {
        public int id { get; }
        public string nome { get; set; }
        public string data_nascimento { get; set; }
        public int sexo { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string cep { get; set; }

    }
}
