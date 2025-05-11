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

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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

        private void chBNoTengoCuenta_CheckedChanged(object sender, EventArgs e)
        {
           
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
