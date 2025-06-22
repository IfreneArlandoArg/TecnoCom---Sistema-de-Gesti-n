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

namespace GUI
{
    public partial class GestionPerfiles : Form
    {
        public GestionPerfiles()
        {
            InitializeComponent();
        }

        BLLPermiso permisosDisponibles = new BLLPermiso();

        void mostrar(DataGridView dtgv, Object pO) 
        { 
            dtgv.DataSource = null;
            dtgv.DataSource = pO;
        
        }

        void mostrarPermisos() 
        {
            mostrar(dataGridView1, permisosDisponibles.Listar());
        }
        private void GestionPerfiles_Load(object sender, EventArgs e)
        {
            try
            {
                mostrarPermisos();
                
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error");
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
