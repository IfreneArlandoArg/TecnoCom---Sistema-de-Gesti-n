using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALFactura : DALConnection
    {
        //string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";

        public void Alta(BEFactura bEFactura)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ALTA_FACTURA", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DNI", bEFactura.Cliente.DNI));
                cmd.Parameters.Add(new SqlParameter("@FECHA", bEFactura.Fecha));
                cmd.Parameters.Add(new SqlParameter("@TOTAL", bEFactura.Total));

                

                SqlParameter outputIdParam = new SqlParameter("@ID_FACTURA", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);


                conn.Open();

                cmd.ExecuteNonQuery();


                int newFacturaId = (int)cmd.Parameters["@ID_FACTURA"].Value;
                bEFactura.ID = newFacturaId;




            }



            foreach (var item in bEFactura.ListaProductos)
            {
                AltaItemFacturaProducto(bEFactura.ID, item.Producto, item.Cantidad, item.TotalPrecioItem());
            }

        }


        
        public List<BEFactura> Listar()
        {
            List<BEFactura> tmp = new List<BEFactura>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_FACTURAS", conn);

                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    BECliente ClienteTmp = new BECliente(reader["DNI"].ToString(), reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString(), reader["EMAIL"].ToString());

                    BEFactura Facturatmp = new BEFactura(reader["ID_FACTURA"].ToString(), ClienteTmp, reader["FECHA"].ToString(), reader["TOTAL"].ToString());

                   

                    tmp.Add(ListarProductosFactura(Facturatmp));

                }

                

            }

            return tmp;
        }

        public void ListarFacturasCliente()
        {
            throw new System.NotImplementedException();
        }

        private void AltaItemFacturaProducto(int IdFactura, BEProducto producto, int pCantidad, decimal pSubtotal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AltaItemFacturaProducto", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdFactura", IdFactura));
                cmd.Parameters.Add(new SqlParameter("@IdProducto", producto.ID));
                cmd.Parameters.Add(new SqlParameter("@CantidadProd", pCantidad));
                cmd.Parameters.Add(new SqlParameter("@Subtotal", pSubtotal));


                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }


        private BEFactura ListarProductosFactura(BEFactura pFactura)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_PRODUCTO_FACTURA_FACTURA", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID_FACTURA", pFactura.ID));

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FacturaItem fact = new FacturaItem
                    {
                        Producto = new BEProducto(reader["ID_PRODUCTO"].ToString(), reader["NOMBRE"].ToString(), reader["DESCRIPCION"].ToString(), reader["PRECIO"].ToString(), reader["STOCK"].ToString()),
                        Cantidad = (int)reader["CANTIDAD"]

                    };
                    

                    

                    pFactura.ListaProductos.Add(fact);

                }


            }

            return pFactura;

        }


    }
}