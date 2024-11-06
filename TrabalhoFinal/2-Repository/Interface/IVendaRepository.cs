using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._2_Repository.Interface
{
    public interface IVendaRepository
    {
        void AdicionarVenda(Venda venda);
        void EditarVenda(Venda venda);
        List<Venda> ListarVenda();
        void ExcluirVenda(int id);
        Venda BuscarPorId(int id);
    }
}
