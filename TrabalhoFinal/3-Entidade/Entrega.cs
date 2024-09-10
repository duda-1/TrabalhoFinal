using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._3_Entidade
{
    public class Entrega
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Num_Casa { get; set; }
        public double Valor_Fret { get; set; }
        public double Valor_Total { get; set; }
    }
}
