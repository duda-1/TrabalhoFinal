using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._2_Repository
{
    public class CarrinhoRepository
    {
        private readonly string ConnectionString;
        public CarrinhoRepository(string s)
        {
            ConnectionString = s;
        }

        public void Adicionar(Carrinho c)
        {
            using var connnection = new SQLiteConnection(ConnectionString);
            connnection.Insert<Carrinho>(c);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Carrinho novoCarrinho = BuscarPorId(id);
            connection.Delete<Carrinho>(novoCarrinho);
        }

        public List<Carrinho> Listar()
        {
            //mexer no listar
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Carrinho>().ToList();
        }

        public void Editar(Carrinho c)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Carrinho>(c);
        }

        public Carrinho BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Carrinho>(id);
        }
    }
}
