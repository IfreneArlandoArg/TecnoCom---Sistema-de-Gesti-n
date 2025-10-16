namespace GUI
{
    partial class gestionProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gestionProductos));
            this.dtgvProductos = new System.Windows.Forms.DataGridView();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.groupBoxAlta = new System.Windows.Forms.GroupBox();
            this.checkBoxAlta = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.groupBoxAlta.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvProductos
            // 
            this.dtgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dtgvProductos, "dtgvProductos");
            this.dtgvProductos.MultiSelect = false;
            this.dtgvProductos.Name = "dtgvProductos";
            this.dtgvProductos.RowTemplate.Height = 24;
            this.dtgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // lblNombreProducto
            // 
            resources.ApplyResources(this.lblNombreProducto, "lblNombreProducto");
            this.lblNombreProducto.Name = "lblNombreProducto";
            // 
            // txtNombre
            // 
            resources.ApplyResources(this.txtNombre, "txtNombre");
            this.txtNombre.Name = "txtNombre";
            // 
            // txtDescripcion
            // 
            resources.ApplyResources(this.txtDescripcion, "txtDescripcion");
            this.txtDescripcion.Name = "txtDescripcion";
            // 
            // lblDescripcion
            // 
            resources.ApplyResources(this.lblDescripcion, "lblDescripcion");
            this.lblDescripcion.Name = "lblDescripcion";
            // 
            // lblPrecio
            // 
            resources.ApplyResources(this.lblPrecio, "lblPrecio");
            this.lblPrecio.Name = "lblPrecio";
            // 
            // btnAlta
            // 
            resources.ApplyResources(this.btnAlta, "btnAlta");
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBaja
            // 
            resources.ApplyResources(this.btnBaja, "btnBaja");
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificar
            // 
            resources.ApplyResources(this.btnModificar, "btnModificar");
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // numStock
            // 
            resources.ApplyResources(this.numStock, "numStock");
            this.numStock.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numStock.Name = "numStock";
            // 
            // numPrecio
            // 
            resources.ApplyResources(this.numPrecio, "numPrecio");
            this.numPrecio.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            // 
            // lblStock
            // 
            resources.ApplyResources(this.lblStock, "lblStock");
            this.lblStock.Name = "lblStock";
            // 
            // groupBoxAlta
            // 
            this.groupBoxAlta.Controls.Add(this.lblNombreProducto);
            this.groupBoxAlta.Controls.Add(this.lblStock);
            this.groupBoxAlta.Controls.Add(this.lblPrecio);
            this.groupBoxAlta.Controls.Add(this.txtDescripcion);
            this.groupBoxAlta.Controls.Add(this.txtNombre);
            this.groupBoxAlta.Controls.Add(this.btnAlta);
            this.groupBoxAlta.Controls.Add(this.numStock);
            this.groupBoxAlta.Controls.Add(this.numPrecio);
            this.groupBoxAlta.Controls.Add(this.lblDescripcion);
            resources.ApplyResources(this.groupBoxAlta, "groupBoxAlta");
            this.groupBoxAlta.Name = "groupBoxAlta";
            this.groupBoxAlta.TabStop = false;
            // 
            // checkBoxAlta
            // 
            resources.ApplyResources(this.checkBoxAlta, "checkBoxAlta");
            this.checkBoxAlta.Name = "checkBoxAlta";
            this.checkBoxAlta.UseVisualStyleBackColor = true;
            this.checkBoxAlta.CheckedChanged += new System.EventHandler(this.checkBoxAlta_CheckedChanged);
            // 
            // gestionProductos
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxAlta);
            this.Controls.Add(this.groupBoxAlta);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.dtgvProductos);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "gestionProductos";
            this.Load += new System.EventHandler(this.gestionProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.groupBoxAlta.ResumeLayout(false);
            this.groupBoxAlta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvProductos;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.GroupBox groupBoxAlta;
        private System.Windows.Forms.CheckBox checkBoxAlta;
    }
}