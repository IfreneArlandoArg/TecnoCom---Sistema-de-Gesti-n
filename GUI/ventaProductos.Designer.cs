namespace GUI
{
    partial class ventaProductos
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dtgvProductos = new System.Windows.Forms.DataGridView();
            this.lstBProductosSeleccionados = new System.Windows.Forms.ListBox();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblDNI_ = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.chBRegistrarNuevoCliente = new System.Windows.Forms.CheckBox();
            this.gbRegistrar = new System.Windows.Forms.GroupBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.numDNI = new System.Windows.Forms.NumericUpDown();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.dtgvCliente = new System.Windows.Forms.DataGridView();
            this.gbPago = new System.Windows.Forms.GroupBox();
            this.btnProcesarPago = new System.Windows.Forms.Button();
            this.lblTotalPago = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProductos)).BeginInit();
            this.gbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbCliente.SuspendLayout();
            this.gbRegistrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDNI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCliente)).BeginInit();
            this.gbPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(881, 351);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(91, 32);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(992, 351);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(91, 32);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtgvProductos
            // 
            this.dtgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvProductos.Location = new System.Drawing.Point(43, 31);
            this.dtgvProductos.Name = "dtgvProductos";
            this.dtgvProductos.RowHeadersWidth = 51;
            this.dtgvProductos.RowTemplate.Height = 24;
            this.dtgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvProductos.Size = new System.Drawing.Size(681, 269);
            this.dtgvProductos.TabIndex = 4;
            // 
            // lstBProductosSeleccionados
            // 
            this.lstBProductosSeleccionados.FormattingEnabled = true;
            this.lstBProductosSeleccionados.ItemHeight = 16;
            this.lstBProductosSeleccionados.Location = new System.Drawing.Point(820, 31);
            this.lstBProductosSeleccionados.Name = "lstBProductosSeleccionados";
            this.lstBProductosSeleccionados.Size = new System.Drawing.Size(325, 196);
            this.lstBProductosSeleccionados.TabIndex = 5;
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.numericUpDown2);
            this.gbProductos.Controls.Add(this.dtgvProductos);
            this.gbProductos.Controls.Add(this.lblCantidad);
            this.gbProductos.Controls.Add(this.lstBProductosSeleccionados);
            this.gbProductos.Controls.Add(this.btnAgregar);
            this.gbProductos.Controls.Add(this.btnEliminar);
            this.gbProductos.Location = new System.Drawing.Point(210, 56);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(1237, 397);
            this.gbProductos.TabIndex = 6;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "Productos";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(1030, 257);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(112, 22);
            this.numericUpDown2.TabIndex = 13;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(899, 259);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(67, 16);
            this.lblCantidad.TabIndex = 14;
            this.lblCantidad.Text = "Cantidad :";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(429, 26);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(131, 22);
            this.numericUpDown1.TabIndex = 7;
            // 
            // lblDNI_
            // 
            this.lblDNI_.AutoSize = true;
            this.lblDNI_.Location = new System.Drawing.Point(317, 28);
            this.lblDNI_.Name = "lblDNI_";
            this.lblDNI_.Size = new System.Drawing.Size(36, 16);
            this.lblDNI_.TabIndex = 8;
            this.lblDNI_.Text = "DNI :";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(469, 64);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 32);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.chBRegistrarNuevoCliente);
            this.gbCliente.Controls.Add(this.gbRegistrar);
            this.gbCliente.Controls.Add(this.dtgvCliente);
            this.gbCliente.Controls.Add(this.btnBuscar);
            this.gbCliente.Controls.Add(this.numericUpDown1);
            this.gbCliente.Controls.Add(this.lblDNI_);
            this.gbCliente.Location = new System.Drawing.Point(211, 478);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(585, 598);
            this.gbCliente.TabIndex = 9;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Cliente";
            // 
            // chBRegistrarNuevoCliente
            // 
            this.chBRegistrarNuevoCliente.AutoSize = true;
            this.chBRegistrarNuevoCliente.Location = new System.Drawing.Point(52, 231);
            this.chBRegistrarNuevoCliente.Name = "chBRegistrarNuevoCliente";
            this.chBRegistrarNuevoCliente.Size = new System.Drawing.Size(171, 20);
            this.chBRegistrarNuevoCliente.TabIndex = 12;
            this.chBRegistrarNuevoCliente.Text = "Registrar Nuevo Cliente";
            this.chBRegistrarNuevoCliente.UseVisualStyleBackColor = true;
            this.chBRegistrarNuevoCliente.CheckedChanged += new System.EventHandler(this.chBRegistrarNuevoCliente_CheckedChanged);
            // 
            // gbRegistrar
            // 
            this.gbRegistrar.Controls.Add(this.btnRegistrar);
            this.gbRegistrar.Controls.Add(this.lblNombre);
            this.gbRegistrar.Controls.Add(this.lblEmail);
            this.gbRegistrar.Controls.Add(this.lblDNI);
            this.gbRegistrar.Controls.Add(this.txtEmail);
            this.gbRegistrar.Controls.Add(this.numDNI);
            this.gbRegistrar.Controls.Add(this.lblApellido);
            this.gbRegistrar.Controls.Add(this.txtNombre);
            this.gbRegistrar.Controls.Add(this.txtApellido);
            this.gbRegistrar.Location = new System.Drawing.Point(179, 259);
            this.gbRegistrar.Name = "gbRegistrar";
            this.gbRegistrar.Size = new System.Drawing.Size(386, 317);
            this.gbRegistrar.TabIndex = 11;
            this.gbRegistrar.TabStop = false;
            this.gbRegistrar.Text = "Registrar";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(278, 262);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(91, 32);
            this.btnRegistrar.TabIndex = 17;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 92);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 16);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(17, 186);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 16);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email :";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(116, 42);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(36, 16);
            this.lblDNI.TabIndex = 10;
            this.lblDNI.Text = "DNI :";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(88, 184);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(281, 22);
            this.txtEmail.TabIndex = 15;
            // 
            // numDNI
            // 
            this.numDNI.Location = new System.Drawing.Point(238, 40);
            this.numDNI.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.numDNI.Name = "numDNI";
            this.numDNI.Size = new System.Drawing.Size(131, 22);
            this.numDNI.TabIndex = 9;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(8, 133);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(63, 16);
            this.lblApellido.TabIndex = 14;
            this.lblApellido.Text = "Apellido :";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(88, 90);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(281, 22);
            this.txtNombre.TabIndex = 11;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(88, 127);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(281, 22);
            this.txtApellido.TabIndex = 13;
            // 
            // dtgvCliente
            // 
            this.dtgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCliente.Location = new System.Drawing.Point(42, 112);
            this.dtgvCliente.Name = "dtgvCliente";
            this.dtgvCliente.RowHeadersWidth = 51;
            this.dtgvCliente.RowTemplate.Height = 24;
            this.dtgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvCliente.Size = new System.Drawing.Size(518, 101);
            this.dtgvCliente.TabIndex = 6;
            // 
            // gbPago
            // 
            this.gbPago.Controls.Add(this.btnProcesarPago);
            this.gbPago.Controls.Add(this.lblTotalPago);
            this.gbPago.Location = new System.Drawing.Point(816, 486);
            this.gbPago.Name = "gbPago";
            this.gbPago.Size = new System.Drawing.Size(355, 205);
            this.gbPago.TabIndex = 10;
            this.gbPago.TabStop = false;
            this.gbPago.Text = "Pago";
            // 
            // btnProcesarPago
            // 
            this.btnProcesarPago.Location = new System.Drawing.Point(112, 84);
            this.btnProcesarPago.Name = "btnProcesarPago";
            this.btnProcesarPago.Size = new System.Drawing.Size(181, 32);
            this.btnProcesarPago.TabIndex = 6;
            this.btnProcesarPago.Text = "Finalizar Compra";
            this.btnProcesarPago.UseVisualStyleBackColor = true;
            this.btnProcesarPago.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.AutoSize = true;
            this.lblTotalPago.Location = new System.Drawing.Point(34, 48);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(44, 16);
            this.lblTotalPago.TabIndex = 0;
            this.lblTotalPago.Text = "label2";
            // 
            // ventaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1617, 1084);
            this.ControlBox = false;
            this.Controls.Add(this.gbPago);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ventaProductos";
            this.Text = "ventaProductos";
            this.Load += new System.EventHandler(this.ventaProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProductos)).EndInit();
            this.gbProductos.ResumeLayout(false);
            this.gbProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.gbRegistrar.ResumeLayout(false);
            this.gbRegistrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDNI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCliente)).EndInit();
            this.gbPago.ResumeLayout(false);
            this.gbPago.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dtgvProductos;
        private System.Windows.Forms.ListBox lstBProductosSeleccionados;
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblDNI_;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.DataGridView dtgvCliente;
        private System.Windows.Forms.GroupBox gbPago;
        private System.Windows.Forms.Label lblTotalPago;
        private System.Windows.Forms.Button btnProcesarPago;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown numDNI;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.GroupBox gbRegistrar;
        private System.Windows.Forms.CheckBox chBRegistrarNuevoCliente;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label lblCantidad;
    }
}