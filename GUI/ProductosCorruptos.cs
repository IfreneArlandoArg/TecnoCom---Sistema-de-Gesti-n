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
using BLL;

namespace GUI
{
    public partial class ProductosCorruptos : Form
    {

        List<BEProducto> productosCorruptos = new List<BEProducto>();

        public ProductosCorruptos(List<BEProducto> productosCorruptos)
        {
            InitializeComponent();
            this.productosCorruptos = productosCorruptos;
        }

        BLLProducto bllProducto = new BLLProducto();

        void MostrarDTGV(DataGridView dtgv, object pO) 
        { 
            dtgv.DataSource = null;
            dtgv.DataSource = pO;
        }

        private void ProductosCorruptos_Load(object sender, EventArgs e)
        {
            MostrarDTGV(dtgvProductosCorruptos, productosCorruptos);
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
              foreach(BEProducto producto in productosCorruptos) 
              { 
                  bllProducto.RestaurarDesdeHistorial(producto.ID, LoginSession.Instancia.UsuarioActual.IdUsuario);
              }

                MessageBox.Show("Productos restaurados correctamente. Por favor reinicie Login.", "Info", MessageBoxButtons.OK);

                this.Close();
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message,"Error", MessageBoxButtons.OK);
            }
        }
    }
}
