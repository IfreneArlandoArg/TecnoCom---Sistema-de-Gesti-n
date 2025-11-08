using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALProductoPrecioLog : DALConnection
    {
        //string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public void Alta(BEProductoPrecioLog productoPrecioLog)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ALTA_PRODUCTO_PRECIO_LOG", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID_USUARIO", productoPrecioLog.getIdUsuario()));
                cmd.Parameters.Add(new SqlParameter("@ID_PRODUCTO", productoPrecioLog.getIdProducto()));
                cmd.Parameters.Add(new SqlParameter("@PRECIO", productoPrecioLog.Precio));



                conn.Open();

                cmd.ExecuteNonQuery();


            }
        }



        public List<BEProductoPrecioLog> Listar(int IdProducto)
        {
            List<BEProductoPrecioLog> tmp = new List<BEProductoPrecioLog>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_LOGS_PRECIOS_PRODUCTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID_PRODUCTO", IdProducto));
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    tmp.Add(new BEProductoPrecioLog((int)reader["ID_PRODUCTO_PRECIO_LOG"], (int)reader["ID_USUARIO"], (int)reader["ID_PRODUCTO"], (decimal)reader["PRECIO"], (DateTime)reader["FECHA"]));

                }
            }



            return tmp;
        }





    }


}