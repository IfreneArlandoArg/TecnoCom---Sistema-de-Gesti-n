using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLUsuario : IUserRegistrationChecher
    {
        DALUsuario dalUsuario = new DALUsuario();
        BLLUsuarioLog log = new BLLUsuarioLog();
        public bool IsUserRegistered(string pEmail, string pPassword, out BEUsuario UserFound)
        {
            bool returnValue = false;
            UserFound = null;


            foreach(BEUsuario pUser in ListarActivos()) 
            { 
                if(pUser.Email == pEmail && pUser.PasswordHash == pPassword) 
                { 
                    returnValue = true;
                    UserFound = pUser;
                }
            }



            return returnValue;
        }

        public void Alta(BEUsuario pBeUsuario)
        {
            dalUsuario.Alta(pBeUsuario);

            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Alta_Usuario");
            log.Alta(beUsuarioLog);
        }

        public void Baja(BEUsuario pBEUsuario)
        {
            dalUsuario.Borrar(pBEUsuario);
          
            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Baja_Usuario");
            log.Alta(beUsuarioLog);
        }

        public void Modificar(BEUsuario pBEUsuario)
        {
            dalUsuario.Modificar(pBEUsuario);
           
            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Modificacion_Usuario");
            log.Alta(beUsuarioLog);
        }

        public List<BEUsuario> ListarActivos()
        {
            return dalUsuario.ListarActivos();
        }

        public List<BEUsuario> Listar()
        {
            return dalUsuario.Listar();
        }

        public List<BEUsuario> Listar(int IdUsuario)
        {
            return dalUsuario.Listar().Where(User => User.IdUsuario == IdUsuario).ToList();
        }

        public BEUsuario getUsuario(int IdUsuario)
        {
            return dalUsuario.Listar().Where(User => User.IdUsuario == IdUsuario).FirstOrDefault();
        }

        public void BajaPermisoUsuario(int pIdUsuario, int pIdPermiso) 
        { 
           dalUsuario.BajaPermisoUsuario(pIdUsuario, pIdPermiso);
           
            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Baja_Permiso_Usuario");
            log.Alta(beUsuarioLog);
        }

        public void AltaPermisoUsuario(int pIdUsuario, int pIdPermiso) 
        { 
            dalUsuario.AltaPermisoUsuario(pIdUsuario, pIdPermiso);

            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Alta_Permiso_Usuario");
            log.Alta(beUsuarioLog);

        }

    }
}