using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service
{
    public class ClienteService
    {
        public ClienteRepository repository { get; set; }

        public ClienteService(string coonn)
        {
            repository = new ClienteRepository(coonn);
        }
        public void Adicionar(Cliente c)
        {
            repository.Adicionar(c);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Cliente> Listar()
        {
            return repository.Listar();
        }

        public void Editar(Cliente c)
        {
            repository.Editar(c);
        }

        public Cliente BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
    }
}
