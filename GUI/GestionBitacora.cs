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

                if(control is ComboBox comboBox)
                {
                    comboBox.Items.Clear();

                    LoadComboBox(comboBox);

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

        static void AddItemsToComboBox(ComboBox comboBox, Type enumType)
        {
            foreach (var value in Enum.GetValues(enumType))
            {
                comboBox.Items.Add(value);
            }
        }
        static void AddItemsToComboBox(ComboBox comboBox) 
        {
            switch (comboBox.Name)
            {
                case "comboBoxFacts":
                    AddItemsToComboBox(comboBox, typeof(OrderBy));
                    
                    break;
                case "comboBoxActions":
                    AddItemsToComboBox(comboBox, typeof(EnumAccion));
                    
                    break;
                default:
                    throw new ArgumentException("ComboBox no reconocido");


            }   
        }

        static void LoadComboBox(ComboBox comboBox) 
        {
            AddItemsToComboBox(comboBox);

            comboBox.SelectedIndex = 0;
        }

        void LoadComboBoxes() 
        {
            
            LoadComboBox(comboBoxFacts);


            LoadComboBox(comboBoxActions);


        }

        private void GestionBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                

                LoadComboBoxes();

                
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
                     mostrarDTGV(dtgvLogs, bllUsuarioLog.Listar((EnumAccion)comboBoxActions.SelectedItem));
                    
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
