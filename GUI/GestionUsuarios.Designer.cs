namespace GUI
{
    partial class GestionUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbOperacionesUsuario = new System.Windows.Forms.GroupBox();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.lblPermisosDisponibles = new System.Windows.Forms.Label();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnSacar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelPermisosUsuario = new System.Windows.Forms.Label();
            this.lblNombreUsuarioTmp = new System.Windows.Forms.Label();
            this.gbOperacionesUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOperacionesUsuario
            // 
            this.gbOperacionesUsuario.Controls.Add(this.btnBaja);
            this.gbOperacionesUsuario.Controls.Add(this.btnModificar);
            this.gbOperacionesUsuario.Controls.Add(this.btnAlta);
            this.gbOperacionesUsuario.Controls.Add(this.lblPermisosDisponibles);
            this.gbOperacionesUsuario.Controls.Add(this.btnAsignar);
            this.gbOperacionesUsuario.Controls.Add(this.lblPassword);
            this.gbOperacionesUsuario.Controls.Add(this.treeView2);
            this.gbOperacionesUsuario.Controls.Add(this.txtPassword);
            this.gbOperacionesUsuario.Controls.Add(this.lblNombre);
            this.gbOperacionesUsuario.Controls.Add(this.lblEmail);
            this.gbOperacionesUsuario.Controls.Add(this.txtEmail);
            this.gbOperacionesUsuario.Controls.Add(this.lblApellido);
            this.gbOperacionesUsuario.Controls.Add(this.txtNombre);
            this.gbOperacionesUsuario.Controls.Add(this.txtApellido);
            this.gbOperacionesUsuario.Controls.Add(this.lblFechaNacimiento);
            this.gbOperacionesUsuario.Controls.Add(this.dateTimePicker1);
            this.gbOperacionesUsuario.Location = new System.Drawing.Point(85, 460);
            this.gbOperacionesUsuario.Name = "gbOperacionesUsuario";
            this.gbOperacionesUsuario.Size = new System.Drawing.Size(1495, 486);
            this.gbOperacionesUsuario.TabIndex = 0;
            this.gbOperacionesUsuario.TabStop = false;
            this.gbOperacionesUsuario.Text = "Operaciones Usuario";
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(690, 248);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(107, 41);
            this.btnBaja.TabIndex = 29;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(535, 248);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(107, 41);
            this.btnModificar.TabIndex = 28;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(382, 248);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(107, 41);
            this.btnAlta.TabIndex = 27;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // lblPermisosDisponibles
            // 
            this.lblPermisosDisponibles.AutoSize = true;
            this.lblPermisosDisponibles.Location = new System.Drawing.Point(1085, 27);
            this.lblPermisosDisponibles.Name = "lblPermisosDisponibles";
            this.lblPermisosDisponibles.Size = new System.Drawing.Size(137, 16);
            this.lblPermisosDisponibles.TabIndex = 32;
            this.lblPermisosDisponibles.Text = "Permisos disponibles";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(1324, 396);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(107, 41);
            this.btnAsignar.TabIndex = 30;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(89, 196);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 16);
            this.lblPassword.TabIndex = 26;
            this.lblPassword.Text = "Password :";
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(1084, 53);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(347, 318);
            this.treeView2.TabIndex = 31;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(183, 194);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(281, 22);
            this.txtPassword.TabIndex = 25;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(79, 69);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 16);
            this.lblNombre.TabIndex = 20;
            this.lblNombre.Text = "Nombre :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(90, 153);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 16);
            this.lblEmail.TabIndex = 24;
            this.lblEmail.Text = "Email :";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(183, 153);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(281, 22);
            this.txtEmail.TabIndex = 23;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(81, 110);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(63, 16);
            this.lblApellido.TabIndex = 22;
            this.lblApellido.Text = "Apellido :";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(183, 69);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(281, 22);
            this.txtNombre.TabIndex = 19;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(183, 106);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(281, 22);
            this.txtApellido.TabIndex = 21;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(509, 67);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(119, 16);
            this.lblFechaNacimiento.TabIndex = 1;
            this.lblFechaNacimiento.Text = "Fecha nacimiento :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(644, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(273, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dtgvUsuarios
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvUsuarios.Location = new System.Drawing.Point(105, 47);
            this.dtgvUsuarios.Name = "dtgvUsuarios";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvUsuarios.RowHeadersWidth = 51;
            this.dtgvUsuarios.RowTemplate.Height = 24;
            this.dtgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvUsuarios.Size = new System.Drawing.Size(872, 318);
            this.dtgvUsuarios.TabIndex = 0;
            this.dtgvUsuarios.SelectionChanged += new System.EventHandler(this.dtgvUsuarios_SelectionChanged);
            // 
            // btnSacar
            // 
            this.btnSacar.Location = new System.Drawing.Point(1409, 394);
            this.btnSacar.Name = "btnSacar";
            this.btnSacar.Size = new System.Drawing.Size(107, 41);
            this.btnSacar.TabIndex = 31;
            this.btnSacar.Text = "Sacar";
            this.btnSacar.UseVisualStyleBackColor = true;
            this.btnSacar.Click += new System.EventHandler(this.btnSacar_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(1169, 89);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(347, 276);
            this.listBox1.TabIndex = 1;
            // 
            // labelPermisosUsuario
            // 
            this.labelPermisosUsuario.AutoSize = true;
            this.labelPermisosUsuario.Location = new System.Drawing.Point(1166, 47);
            this.labelPermisosUsuario.Name = "labelPermisosUsuario";
            this.labelPermisosUsuario.Size = new System.Drawing.Size(44, 16);
            this.labelPermisosUsuario.TabIndex = 2;
            this.labelPermisosUsuario.Text = "label7";
            // 
            // lblNombreUsuarioTmp
            // 
            this.lblNombreUsuarioTmp.AutoSize = true;
            this.lblNombreUsuarioTmp.Location = new System.Drawing.Point(1472, 47);
            this.lblNombreUsuarioTmp.Name = "lblNombreUsuarioTmp";
            this.lblNombreUsuarioTmp.Size = new System.Drawing.Size(44, 16);
            this.lblNombreUsuarioTmp.TabIndex = 32;
            this.lblNombreUsuarioTmp.Text = "label7";
            // 
            // GestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1690, 1036);
            this.ControlBox = false;
            this.Controls.Add(this.lblNombreUsuarioTmp);
            this.Controls.Add(this.btnSacar);
            this.Controls.Add(this.labelPermisosUsuario);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.gbOperacionesUsuario);
            this.Controls.Add(this.dtgvUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionUsuarios";
            this.Text = "GestionUsuarios";
            this.Load += new System.EventHandler(this.GestionUsuarios_Load);
            this.gbOperacionesUsuario.ResumeLayout(false);
            this.gbOperacionesUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOperacionesUsuario;
        private System.Windows.Forms.DataGridView dtgvUsuarios;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label lblPermisosDisponibles;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button btnSacar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelPermisosUsuario;
        private System.Windows.Forms.Label lblNombreUsuarioTmp;
    }
}