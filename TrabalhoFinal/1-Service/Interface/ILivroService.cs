using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service.Interface
{
    public interface ILivroService
    {
        void Adicionar(Livro l);
        void Remover(int id);
        List<Livro> Listar();
        void Editar(Livro l);
        Livro BuscarPorId(int id);
    }
}
