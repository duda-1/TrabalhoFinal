using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._1_Service.Interface;
using TrabalhoFinal._2_Repository;
using TrabalhoFinal._2_Repository.Data;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service
{
    public  class LivroService : ILivroService
    {
        public readonly ILivroRepository repository;

       public LivroService(ILivroRepository _repository)
        {
            repository= _repository;
        }

        public void Adicionar(Livro l)
        {
            repository.Adicionar(l);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Livro> Listar()
        {
           return repository.Listar();
        }

        public void Editar(Livro l)
        {
            repository.Editar(l);
        }

        public Livro BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
    }
}
