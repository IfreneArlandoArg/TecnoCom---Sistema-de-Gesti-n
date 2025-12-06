using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class Login : Form, IIdiomaObserver
    {
        public Login()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

        BLLUsuario bllUsuario = new BLLUsuario();
        BLLUsuarioLog log = new BLLUsuarioLog();
        BLLIdioma bllIdioma = new BLLIdioma();
        BLLProducto bllProducto = new BLLProducto();
        int ConteoLogin = 0;
        


        public void ActualizarIdioma(Idioma idioma)
        {
            this.Text = Traductor.Instancia.Traducir(this.Name);
            TraducirControles(this.Controls);
        }

        private void TraducirControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {

                if (!string.IsNullOrEmpty(control.Name) && !(control is TextBox))
                {
                    string textoTraducido = Traductor.Instancia.Traducir(control.Name);
                    if (!string.IsNullOrEmpty(textoTraducido))
                        control.Text = textoTraducido;
                }


                if (control.HasChildren)
                    TraducirControles(control.Controls);

                if (control is TextBox)
                {
                    control.Text = String.Empty;
                }

            }
        }
        private void chBVerPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chBVerPass.Checked)
            {
                txtPassword.PasswordChar = char.MinValue;
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void handleExceededAttempts()
        {
            MessageBox.Show("Ha excedido el número de intentos permitidos. La aplicación se cerrará.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ConteoLogin++;
                
                UpdateLblIntentos();

                if (ConteoLogin > 3)
                {
                    handleExceededAttempts();
                    
                }

                if (txtEmail.Text == string.Empty)
                    throw new Exception("El campo email tiene qué tener un valor...");

                if (txtPassword.Text == string.Empty)
                    throw new Exception("El campo password tiene qué tener un valor...");

                

                BEUsuario tmpUsuario;


                string passwordHasheada = Encriptador.HashearConSHA256(txtPassword.Text);

                

                bool registrado = bllUsuario.IsUserRegistered(txtEmail.Text, passwordHasheada, out tmpUsuario);

                if (!registrado)
                    throw new Exception("Email y/o Password incorrecto...");

                if(!tmpUsuario.Activo)
                    throw new Exception("El usuario se encuentra inactivo. Contacte con un administrador...");

                var resultado = bllProducto.VerificarIntegridad();

                LoginSession.Instancia.Login(tmpUsuario);

                if (!resultado.IntegridadOk)
                {
                    if(!bllUsuario.EsAdmin(tmpUsuario))
                    throw new Exception("La integridad de los productos ha sido comprometida. Contacte con un administrador...");

                    //Actions for admin users.....below...
                    Form frmProductosCorruptos = new ProductosCorruptos(resultado.ProductosCorruptos);
                    frmProductosCorruptos.ShowDialog();
                    throw new Exception($"Admin  : {LoginSession.Instancia.UsuarioActual.Apellido}, {LoginSession.Instancia.UsuarioActual.Nombre}\nLa integridad de los productos ha sido comprometida. \nHacer Login...");
                }


                


                Form frm = new FormAdmin();



               

                BEUsuarioLog beUsuarioLog = new BEUsuarioLog(tmpUsuario.IdUsuario, "Login");

                log.Alta(beUsuarioLog);

                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;

                ConteoLogin = 0;

                frm.ShowDialog();

                


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        void UpdateLblIntentos() 
        {
           lblIntentos.Text = Traductor.Instancia.Traducir("lblIntentos") +  $" {ConteoLogin}";
          
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                Idioma idiomaPredeterminado = bllIdioma.ObtenerTodos().FirstOrDefault(i => i.Codigo == "es");

                Traductor.Instancia.CambiarIdioma(idiomaPredeterminado);

                UpdateLblIntentos();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void GestionClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Traductor.Instancia.Desuscribir(this);

        }

    }
}
