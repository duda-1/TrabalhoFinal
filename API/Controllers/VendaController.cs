using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._1_Service.Interface;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _service;
        private readonly IMapper _mapper;
        public VendaController(IVendaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("adicionar-venda")]
        public void AdicionarVenda(Venda v)
        {
         
        }

        [HttpGet("listar-venda")]
        public List<Venda> ListarVenda()
        {
            return null;
        }

        [HttpPut("editar-venda")]
        public void EditarVenda()
        {
           
        }

        [HttpDelete("deletar-venda")]
        public void DeletarVenda()
        {
            
        }
    }
}
