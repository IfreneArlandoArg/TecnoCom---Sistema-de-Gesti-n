using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BE; 
using BLL;

namespace GUI
{
    public partial class GestionIdiomas : Form, IIdiomaObserver
    {
        private BLLIdioma bllIdioma = new BLLIdioma();
        private BLLTraduccion bllTraduccion = new BLLTraduccion();
        


        public GestionIdiomas()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

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

        private void GestionIdiomas_Load(object sender, EventArgs e)
        {
            ActualizarIdioma(Traductor.Instancia.IdiomaActual);
            CargarIdiomas();
        }

        private void GestionIdiomas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Traductor.Instancia.Desuscribir(this);

        }

        private void CargarIdiomas()
        {
            List<Idioma> idiomas = bllIdioma.ObtenerTodos();
            cmbIdiomas.DataSource = idiomas;
            cmbIdiomas.DisplayMember = "Nombre";
            cmbIdiomas.ValueMember = "Id";
        }

        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbIdiomas.SelectedItem == null) return;

                Idioma idiomaSeleccionado = (Idioma)cmbIdiomas.SelectedItem;

                List<Traduccion> traducciones = bllTraduccion.ObtenerPorIdioma(idiomaSeleccionado.Id);

                //if (traducciones.Count == 0) return;

                dgvTraducciones.Rows.Clear();

                foreach (var t in traducciones)
                {
                    dgvTraducciones.Rows.Add(t.Etiqueta, t.Texto);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnNuevoIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNuevoIdioma.Text.Trim();
                string codigo = txtCodigoIdioma.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("Por favor, completá el nombre y código del nuevo idioma.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Idioma nuevo = new Idioma
                {
                    Nombre = nombre,
                    Codigo = codigo
                };

                bllIdioma.Insertar(nuevo);

                CargarIdiomas();

               

                if (cmbIdiomas.SelectedItem is Idioma idiomaSeleccionado)
                {
                    Traductor.Instancia.CambiarIdioma(idiomaSeleccionado);

                }





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbIdiomas.SelectedItem == null) return;

                Idioma idioma = (Idioma)cmbIdiomas.SelectedItem;
                List<Traduccion> lista = new List<Traduccion>();

                foreach (DataGridViewRow fila in dgvTraducciones.Rows)
                {
                    if (fila.IsNewRow) continue;

                    string etiqueta = fila.Cells["Etiqueta"].Value?.ToString();
                    string texto = fila.Cells["Texto"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(etiqueta))
                    {
                        lista.Add(new Traduccion
                        {
                            Etiqueta = etiqueta,
                            Texto = texto
                        });
                    }
                }

                bllTraduccion.GuardarTraducciones(idioma.Id, lista);
                MessageBox.Show("Traducciones guardadas correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
