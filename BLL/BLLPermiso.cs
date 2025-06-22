using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class BLLPermiso
    {
        DALPermiso dalPermiso = new DALPermiso();
        public List<Permiso> Listar()
        {
            return dalPermiso.Listar();
        }
    }
}