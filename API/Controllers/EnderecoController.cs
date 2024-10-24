using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller    
    {
        private readonly EnderecoService _service;
        private readonly IMapper _mapper;

        public EnderecoController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new EnderecoService(_config);
            _mapper = mapper;
        }

        [HttpPost("adicionar-endereco")]
        public Endereco AdicionarEndereco([FromBody] Endereco carrinhoDTO)
        {
            Endereco carrinho = _mapper.Map<Endereco>(carrinhoDTO);
            _service.Adicionar(carrinho);
            return carrinho;
        }

        [HttpGet("listar-endereco")]
        public List<Endereco> ListarEndereco()
        {
            return _service.Listar();
        }

        [HttpGet("listar-endereco-usuario")]
        public List<Endereco> ListarEnderecoUsuario([FromBody] int usuarioId)
        {
            return _service.ListarEnderecoUsuario(usuarioId);
        }

        [HttpPut("editar-endereco")]
        public void EditarEndereco([FromBody] Endereco c)
        {
            _service.Editar(c);
        }

        [HttpDelete("deletar-endereco")]
        public void DeletarEndereco([FromBody] int id)
        {
            _service.Remover(id);
        }
    }
}
