using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._3_Entidade
{
    public class Venda
    {
        public int id { get; set; }
        public double ValotFret { get; set; }
        public double ValorTotal { get; set; }
        public int FormaPagamento { get; set; } 
        public int UsuarioNameId { get; set; }    
        public int CarrinhoId { get; set; }
    }
}
