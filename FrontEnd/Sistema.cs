using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd;

public class Sistema
{
    private static Cliente ClienteLogado { get; set; }
    public readonly ClienteUC _clienteUC;
    public readonly LivroUC _livroUC;
    public readonly CarrinhoUC _CarrinhoUC;
    public readonly EnderecoUC _enderecoUC;
    public readonly VendaUC _venda;

    public Sistema(HttpClient client)
    {
        _clienteUC = new ClienteUC(client);
        _livroUC = new LivroUC(client);
        _CarrinhoUC = new CarrinhoUC(client);
        _enderecoUC = new EnderecoUC(client);
        _venda = new VendaUC(client);
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
                    List<Livro> livro = _livroUC.ListarLivro();
                    foreach (Livro l in livro)
                    {
                        Console.WriteLine(l.ToString());
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
        Console.WriteLine("1 - Listar Livros");//Alterar
        Console.WriteLine("2 - Realizar uma compra");
        Console.WriteLine("Qual opição de seja realizar??");
        return int.Parse(Console.ReadLine());
    }

    public Carrinho CriarCarrinho()
    {
        Livro l = new Livro();
        Carrinho carrinho = new Carrinho();
        Console.WriteLine("Id do Produto: ");
        int id = int.Parse(Console.ReadLine());
        carrinho.LivroId = id;
        carrinho.ClienteId = ClienteLogado.Id;
        Carrinho carrinho1 = new Carrinho();
        Console.WriteLine("Ok,  deu serto!!");
        return carrinho;
    }

    public void RealizarCompra()
    {
        int acao = 1;
        while (acao != 0)
        {

            if (acao == 1)
            {

                List<Livro> livro = _livroUC.ListarLivro();
                foreach (Livro l in livro)
                {
                    Console.WriteLine(l.ToString());
                }
                Carrinho c = CriarCarrinho();
                _CarrinhoUC.CadastrarCarrinho(c);

                Console.WriteLine($"1- Deseja escolher mais produto" +
                                  $"\n2- Finalizar Pedido");
                acao = int.Parse(Console.ReadLine());

            }
            else
            {
                List<ReadCarrinhoDTO> carrinhosDTO = _CarrinhoUC.ListarCarrinhoUsuarioLogado(ClienteLogado.Id);
                foreach (ReadCarrinhoDTO car in carrinhosDTO)
                {
                    Console.WriteLine(car.ToString());
                }

                RealizarEntrega();

            }

        }
    }
    // Livro e Carrinho Fim

    //Entega começo
    public Endereco CriarEndereco()
    {
        Endereco endereco = new Endereco();
        Console.WriteLine("Qual sua Cidade: ");
        endereco.Cidade = Console.ReadLine();

        Console.WriteLine("Qual sua Rua: ");
        endereco.Rua = Console.ReadLine();

        Console.WriteLine("Qual o Bairro: ");
        endereco.Bairro = Console.ReadLine();

        Console.WriteLine("Qual o Numero: ");
        endereco.Num = int.Parse(Console.ReadLine());
        endereco.ClienteId = ClienteLogado.Id;

        return endereco;
    }

    private void RealizarEntrega()
    {
        int idEndereco = 0;
        Console.WriteLine("Escolha uma opção: \n 1- Retirar na loja " +
                                             "\n 2- Entregar a domicilio");
        int alternativa = int.Parse(Console.ReadLine());
        if (alternativa == 1)
        {
            Console.WriteLine("Retire a sua compra na loja em 7 dias.");
        }
        else if (alternativa == 2)
        {
            Console.WriteLine("Escolha as opção: \n 1 - Listar Enderecos cadastrados" +
                                                "\n 2 - Cadastrar endereço");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                List<Endereco> enderecos = _enderecoUC.ListarEnderecosDoUsuario(ClienteLogado.Id);
                foreach (Endereco end in enderecos)
                {
                    Console.WriteLine(end.ToString());
                }
                Console.WriteLine("Digite qual endereco deseja entregar");

                idEndereco = int.Parse(Console.ReadLine());


                Console.WriteLine($"Deseja Finalizar esta Compra? " +
                                  $"\n1-Sim" +
                                  $"\n2-Não");
                int a = int.Parse(Console.ReadLine());
                if (a == 1)
                {
                    _CarrinhoUC.SomarCompra(ClienteLogado.Id);
                }
            }
            else
            {
                Endereco endereco = CriarEndereco();
                _enderecoUC.CadastrarEndereco(endereco);
                idEndereco = endereco.Id;
            }
        }
    }
    //Fim da Entega

   //public double NotaFiscalVenda()
   //{
   //    //double valor = 0;
   //    //List<ReadCarrinhoDTO> carrinhosDTO = _CarrinhoUC.ListarCarrinhoUsuarioLogado(ClienteLogado.Id);
   //    //foreach (ReadCarrinhoDTO car in carrinhosDTO)
   //    //{
   //    //    valor += car.Livro.Preco;
   //    //}
   //    //return valor;
   //}
}
