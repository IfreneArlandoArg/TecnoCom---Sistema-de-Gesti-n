using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Windows.Forms;

namespace BLL
{
    public class BLLProductoPrecioLog
    {
        DALProductoPrecioLog dalProductoPrecioLog = new DALProductoPrecioLog();
        
        public void Alta(BEProductoPrecioLog productoPrecioLog)
        {
           

            if (PrecioEsDiferente(productoPrecioLog.getIdProducto(), productoPrecioLog.Precio))
            {
                dalProductoPrecioLog.Alta(productoPrecioLog);
            }
            else 
            { 
               MessageBox.Show("El precio ingresado es el mismo que el actual. \nNo se realizará ningún cambio relacionado a Precio.");
            }


        }

       

        private bool PrecioEsDiferente(int pIdProducto, decimal pPrecio)
        {
            
            return new BLLProducto().ObtenerPorId(pIdProducto).Precio != pPrecio;
        }


        public List<BEProductoPrecioLog> Listar(int IdProducto)
        {
            return dalProductoPrecioLog.Listar(IdProducto);
        }

    }
}