namespace GUI
{
    partial class ProductosCorruptos
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
            this.dtgvProductosCorruptos = new System.Windows.Forms.DataGridView();
            this.btnRestaurar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProductosCorruptos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvProductosCorruptos
            // 
            this.dtgvProductosCorruptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvProductosCorruptos.Location = new System.Drawing.Point(29, 27);
            this.dtgvProductosCorruptos.Name = "dtgvProductosCorruptos";
            this.dtgvProductosCorruptos.RowHeadersWidth = 51;
            this.dtgvProductosCorruptos.RowTemplate.Height = 24;
            this.dtgvProductosCorruptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvProductosCorruptos.Size = new System.Drawing.Size(564, 267);
            this.dtgvProductosCorruptos.TabIndex = 0;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(472, 344);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(121, 37);
            this.btnRestaurar.TabIndex = 1;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // ProductosCorruptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 450);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.dtgvProductosCorruptos);
            this.Name = "ProductosCorruptos";
            this.Text = "ProductosCorruptos";
            this.Load += new System.EventHandler(this.ProductosCorruptos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProductosCorruptos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvProductosCorruptos;
        private System.Windows.Forms.Button btnRestaurar;
    }
}