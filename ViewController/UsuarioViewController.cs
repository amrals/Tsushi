using System;
using System.Collections.Generic;
using Senai.Tsushi.MVC.Repositorio;
using Senai.Tsushi.MVC.Utils;
using Senai.Tsushi.MVC.ViewModel;

namespace Senai.Tsushi.MVC.ViewController
{
    public class UsuarioViewController
    {
        static UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        public static void CadastrarUsuario ()
        {
            string nome, email, senha, confirmaSenha;
            do
            {
                System.Console.WriteLine("Digite o nome do usuário");
                nome = Console.ReadLine();
                if(string.IsNullOrEmpty(nome))
                {
                    System.Console.WriteLine("Nome inválido");
                }
            } while (string.IsNullOrEmpty(nome));

            do
            {
                System.Console.WriteLine("Digite o E-mail do usuário");
                email = Console.ReadLine();
                
                if (!ValidacaoUtil.ValidarEmail(email))
                {
                    System.Console.WriteLine("Email inválido, o email deve conter @ e .");
                }
                
            } while (!ValidacaoUtil.ValidarEmail(email));

            do
            {
                System.Console.WriteLine("Digite a senha do usuário");
                senha = Console.ReadLine();
                
                System.Console.WriteLine("Confirme a senha");
                confirmaSenha = Console.ReadLine();
                
                if (!ValidacaoUtil.ConfirmacaoSenha(senha,confirmaSenha))
                {
                    System.Console.WriteLine("As senhas não são iguais");
                }
            } while (!ValidacaoUtil.ConfirmacaoSenha(senha,confirmaSenha));

            //Cria um objeto do tipo usuário
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Nome = nome;
            usuarioViewModel.Email = email;
            usuarioViewModel.Senha = senha;

            //Ter um metodo para inserir o bnco de dados
            usuarioRepositorio.Inserir(usuarioViewModel);
            System.Console.WriteLine("Cadastro efetuado com sucesso");
        }//fim cadastrarusuario

        public static void ListarUsuario()
        {
            List<UsuarioViewModel> listaDeUsuarios = usuarioRepositorio.Listar();
            foreach (var item in listaDeUsuarios)
            {
                System.Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Email: {item.Email} - Senha: {item.Senha} - Data: {item.Data}");
            }
        }
        public static UsuarioViewModel EfetuarLogin()
        {
            string email, senha;
            do
            {
                System.Console.WriteLine("Digite seu email");
                email = Console.ReadLine();
                if (!ValidacaoUtil.ValidarEmail(email))
                {
                    System.Console.WriteLine("Digite um email válido");
                }
            } while (!ValidacaoUtil.ValidarEmail(email));
            System.Console.WriteLine("Digite a senha");
            senha = Console.ReadLine();
            
            UsuarioViewModel usuarioRecuperado = usuarioRepositorio.BuscarUsuario(email, senha);
            if (usuarioRecuperado != null)
            {
                return usuarioRecuperado;
            }else
            {
                System.Console.WriteLine("E-mail ou senha inválida");
                return null;
            }
        }
    }
}