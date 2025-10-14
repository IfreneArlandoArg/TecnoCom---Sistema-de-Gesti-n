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

        public List<BEUsuarioLog> Listar()
        {
            return dalUsuarioLog.Listar()
                   .OrderByDescending(UserLog => UserLog.FechaHora)
                   .ToList();
        }

        public List<BEUsuarioLog> Listar(EnumAccion enumAccion)
        {
            return dalUsuarioLog.Listar()
                .Where(UserLog => UserLog.Accion == enumAccion.ToString())
                .OrderByDescending(UserLog => UserLog.FechaHora)
                .ToList();
        }

        public Dictionary<string, int> GetLogCountByAction()
        {
            var logs = Listar();
            return logs
                .GroupBy(log => log.Accion)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<int, int> GetLogCountByUser()
        {
            var logs = Listar();
            return logs
                .GroupBy(log => log.IdUsuario)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<DateTime, int> GetLogCountByDate()
        {
            var logs = Listar();
            return logs
                .GroupBy(log => log.FechaHora.Date)
                .ToDictionary(g => g.Key, g => g.Count());
        }

    }
}