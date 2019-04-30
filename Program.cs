using System;
using Senai.Tsushi.MVC.Utils;
using Senai.Tsushi.MVC.ViewController;
using Senai.Tsushi.MVC.ViewModel;

namespace Senai.Tsushi.MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcaoDeslogado = 0;
            int opcaoLogado = 0;
            do
            {
                MenuUtil.MenuDeslogado();
                opcaoDeslogado = int.Parse(Console.ReadLine());
                switch (opcaoDeslogado)
                {
                    case 1:
                    //Cadastra Usuario
                    UsuarioViewController.CadastrarUsuario();
                    break;
                    case 2:
                    //Efetua Login
                    UsuarioViewModel usuarioRecuperado = UsuarioViewController.EfetuarLogin();
                    if (usuarioRecuperado != null)
                    {
                        System.Console.WriteLine($"Seja bem vindo {usuarioRecuperado.Nome}");
                        System.Console.WriteLine("Pressione ENTER para continuar");
                        Console.ReadLine();
                        do
                        {
                            MenuUtil.MenuLogado();
                            opcaoLogado = int.Parse(Console.ReadLine());
                            switch (opcaoLogado)
                            {
                                case 1:
                                //CADASTRAR PRODUTO
                                ProdutoViewController.CadastrarProduto();
                                break;
                                case 2:
                                //LISTAR
                                ProdutoViewController.ListarProduto();
                                break;
                                case 3:
                                //BUSCA POR ID
                                ProdutoViewController.BuscaPorId();
                                break;
                                case 0:
                                break;
                                default:
                                    System.Console.WriteLine("Digite uma opção válida");
                                break;
                            }
                            
                        } while (true);
                        
                        
                    }
                    break;
                    case 3:
                    //Listar
                    UsuarioViewController.ListarUsuario();
                    break;
                    case 0:
                    //Sair
                    break;
                    default:
                        System.Console.WriteLine("Opção Inválida");
                    break;
                }
                
                
            } while (opcaoDeslogado != 0);
        }
    }
}
