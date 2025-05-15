using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public BERol Rol { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public bool Activo { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }


        public BEUsuario(string pIdUsuario, string pNombre, string pApellido, BERol pRol, string pfechaNacimiento, string pActivo, string pEmail, string pPasswordHash ) 
        {
            DateTime tmpDate;

            if(!DateTime.TryParse(pfechaNacimiento, out tmpDate)) 
            {
                throw new Exception($"Error (\"Formato\") con la fecha de nacimiento {pfechaNacimiento} del usuario : {pApellido}, {pNombre}" +
                    $"\nEmail : {pEmail}\nRol : {pRol.NombreRol}");
            }


            IdUsuario = int.Parse(pIdUsuario);
            Nombre = pNombre;
            Apellido = pApellido;
            Rol = pRol;
            FechaNacimiento = tmpDate;
            Activo = bool.Parse(pActivo);   
            Email = pEmail; 
            PasswordHash = pPasswordHash;
                 
        }


        public BEUsuario(string pNombre, string pApellido, BERol pRol, DateTime pfechaNacimiento, string pEmail, string pPasswordHash)
        {
           
            Nombre = pNombre;
            Apellido = pApellido;
            Rol = pRol;
            FechaNacimiento = pfechaNacimiento;
            Email = pEmail;
            PasswordHash = pPasswordHash;

        }




    }
}
