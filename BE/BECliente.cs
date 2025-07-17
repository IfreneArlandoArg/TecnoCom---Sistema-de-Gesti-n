using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BECliente
    {
        
        public int DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Email { get; set; }


        public BECliente(string pDNI, string pNombre, string pApellido, string pEmail)
        {
            DNI = int.Parse(pDNI);
            Nombre = pNombre;
            Apellido = pApellido;
            Email = pEmail;
        }

        public BECliente(int pDNI, string pNombre, string pApellido, string pEmail)
        {
            DNI = pDNI;
            Nombre = pNombre;
            Apellido = pApellido;
            Email = pEmail;
        }


        public override string ToString()
        {
            return $"{Apellido}, {Nombre}";
        }

    }
}