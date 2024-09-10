using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._3_Entidade.DTO
{
    public class CreateCadastroC_DTO
    {
        public string Nome { get; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
