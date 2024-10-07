using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class LivroUC
    {
        private readonly HttpClient _client;
        public LivroUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Livro> ListarLivro()
        {
            return _client.GetFromJsonAsync<List<Livro>>("LivroControllers/Listar_Livro").Result;
        }
        public void CadastrarLivro(Livro livro)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("LivroControllers/Adicionar_Livro", livro).Result;
        }
    }
}
