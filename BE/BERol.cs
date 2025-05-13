using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BERol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public BERol(string pIdRol, string pNombreRol) 
        { 
            IdRol = int.Parse(pIdRol);
            NombreRol = pNombreRol;
        
        }

        public override string ToString()
        {
            return NombreRol;
        }
    }
}