namespace GUI
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox comboBoxPaymentType;
        private System.Windows.Forms.ComboBox comboBoxInstallments;
        private System.Windows.Forms.Label lblInstallmentDetails;
        private System.Windows.Forms.Label lblRandomNumber;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Button btnProcessPayment;


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
            this.comboBoxPaymentType = new System.Windows.Forms.ComboBox();
            this.comboBoxInstallments = new System.Windows.Forms.ComboBox();
            this.lblInstallmentDetails = new System.Windows.Forms.Label();
            this.lblRandomNumber = new System.Windows.Forms.Label();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPaymentType
            // 
            this.comboBoxPaymentType.Location = new System.Drawing.Point(97, 32);
            this.comboBoxPaymentType.Name = "comboBoxPaymentType";
            this.comboBoxPaymentType.Size = new System.Drawing.Size(121, 24);
            this.comboBoxPaymentType.TabIndex = 0;
            this.comboBoxPaymentType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPaymentType_SelectedIndexChanged);
            // 
            // comboBoxInstallments
            // 
            this.comboBoxInstallments.Location = new System.Drawing.Point(97, 72);
            this.comboBoxInstallments.Name = "comboBoxInstallments";
            this.comboBoxInstallments.Size = new System.Drawing.Size(121, 24);
            this.comboBoxInstallments.TabIndex = 1;
            this.comboBoxInstallments.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstallments_SelectedIndexChanged);
            // 
            // lblInstallmentDetails
            // 
            this.lblInstallmentDetails.Location = new System.Drawing.Point(62, 112);
            this.lblInstallmentDetails.Name = "lblInstallmentDetails";
            this.lblInstallmentDetails.Size = new System.Drawing.Size(300, 23);
            this.lblInstallmentDetails.TabIndex = 2;
            this.lblInstallmentDetails.Text = "l";
            // 
            // lblRandomNumber
            // 
            this.lblRandomNumber.Location = new System.Drawing.Point(80, 147);
            this.lblRandomNumber.Name = "lblRandomNumber";
            this.lblRandomNumber.Size = new System.Drawing.Size(300, 23);
            this.lblRandomNumber.TabIndex = 3;
            this.lblRandomNumber.Text = "l";
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(105, 182);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(100, 22);
            this.txtUserCode.TabIndex = 4;
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.Location = new System.Drawing.Point(87, 224);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Size = new System.Drawing.Size(150, 30);
            this.btnProcessPayment.TabIndex = 5;
            this.btnProcessPayment.Text = "Process Payment";
            this.btnProcessPayment.Click += new System.EventHandler(this.btnProcessPayment_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 301);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxPaymentType);
            this.Controls.Add(this.comboBoxInstallments);
            this.Controls.Add(this.lblInstallmentDetails);
            this.Controls.Add(this.lblRandomNumber);
            this.Controls.Add(this.txtUserCode);
            this.Controls.Add(this.btnProcessPayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Form";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}