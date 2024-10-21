using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._2_Repository
{
    public class EnderecoRepository
    {
        private readonly string ConnectionString;
        private readonly LivroRepository _repositoryLivro;
        private readonly ClienteRepository _repositoryCliente;
        public EnderecoRepository(string connectioString)
        {
            ConnectionString = connectioString;
            _repositoryLivro = new LivroRepository(connectioString);
            _repositoryCliente = new ClienteRepository(connectioString);
        }
        public void Adicionar(Endereco Endereco)
        {
            using var endereco = new SQLiteConnection(ConnectionString);
            endereco.Insert<Endereco>(Endereco);
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

        public List<Endereco> ListarEnderecoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Endereco> list = connection.Query<Endereco>($"SELECT Id, Rua, Bairro, Numero, UsuarioId FROM Enderecos WHERE UsuarioId = {usuarioId}").ToList();
            return list;
        }


        public Endereco BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Endereco>(id);
        }
    }
}
