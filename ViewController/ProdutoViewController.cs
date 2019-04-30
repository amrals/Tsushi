using System;
using System.Collections.Generic;
using Senai.Tsushi.MVC.Repositorio;
using Senai.Tsushi.MVC.Utils;
using Senai.Tsushi.MVC.ViewModel;

namespace Senai.Tsushi.MVC.ViewController
{
    public class ProdutoViewController
    {
        static ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
        public static void CadastrarProduto ()
        {
            string nome, descricao, categoria;
            float preco;
            do
            {
                System.Console.WriteLine("Digite o nome do produto");
                nome = Console.ReadLine();
                if(string.IsNullOrEmpty(nome))
                {
                    System.Console.WriteLine("Nome inválido");
                }
                
            } while (string.IsNullOrEmpty(nome));
            do
            {
                System.Console.WriteLine("Descreva o produto");
                descricao = Console.ReadLine();
                if(string.IsNullOrEmpty(descricao))
                {
                    System.Console.WriteLine("Descrição inválida");
                }
            } while (string.IsNullOrEmpty(descricao));
            do
            {
                System.Console.WriteLine("Digite o preço do produto");
                preco = float.Parse(Console.ReadLine());
                if(preco < 1)
                {
                    System.Console.WriteLine("Preço inválido");
                }
            } while (preco < 1);
            do
            {
                System.Console.WriteLine("Digite a categoria do produto");
                System.Console.WriteLine("SUSHI / BEBIDA");
                categoria = Console.ReadLine();
                if (!ValidacaoUtil.EscolhaCategoria(categoria))
                {
                    System.Console.WriteLine("Escolha uma categoria válida");
                }
            } while (!ValidacaoUtil.EscolhaCategoria(categoria));

            ProdutoViewModel produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Nome = nome;
            produtoViewModel.Descricao = descricao;
            produtoViewModel.Preco = preco;
            produtoViewModel.Categoria = categoria;

            produtoRepositorio.InserirProduto(produtoViewModel);
            System.Console.WriteLine("Cadastro efetuado com sucesso");            
        }//fim cadastrar produto
        public static void ListarProduto()
        {
            List<ProdutoViewModel> listaDeProdutos = produtoRepositorio.Listar();
            foreach (var item in listaDeProdutos)
            {
                System.Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao} - Preço: {item.Preco} - Data: {item.Data}");
            }
        }
        public static ProdutoViewModel BuscaPorId ()
        {
            int id;
            System.Console.WriteLine("Digite seu ID");
            id = int.Parse(Console.ReadLine());

            ProdutoViewModel produtoRecuperado = produtoRepositorio.BuscarProduto(id);
            if (produtoRecuperado != null)
            {
                return produtoRecuperado;
            } else
            {
                System.Console.WriteLine("ID Inválido");
                return null;
            }
            
        }
    }
}