using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service
{
    public  class LivroService
    {
        public LivroRepository repository { get; set; }
        public void Adicionar(Livros v)
        {
            repository.Adicionar(v);
        }

        public void Remover()
        {
            repository.Remover();
        }

        public void Listar()
        {
            repository.Listar();
        }

        public void Editar()
        {
            repository.Editar();
        }

        public void BuscarPorId()
        {

        }
    }
}
