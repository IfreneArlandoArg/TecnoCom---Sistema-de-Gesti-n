using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLComponente
    {
        DALComponente dalComponente = new DALComponente();

        public List<Componente> ObtenerJerarquia()
        {
            return dalComponente.ObtenerJerarquia();
        }


        public void Alta(Componente componente, int? idPadre)
        {

            dalComponente.AltaComponente(componente, idPadre);
        }

        public void Baja(int id)
        {
            dalComponente.Baja(id);
        }

        public void Modificar(Componente componente)
        {
            dalComponente.Modificar(componente);
        }

        public void AsignarHijo(int idPadre, int idHijo)
        {
            dalComponente.AsignarHijo(idPadre, idHijo);
        }

        public void DesasignarHijo(int idPadre, int idHijo)
        {
            dalComponente.DesasignarHijo(idPadre, idHijo);

        }

        public List<Componente> Listar()
        {
            return dalComponente.Listar();
        }

    }
}