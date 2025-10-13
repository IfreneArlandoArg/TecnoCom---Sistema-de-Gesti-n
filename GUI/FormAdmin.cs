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
using System.Security.Cryptography;


namespace GUI
{
    public partial class FormAdmin : Form, IIdiomaObserver
    {
        public FormAdmin()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

        BLLComponente bLLComponente = new BLLComponente();
        BLLUsuarioLog log = new BLLUsuarioLog();
        BLLIdioma bllIdioma = new BLLIdioma();



        public void ActualizarIdioma(Idioma idioma)
        {
            this.Text = Traductor.Instancia.Traducir(this.Name);
            TraducirControles(this.Controls);
            TraducirMenuItems(menuStrip1.Items);
            TraducirStatusStrip();
        }

        private void TraducirControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (!string.IsNullOrEmpty(control.Name))
                {
                    string textoTraducido = Traductor.Instancia.Traducir(control.Name);
                    if (!string.IsNullOrEmpty(textoTraducido))
                        control.Text = textoTraducido;
                }

                if (control.HasChildren)
                    TraducirControles(control.Controls);

                if(control is ComboBox && (cmbIdiomas.Items.Count != bllIdioma.ObtenerTodos().Count)) 
                { 
                   CargarIdiomasMain();
                }
            }
        }

        private void TraducirMenuItems(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    string textoTraducido = Traductor.Instancia.Traducir(item.Name);
                    if (!string.IsNullOrEmpty(textoTraducido))
                        item.Text = textoTraducido;
                }

                if (item is ToolStripMenuItem menuItem && menuItem.HasDropDownItems)
                {
                    TraducirMenuItems(menuItem.DropDownItems);
                }
            }
        }

        private void TraducirStatusStrip()
        {
            foreach (ToolStripItem item in statusStrip1.Items)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    string textoTraducido = Traductor.Instancia.Traducir(item.Name);
                    if (!string.IsNullOrEmpty(textoTraducido))
                        item.Text = textoTraducido;
                }
            }
        }


        void cerrarFormsHijos() 
        {
            
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        } 

        void mostrarForm(Form form) 
        {

            form.MdiParent = this; 
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                

                DialogResult result = ConfirmationMessageBox.Mostrar(Traductor.Instancia.Traducir("CerrarSesion_Mensaje"), "ConfirmationMessageBox");


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
            btnCerrarSesion.Location = new Point(this.ClientSize.Width - btnCerrarSesion.Width - 10, this.ClientSize.Height - statusStrip1.Height - btnCerrarSesion.Height - 5);
        
        }


        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void CargarIdiomasMain() 
        {
            
            cmbIdiomas.DataSource = bllIdioma.ObtenerTodos() ;
            cmbIdiomas.DisplayMember = "Nombre";
            cmbIdiomas.ValueMember = "Id";
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                List<Componente> patentesDisponibles = bLLComponente.Listar().Where(p => p is Patente).ToList();



                foreach (Componente c in patentesDisponibles)
                {
                    if (!LoginSession.Instancia.UsuarioActual.Permisos.Any(p => p.Validar(c)))
                    {
                        var item = menuStrip1.Items.OfType<ToolStripItem>().FirstOrDefault(i => i.Name == $"{c.Nombre}ToolStripMenuItem");

                        if (item != null)
                        {
                            menuStrip1.Items.Remove(item);
                        }
                    }

                }


                CargarIdiomasMain();

                
                Idioma idiomaPredeterminado = bllIdioma.ObtenerTodos().FirstOrDefault(i => i.Codigo == "es"); 
                if (idiomaPredeterminado != null)
                    cmbIdiomas.SelectedItem = idiomaPredeterminado;


                //toolStripStatusLabel.Text += $" : {LoginSession.Instancia.UsuarioActual.Apellido}, {LoginSession.Instancia.UsuarioActual.Nombre} ";


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Traductor.Instancia.Desuscribir(this);
        }



        private void gestionDePerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarFormsHijos();

                
                GestionPerfiles gestionPerfiles = new GestionPerfiles();
                mostrarForm(gestionPerfiles);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarFormsHijos();



                GestionClientes gestionClientes = new GestionClientes();
                mostrarForm(gestionClientes);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestiónDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarFormsHijos();

                gestionProductos gestProductos = new gestionProductos();

                mostrarForm(gestProductos);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarFormsHijos();

                ventaProductos formVentaProductos = new ventaProductos();

                mostrarForm(formVentaProductos);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarFormsHijos();

                mostrarForm(new ReportesVentas());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarFormsHijos();
                mostrarForm(new GestionUsuarios());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionIdiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarFormsHijos();
                

                mostrarForm(new GestionIdiomas());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdiomas.SelectedItem is Idioma idiomaSeleccionado)
            {
                Traductor.Instancia.CambiarIdioma(idiomaSeleccionado);

               

                toolStripStatusLabel.Text += $" : {LoginSession.Instancia.UsuarioActual.Apellido}, {LoginSession.Instancia.UsuarioActual.Nombre} ";
            }
        }

        private void gestionBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarFormsHijos();

                mostrarForm(new GestionBitacora());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
