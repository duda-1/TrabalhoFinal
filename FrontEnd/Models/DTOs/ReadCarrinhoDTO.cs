using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models.DTOs
{
    public class ReadCarrinhoDTO
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }

        public override string ToString()
        {
            if (Cliente == null || Livro == null)
            {
                return $"Codigo com Erro Produto ou Usuario Vazio!!! Confira no Banco";
            }
            return $"Usuario {Cliente.Nome} - Produto : {Livro.NomeLivro} - Preço: {Livro.Preco}";
        }
    }
}
