using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEUsuarioLog
    {
        public int IdLog { get; set; }
        public BEUsuario Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Accion { get; set; }


        public BEUsuarioLog(int idLog, BEUsuario pUsuario, DateTime fechaHora, string accion)
        {
            IdLog = idLog;
            Usuario = pUsuario;
            FechaHora = fechaHora;
            Accion = accion;
        }

        public BEUsuarioLog(BEUsuario pUsuario, DateTime fechaHora, string accion)
        {
            Usuario = pUsuario;
            FechaHora = fechaHora;
            Accion = accion;
        }




    }
}