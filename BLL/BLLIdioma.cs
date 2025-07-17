using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLIdioma
    {
        private DALIdioma dal = new DALIdioma();

        public List<Idioma> ObtenerTodos() => dal.ObtenerTodos();

        public void Insertar(Idioma idioma) => dal.Insertar(idioma);
    }

}