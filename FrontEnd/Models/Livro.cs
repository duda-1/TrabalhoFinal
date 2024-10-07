using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string NomeLivro { get; set; }
        public int NumPaginas { get; set; }
        public string EditoraLivro { get; set; }
        public string NomeAutor { get; set; }
        public double Preco { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Nome Livro: {NomeLivro} - Numero Paginas: {NumPaginas} - Preco: {Preco} - Nome Autor: {NomeAutor} ";
        }
    }
}
