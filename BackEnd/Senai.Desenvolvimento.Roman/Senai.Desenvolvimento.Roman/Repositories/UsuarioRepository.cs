using Senai.Desenvolvimento.Roman.Domains;
using Senai.Sprint5.Exercicio.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sprint5.Exercicio.Roman.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string StringConexao = "DATA source=.\\SQLSERVERJIROS; initial catalog=Roman; user id=sa; pwd=ji_15?27101001_roS";

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            string Select = "SELECT U.ID, U.EMAIL, U.NOME, T.TIPO_USUARIO_ID, T.TIPO, U.SENHA FROM USUARIOS U JOIN TIPO_USUARIOS T ON U.ID_TIPO_USUARIO = T.TIPO_USUARIO_ID WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);
                    con.Open();

                    SqlDataReader sqr = cmd.ExecuteReader();

                    if (sqr.HasRows)
                    {
                        Usuarios usuario = new Usuarios();

                        while (sqr.Read())
                        {
                            usuario.Id = Convert.ToInt32(sqr["ID"]);
                            usuario.Nome= sqr["NOME"].ToString();
                            usuario.Email = sqr["EMAIL"].ToString();
                            usuario.Senha = sqr["SENHA"].ToString();
                            usuario.IdTipoUsuarioNavigation = new TipoUsuarios()
                            {
                                TipoUsuarioId = Convert.ToInt32(sqr["TIPO_USUARIO_ID"]),
                                Tipo = sqr["TIPO"].ToString()
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
                string Select = "SELECT U.ID, U.EMAIL, U.NOME, T.TIPO, U.SENHA FROM USUARIOS U JOIN TIPO_USUARIOS T ON U.ID_TIPO_USUARIO = T.TIPO_USUARIO_ID";

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
                                Id = Convert.ToInt32(sqr["ID"]),
                                Nome = sqr["NOME"].ToString(),
                                Senha = sqr["SENHA"].ToString(),
                                Email = sqr["EMAIL"].ToString(),
                                IdTipoUsuarioNavigation = new TipoUsuarios()
                                {
                                    Tipo = sqr["TIPO"].ToString(),

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
