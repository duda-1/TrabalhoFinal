using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;
using TrabalhoFinal._3_Entidade.DTO;
using TrabalhoFinal._3_Entidade.DTO.Carrinho;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]//Data Annotations

    public class CarrinhoController : ControllerBase
    {
        public readonly string ConnectionString;
        public readonly ICarrinhoService service;
        private readonly IMapper _mapper;

        public CarrinhoController(IMapper mapper, ICarrinhoService _service)
        {
            service = _service;
            _mapper= mapper;

        }

        /// <summary>
        /// Adicionar um novo carrinho 
        /// </summary>
        /// <param name="c"></param>
        [HttpPost("Adicionar_Carrinho")]
        public IActionResult AdicionmarCarrinho([FromBody] Carrinho c)
        {
            try
            {
                Carrinho Carrinho = _mapper.Map<Carrinho>(c);
                service.Adicionar(Carrinho);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ocorreu um erro ao adicionar Carrinho, o erro foi \n{e.Message}");
            }
        }

        /// <summary>
        /// Listar todos os carrinho 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar_Carrinho")]
        public List<CreateCarrinhoDTO> ListarCarrinho()
        {
            try
            {
               return service.Listar();
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao adicionar Carrinho, o erro foi \n{e.Message}");
            }
        }

        /// <summary>
        /// Listar o carrinho que o usuario que esta logado 
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet("listar-carrinho-do-usuario")]
        public List<ReadCarrinhoDTO> ListarCarrinhoDoUsuario([FromQuery] int usuarioId)
        {
            try
            {
                return service.ListarCarrinhoDoUsuario(usuarioId);
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao adicionar Carrinho, o erro foi \n{e.Message}");
            }
         
        }

        /// <summary>
        /// Deletar um Carrinho 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Remover_Carrinho")]
        public IActionResult RemoverCarrinho( int id)
        {
            try
            {
                service.Remover(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao adicionar Carrinho, o erro foi \n{e.Message}");
            }

        }

        /// <summary>
        /// Editar dado que esta errado
        /// </summary>
        /// <param name="c"></param>
        [HttpPut("Editar_Carrinho")]
        public IActionResult Editar_Carrinho([FromBody] Carrinho c)
        {
            try
            {
                service.Editar(c);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao adicionar Carrinho, o erro foi \n{e.Message}");
            }

        }

    }
}
