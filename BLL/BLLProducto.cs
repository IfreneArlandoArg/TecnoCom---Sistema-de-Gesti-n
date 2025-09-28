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
        BLLUsuarioLog log = new BLLUsuarioLog();
        public void Alta(BEProducto pProducto)
        {
            dalProducto.Alta(pProducto);
            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Alta_Producto");
            log.Alta(beUsuarioLog);


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