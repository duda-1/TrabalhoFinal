using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service
{
    public class CarrinhoService
    {
        public CarrinhoRepository repository { get; set; }

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

        public List<Carrinho> Listar()
        {
            return repository.Listar();
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
