using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._1_Service.DTO;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]//Data Annotations
public class LivroControllers : ControllerBase
{
    public readonly string _connectionString;
    public LivroService service { get; set; }
    private readonly IMapper _mapper;

    public LivroControllers(IMapper mapper, IConfiguration configuration) 
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        service = new LivroService(_connectionString);
        _mapper = mapper;
    }

    [HttpPost("Adicionar_Livro")]
    public void AdicionmarLivro([FromBody] CreateLivroDTO l)
    {
        Livro livro = _mapper.Map<Livro>(l);
        service.Adicionar(livro);
    }


    [HttpGet("Listar_Livro")]
    public List<Livro> ListarTime()
    {
       return service.Listar();
    }

    [HttpDelete("Remover_Livro")]
    public void RemoverLivro([FromBody] int id)
    {
        service.Remover(id);
    }

    [HttpPut("Editar_Livro")]
    public void Editar_Livro([FromBody] Livro livro)
    {
       service.Editar(livro);
    }
}
