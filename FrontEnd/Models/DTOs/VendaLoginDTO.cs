using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models.DTOs
{
    public class VendaLoginDTO
    {
        public double ValotFret { get; set; }
        public double ValorTotal { get; set; }
        public int FormaPagamento { get; set; }
        public int UsuarioNameId { get; set; }
        public int CarrinhoId { get; set; }
    }
}
