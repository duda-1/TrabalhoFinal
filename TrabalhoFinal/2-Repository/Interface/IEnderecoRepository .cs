using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._2_Repository.Interface
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco e);
        void Remover(int id);
        void Editar(Endereco Endereco);
        List<Endereco> Listar();
        List<Endereco> ListarEnderecoUsuario(int clienteId);
        Endereco BuscarPorId(int id);
    }
}
