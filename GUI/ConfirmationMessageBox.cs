using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConfirmationMessageBox : Form, IIdiomaObserver
    {
        private string tituloKey;

       

        public ConfirmationMessageBox(string mensaje, string tituloKey)
        {
            InitializeComponent();

            this.tituloKey = tituloKey;

            Traductor.Instancia.Suscribir(this);
            lblMensaje.Text = mensaje;

            TraducirControles(); 
        }

        public void ActualizarIdioma(Idioma idioma)
        {
            TraducirControles(); 
        }

        private void TraducirControles()
        {
            
            this.Text = Traductor.Instancia.Traducir(tituloKey);

            
            btnSi.Text = Traductor.Instancia.Traducir(btnSi.Name);
            btnNo.Text = Traductor.Instancia.Traducir(btnNo.Name);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Traductor.Instancia.Desuscribir(this);
        }


        public static DialogResult Mostrar(string mensaje, string tituloKey)
        {
            using (var form = new ConfirmationMessageBox(mensaje, tituloKey))
            {
                return form.ShowDialog();
            }
        }

    }
}
