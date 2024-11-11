using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase    
    {
        public readonly  IEnderecoService _service;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Adicionar um novo Endereço no Banco 
        /// </summary>
        /// <param name="carrinhoDTO"></param>
        /// <returns></returns>
        [HttpPost("adicionar-endereco")]
        public Endereco AdicionarEndereco([FromBody] Endereco carrinhoDTO)
        {
            try
            {
                Endereco carrinho = _mapper.Map<Endereco>(carrinhoDTO);
                _service.Adicionar(carrinho);
                return carrinho;
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
            }
           
        }

        /// <summary>
        /// Listar todos os Endereços sem estar logado
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar-endereco")]
        public List<Endereco> ListarEndereco()
        {
            try
            {
                return _service.Listar();
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
            }

        }

        /// <summary>
        /// Listar o Endereço do Usuário que esta logado
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet("listar-endereco-usuario")]
        public List<Endereco> ListarEnderecoUsuario([FromBody] int usuarioId)
        {
            try
            {
                return _service.ListarEnderecoUsuario(usuarioId);
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
            }

        }

        /// <summary>
        /// Editar dado que esta errado
        /// </summary>
        /// <param name="c"></param>
        [HttpPut("editar-endereco")]
        public IActionResult EditarEndereco([FromBody] Endereco c)
        {
            try
            {
                _service.Editar(c);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
            }
        }

        /// <summary>
        /// Deletar um endereço
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("deletar-endereco")]
        public IActionResult DeletarEndereco([FromBody] int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
            }
        }
    }
}
