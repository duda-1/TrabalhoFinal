using Dapper;
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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string ConnectionString;
        private readonly ILivroRepository _repositoryLivro;
        private readonly IClienteRepository _repositoryCliente;
        public EnderecoRepository(IConfiguration config, ILivroRepository repositoryLivro, IClienteRepository repositoryCliente)
        {
            ConnectionString = config.GetConnectionString("DefaultConnection");
            _repositoryLivro = repositoryLivro;
            _repositoryCliente = repositoryCliente;
        }

        public void Adicionar(Endereco e)
        {
            using var endereco = new SQLiteConnection(ConnectionString);
            endereco.Insert<Endereco>(e);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Endereco Endereco = BuscarPorId(id);
            connection.Delete<Endereco>(Endereco);
        }
        public void Editar(Endereco Endereco)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Endereco>(Endereco);
        }
        public List<Endereco> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Endereco> list = connection.GetAll<Endereco>().ToList();
            return list;
        }

        public List<Endereco> ListarEnderecoUsuario(int clienteId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Endereco> list = connection.Query<Endereco>($"SELECT Id,Cidade, Rua, Bairro, Num, ClienteId FROM Enderecos WHERE ClienteId = {clienteId}").ToList();
            return list;
        }


        public Endereco BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Endereco>(id);
        }
    }
}
