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
    public partial class gestionProductos : Form, IIdiomaObserver
    {
        public gestionProductos()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

        BLLProducto bllProducto = new BLLProducto();
        BLLProductoPrecioLog bllProductoPrecioLog = new BLLProductoPrecioLog();
        BLLUsuario bllUsuario = new BLLUsuario();

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

        void mostrarProductos()
        {
            mostrar(dtgvProductos, bllProducto.Listar());
        }

        private void gestionProductos_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarIdioma(Traductor.Instancia.IdiomaActual);
                mostrarProductos();

                groupBoxAlta.Visible = checkBoxAlta.Checked;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtNombre.Text == string.Empty)
                    throw new Exception("Campo nombre vacio...");
                if (txtDescripcion.Text == string.Empty)
                    throw new Exception("Campo descripción vacio...");
                if (numPrecio.Value <= 0)
                    throw new Exception("El precio debe ser mayor a 0...");
                if (numStock.Value < 0)
                    throw new Exception("El stock no puede ser negativo...");


                bllProducto.Alta(new BEProducto(txtNombre.Text, txtDescripcion.Text, (decimal)numPrecio.Value, (int)numStock.Value));

                mostrarProductos();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                BEProducto prodSeleccionado = (BEProducto)dtgvProductos.CurrentRow.DataBoundItem;

                if (prodSeleccionado.Nombre == string.Empty)
                    throw new Exception("Campo nombre vacio...");
                if (prodSeleccionado.Descripcion == string.Empty)
                    throw new Exception("Campo descripción vacio...");
                if (prodSeleccionado.Precio <= 0)
                    throw new Exception("El precio debe ser mayor a 0...");
                if (prodSeleccionado.Stock < 0)
                    throw new Exception("El stock no puede ser negativo...");


                bllProducto.Modificar(prodSeleccionado);

                mostrarProductos();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                BEProducto prodSeleccionado = (BEProducto)dtgvProductos.CurrentRow.DataBoundItem;
                bllProducto.baja(prodSeleccionado);

                mostrarProductos();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxAlta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                 
                   groupBoxAlta.Visible = checkBoxAlta.Checked;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dtgvProductos.SelectedRows.Count > 0) 
                { 
                   mostrar(dtgvLogsPrecios, bllProductoPrecioLog.Listar((dtgvProductos.CurrentRow.DataBoundItem as BEProducto).ID));
                }
                else 
                { 
                   mostrar(dtgvLogsPrecios, new List<BEProductoPrecioLog>());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvLogsPrecios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvLogsPrecios.SelectedRows.Count > 0) 
                {
                    listBoxUsuarios.DataSource = null;
                    listBoxUsuarios.DataSource = bllUsuario.Listar((dtgvLogsPrecios.CurrentRow.DataBoundItem as BEProductoPrecioLog).getIdUsuario());
                }
                else
                {
                    listBoxUsuarios.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
            try
            {
                if(dtgvLogsPrecios.SelectedRows.Count == 0)
                    throw new Exception("No hay ningún log seleccionado...\nNo se hicieron\\registró ningún cambio de precio.");

                BEProducto prodSeleccionado = (BEProducto)dtgvProductos.CurrentRow.DataBoundItem;

                BEProductoPrecioLog logSeleccionado = (BEProductoPrecioLog)dtgvLogsPrecios.CurrentRow.DataBoundItem;

                prodSeleccionado.Precio = logSeleccionado.Precio;

                if (prodSeleccionado.Nombre == string.Empty)
                    throw new Exception("Campo nombre vacio...");
                if (prodSeleccionado.Descripcion == string.Empty)
                    throw new Exception("Campo descripción vacio...");
                if (prodSeleccionado.Precio <= 0)
                    throw new Exception("El precio debe ser mayor a 0...");
                if (prodSeleccionado.Stock < 0)
                    throw new Exception("El stock no puede ser negativo...");

                bllProducto.Modificar(prodSeleccionado);

                mostrarProductos();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
