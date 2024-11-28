using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._2_Repository.Interface
{
    public interface IEnderecoService
    {
        void Adicionar(Endereco Endereco);
        void Remover(int id);
        List<Endereco> Listar();
        List<Endereco> ListarEnderecoUsuario(int clienteId);
        Endereco BuscarTimePorId(int id);
        void Editar(Endereco editPessoa);
    }
}
