using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Venda
    {
        public int id { get; set; }
        public double ValotFret { get; set; }
        public double ValorTotal { get; set; }
        public int FormaPagamento { get; set; }
        public int UsuarioNameId { get; set; }
        public int CarrinhoId { get; set; }
        public override string ToString()
        {
            return $"Id: {id} - Valo do Fret: {ValotFret} - Valor Total: {ValorTotal} - Forma de Pagamento: {FormaPagamento}" +
                   $"Usuario: {UsuarioNameId} - Carrinho: {CarrinhoId} ";
        }
    }
}
