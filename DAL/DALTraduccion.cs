using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALTraduccion : DALConnection
    {
        //string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public List<Traduccion> ObtenerPorIdioma(int idiomaId)
        {
            List<Traduccion> lista = new List<Traduccion>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Traduccion_ObtenerPorIdioma", conn);

                cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.AddWithValue("@IdiomaId", idiomaId);
                conn.Open();
            
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Traduccion
                    {
                        Etiqueta = reader["Etiqueta"].ToString(),
                        Texto = reader["Texto"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Guardar(int idiomaId, Traduccion traduccion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Traduccion_Guardar", conn);

                cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.AddWithValue("@IdiomaId", idiomaId);
                cmd.Parameters.AddWithValue("@Etiqueta", traduccion.Etiqueta);
                cmd.Parameters.AddWithValue("@Texto", traduccion.Texto);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}