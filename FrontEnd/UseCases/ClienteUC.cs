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
    public class ClienteUC
    {
        private readonly HttpClient _client;
        public ClienteUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Cliente> ListarCliente()
        {
            return _client.GetFromJsonAsync<List<Cliente>>("Cliente/Listar_Cliente").Result;
        }
        public void CadastrarCliente(Cliente cliente)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Cliente/Adicionar_Cliente", cliente).Result;        
        }
        public Cliente FazerLogin(ClienteLoginDTO clienteLogin)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Cliente/fazer-login", clienteLogin).Result;
            Cliente cliente = response.Content.ReadFromJsonAsync<Cliente>().Result;
            return cliente;
        }
    }
}
