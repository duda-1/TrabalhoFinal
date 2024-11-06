using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._2_Repository
{
    public  class VendaRepository : IVendaRepository
    {
        private readonly string ConnectionString;
        private readonly ILivroRepository _repositoryProduto;
        private readonly IClienteRepository _repositoryUsuario;
        public VendaRepository(IConfiguration config, ILivroRepository repositoryProduto, IClienteRepository repositoryUsuario)
        {
            ConnectionString = config.GetConnectionString("DefaultConnection");
            _repositoryProduto = repositoryProduto;
            _repositoryUsuario = repositoryUsuario;
        }

        public void AdicionarVenda(Venda venda)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Venda>(venda);
        }

        public void EditarVenda(Venda venda)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Venda>(venda);
        }

        public List<Venda> ListarVenda()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Venda> list = connection.GetAll<Venda>().ToList();
            return list;
        }

        public void ExcluirVenda(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Venda venda = BuscarPorId(id);
            connection.Delete<Venda>(venda);
        }

        public Venda BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Venda>(id);
        }
    }
}
