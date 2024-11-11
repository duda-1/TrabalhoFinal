using AutoMapper;
using FrontEnd.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._1_Service;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]//Data Annotations

    public class ClienteController : ControllerBase
    {
        public readonly string ConnectionString;
        public readonly IClienteService service;
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper, IClienteService _service)
        {
            service = _service;
            _mapper = mapper;

        }

        /// <summary>
        /// Adicionar um novo Cliente ao Banco
        /// </summary>
        /// <param name="c"></param>
        [HttpPost("Adicionar_Cliente")]
        public IActionResult AdicionmarCliente([FromBody] CreateClienteDTO c)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(c);
                service.Adicionar(cliente);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
            }
        }

        /// <summary>
        /// Um Cliente que já e cadastrado fazer login em sua conta
        /// </summary>
        /// <param name="clienteLogin"></param>
        /// <returns></returns>
        [HttpPost("fazer-login")]
        public Cliente FazerLogin([FromBody] ClienteLoginDTO clienteLogin)
        {
            try
            {
                Cliente cliente = service.FazerLogin(clienteLogin);
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
            }
            
        }

        /// <summary>
        /// Listar todos os Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar_Cliente")]
        public List<Cliente> ListarCliente()
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
        /// Deletar um Cliente
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Remover_Cliente")]
        public IActionResult RemoverCliente( int id)
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
        /// <param name="c"></param>
        [HttpPut("Editar_Cliente")]
        public IActionResult Editar_Cliente([FromBody] Cliente c)
        {
            try
            {
                service.Editar(c);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao adicionar Usuario, o erro foi \n{e.Message}");
            }
        }
    }
}
