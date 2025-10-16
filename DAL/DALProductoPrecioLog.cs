using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALProductoPrecioLog
    {
        string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
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
    }
}