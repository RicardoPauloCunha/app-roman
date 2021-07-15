using WebApi.Roman.Domains;
using WebApi.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApi.Roman.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly string StringConexao = "connection-string";

        public List<Professores> ListarProfessores()
        {
            List<Professores> lista = new List<Professores>();

            string Select = "SELECT P.Id, U.Nome, E.Descricao FROM Professores P " +
                "JOIN Usuarios U " +
                "ON U.ID = P.UsuariosId " +
                "JOIN Equipes E " +
                "ON E.Id = P.EquipeId";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Select, con))
                {
                    con.Open();

                    SqlDataReader sqr = cmd.ExecuteReader();

                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Professores professor = new Professores()
                            {
                                Id = Convert.ToInt32(sqr["Id"]),
                                Equipe = new Equipes()
                                {
                                    Descricao = sqr["Equipe"].ToString()
                                },
                                Usuarios = new Usuarios()
                                {
                                    Nome = sqr["Nome"].ToString()
                                }
                            };

                            lista.Add(professor);
                        }
                    }
                    return lista;
                }
            }
        }

        public List<Professores> ListarProfessoresPorArea(string equipe)
        {
            List<Professores> lista = new List<Professores>();

            string Select = "SELECT P.Id, U.Nome, E.Descricao FROM Professores P " +
                "JOIN Usuarios U " +
                "ON U.Id = P.UsuariosId " +
                "JOIN Equipes E " +
                "ON E.Id = P.EquipeId " +
                "WHERE E.Descricao = @DescricaoEquipe";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    cmd.Parameters.AddWithValue("@DescricaoEquipe", equipe);

                    SqlDataReader sqr = cmd.ExecuteReader();

                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Professores professor = new Professores()
                            {
                                Id = Convert.ToInt32(sqr["Id"]),
                                Equipe = new Equipes()
                                {
                                    Descricao = sqr["Equipe"].ToString()
                                },
                                Usuarios = new Usuarios()
                                {
                                    Nome = sqr["Nome"].ToString()
                                }
                            };

                            lista.Add(professor);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
