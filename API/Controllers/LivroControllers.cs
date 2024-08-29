﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroControllers : ControllerBase
{
    public LivroService service { get; set; }
    public LivroControllers() 
    {
        service = new LivroService();
    }

    [HttpPost("Adicionar_Livro")]
    public void AdicionmarLivro([FromQuery] Livros v)
    {
        service.Adicionar(v);
    }


    [HttpGet("Listar_Livro")]
    public void GetListarTime()
    {
        
    }

    [HttpDelete("Remover_Livro")]
    public void RemoverLivro()
    {
        
    }

    [HttpPut("Editar_Livro")]
    public void Editar_Livro()
    {
       
    }
}