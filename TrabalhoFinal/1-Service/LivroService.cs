﻿using System;
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

       public LivroService(string l)
        {
            repository= new LivroRepository(l);
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
