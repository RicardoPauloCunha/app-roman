using Senai.Desenvolvimento.Roman.Domains;
using Senai.Desenvolvimento.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Desenvolvimento.Roman.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=ROMAN;User ID = sa; Password = 132;";
        public List<Professores> listarProfessores()
        {
            List<Professores> lista = new List<Professores>();
            string Select = "SELECT P.PROFESSOR_ID, U.NOME, E.EQUIPE FROM PROFESSORES P JOIN USUARIOS U ON U.ID = P.ID_USUARIO JOIN EQUIPES E ON E.EQUIPE_ID = P.ID_AREA";
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
                                ProfessorId = Convert.ToInt32(sqr["PROFESSOR_ID"]),
                                IdEquipeNavigation = new Equipes()
                                {
                                    Nome = sqr["EQUIPE"].ToString()
                                },
                                IdUsuarioNavigation = new Usuarios()
                                {
                                    Nome = sqr["NOME"].ToString()
                                }
                            };
                            lista.Add(professor);
                        }
                    }
                    return lista;

                }
            }
        }

        public List<Professores> listarProfessoresPorArea(string area)
        {
            List<Professores> lista = new List<Professores>();
            string Select = "SELECT P.PROFESSOR_ID, U.NOME, E.EQUIPE FROM PROFESSORES P JOIN USUARIOS U ON U.ID = P.ID_USUARIO JOIN EQUIPES E ON E.EQUIPE_ID = P.ID_AREA WHERE P.ID_AREA = @AREA";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    cmd.Parameters.AddWithValue("@AREA", area);
                    con.Open();
                    SqlDataReader sqr = cmd.ExecuteReader();
                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Professores professor = new Professores()
                            {
                                ProfessorId = Convert.ToInt32(sqr["PROFESSOR_ID"]),
                                IdEquipeNavigation = new Equipes()
                                {
                                    Nome = sqr["EQUIPE"].ToString()
                                },
                                IdUsuarioNavigation = new Usuarios()
                                {
                                    Nome = sqr["NOME"].ToString()
                                }
                            };
                            lista.Add(professor);
                        }
                    }
                    return lista;

                }
            }
        }
    }
}
