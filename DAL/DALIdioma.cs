using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALIdioma
    {
        string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public List<Idioma> ObtenerTodos()
        {
            List<Idioma> lista = new List<Idioma>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("sp_Idioma_ObtenerTodos", conn);  
                cmd.CommandType = CommandType.StoredProcedure;
            
                conn.Open();
            
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Idioma
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Codigo = reader["Codigo"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Insertar(Idioma idioma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Idioma_Insertar", conn);

                cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.AddWithValue("@Nombre", idioma.Nombre);
                cmd.Parameters.AddWithValue("@Codigo", idioma.Codigo);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            
        }
    }

}