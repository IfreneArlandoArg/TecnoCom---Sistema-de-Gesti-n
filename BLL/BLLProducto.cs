using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLProducto
    {
        DALProducto dalProducto = new DALProducto();
        public void Alta(BEProducto pProducto)
        {
            dalProducto.Alta(pProducto);
        }

        public List<BEProducto> Listar()
        {
            return dalProducto.Listar();
        }

        public List<BEProducto> ListarProductosConStock()
        {
            return Listar().Where(P => P.Stock > 0).ToList();
        }


    }
}