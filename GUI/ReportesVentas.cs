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
using BE;
using System.Windows.Forms.DataVisualization.Charting;


namespace GUI
{
    public partial class ReportesVentas : Form, IIdiomaObserver
    {
        public ReportesVentas()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

        BLLFactura bllFactura = new BLLFactura();

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

        void mostrarLstBox(ListBox lstB, object pO)
        {
            lstB.DataSource = null;
            lstB.DataSource = pO;
        }

        void mostrarDTGV(DataGridView dtgv, object pO)
        {
            dtgv.DataSource = null;
            dtgv.DataSource = pO;
        }

        private void MostrarGraficoRanking()
        {
            // Diccionario para acumular cantidades vendidas por producto
            Dictionary<string, int> ranking = new Dictionary<string, int>();

            foreach (var factura in bllFactura.Listar())
            {
                foreach (var item in factura.ListaProductos)
                {
                    string nombreProducto = item.Producto.Nombre;
                    int cantidad = item.Cantidad;

                    if (ranking.ContainsKey(nombreProducto))
                        ranking[nombreProducto] += cantidad;
                    else
                        ranking[nombreProducto] = cantidad;
                }
            }

            
            chartRanking.Series["Productos"].Points.Clear();

            
            foreach (var item in ranking.OrderByDescending(p => p.Value))
            {
                chartRanking.Series["Productos"].Points.AddXY(item.Key, item.Value);
            }
        }


        public static List<(BECliente Cliente, decimal MontoTotal, int CantidadTotal)> ObtenerClientesOrdenados(List<BEFactura> facturas)
        {
            var resumenClientes = facturas
                .SelectMany(f => f.ListaProductos.Select(item => new
                {
                    Cliente = f.Cliente,
                    ClienteDNI = f.Cliente.DNI, 
                    f.Cliente.Nombre,
                    f.Cliente.Apellido,
                    item.Producto,
                    item.Cantidad,
                    TotalItem = item.TotalPrecioItem()
                }))
                .GroupBy(x => x.ClienteDNI)
                .Select(g => new
                {
                    Cliente = new BECliente(g.Key, g.First().Nombre, g.First().Apellido, g.First().Cliente.Email),
                    MontoTotal = g.Sum(x => x.TotalItem),
                    CantidadTotal = g.Sum(x => x.Cantidad)
                })
                .OrderByDescending(x => x.MontoTotal)
                .ThenByDescending(x => x.CantidadTotal)
                .Take(10) 
                .ToList();

            return resumenClientes
                .Select(x => (x.Cliente, x.MontoTotal, x.CantidadTotal))
                .ToList();
        }




        public void MostrarClientesEnPieChart(List<(BECliente Cliente, decimal MontoTotal, int CantidadTotal)> clientesOrdenados)
        {
        
          chartClientes.Series.Clear();
          chartClientes.Titles.Clear();

        
          Series serie = new Series("Clientes");
          serie.ChartType = SeriesChartType.Pie;
          serie.IsValueShownAsLabel = true;

        
          foreach (var item in clientesOrdenados)
          {
            string nombreCliente = item.Cliente.ToString() + $",{item.Cliente.DNI}"; 
            serie.Points.AddXY(nombreCliente, item.MontoTotal);
          }

        
           chartClientes.Series.Add(serie);

        
           //chartClientes.Titles.Add("Clientes que más gastaron");

        
          chartClientes.Legends[0].Enabled = true;
          chartClientes.Legends[0].Docking = Docking.Right;
        }




    void mostrar() 
        {
            mostrarDTGV(dtgvVentas, bllFactura.Listar());
            MostrarGraficoRanking();
            MostrarClientesEnPieChart(ObtenerClientesOrdenados(bllFactura.Listar()));

        }
        private void ReportesVentas_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarIdioma(Traductor.Instancia.IdiomaActual);
                mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ReportesVentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Traductor.Instancia.Desuscribir(this);

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dtgvVentas.SelectedRows.Count > 0) 
                {
                    mostrarLstBox(lstBProductosSeleccionados, (dtgvVentas.CurrentRow.DataBoundItem as BEFactura).ListaProductos);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gbVentas_Enter(object sender, EventArgs e)
        {

        }
    }
}
