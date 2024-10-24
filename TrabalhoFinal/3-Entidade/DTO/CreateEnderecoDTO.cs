using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._3_Entidade.DTO
{
    public class CreateEnderecoDTO
    {
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Num { get; set; }
        public int ClienteId { get; set; }
    }
}
