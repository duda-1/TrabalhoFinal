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
        public readonly LivroUC _livroUC;
        public Sistema(HttpClient client)
        {
            _clienteUC= new ClienteUC(client);  
        }

        public void InicializarSistema()
        {
            int resposta = -1;
            while (resposta != 0)
            {
                if (ClienteLogado == null)
                {
                    resposta = ExibirLogin();
                    if (resposta == 1)
                    {
                        FazerLogin();
                    }
                    else if (resposta == 2)
                    {
                        Cliente cliente = CriarCliente();
                        _clienteUC.CadastrarCliente(cliente);
                        Console.WriteLine("Usuário cadastrado com sucesso");
                    }
                    else if (resposta == 3)
                    {
                        List<Cliente> cliente = _clienteUC.ListarCliente();
                        foreach (Cliente cli in cliente)
                        {
                            Console.WriteLine(cli.ToString());
                        }
                    }
                }

                else 
                    {
                        resposta = ExibirMenuPrincipalCliente();
                        if (resposta == 1)
                        {
                            List<Livro> produto = _livroUC.ListarLivro();
                            foreach (Livro p in produto)
                            {
                                Console.WriteLine(p.ToString());
                            }
                        }
                        else if (resposta == 2)
                        {
                            RealizarCompra();
                        }
                    }
                

            }
        }

        // Login Cliente Inicio
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

            Console.WriteLine("Digite seu UserName: ");
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
            string usuarioName = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
           ClienteLoginDTO usuDTO = new ClienteLoginDTO
           {
                UsuarioName = usuarioName,
                Senha = senha
            };
            Cliente cliente = _clienteUC.FazerLogin(usuDTO);
            if (cliente == null)
            {
                Console.WriteLine("Usuário ou senha inválidos!!!");
            }

           ClienteLogado = cliente;
        }
        // Login Cliente Fim


        // Livro e Carrinho Inicio
        public int ExibirMenuPrincipalCliente()
        {
            Console.WriteLine("------------------Produto------------------");
            Console.WriteLine("1 - Listar Livros");
            Console.WriteLine("2 - Realizar uma compra");
            Console.WriteLine("Qual opição de seja realizar??");
            return int.Parse(Console.ReadLine());
        }

        public void RealizarCompra()
        {

        }


        // Livro e Carrinho Fim
    }
}
