namespace GUI
{
    partial class ConfirmationMessageBox
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Button btnNo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(66, 31);
            this.lblMensaje.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(44, 16);
            this.lblMensaje.TabIndex = 0;
            this.lblMensaje.Text = "label1";
            // 
            // btnSi
            // 
            this.btnSi.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnSi.Location = new System.Drawing.Point(50, 70);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(90, 30);
            this.btnSi.TabIndex = 1;
            this.btnSi.Text = "Sí";
            this.btnSi.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(160, 70);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(90, 30);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // ConfirmationMessageBox
            // 
            this.AcceptButton = this.btnSi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(300, 120);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.lblMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmationMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirmar acción";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
