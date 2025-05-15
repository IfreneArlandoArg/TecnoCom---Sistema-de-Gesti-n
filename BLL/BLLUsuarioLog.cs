using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class BLLUsuarioLog
    {
        DALUsuarioLog dalUsuarioLog = new DALUsuarioLog();
        public void Alta(BEUsuarioLog pBEUsuarioLog)
        {
            dalUsuarioLog.Alta(pBEUsuarioLog);
        }

        public List<BEUsuarioLog> Listar(BEUsuario pBEUsuario)
        {
            return dalUsuarioLog.Listar(pBEUsuario);
        }
    }
}