using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class VendaUC
    {
        private readonly HttpClient _client;

        public VendaUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Venda> ListarVenda()
        {
            return _client.GetFromJsonAsync<List<Venda>>("Venda/listar-venda").Result;
        }
        public void AdicionarVenda(Venda venda)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Venda/adicionar-venda", venda).Result;
        }
    }
}
