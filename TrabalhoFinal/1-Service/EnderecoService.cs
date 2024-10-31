using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service
{
    public class EnderecoService :IEnderecoService
    {
        public readonly IEnderecoRepository repository;
        public EnderecoService(IEnderecoRepository _repository)
        {
            repository = _repository;
        }

        public void Adicionar(Endereco Endereco)
        {
            repository.Adicionar(Endereco);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Endereco> Listar()
        {
            return repository.Listar();
        }

        public List<Endereco> ListarEnderecoUsuario(int usuarioId)
        {
            return repository.ListarEnderecoUsuario(usuarioId);
        }

        public Endereco BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Endereco editPessoa)
        {
            repository.Editar(editPessoa);
        }
    }
}
