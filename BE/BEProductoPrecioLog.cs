using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEProductoPrecioLog
    {
        private int IdProductoPrecioLog;
        private int IdProducto;
        private int IdUsuario;


        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }


        public BEProductoPrecioLog(int pIdUsuario, int pIdProducto, decimal pPrecio)
        {
            IdUsuario = pIdUsuario;
            IdProducto = pIdProducto;
            Precio = pPrecio;
        }

        public BEProductoPrecioLog(int pIdProductoPrecioLog, int pIdUsuario, int pIdProducto, decimal pPrecio, DateTime pFecha)
        {
            IdProductoPrecioLog = pIdProductoPrecioLog;
            IdUsuario = pIdUsuario;
            IdProducto = pIdProducto;
            Precio = pPrecio;
            Fecha = pFecha;
        }


        public int getIdUsuario()
        {
            return IdUsuario;
        }

       

        public int getIdProducto()
        {
            return IdProducto;
        }

       

        public int getIdProductoPrecioLog()
        {
            return IdProductoPrecioLog;
        }

       




    }
}