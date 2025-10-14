using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace GUI
{
    public partial class GestionBitacoraForm : Form, IIdiomaObserver
    {
        public GestionBitacoraForm()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

        BLLUsuarioLog bllUsuarioLog = new BLLUsuarioLog();
        BLLUsuario bLLUsuario = new BLLUsuario();

        void mostrarDTGV(DataGridView dtgv, object pO)
        {
            dtgv.DataSource = null;
            dtgv.DataSource = pO;
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

                if (!string.IsNullOrEmpty(control.Name) && !(control is TextBox) && !(control is ComboBox))
                {
                    string textoTraducido = Traductor.Instancia.Traducir(control.Name);
                    if (!string.IsNullOrEmpty(textoTraducido))
                        control.Text = textoTraducido;
                }


                if (control.HasChildren )
                    TraducirControles(control.Controls);

                if (control is TextBox)
                {
                    control.Text = String.Empty;
                }

                if(control is ComboBox)
                {
                    (control as ComboBox).Items.Clear();

                    LoadComboBoxes();

                }

                

            }
        }


        private void LoadLogChartFactCount(Dictionary<string, int> logCounts, Chart chart, SeriesChartType charType, OrderBy orderBy)
        {
            
            
            chart.Series.Clear();
            var series = new Series
            {
                Name = orderBy.ToString()+"s",
                ChartType = charType
            };
            chart.Series.Add(series);

            foreach (var kvp in logCounts)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            chart.ChartAreas[0].AxisX.Title = orderBy.ToString();
            chart.ChartAreas[0].AxisY.Title = "Quantity";
        }

        private void LoadLogChartFactCount(Dictionary<DateTime, int> logCounts, Chart chart, SeriesChartType charType, OrderBy orderBy)
        {


            chart.Series.Clear();
            var series = new Series
            {
                Name = orderBy.ToString() + "s",
                ChartType = charType
            };
            chart.Series.Add(series);

            foreach (var kvp in logCounts)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            chart.ChartAreas[0].AxisX.Title = orderBy.ToString();
            chart.ChartAreas[0].AxisY.Title = "Quantity";
        }

        void LoadComboBoxes() 
        {
            comboBoxFacts.Items.Add(OrderBy.Action);
            comboBoxFacts.Items.Add(OrderBy.Date);
            comboBoxFacts.Items.Add(OrderBy.User);

            comboBoxFacts.SelectedIndex = 0;


            comboBoxActions.Items.Add("All");
            comboBoxActions.Items.Add(EnumAccion.Login);
            comboBoxActions.Items.Add(EnumAccion.Logout);
            comboBoxActions.Items.Add(EnumAccion.Alta_Usuario);
            comboBoxActions.Items.Add(EnumAccion.Baja_Usuario);
            comboBoxActions.Items.Add(EnumAccion.Modificacion_Usuario);
            comboBoxActions.Items.Add(EnumAccion.Alta_Cliente);
            comboBoxActions.Items.Add(EnumAccion.Baja_Cliente);
            comboBoxActions.Items.Add(EnumAccion.Modificacion_Cliente);
            comboBoxActions.Items.Add(EnumAccion.Alta_Producto);
            comboBoxActions.Items.Add(EnumAccion.Baja_Producto);
            comboBoxActions.Items.Add(EnumAccion.Modificacion_Producto);
            comboBoxActions.Items.Add(EnumAccion.Alta_Factura);
            comboBoxActions.Items.Add(EnumAccion.Alta_Permiso_Usuario);
            comboBoxActions.Items.Add(EnumAccion.Baja_Permiso_Usuario);
            comboBoxActions.Items.Add(EnumAccion.Cambio_Idioma);

            comboBoxActions.SelectedIndex = 0;

            
        }
      
        private void GestionBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                //mostrarDTGV(dtgvLogs, bllUsuarioLog.Listar());

                LoadComboBoxes();

                //LoadLogChartFactCount( bllUsuarioLog.GetLogCountByAction() ,chartLogManagement, SeriesChartType.Column, OrderBy.Action);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxFacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxFacts.Items.Count > 0)
                {
                    var selectedOrderBy = (OrderBy)comboBoxFacts.SelectedItem;

                    switch (selectedOrderBy) 
                    { 
                       case OrderBy.Action:
                            LoadLogChartFactCount(bllUsuarioLog.GetLogCountByAction(), chartLogManagement, SeriesChartType.Funnel, OrderBy.Action);
                            break;
                       case OrderBy.Date:
                            LoadLogChartFactCount(bllUsuarioLog.GetLogCountByDate(), chartLogManagement, SeriesChartType.Line, OrderBy.Date);
                            break;
                       case OrderBy.User:
                            LoadLogChartFactCount(bllUsuarioLog.GetLogCountByUser().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value), chartLogManagement, SeriesChartType.Pie, OrderBy.User);
                            break;
                    }
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxActions.Items.Count > 0)
                {
                    switch (comboBoxActions.SelectedItem) 
                    { 
                      case "All":
                            mostrarDTGV(dtgvLogs, bllUsuarioLog.Listar());
                            break;
                      default:
                            mostrarDTGV(dtgvLogs, bllUsuarioLog.Listar((EnumAccion)comboBoxActions.SelectedItem));
                            break;
                    }



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvLogs_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dtgvLogs.SelectedRows.Count > 0)
                {
                    lstBUserLog.DataSource = null;
                    lstBUserLog.DataSource = bLLUsuario.Listar((dtgvLogs.CurrentRow.DataBoundItem as BEUsuarioLog).IdUsuario);
                }
                else
                {
                    lstBUserLog.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
