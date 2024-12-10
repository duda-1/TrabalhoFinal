using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Nome Cliente: {ClienteId} - Livro: {LivroId} - Preco: {PrecoId}  ";
        }
    }
}
