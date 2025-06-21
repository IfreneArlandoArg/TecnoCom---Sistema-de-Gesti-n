using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Rol : Permiso
    {
        private List<Permiso> listaPermisos = new List<Permiso>();

        public List<Permiso> ListaPermisos
        {
            get { return listaPermisos; }
            
        }


        public Rol(string pNombre, string pDescripcion) : base(pNombre,pDescripcion) 
        { 
        
        }

        public Rol(string pID, string pNombre, string pDescripcion) : base(pID,pNombre, pDescripcion)
        {

        }

        //Override de Validar
        public override bool Validar(Permiso pPermiso)
        {
            
            

            if (listaPermisos.Count > 0) 
            {
                foreach (Permiso p in listaPermisos) 
                { 
                  if(p.Validar(pPermiso))
                        return true;
                }
            
            }


            return false;
        }

    }
}