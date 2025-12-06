using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAL
{
    public class DALProducto: DALConnection
    {
        //string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
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

       

        public void Modificar(BEProducto pProducto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("MODIFICAR_PRODUCTO", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID_PRODUCTO", pProducto.ID));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", pProducto.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", pProducto.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@PRECIO", pProducto.Precio));
                cmd.Parameters.Add(new SqlParameter("@STOCK", pProducto.Stock));


                conn.Open();

                cmd.ExecuteNonQuery();


            }

        }

        public void Baja(BEProducto pProducto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("BAJA_PRODUCTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID_PRODUCTO", pProducto.ID));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RestaurarDesdeHistorial(int idProducto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Producto_RestaurarDesdeHistorial", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_PRODUCTO", idProducto);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public void GuardarHistorial(BEProducto p, string accion, int IDUsuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Producto_GuardarHistorial", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_PRODUCTO", p.ID);
                cmd.Parameters.AddWithValue("@NOMBRE", p.Nombre);
                cmd.Parameters.AddWithValue("@DESCRIPCION", p.Descripcion);
                cmd.Parameters.AddWithValue("@PRECIO", p.Precio);
                cmd.Parameters.AddWithValue("@STOCK", p.Stock);
                cmd.Parameters.AddWithValue("@ACCION", accion);
                cmd.Parameters.AddWithValue("@USUARIO", IDUsuario);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        //Update DVH(Digito verificador Horizontal) for all products
        public void ActualizarDVH()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_DVH_PRODUCTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Update DVV(Digito verificador Vertical) for all products
        public void ActualizarDVV()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_DVV_PRODUCTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public (bool IntegridadOk, List<BEProducto> ProductosCorruptos) VerificarIntegridad()
        {
            List<BEProducto> corruptos = new List<BEProducto>();
            bool integridadOk = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Verificar_Integridad_Productos_2", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // ---------------------------------------------------------
                    // Primer resultset → valor de integridad
                    // ---------------------------------------------------------
                    if (reader.Read())
                    {
                        integridadOk = reader.GetBoolean(reader.GetOrdinal("IntegridadValida"));
                    }

                    // Pasar al segundo resultset
                    reader.NextResult();

                    // ---------------------------------------------------------
                    // Segundo resultset → productos corruptos
                    // ---------------------------------------------------------
                    while (reader.Read())
                    {
                        corruptos.Add(new BEProducto(
                            reader["ID_PRODUCTO"].ToString(),
                            reader["NOMBRE"].ToString(),
                            reader["DESCRIPCION"].ToString(),
                            reader["PRECIO"].ToString(),
                             reader["STOCK"].ToString()
                        ));
                    }
                }
            }

            return (integridadOk, corruptos);
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