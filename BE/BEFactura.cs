using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEFactura
    {
        public int ID { get; set; }
        public BECliente Cliente { get; set; }

        private List<FacturaItem> listaProductos = new List<FacturaItem>();

        public List<FacturaItem> ListaProductos
        {
            get { return listaProductos; }
        }

        public DateTime Fecha { get; set; }


        public EnumEstado Estado { get; set; }

        public decimal Total { get; set; }


        public BEFactura(string pID, BECliente pCliente , string pFecha, string pTotal) 
        { 
            ID = int.Parse(pID);
            Cliente = pCliente;
            Fecha = DateTime.Parse(pFecha);
            Estado = EnumEstado.Emitida;
            Total = decimal.Parse(pTotal);
            
        }

        public BEFactura(BECliente pCliente)
        {
            
            Cliente = pCliente;
            Fecha = DateTime.Now;
            Estado = EnumEstado.EnProceso;
            

        }

        public BEFactura()
        {
            Fecha = DateTime.Now;
            Estado = EnumEstado.EnProceso;
        }

        public void AgregarProducto(FacturaItem factI) 
        {
           

            bool exist = false;

            foreach (var item in listaProductos)
            {
                if (item.Producto.ID == factI.Producto.ID)
                {
                    if (item.Producto.Stock < (item.Cantidad + factI.Cantidad))
                        throw new Exception($"¡{item.Producto} sin stock suficiente!");


                    item.Cantidad += factI.Cantidad;

                    exist = true;

                }
            }

            if(!exist)
            { 
                if(factI.Producto.Stock < factI.Cantidad)
                    throw new Exception($"¡{factI.Producto} sin stock suficiente!");
                
                listaProductos.Add(factI); 
            }

            Total = listaProductos.Sum(P => P.TotalPrecioItem() );
        }

        public void SacarProducto(FacturaItem factI, int pCantidad)
        { 
          
            if(factI.Cantidad == pCantidad)
            { 
                listaProductos.Remove(factI); 
            }
            else 
            {
                factI.Cantidad -= pCantidad; 
            }


          
            Total = listaProductos.Sum(P => P.TotalPrecioItem());
        }





    }
}