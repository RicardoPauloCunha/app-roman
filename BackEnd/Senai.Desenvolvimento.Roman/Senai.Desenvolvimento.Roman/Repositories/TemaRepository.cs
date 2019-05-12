using Senai.Desenvolvimento.Roman.Domains;
using Senai.Desenvolvimento.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Desenvolvimento.Roman.Repositories
{
    public class TemaRepository : ITemaRepository
    {
    private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=ROMAN;User ID = sa; Password = 132;";

        public void Alterar(Temas tema)
        {
            string Update = "UPDATE TEMAS SET ATIVO = @ATIVO WHERE TEMAID = @TEMAID";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                
                using(SqlCommand cmd = new SqlCommand(Update, con))
                {
                    cmd.Parameters.AddWithValue("TEMAID", tema.Temaid);                    
                    cmd.Parameters.AddWithValue("@ATIVO", tema.Ativo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(Temas tema)
        {
            string Insert = "INSERT INTO TEMAS VALUES(@TEMA, @ATIVO)";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Insert, con))
                {
                    cmd.Parameters.AddWithValue("@TEMA", tema.Tema);
                    cmd.Parameters.AddWithValue("@ATIVO", tema.Ativo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }   

        public List<Temas> listarTemas()
        {
            string Select = "SELECT T.TEMAID, T.TEMA, T.ATIVO FROM TEMAS T";

            List<Temas> listarTemas = new List<Temas>();
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Select, con))
                {
                    SqlDataReader sqr = cmd.ExecuteReader();

                    if(sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Temas tema = new Temas()
                            {
                                Temaid = Convert.ToInt32(sqr["TEMAID"]),
                                Tema = sqr["TEMA"].ToString(),
                                Ativo = Convert.ToBoolean(sqr["ATIVO"])
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
            string Select = "SELECT T.TEMAID, T.TEMA FROM TEMAS T WHERE T.ATIVO = 0";

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
                                Temaid = Convert.ToInt32(sqr["TEMAID"]),
                                Tema = sqr["TEMA"].ToString()                               
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
