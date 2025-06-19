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
using BE;


namespace GUI
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        
     //   BLLRol bllRol = new BLLRol();
        BLLUsuarioLog log = new BLLUsuarioLog();
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = ConfirmationMessageBox.Mostrar("¿Deseas cerrar la sesión?", "Confirmar");

                if (result == DialogResult.Yes)
                {

                    BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Logout");
                    log.Alta(beUsuarioLog);

                    LoginSession.Instancia.Logout();

                   

                    this.Close();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            try
            {
               

                toolStripStatusLabel.Text += $" {LoginSession.Instancia.UsuarioActual.Apellido}, {LoginSession.Instancia.UsuarioActual.Nombre} ";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionDePerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Cerrar cualquier formulario hijo que esté abierto
                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Close();
                }

                // Crear una nueva instancia del formulario de gestión de perfiles
                GestionPerfiles gestionPerfiles = new GestionPerfiles();
                gestionPerfiles.MdiParent = this; // Establecer FormAdmin como contenedor MDI
                gestionPerfiles.WindowState = FormWindowState.Maximized; // Opcional: maximizar al abrir
                gestionPerfiles.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
