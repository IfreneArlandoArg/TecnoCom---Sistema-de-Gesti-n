using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Traductor
    {
        private static Traductor _instancia;
        private List<IIdiomaObserver> _observadores = new List<IIdiomaObserver>();
        private Idioma _idiomaActual;
        private Dictionary<string, string> _traducciones = new Dictionary<string, string>();

        private Traductor() { }

        public static Traductor Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Traductor();
                return _instancia;
            }
        }


        public void Suscribir(IIdiomaObserver obs)
        {
            if (!_observadores.Contains(obs)) _observadores.Add(obs);
        }

        public void Desuscribir(IIdiomaObserver obs)
        {
            _observadores.Remove(obs);
        }

        public void CambiarIdioma(Idioma idioma)
        {
            _idiomaActual = idioma;
            CargarTraducciones(idioma);
            Notificar();
        }

        private void CargarTraducciones(Idioma idioma)
        {
            _traducciones.Clear();
            var lista = new BLLTraduccion().ObtenerPorIdioma(idioma.Id);
            foreach (var t in lista)
                _traducciones[t.Etiqueta] = t.Texto;
        }

        private void Notificar()
        {
            foreach (var obs in _observadores)
                obs.ActualizarIdioma(_idiomaActual);
        }

        public string Traducir(string etiqueta)
        {
            return _traducciones.ContainsKey(etiqueta) ? _traducciones[etiqueta] : $"[{etiqueta}]";
        }

        public Idioma IdiomaActual => _idiomaActual;
    }

}