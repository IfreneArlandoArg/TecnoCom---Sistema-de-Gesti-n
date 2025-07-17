namespace GUI
{
    partial class GestionIdiomas
    {
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

        private void InitializeComponent()
        {
            this.cmbIdiomas = new System.Windows.Forms.ComboBox();
            this.btnNuevoIdioma = new System.Windows.Forms.Button();
            this.txtNuevoIdioma = new System.Windows.Forms.TextBox();
            this.txtCodigoIdioma = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblSeleccionar = new System.Windows.Forms.Label();
            this.lblNombreNuevo = new System.Windows.Forms.Label();
            this.lblCodigoNuevo = new System.Windows.Forms.Label();
            this.dgvTraducciones = new System.Windows.Forms.DataGridView();
            this.Etiqueta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIdiomas
            // 
            this.cmbIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdiomas.FormattingEnabled = true;
            this.cmbIdiomas.Location = new System.Drawing.Point(450, 127);
            this.cmbIdiomas.Name = "cmbIdiomas";
            this.cmbIdiomas.Size = new System.Drawing.Size(200, 24);
            this.cmbIdiomas.TabIndex = 0;
            this.cmbIdiomas.SelectedIndexChanged += new System.EventHandler(this.cmbIdiomas_SelectedIndexChanged);
            // 
            // btnNuevoIdioma
            // 
            this.btnNuevoIdioma.Location = new System.Drawing.Point(1163, 121);
            this.btnNuevoIdioma.Name = "btnNuevoIdioma";
            this.btnNuevoIdioma.Size = new System.Drawing.Size(131, 37);
            this.btnNuevoIdioma.TabIndex = 1;
            this.btnNuevoIdioma.Text = "Agregar idioma";
            this.btnNuevoIdioma.UseVisualStyleBackColor = true;
            this.btnNuevoIdioma.Click += new System.EventHandler(this.btnNuevoIdioma_Click);
            // 
            // txtNuevoIdioma
            // 
            this.txtNuevoIdioma.Location = new System.Drawing.Point(776, 127);
            this.txtNuevoIdioma.Name = "txtNuevoIdioma";
            this.txtNuevoIdioma.Size = new System.Drawing.Size(150, 22);
            this.txtNuevoIdioma.TabIndex = 2;
            // 
            // txtCodigoIdioma
            // 
            this.txtCodigoIdioma.Location = new System.Drawing.Point(1009, 128);
            this.txtCodigoIdioma.Name = "txtCodigoIdioma";
            this.txtCodigoIdioma.Size = new System.Drawing.Size(120, 22);
            this.txtCodigoIdioma.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(1070, 925);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(136, 43);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblSeleccionar
            // 
            this.lblSeleccionar.AutoSize = true;
            this.lblSeleccionar.Location = new System.Drawing.Point(252, 131);
            this.lblSeleccionar.Name = "lblSeleccionar";
            this.lblSeleccionar.Size = new System.Drawing.Size(182, 16);
            this.lblSeleccionar.TabIndex = 6;
            this.lblSeleccionar.Text = "Seleccionar idioma existente:";
            // 
            // lblNombreNuevo
            // 
            this.lblNombreNuevo.AutoSize = true;
            this.lblNombreNuevo.Location = new System.Drawing.Point(682, 131);
            this.lblNombreNuevo.Name = "lblNombreNuevo";
            this.lblNombreNuevo.Size = new System.Drawing.Size(59, 16);
            this.lblNombreNuevo.TabIndex = 7;
            this.lblNombreNuevo.Text = "Nombre:";
            // 
            // lblCodigoNuevo
            // 
            this.lblCodigoNuevo.AutoSize = true;
            this.lblCodigoNuevo.Location = new System.Drawing.Point(931, 131);
            this.lblCodigoNuevo.Name = "lblCodigoNuevo";
            this.lblCodigoNuevo.Size = new System.Drawing.Size(54, 16);
            this.lblCodigoNuevo.TabIndex = 8;
            this.lblCodigoNuevo.Text = "Código:";
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.AllowUserToAddRows = false;
            this.dgvTraducciones.AllowUserToDeleteRows = false;
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Etiqueta,
            this.Texto});
            this.dgvTraducciones.Location = new System.Drawing.Point(377, 203);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.RowHeadersWidth = 51;
            this.dgvTraducciones.RowTemplate.Height = 24;
            this.dgvTraducciones.Size = new System.Drawing.Size(829, 683);
            this.dgvTraducciones.TabIndex = 4;
            // 
            // Etiqueta
            // 
            this.Etiqueta.HeaderText = "Etiqueta";
            this.Etiqueta.MinimumWidth = 6;
            this.Etiqueta.Name = "Etiqueta";
            this.Etiqueta.Width = 300;
            // 
            // Texto
            // 
            this.Texto.HeaderText = "Traducción";
            this.Texto.MinimumWidth = 6;
            this.Texto.Name = "Texto";
            this.Texto.Width = 500;
            // 
            // GestionIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1526, 1074);
            this.ControlBox = false;
            this.Controls.Add(this.lblCodigoNuevo);
            this.Controls.Add(this.lblNombreNuevo);
            this.Controls.Add(this.lblSeleccionar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvTraducciones);
            this.Controls.Add(this.txtCodigoIdioma);
            this.Controls.Add(this.txtNuevoIdioma);
            this.Controls.Add(this.btnNuevoIdioma);
            this.Controls.Add(this.cmbIdiomas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionIdiomas";
            this.Text = "GestionIdiomas";
            this.Load += new System.EventHandler(this.GestionIdiomas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIdiomas;
        private System.Windows.Forms.Button btnNuevoIdioma;
        private System.Windows.Forms.TextBox txtNuevoIdioma;
        private System.Windows.Forms.TextBox txtCodigoIdioma;
        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblSeleccionar;
        private System.Windows.Forms.Label lblNombreNuevo;
        private System.Windows.Forms.Label lblCodigoNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etiqueta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Texto;
    }
}
