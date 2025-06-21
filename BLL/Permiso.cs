using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Permiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Permiso(string pNombre, string pDescripcion) 
        { 
           Nombre = pNombre;
           Descripcion = pDescripcion;
        }

        public Permiso(string pID, string pNombre, string pDescripcion)
        {
            Id = int.Parse(pID);
            Nombre = pNombre;
            Descripcion = pDescripcion;
        }


        public virtual bool Validar(Permiso pPermiso) 
        {
            return (this.Id == pPermiso.Id);
        }

    }
}