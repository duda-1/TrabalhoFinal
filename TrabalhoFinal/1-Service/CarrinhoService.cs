using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;
using TrabalhoFinal._3_Entidade.DTO;
using TrabalhoFinal._3_Entidade.DTO.Carrinho;

namespace TrabalhoFinal._1_Service
{
    public class CarrinhoService : ICarrinhoService
    {
        public readonly ICarrinhoRepository repository;

        public CarrinhoService(string coonn)
        {
            repository = new CarrinhoRepository(coonn);
        }

        public void Adicionar(Carrinho c)
        {
            repository.Adicionar(c);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<CreateCarrinhoDTO> Listar()
        {
            return repository.Listar();
        }

        public List<ReadCarrinhoDTO> ListarCarrinhoDoUsuario(int usuarioId)
        {
            return repository.ListarCarrinhoDoUsuario(usuarioId);
        }

        public void Editar(Carrinho c)
        {
            repository.Editar(c);
        }

        public Carrinho BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
    }
}
