using WebApi.Roman.Domains;
using Senai.Sprint5.Exercicio.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Sprint5.Exercicio.Roman.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly string StringConexao = "connection-string";

        public void Cadastrar(ProjetosViewModel projeto)
        {
            string Insert = "INSERT INTO Projetos " +
                "VALUES(@Titulo, @DDescricao, @TemaId, @ProfessorId)";        
            
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Insert, con))
                {
                    cmd.Parameters.AddWithValue("@TItulo", projeto.Titulo);
                    cmd.Parameters.AddWithValue("@Descricao", projeto.Descricao);
                    cmd.Parameters.AddWithValue("@TemaId", projeto.TemasId);
                    cmd.Parameters.AddWithValue("@ProfessorId", projeto.ProfessorId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                };
            }
        }

        public List<Projetos> ListarProjetos()
        {
            string Select = "SELECT P.Id, U.Nome, P.TItulo, P.Descricao, T.Tema FROM Projetos P " +
                "JOIN Temas T " +
                "ON P.TemaId = T.Id " +
                "JOIN Projetos PS " +
                "ON PS.ProfessorId = P.Id " +
                "JOIN Usuarios U " +
                "ON U.Id = P.UsuariosId";

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
                                Id = Convert.ToInt32(sqr["Id"]),
                                Titutlo = sqr["Titulo"].ToString(),
                                Descricao = sqr["Descricao"].ToString(),
                                Tema = new Temas()
                                {
                                    Tema = sqr["Tema"].ToString()
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