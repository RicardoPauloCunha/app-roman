using WebApi.Roman.Domains;
using System.Collections.Generic;

namespace Senai.Sprint5.Exercicio.Roman.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailSenha(string email, string senha);
        List<Usuarios> ListarUsuarios();
    }
}
