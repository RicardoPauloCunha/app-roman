using WebApi.Roman.Domains;
using Senai.Sprint5.Exercicio.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Sprint5.Exercicio.Roman.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string StringConexao = "connection-string";

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            string Select = "SELECT U.Id, U.Email, U.Nome, T.Id, T.Descricao, U.Senha FROM Usuarios U " +
                "JOIN TiposUsuarios T " +
                "ON U.TipoUsuarioId = T.Id " +
                "WHERE Email = @Email AND Senha = @Senha";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    con.Open();

                    SqlDataReader sqr = cmd.ExecuteReader();

                    if (sqr.HasRows)
                    {
                        Usuarios usuario = new Usuarios();

                        while (sqr.Read())
                        {
                            usuario.Id = Convert.ToInt32(sqr["Id"]);
                            usuario.Nome= sqr["Nome"].ToString();
                            usuario.Email = sqr["Email"].ToString();
                            usuario.Senha = sqr["Senha"].ToString();
                            usuario.TipoUsuario = new TiposUsuarios()
                            {
                                Id = Convert.ToInt32(sqr["Id"]),
                                Descricao = sqr["Descricao"].ToString()
                            };
                        }

                        return usuario;
                    }
                }
                return null;
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Select = "SELECT U.Id, U.Email, U.Nome, T.Descricao, U.Senha FROM Usuairos U " +
                    "JOIN TiposUsuarios T " +
                    "ON U.TipoUsuariosId = T.Id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    SqlDataReader sqr = cmd.ExecuteReader();

                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Usuarios usuario = new Usuarios()
                            {
                                Id = Convert.ToInt32(sqr["Id"]),
                                Nome = sqr["Nome"].ToString(),
                                Senha = sqr["Senha"].ToString(),
                                Email = sqr["Email"].ToString(),
                                TipoUsuario = new TiposUsuarios()
                                {
                                    Descricao = sqr["Descricao"].ToString(),
                                },                                
                            };

                            ListaUsuarios.Add(usuario);
                        }
                    }
                    return ListaUsuarios;
                }
            }
        }
    }
}
