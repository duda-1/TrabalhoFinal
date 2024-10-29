using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;
using TrabalhoFinal._3_Entidade.DTO;
using TrabalhoFinal._3_Entidade.DTO.Carrinho;

namespace TrabalhoFinal._2_Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly string ConnectionString;
        private readonly IClienteRepository _repositoryCliente;
        private readonly ILivroRepository _repositoryLivro;

        public CarrinhoRepository(string s)
        {
            ConnectionString = s;
            _repositoryCliente = new ClienteRepository(ConnectionString);
            _repositoryLivro = new LivroRepository(ConnectionString);
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

        public List<CreateCarrinhoDTO> Listar()
        {
            // mexer no listar
            //using var connection = new SQLiteConnection(ConnectionString);
            //return connection.GetAll<Carrinho>().ToList();

            using var connection = new SQLiteConnection(ConnectionString);
            List<Carrinho> carrinho = connection.GetAll<Carrinho>().ToList();
            List<CreateCarrinhoDTO> carrinhosDTO = new List<CreateCarrinhoDTO>();//_mapper.Map<List<Read                carrinhoDTO>>(lista);
            foreach (Carrinho c in carrinho)
            {
                CreateCarrinhoDTO carrinhoDTO = new CreateCarrinhoDTO();
                carrinhoDTO.ClienteId = c.ClienteId;
                carrinhoDTO.LivroId = c.LivroId;
                carrinhosDTO.Add(carrinhoDTO);
            }
            return carrinhosDTO;
        }

        public List<ReadCarrinhoDTO> ListarCarrinhoDoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Carrinho> list = connection.Query<Carrinho>($"SELECT Id, UsuarioId, ProdutoId FROM Carrinhos WHERE UsuarioId = {usuarioId}").ToList();
            List<ReadCarrinhoDTO> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
            return listDTO;
        }
        private List<ReadCarrinhoDTO> TransformarListaCarrinhoEmCarrinhoDTO(List<Carrinho> list)
        {
            List<ReadCarrinhoDTO> listDTO = new List<ReadCarrinhoDTO>();

            foreach (Carrinho car in list)
            {
                ReadCarrinhoDTO CarrinhoDTO = new ReadCarrinhoDTO();
                CarrinhoDTO.Livro = _repositoryLivro.BuscarPorId(car.LivroId);
                CarrinhoDTO.Cliente = _repositoryCliente.BuscarPorId(car.ClienteId);
                listDTO.Add(CarrinhoDTO);
            }
            return listDTO;
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
