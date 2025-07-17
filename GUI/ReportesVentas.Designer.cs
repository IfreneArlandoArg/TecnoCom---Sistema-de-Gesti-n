using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    partial class ReportesVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gbVentas = new System.Windows.Forms.GroupBox();
            this.lblProductosMasVendidos = new System.Windows.Forms.Label();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.lstBProductosSeleccionados = new System.Windows.Forms.ListBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dtgvVentas = new System.Windows.Forms.DataGridView();
            this.chartRanking = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartClientes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTopSpendingCustomers = new System.Windows.Forms.Label();
            this.gbVentas.SuspendLayout();
            this.gbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRanking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVentas
            // 
            this.gbVentas.Controls.Add(this.lblTopSpendingCustomers);
            this.gbVentas.Controls.Add(this.chartClientes);
            this.gbVentas.Controls.Add(this.lblProductosMasVendidos);
            this.gbVentas.Controls.Add(this.gbProductos);
            this.gbVentas.Controls.Add(this.btnRefrescar);
            this.gbVentas.Controls.Add(this.dtgvVentas);
            this.gbVentas.Controls.Add(this.chartRanking);
            this.gbVentas.Location = new System.Drawing.Point(36, 88);
            this.gbVentas.Name = "gbVentas";
            this.gbVentas.Size = new System.Drawing.Size(1877, 973);
            this.gbVentas.TabIndex = 0;
            this.gbVentas.TabStop = false;
            this.gbVentas.Text = "Ventas";
            this.gbVentas.Enter += new System.EventHandler(this.gbVentas_Enter);
            // 
            // lblProductosMasVendidos
            // 
            this.lblProductosMasVendidos.AutoSize = true;
            this.lblProductosMasVendidos.Location = new System.Drawing.Point(52, 479);
            this.lblProductosMasVendidos.Name = "lblProductosMasVendidos";
            this.lblProductosMasVendidos.Size = new System.Drawing.Size(158, 16);
            this.lblProductosMasVendidos.TabIndex = 3;
            this.lblProductosMasVendidos.Text = "Productos Mas Vendidos";
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.lstBProductosSeleccionados);
            this.gbProductos.Location = new System.Drawing.Point(979, 21);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(488, 447);
            this.gbProductos.TabIndex = 1;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "Productos";
            // 
            // lstBProductosSeleccionados
            // 
            this.lstBProductosSeleccionados.FormattingEnabled = true;
            this.lstBProductosSeleccionados.ItemHeight = 16;
            this.lstBProductosSeleccionados.Location = new System.Drawing.Point(63, 47);
            this.lstBProductosSeleccionados.Name = "lstBProductosSeleccionados";
            this.lstBProductosSeleccionados.Size = new System.Drawing.Size(339, 308);
            this.lstBProductosSeleccionados.TabIndex = 0;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(744, 521);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(113, 37);
            this.btnRefrescar.TabIndex = 1;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dtgvVentas
            // 
            this.dtgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvVentas.Location = new System.Drawing.Point(55, 59);
            this.dtgvVentas.Name = "dtgvVentas";
            this.dtgvVentas.RowHeadersWidth = 51;
            this.dtgvVentas.RowTemplate.Height = 24;
            this.dtgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvVentas.Size = new System.Drawing.Size(802, 365);
            this.dtgvVentas.TabIndex = 0;
            this.dtgvVentas.SelectionChanged += new System.EventHandler(this.dtgvVentas_SelectionChanged);
            // 
            // chartRanking
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRanking.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRanking.Legends.Add(legend2);
            this.chartRanking.Location = new System.Drawing.Point(55, 521);
            this.chartRanking.Name = "chartRanking";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "Legend1";
            series2.Name = "Productos";
            this.chartRanking.Series.Add(series2);
            this.chartRanking.Size = new System.Drawing.Size(488, 400);
            this.chartRanking.TabIndex = 2;
            // 
            // chartClientes
            // 
            chartArea1.Name = "ChartArea1";
            this.chartClientes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartClientes.Legends.Add(legend1);
            this.chartClientes.Location = new System.Drawing.Point(956, 521);
            this.chartClientes.Name = "chartClientes";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartClientes.Series.Add(series1);
            this.chartClientes.Size = new System.Drawing.Size(488, 400);
            this.chartClientes.TabIndex = 4;
            this.chartClientes.Text = "chart1";
            // 
            // lblTopSpendingCustomers
            // 
            this.lblTopSpendingCustomers.AutoSize = true;
            this.lblTopSpendingCustomers.Location = new System.Drawing.Point(953, 479);
            this.lblTopSpendingCustomers.Name = "lblTopSpendingCustomers";
            this.lblTopSpendingCustomers.Size = new System.Drawing.Size(200, 20);
            this.lblTopSpendingCustomers.TabIndex = 5;
            this.lblTopSpendingCustomers.Text = "Top Spending Customers";
            // 
            // ReportesVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(2053, 1104);
            this.ControlBox = false;
            this.Controls.Add(this.gbVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportesVentas";
            this.Text = "ReportesVentas";
            this.Load += new System.EventHandler(this.ReportesVentas_Load);
            this.gbVentas.ResumeLayout(false);
            this.gbVentas.PerformLayout();
            this.gbProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRanking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVentas;
        private System.Windows.Forms.DataGridView dtgvVentas;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.ListBox lstBProductosSeleccionados;
        
        
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRanking;
        private System.Windows.Forms.Label lblProductosMasVendidos;
        private Chart chartClientes;
        private System.Windows.Forms.Label lblTopSpendingCustomers;
    }
}