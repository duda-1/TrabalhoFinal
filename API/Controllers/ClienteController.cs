using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]//Data Annotations

    public class ClienteController : ControllerBase
    {
        public readonly string ConnectionString;
        public ClienteService service { get; set; }

        public ClienteController(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
            service = new ClienteService(ConnectionString);
        }

        [HttpPost("Adicionar_Cliente")]
        public void AdicionmarCliente([FromQuery] Cliente c)
        {
            service.Adicionar(c);
        }


        [HttpGet("Listar_Cliente")]
        public List<Cliente> ListarCliente()
        {
            return service.Listar();
        }

        [HttpDelete("Remover_Cliente")]
        public void RemoverCliente(int id)
        {
            service.Remover(id);
        }

        [HttpPut("Editar_Cliente")]
        public void Editar_Cliente([FromQuery] Cliente c)
        {
            service.Editar(c);
        }
    }
}
