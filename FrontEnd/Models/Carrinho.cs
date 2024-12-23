﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }

        public Livro livro { get; set; }    

        public override string ToString()
        {
            return $"Id: {Id} - Nome Cliente: {UsuarioId} - Livro: {LivroId} - Preco: {livro.Preco}  ";
        }
    }
}
