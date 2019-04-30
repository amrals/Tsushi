using System;
using System.Collections.Generic;
using Senai.Tsushi.MVC.ViewModel;

namespace Senai.Tsushi.MVC.Repositorio
{
    public class ProdutoRepositorio
    {
        List<ProdutoViewModel> listaDeProdutos = new List<ProdutoViewModel>();

        /// <summary>Método responsável por armazenar um produto</summary>
        public ProdutoViewModel InserirProduto(ProdutoViewModel produto)
        {
            produto.Id = listaDeProdutos.Count + 1;
            produto.Data = DateTime.Now;
            //insere o objeto produto dentro da lista
            listaDeProdutos.Add(produto);
            return produto;
        }
        public List<ProdutoViewModel> Listar ()
        {
            return listaDeProdutos;
        }
        public ProdutoViewModel BuscarProduto(int id)
        {
            foreach (var item in listaDeProdutos)
            {
                if (item.Id.Equals(id))
                {
                    return item;
                }
            }
                return null;
        }
    }
}