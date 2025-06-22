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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        BLLUsuario bllUsuario = new BLLUsuario();
        BLLUsuarioLog log = new BLLUsuarioLog();

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


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text == string.Empty)
                    throw new Exception("El campo email tiene qué tener un valor...");

                if (txtPassword.Text == string.Empty)
                    throw new Exception("El campo password tiene qué tener un valor...");

                

                BEUsuario tmpUsuario;


                string passwordHasheada = Encriptador.HashearConSHA256(txtPassword.Text);

                //txtPassword.Text = passwordHasheada;

                bool registrado = bllUsuario.IsUserRegistered(txtEmail.Text, passwordHasheada, out tmpUsuario);

                if (!registrado)
                    throw new Exception("Email y/o Password incorrecto...");

                LoginSession.Instancia.Login(tmpUsuario);


                Form frm = new FormAdmin();



                //if (tmpUsuario.Rol.Nombre == "Admin") 
                //{
                //    frm = new FormAdmin();

                //}

                BEUsuarioLog beUsuarioLog = new BEUsuarioLog(tmpUsuario.IdUsuario, "Login");

                log.Alta(beUsuarioLog);

                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;

                frm.ShowDialog();

                


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

      

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
