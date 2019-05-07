using Senai.Desenvolvimento.Roman.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sprint5.Exercicio.Roman.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista usuarios
        /// </summary>
        /// <returns>Retorna uma lista de todos os usuários cadastrados</returns>
        List<Usuarios> ListarUsuarios();

        /// <summary>
        /// Busca por email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Retorna um usuário que tenha o mesmo email e senha que os parâmetros fornecidos</returns>
        Usuarios BuscarPorEmailSenha(string email, string senha);

    }
}
