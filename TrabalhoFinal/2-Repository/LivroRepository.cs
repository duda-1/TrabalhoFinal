using AutoMapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;
using static System.Net.Mime.MediaTypeNames;

namespace TrabalhoFinal._2_Repository
{
    public class LivroRepository : ILivroRepository
    {

        private readonly string ConnectionString;

        public LivroRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Livro l)
        {
            using var connnection = new SQLiteConnection(ConnectionString);
            connnection.Insert<Livro>(l);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Livro novoLivro = BuscarPorId(id);
            connection.Delete<Livro>(novoLivro);
        }

        public List<Livro> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Livro>().ToList();
        }

        public void Editar(Livro l)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Livro>(l);
        }

        public Livro BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Livro>(id);
        }
    }
}
