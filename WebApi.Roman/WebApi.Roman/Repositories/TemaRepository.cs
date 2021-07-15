using WebApi.Roman.Domains;
using WebApi.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApi.Roman.Repositories
{
    public class TemaRepository : ITemaRepository
    {
    private readonly string StringConexao = "connection-string";

        public void Alterar(TemasViewModel tema)
        {
            string Update = "UPDATE Temas SET Ativo = @Ativo WHERE Id = @TemaId";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Update, con))
                {
                    cmd.Parameters.AddWithValue("@TemaId", tema.TemaId);                    
                    cmd.Parameters.AddWithValue("@Ativo", tema.Ativo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(TemasViewModel tema)
        {
            string Insert = "INSERT INTO Temas VALUES(@Tema, @Ativo)";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Insert, con))
                {
                    cmd.Parameters.AddWithValue("@Tema", tema.Tema);
                    cmd.Parameters.AddWithValue("@Ativo", tema.Ativo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }   

        public List<Temas> ListarTemas()
        {
            string Select = "SELECT T.Id, T.Tema, T.Ativo FROM Temas T";

            List<Temas> listarTemas = new List<Temas>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    SqlDataReader sqr = cmd.ExecuteReader();

                    if(sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Temas tema = new Temas()
                            {
                                Id = Convert.ToInt32(sqr["Id"]),
                                Tema = sqr["Tema"].ToString(),
                                Ativo = Convert.ToBoolean(sqr["Ativo"])
                            };

                            listarTemas.Add(tema);
                        }
                    }
                    return listarTemas;
                }
            }
        }

        public List<Temas> TemasAtivos()
        {
            string Select = "SELECT T.Id, T.Tema FROM Temas T WHERE T.Ativo = 1";

            List<Temas> listarTemas = new List<Temas>();

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
                            Temas tema = new Temas()
                            {
                                Id = Convert.ToInt32(sqr["Id"]),
                                Tema = sqr["Tema"].ToString()                               
                            };

                            listarTemas.Add(tema);
                        }
                    }
                    return listarTemas;
                }
            }
        }
    }
}
