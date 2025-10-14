
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

        private List<Componente> permisos = new List<Componente>();

        public List<Componente> Permisos
        {
            get { return permisos; }
            
        }


        public DateTime FechaNacimiento { get; set; }

        public bool Activo { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }


        public BEUsuario(string pIdUsuario, string pNombre, string pApellido, string pfechaNacimiento, string pActivo, string pEmail, string pPasswordHash ) 
        {
            DateTime tmpDate;

            if(!DateTime.TryParse(pfechaNacimiento, out tmpDate)) 
            {
                throw new Exception($"Error (\"Formato\") con la fecha de nacimiento {pfechaNacimiento} del usuario : {pApellido}, {pNombre}" +
                    $"\nEmail : {pEmail}");
            }


            IdUsuario = int.Parse(pIdUsuario);
            Nombre = pNombre;
            Apellido = pApellido;
           
            FechaNacimiento = tmpDate;
            Activo = bool.Parse(pActivo);   
            Email = pEmail; 
            PasswordHash = pPasswordHash;
                 
        }


        public BEUsuario(string pNombre, string pApellido, DateTime pfechaNacimiento, string pEmail, string pPasswordHash)
        {
           
            Nombre = pNombre;
            Apellido = pApellido;
           
            FechaNacimiento = pfechaNacimiento;
            Email = pEmail;
            PasswordHash = pPasswordHash;

        }

        public void AgregarPermiso(Componente pPermiso)
        {
            

            if (!permisos.Any(p => p.Validar(pPermiso)))
            {
                permisos.Add(pPermiso);
            }
           
        }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre} - {(Activo ? "Activo" : "Inactivo")}\r\n";

        }

        public string NombreCompleto()
        {
            return $"{Apellido}, {Nombre}";
        }



    }
}
