using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
    public class DALCliente
    {
        string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public void Alta(BECliente pCliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("ALTA_CLIENTE",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DNI",pCliente.DNI));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE",pCliente.Nombre));
                cmd.Parameters.Add(new SqlParameter("@APELLIDO", pCliente.Apellido));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", pCliente.Email));


                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<BECliente> Listar()
        {
            List<BECliente> tmp = new List<BECliente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_CLIENTES", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    tmp.Add(new BECliente(reader["DNI"].ToString(), reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString(), reader["EMAIL"].ToString() ));
                }
               

            }

            return tmp;
        }

        public void Modificar(BECliente pCliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("MODIFICAR_CLIENTE", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DNI", pCliente.DNI));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", pCliente.Nombre));
                cmd.Parameters.Add(new SqlParameter("@APELLIDO", pCliente.Apellido));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", pCliente.Email));

                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Baja(BECliente pCliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("BORRAR_CLIENTE", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DNI", pCliente.DNI));
                
                conn.Open();

                cmd.ExecuteNonQuery();

            }

        }
    }
}