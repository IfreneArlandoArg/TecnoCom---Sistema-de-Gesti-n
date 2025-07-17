using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALProducto
    {
        string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public void Alta(BEProducto pProducto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ALTA_PRODUCTO", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@NOMBRE", pProducto.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", pProducto.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@PRECIO", pProducto.Precio));
                cmd.Parameters.Add(new SqlParameter("@STOCK", pProducto.Stock));


                conn.Open();

                cmd.ExecuteNonQuery();


            }

        }

        public List<BEProducto> Listar()
        {
            List<BEProducto> tmp = new List<BEProducto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_PRODUCTOS", conn);

                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    tmp.Add(new BEProducto(reader["ID_PRODUCTO"].ToString(), reader["NOMBRE"].ToString(), reader["DESCRIPCION"].ToString(), reader["PRECIO"].ToString(), reader["STOCK"].ToString()));

                }


            }

            return tmp;

        }


       


        public void ModificarStock(BEProducto pProducto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("MODIFICAR_STOCK_PRODUCTO", conn);

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@ID", pProducto.ID));
                cmd.Parameters.Add(new SqlParameter("@STOCK", pProducto.Stock));


                conn.Open();

                cmd.ExecuteNonQuery();


            }
        }

      

    }
}