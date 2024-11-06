using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class CarrinhoUC
    {
        private readonly HttpClient _client;
        public CarrinhoUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Carrinho> ListarCarrinho()
        {
            return _client.GetFromJsonAsync<List<Carrinho>>("Carrinho/Listar_Carrinho").Result;
        }
        public void CadastrarCarrinho(Carrinho carrinho)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Carrinho/Adicionar_Carrinho", carrinho).Result;
        }

        public  List<ReadCarrinhoDTO> ListarCarrinhoUsuarioLogado(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<ReadCarrinhoDTO>>("Carrinho/listar-carrinho-do-usuario?usuarioId=" + usuarioId).Result;
        }
        public double SomarCompra(int UsuarioId)
        {
            List<ReadCarrinhoDTO> carrinho = ListarCarrinhoUsuarioLogado(UsuarioId);
            double total = 0;
            foreach (var ca in carrinho)
            {
                total += ca.Livro.Preco+15;
            }
            return total;
        }
    }
}
