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
    public partial class ConfirmationMessageBox : Form
    {
        public ConfirmationMessageBox(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        public static DialogResult Mostrar(string mensaje, string titulo)
        {
            using (var form = new ConfirmationMessageBox(mensaje))
            {
                form.Text = titulo;
                return form.ShowDialog();
            }
        }

    }
}
