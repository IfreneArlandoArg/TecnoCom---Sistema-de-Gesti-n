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
        public bool IsUserRegistered(string pEmail, string pPassword, out BEUsuario UserFound)
        {
            bool returnValue = false;
            UserFound = null;


            foreach(BEUsuario pUser in Listar()) 
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
        }

        public void Baja(BEUsuario pBEUsuario)
        {
            dalUsuario.Borrar(pBEUsuario);
        }

        public void Modificar(BEUsuario pBEUsuario)
        {
            dalUsuario.Modificar(pBEUsuario);
        }

        public List<BEUsuario> Listar()
        {
            return dalUsuario.Listar();
        }

        public void BajaPermisoUsuario(int pIdUsuario, int pIdPermiso) 
        { 
           dalUsuario.BajaPermisoUsuario(pIdUsuario, pIdPermiso);
        }

        public void AltaPermisoUsuario(int pIdUsuario, int pIdPermiso) 
        { 
            dalUsuario.AltaPermisoUsuario(pIdUsuario, pIdPermiso);
        
        }

    }
}