using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEProducto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public BEProducto(string pID, string pNombre, string pDescripcion, string pPrecio, string pStock)
        {
            ID = int.Parse(pID);
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Precio = decimal.Parse(pPrecio);
            Stock = int.Parse(pStock);
        
        }

        public BEProducto( string pNombre, string pDescripcion, decimal pPrecio, int pStock)
        {
         
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Precio = pPrecio;
            Stock= pStock;

        }

        public override string ToString()
        {
            return $"{Nombre} - {Precio} AR$";
        }

    }
}