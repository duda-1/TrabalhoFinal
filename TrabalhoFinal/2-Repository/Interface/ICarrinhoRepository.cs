using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;
using TrabalhoFinal._3_Entidade.DTO;
using TrabalhoFinal._3_Entidade.DTO.Carrinho;

namespace TrabalhoFinal._2_Repository.Interface
{
    public interface ICarrinhoRepository
    {
        void Adicionar(Carrinho c);
        void Remover(int id);
        List<CreateCarrinhoDTO> Listar();
        List<ReadCarrinhoDTO> ListarCarrinhoDoUsuario(int usuarioId);
        void Editar(Carrinho c);
        Carrinho BuscarPorId(int id);
    }
}
