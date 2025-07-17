using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Windows.Forms;

namespace BLL
{
    public class BLLFactura
    {
        DALFactura dalFactura = new DALFactura();
        DALProducto dalProducto = new DALProducto();

        

        public void Alta(BEFactura pFactura)
        {


            if (pFactura.Estado == EnumEstado.EnProceso)
              throw new Exception("Factura en proceso...\nPago no completado...");
            
            
                


                dalFactura.Alta(pFactura);

                foreach (FacturaItem FI in pFactura.ListaProductos) 
                {
                    FI.Producto.Stock -= FI.Cantidad;
                    
                    
                    dalProducto.ModificarStock(FI.Producto);
                }

                MessageBox.Show("¡Venta Procesada con Exito!");


        }

        public List<BEFactura> Listar()
        {
           return dalFactura.Listar();
        }
    }
}