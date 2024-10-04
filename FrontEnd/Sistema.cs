using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class Sistema
    {
        private static Cliente ClienteLogado { get; set; }
        public readonly ClienteUC _clienteUC;
        public Sistema(HttpClient client)
        {
            _clienteUC= new ClienteUC(client);  
        }

        public void InicializarSistema()
        {
            int resposta = -1;
            while (resposta != 0)
            {
               if(resposta == 1)
                {

                }
              

            }
        }

        public int ExibirLogin()
        {
            Console.WriteLine("--------- LOGIN ---------");
            Console.WriteLine("1 - Deseja Fazer Login");
            Console.WriteLine("2 - Deseja se Cadastrar");
            Console.WriteLine("3 - Listar Usuario Cadastrados");
            return int.Parse(Console.ReadLine());
        }

        public Cliente CriarCliente()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("Digite seu nome: ");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Digite seu username: ");
            cliente.UsuarioName = Console.ReadLine();

            Console.WriteLine("Qual sua idade: ");
            cliente.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite seu email: ");
            cliente.Email = Console.ReadLine();

            Console.WriteLine("Digite seu senha: ");
            cliente.Senha = Console.ReadLine();   

            return cliente;
        }
        public void FazerLogin()
        {
            Console.WriteLine("Digite seu username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
           ClienteLoginDTO usuDTO = new ClienteLoginDTO
           {
                UserName = username,
                Senha = senha
            };
            Cliente usuario = _clienteUC.FazerLogin(usuDTO);
            if (usuario == null)
            {
                Console.WriteLine("Usuário ou senha inválidos!!!");
            }

           ClienteLogado = usuario;
        }
    }
}
