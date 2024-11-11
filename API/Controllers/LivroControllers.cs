using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._1_Service.DTO;
using TrabalhoFinal._1_Service.Interface;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]//Data Annotations
public class LivroControllers : ControllerBase
{
    public readonly string connectionString;
    public readonly ILivroService service;
    private readonly IMapper _mapper;

    public LivroControllers(IMapper mapper, ILivroService _service) 
    {
        service = _service;
        _mapper = mapper;
    }

    /// <summary>
    /// Adicionar livro ao banco de dados
    /// </summary>
    /// <param name="l"></param>
    [HttpPost("Adicionar_Livro")]
    public IActionResult AdicionmarLivro([FromBody] CreateLivroDTO l)
    {
        try
        {
            Livro livro = _mapper.Map<Livro>(l);
            service.Adicionar(livro);
            return Ok();
        }
        catch (Exception e)
        {

            return BadRequest($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
        }
    }

    /// <summary>
    /// Listar todos os livros disponiveis do banco
    /// </summary>
    /// <returns></returns>
    [HttpGet("Listar_Livro")]
    public List<Livro> ListarTime()
    {
        try
        {
            return service.Listar();
        }
        catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
        }

    }

    /// <summary>
    /// Excluir um livro do Banco de dados
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("Remover_Livro")]
    public IActionResult RemoverLivro( int id)
    {
        try
        {
            service.Remover(id);
            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
        }
    }

    /// <summary>
    /// Editar dado que esta errado
    /// </summary>
    /// <param name="livro"></param>
    [HttpPut("Editar_Livro")]
    public IActionResult Editar_Livro([FromBody] Livro livro)
    {
        try
        {
            service.Editar(livro);
            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
        }
    }
}
