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

        /// <summary>
        ///  Adicionar uma nova venda no Banco 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [HttpPost("adicionar-venda")]
        public IActionResult AdicionarVenda(Venda v)
        {
            try
            {
                Venda venda = _mapper.Map<Venda>(v);
                _service.AdicionarVenda(venda);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ocorreu um erro ao adicionar Venda, o erro foi \n{e.Message}");
            }
        }

        /// <summary>
        /// Listar Todad as Vendas Salvas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("listar-venda")]
        public List<Venda> ListarVenda()
        {
            try
            {
                return _service.ListarVenda();
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao adicionar Venda, o erro foi \n{e.Message}");
            }

        }

        /// <summary>
        /// Editar elgum erro em uma venda
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [HttpPut("editar-venda")]
        public IActionResult EditarVenda(Venda v)
        {
            try
            {
                _service.EditarVenda(v);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest($"Ocorreu um erro ao adicionar Venda, o erro foi \n{e.Message}");
            }
        }

        /// <summary>
        /// Deletar uma Venda do Banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletar-venda")]
        public IActionResult DeletarVenda(int id)
        {
            try
            {
                _service.ExcluirVenda(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest($"Ocorreu um erro ao adicionar Venda, o erro foi \n{e.Message}");
            }
        }
    }
}
