using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository;
using TrabalhoFinal._2_Repository.Data;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service
{
    public  class LivroService
    {
        public LivroRepository repository { get; set; }

       public LivroService()
        {
            repository= new LivroRepository();
        }
        public void Adicionar(Livros v)
        {
            repository.Adicionar(v);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Livros> Listar()
        {
           return repository.Listar();
        }

        public void Editar(int id, Livros l)
        {
            repository.Editar(id, l.NomeLivro, l.NumPaginas , l.EditoraLivro, l.NomeAutor);
        }

        public void BuscarPorId()
        {

        }
    }
}
