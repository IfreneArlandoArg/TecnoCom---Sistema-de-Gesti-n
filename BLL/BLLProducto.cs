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
        BLLProductoPrecioLog bllProductoPrecioLog = new BLLProductoPrecioLog();


        public bool VerificarIntegridad()
        {
            return dalProducto.VerificarIntegridad();
        }

        public void Alta(BEProducto pProducto)
        {
            dalProducto.Alta(pProducto);
            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Alta_Producto");
            log.Alta(beUsuarioLog);

            dalProducto.ActualizarDVH();
            dalProducto.ActualizarDVV();
        }

        public BEProducto ObtenerPorId(int id)
        {
            return Listar().FirstOrDefault(p => p.ID == id);
        }

        public List<BEProducto> Listar()
        {
            return dalProducto.Listar();
        }

        public List<BEProducto> ListarProductosConStock()
        {
            return Listar().Where(P => P.Stock > 0).ToList();
        }

        public void Modificar(BEProducto pBEProducto)
        {
            BEProductoPrecioLog productoPrecioLog = new BEProductoPrecioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, pBEProducto.ID, pBEProducto.Precio);
            bllProductoPrecioLog.Alta(productoPrecioLog);

            dalProducto.Modificar(pBEProducto);
            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Modificacion_Producto");
            log.Alta(beUsuarioLog);

            dalProducto.ActualizarDVH();
            dalProducto.ActualizarDVV();
        }


        public void baja(BEProducto pBEProducto)
        {
            dalProducto.Baja(pBEProducto);
            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Baja_Producto");
            log.Alta(beUsuarioLog);

            dalProducto.ActualizarDVV();
        }

    }
}