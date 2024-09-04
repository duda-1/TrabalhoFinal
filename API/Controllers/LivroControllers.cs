using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]//Data Annotations
public class LivroControllers : ControllerBase
{
    public readonly string _connectionString;
    public LivroService service { get; set; }

    public LivroControllers(IConfiguration configuration) 
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        service = new LivroService();
    }

    [HttpPost("Adicionar_Livro")]
    public void AdicionmarLivro([FromQuery] Livros v)
    {
        service.Adicionar(v);
    }


    [HttpGet("Listar_Livro")]
    public List<Livros> ListarTime()
    {
       return service.Listar();
    }

    [HttpDelete("Remover_Livro")]
    public void RemoverLivro(int id)
    {
        service.Remover(id);
    }

    [HttpPut("Editar_Livro")]
    public void Editar_Livro([FromQuery] int id, Livros livro)
    {
       service.Editar(id, livro);
    }
}
