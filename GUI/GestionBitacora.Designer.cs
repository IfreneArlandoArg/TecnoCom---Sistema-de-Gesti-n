namespace GUI
{
    partial class GestionBitacora
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartLogManagement = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtgvLogs = new System.Windows.Forms.DataGridView();
            this.comboBoxFacts = new System.Windows.Forms.ComboBox();
            this.comboBoxActions = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartLogManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLogManagement
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLogManagement.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLogManagement.Legends.Add(legend1);
            this.chartLogManagement.Location = new System.Drawing.Point(915, 152);
            this.chartLogManagement.Name = "chartLogManagement";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLogManagement.Series.Add(series1);
            this.chartLogManagement.Size = new System.Drawing.Size(420, 300);
            this.chartLogManagement.TabIndex = 0;
            this.chartLogManagement.Text = "chart1";
            // 
            // dtgvLogs
            // 
            this.dtgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLogs.Location = new System.Drawing.Point(84, 141);
            this.dtgvLogs.Name = "dtgvLogs";
            this.dtgvLogs.RowHeadersWidth = 51;
            this.dtgvLogs.RowTemplate.Height = 24;
            this.dtgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvLogs.Size = new System.Drawing.Size(648, 387);
            this.dtgvLogs.TabIndex = 1;
            // 
            // comboBoxFacts
            // 
            this.comboBoxFacts.FormattingEnabled = true;
            this.comboBoxFacts.Location = new System.Drawing.Point(1138, 85);
            this.comboBoxFacts.Name = "comboBoxFacts";
            this.comboBoxFacts.Size = new System.Drawing.Size(197, 24);
            this.comboBoxFacts.TabIndex = 2;
            this.comboBoxFacts.SelectedIndexChanged += new System.EventHandler(this.comboBoxFacts_SelectedIndexChanged);
            // 
            // comboBoxActions
            // 
            this.comboBoxActions.FormattingEnabled = true;
            this.comboBoxActions.Location = new System.Drawing.Point(535, 85);
            this.comboBoxActions.Name = "comboBoxActions";
            this.comboBoxActions.Size = new System.Drawing.Size(197, 24);
            this.comboBoxActions.TabIndex = 3;
            this.comboBoxActions.SelectedIndexChanged += new System.EventHandler(this.comboBoxActions_SelectedIndexChanged);
            // 
            // GestionBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1446, 977);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxActions);
            this.Controls.Add(this.comboBoxFacts);
            this.Controls.Add(this.dtgvLogs);
            this.Controls.Add(this.chartLogManagement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionBitacora";
            this.Text = "GestionBitacora";
            this.Load += new System.EventHandler(this.GestionBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartLogManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLogManagement;
        private System.Windows.Forms.DataGridView dtgvLogs;
        private System.Windows.Forms.ComboBox comboBoxFacts;
        private System.Windows.Forms.ComboBox comboBoxActions;
    }
}