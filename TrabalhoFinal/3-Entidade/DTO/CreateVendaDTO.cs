using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._3_Entidade.DTO
{
    public class CreateVendaDTO
    {
        public double ValorTotal { get; set; }
        public int FormaPagamento { get; set; }
        public int UsuarioNameId { get; set; }
        public int CarrinhoId { get; set; }
    }
}
