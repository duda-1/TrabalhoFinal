using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository;

namespace TrabalhoFinal._1_Service
{
    public  class LivroService
    {
        public LivroRepository repository { get; set; }
        public void Adicionar()
        {
            repository.Adicionar();
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
