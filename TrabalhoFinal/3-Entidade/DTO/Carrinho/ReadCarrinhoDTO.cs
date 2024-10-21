using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._3_Entidade.DTO.Carrinho
{
    public class ReadCarrinhoDTO
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }
    }
}
