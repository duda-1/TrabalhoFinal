using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service.Interface
{
    public interface IVendaService
    {
        void AdicionarVenda(Venda venda);
        void EditarVenda(Venda venda);
        List<Venda> ListarVenda();
        void ExcluirVenda(int id);
    }
}
