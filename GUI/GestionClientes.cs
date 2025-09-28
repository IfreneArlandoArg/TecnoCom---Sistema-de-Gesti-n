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
    public partial class GestionClientes : Form, IIdiomaObserver
    {
        public GestionClientes()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

        BLLCliente bllCliente = new BLLCliente();
        

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



        void mostrar(DataGridView dtgv, object pO) 
        {
            dtgv.DataSource = null;
            dtgv.DataSource = pO;
        
        }

        void mostrarClientes() 
        {
            mostrar(dtgvGestionClientes, bllCliente.Listar());
        }
        private void GestionClientes_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarIdioma(Traductor.Instancia.IdiomaActual);
                mostrarClientes();
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

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                int dni;
                if (!(int.TryParse(txtDNI.Text, out dni)))
                    throw new Exception("Formato DNI incorrecto.\nTiene que ser un valor numerico...");

                if (txtNombre.Text == string.Empty)
                    throw new Exception("Campo nombre vacio...");
                if (txtApellido.Text == string.Empty)
                    throw new Exception("Campo Apellido vacio...");
                if (txtEmail.Text == string.Empty)
                    throw new Exception("Campo email vacio...");


                bllCliente.Alta(new BECliente(dni, txtNombre.Text, txtApellido.Text, txtEmail.Text));

                

                mostrarClientes();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if(dtgvGestionClientes.SelectedRows.Count == 0)
                    throw new Exception("Hay qué seleccionar Cliente para dar de baja...");

                BECliente tmpCliente = dtgvGestionClientes.CurrentRow.DataBoundItem as BECliente;
                

                DialogResult result = MessageBox.Show($"¡Estás a punto de borrar el cliente!  \n{tmpCliente.Nombre} {tmpCliente.Apellido} ", "Confirmar",MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes) 
                { 
                  bllCliente.Baja(tmpCliente);
                  mostrarClientes();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvGestionClientes.SelectedRows.Count == 0)
                    throw new Exception("Hay qué seleccionar Cliente para dar de baja...");

                if (txtNombre.Text == string.Empty)
                    throw new Exception("Campo nombre vacio...");
                if (txtApellido.Text == string.Empty)
                    throw new Exception("Campo Apellido vacio...");
                if (txtEmail.Text == string.Empty)
                    throw new Exception("Campo email vacio...");

                BECliente tmpCliente = dtgvGestionClientes.CurrentRow.DataBoundItem as BECliente;


                BECliente nuevoCliente = new BECliente(tmpCliente.DNI, txtNombre.Text, txtApellido.Text, txtEmail.Text);


                DialogResult result = MessageBox.Show($"¡Estás a punto de modificar el cliente {tmpCliente.Nombre}!" , "Confirmar", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    bllCliente.Modificar(nuevoCliente);
                    mostrarClientes();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
