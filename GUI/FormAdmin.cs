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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //    DialogResult result = MessageBox.Show("¿Deseas cerrar la sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        //// Podés mostrar el Login o simplemente cerrar el sistema
            //        this.Close();
            //        //// O abrir el formulario Login:
            //        //// new LoginForm().Show();
            //    }


            DialogResult result = ConfirmationMessageBox.Mostrar("¿Deseas cerrar la sesión?", "Confirmar");

            if (result == DialogResult.Yes)
            {
                // this.Close(); o redirigir a Login
                this.Close();

            }



        }

        private void FormAdmin_Resize(object sender, EventArgs e)
        {
            btnCerrarSesion.Location = new Point(
        this.ClientSize.Width - btnCerrarSesion.Width - 10,
        this.ClientSize.Height - statusStrip1.Height - btnCerrarSesion.Height - 5
    );
        }


        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
