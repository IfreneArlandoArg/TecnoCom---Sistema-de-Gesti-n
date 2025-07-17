using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class FacturaItem
    {
        public BEProducto Producto { get; set; }
        public int Cantidad { get; set; }

        public decimal TotalPrecioItem() 
        {             
            return Producto.Precio * Cantidad;
        }

        public override string ToString()
        {
            return $"{Producto.Nombre} -  {Producto.Precio} X {Cantidad}. ";
        }

    }
}