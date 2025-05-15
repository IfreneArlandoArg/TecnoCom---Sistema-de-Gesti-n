using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class BLLRol
    {
        DALRol dalRol = new DALRol();
        public List<BERol> Listar()
        {
            return dalRol.Listar();
        }
    }
}