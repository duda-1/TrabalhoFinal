using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._3_Entidade;
using TrabalhoFinal._3_Entidade.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]//Data Annotations

    public class CarrinhoController : ControllerBase
    {
        public readonly string ConnectionString;
        public CarrinhoService service { get; set; }
        private readonly IMapper _mapper;

        public CarrinhoController(IMapper mapper,IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
            service = new CarrinhoService(ConnectionString);
            _mapper= mapper;

        }

        [HttpPost("Adicionar_Carrinho")]
        public void AdicionmarCarrinho([FromQuery] CreateCarrinhoDTO c)
        {
            Carrinho Carrinho = _mapper.Map<Carrinho>(c);
            service.Adicionar(Carrinho);
        }


        [HttpGet("Listar_Carrinho")]
        public List<Carrinho> ListarCarrinho()
        {
            return service.Listar();
        }

        [HttpDelete("Remover_Carrinho")]
        public void RemoverCarrinho(int id)
        {
            service.Remover(id);
        }

        [HttpPut("Editar_Carrinho")]
        public void Editar_Carrinho([FromQuery] Carrinho c)
        {
            service.Editar(c);
        }
    }
}
