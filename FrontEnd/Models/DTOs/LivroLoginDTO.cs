using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models.DTOs
{
    public class LivroLoginDTO
    {
        public string NomeLivro { get; set; }
        public int NumPaginas { get; set; }
        public string EditoraLivro { get; set; }
        public string NomeAutor { get; set; }
        public double Preco { get; set; }
    }
}
