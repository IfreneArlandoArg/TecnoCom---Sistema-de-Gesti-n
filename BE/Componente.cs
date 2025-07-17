using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public abstract class Componente
    {
        public string Nombre { get; set; }
        public int Id { get; set; }

        public abstract IList<Componente> Hijos { get; }
        public abstract void AgregarHijo(Componente c);

        public abstract bool Validar(Componente c);

        
        


    }

    public class Patente : Componente
    {
        public Patente(int pID, string pNombre)
        {
            Nombre = pNombre;
            Id = pID;

        }

        public override IList<Componente> Hijos
        {
            get
            {
                return null;
            }

        }

        public override void AgregarHijo(Componente c)
        {

        }

        public override bool Validar(Componente c)
        {
            return this.Id == c.Id;
        }


        public override string ToString()
        {
            return $"{Nombre} - Patente";

        }
    }

    public class Familia : Componente
    {
        private IList<Componente> _hijos;
        public Familia()
        {
            _hijos = new List<Componente>();
        }

        public Familia(int pID, string pNombre)
        {
            _hijos = new List<Componente>();
            Id = pID;
            Nombre = pNombre;
        }

        public override IList<Componente> Hijos
        {
            get
            {
                return _hijos.ToArray();
            }

        }

        public override void AgregarHijo(Componente c)
        {
            if(!Validar(c))
            _hijos.Add(c);
        }


        public override bool Validar(Componente c)
        {
            foreach (var hijo in _hijos)
            {
                if (hijo.Validar(c)) return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Nombre} - Familia";

        }

    }
}