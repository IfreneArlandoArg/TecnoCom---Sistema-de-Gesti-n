using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLTraduccion
    {
        private DALTraduccion dal = new DALTraduccion();

        public List<Traduccion> ObtenerPorIdioma(int idiomaId) =>
            dal.ObtenerPorIdioma(idiomaId);

        public void GuardarTraducciones(int idiomaId, List<Traduccion> traducciones)
        {
            foreach (var t in traducciones)
            {
                dal.Guardar(idiomaId, t);
            }
        }
    }

}