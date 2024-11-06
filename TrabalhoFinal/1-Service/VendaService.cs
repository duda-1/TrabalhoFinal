using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._1_Service.Interface;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service
{
    public class VendaService : IVendaService
    {
        public readonly IVendaRepository repository;

        public VendaService(IVendaRepository _repository)
        {
            repository = _repository;
        }


        public void AdicionarVenda(Venda venda)
        {
            repository.AdicionarVenda(venda);
        }

        public void EditarVenda(Venda venda)
        {
            repository.EditarVenda(venda);
        }

        public List<Venda> ListarVenda()
        {
            return repository.ListarVenda();
        }

        public void ExcluirVenda(int id)
        {
            repository.ExcluirVenda(id);
        }

        public Venda BuscarVendaPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
    }
}
