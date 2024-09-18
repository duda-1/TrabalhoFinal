using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;
using TrabalhoFinal._3_Entidade.DTO;

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
           // mexer no listar
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Carrinho>().ToList();

            //using var connection = new SQLiteConnection(ConnectionString);
            //List<Carrinho> carrinho = connection.GetAll<Carrinho>().ToList();
            //List<CreateCarrinhoDTO> carrinhoDTO = new List<CreateCarrinhoDTO>();//_mapper.Map<List<ReadRotinaDTO>>(lista);
            //foreach (Carrinho c in carrinho)
            //{
            //    CreateCarrinhoDTO carrinhoDTO = new CreateCarrinhoDTO();
            //    carrinhoDTO.ClienteId= c.ClienteId;
            //    carrinhoDTO.LivroId= c.LivroId;
            //    carrinhoDTO.Dia = _repositoryDia.BuscarPorID(r.DiaId);
            //    carrinhoDTO.PessoaId = r.PessoaId;
            //    carrinhoDTO.Pessoa = _repositoryPessoa.BuscarPorId(r.PessoaId);
            //    carrinhoDTO.Atividade = _repositoryAtividade.BuscarPorId(r.AtividadeId);
            //    carrinhoDTO.Add(carrinhoDTO);
            //}
            //return carrinhoDTO;
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
