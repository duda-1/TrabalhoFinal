using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._3_Entidade;

public class Livro
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Erro esse nome esta nullo")]
    public string NomeLivro { get; set; }
    public int NumPaginas { get; set; }
    public string EditoraLivro { get; set; }
    public string NomeAutor { get; set; }

}
