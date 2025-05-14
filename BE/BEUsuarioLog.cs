using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEUsuarioLog
    {
        public int IdLog { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Accion { get; set; }


        public BEUsuarioLog(string idLog, string idUsuario, string fechaHora, string accion)
        {
            

            IdLog = int.Parse(idLog);
            IdUsuario = int.Parse(idUsuario);
            FechaHora = DateTime.Parse(fechaHora);
            Accion = accion;
        }

        public BEUsuarioLog(int idUsuario, string accion)
        {
            IdUsuario = idUsuario;
            Accion = accion;
        }




    }
}