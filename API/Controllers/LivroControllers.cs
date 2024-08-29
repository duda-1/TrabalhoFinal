using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroControllers : ControllerBase
{
    public LivroControllers() { }

    [HttpPost("Adicionar_Livro")]
    public void AdicionmarLivro()
    {
      
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
