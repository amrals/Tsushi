using System;
using System.Collections.Generic;
using Senai.Tsushi.MVC.ViewModel;

namespace Senai.Tsushi.MVC.Repositorio
{
    public class UsuarioRepositorio
    {
        List<UsuarioViewModel> listaDeUsuarios = new List<UsuarioViewModel>();

        /// <summary>Método responsável por armazenar um usuário</summary>
        public UsuarioViewModel Inserir(UsuarioViewModel usuario)
        {
            usuario.Id = listaDeUsuarios.Count + 1;
            usuario.Data = DateTime.Now;
            //insere o objeto usuario dentro da lista
            listaDeUsuarios.Add(usuario);
            return usuario;
        }
        /// <summary>Retorna lista de usuários</summary>
        public List<UsuarioViewModel> Listar ()
        {
            return listaDeUsuarios;
        }

        /// <summary>Verifica se o usuário é válido</summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o usuário caso seja encontrado e null caso não exista</returns>
        public UsuarioViewModel BuscarUsuario(string email, string senha)
        {
            foreach (var item in listaDeUsuarios)
            {
                if (item.Email.Equals(email) && item.Senha.Equals(senha))
                {
                    return item;
                }
            }
                return null;
        }
    }
}