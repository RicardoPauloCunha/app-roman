using Senai.Desenvolvimento.Roman.Domains;
using Senai.Sprint5.Exercicio.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sprint5.Exercicio.Roman.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=ROMAN;User ID = sa; Password = 132;";

        public void Cadastrar(Projetos projeto)
        {
            string Insert = "INSERT INTO PROJETOS VALUES(@TITULO, @DESCRICAO, @ID_TEMA, @ID_PROFESSOR)";                           
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Insert, con))
                {
                    cmd.Parameters.AddWithValue("@TITULO", projeto.Titulo);
                    cmd.Parameters.AddWithValue("@DESCRICAO", projeto.Descricao);
                    cmd.Parameters.AddWithValue("@ID_TEMA", projeto.IdTema);
                    cmd.Parameters.AddWithValue("@ID_PROFESSOR", projeto.IdProfessor);
                    con.Open();
                    cmd.ExecuteNonQuery();
                };

            }

        }

        public List<Projetos> listarProjetos()
        {
            string Select = "SELECT P.PROJETO_ID, U.NOME, P.TITULO, P.DESCRICAO, T.TEMA FROM PROJETOS P JOIN TEMAS T ON P.ID_TEMA = T.TEMAID JOIN PROFESSORES PS ON PS.PROFESSOR_ID = P.ID_PROFESSOR JOIN USUARIOS U ON U.ID = P.ID_PROFESSOR";

            List<Projetos> listarProjetos = new List<Projetos>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    SqlDataReader sqr = cmd.ExecuteReader();
                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Projetos projeto = new Projetos()
                            {
                                ProjetoId = Convert.ToInt32(sqr["PROJETO_ID"]),
                                Titulo = sqr["TITULO"].ToString(),
                                Descricao = sqr["DESCRICAO"].ToString(),
                                IdTemaNavigation = new Temas()
                                {
                                    Tema = sqr["TEMA"].ToString()
                                },
                                Usuario = new Usuarios()
                                {
                                    Nome = sqr["NOME"].ToString()
                                }
                            };
                            listarProjetos.Add(projeto);
                        }
                    }
                    return listarProjetos;
                }
            }
        }
    }
}

