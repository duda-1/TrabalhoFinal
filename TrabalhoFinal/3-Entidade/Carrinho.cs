using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._3_Entidade
{
    public class Carrinho
    {
        public  int Id { get; set; }
        public int UsuarioId { get; set; }  
        public int LivroId { get; set; }
        public int PrecoId { get; set; }   
    }
}
