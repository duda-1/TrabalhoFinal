using FrontEnd.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._2_Repository.Interface
{
    public interface IClienteService
    {
        void Adicionar(Cliente c);
        void Remover(int id);
        List<Cliente> Listar();
        void Editar(Cliente c);
        Cliente BuscarPorId(int id);
        Cliente FazerLogin(ClienteLoginDTO usuarioLogin);
    }
}
