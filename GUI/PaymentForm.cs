using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PaymentForm : Form
    {
        private decimal totalAmount;
        private int randomCode;
        public bool IsPaymentSuccessful { get; private set; }

        public PaymentForm(decimal total)
        {
            InitializeComponent();
            totalAmount = total;
            IsPaymentSuccessful = false;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            comboBoxPaymentType.Items.AddRange(new string[] { "Cash", "Debit", "Credit" });
            comboBoxInstallments.Items.AddRange(new string[] { "1", "3", "5" });
            comboBoxInstallments.Visible = false;
            lblInstallmentDetails.Visible = false;

            comboBoxPaymentType.SelectedIndex = 0; 
            comboBoxInstallments.SelectedIndex = 0;

            

            Random rnd = new Random();
            randomCode = rnd.Next(1000, 9999);
            lblRandomNumber.Text = $"Enter this code: {randomCode}";
        }

        private void comboBoxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCredit = comboBoxPaymentType.SelectedItem?.ToString() == "Credit";
            comboBoxInstallments.Visible = isCredit;
            lblInstallmentDetails.Visible = isCredit;


          

        }

        private void comboBoxInstallments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxInstallments.SelectedItem.ToString(), out int installments) && installments > 0)
            { 
                
                decimal perInstallment = Math.Round(totalAmount / installments, 2);
                lblInstallmentDetails.Text = $"{installments} x {perInstallment:C} = {totalAmount:C}";
            }
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtUserCode.Text, out int enteredCode) && enteredCode == randomCode)
                IsPaymentSuccessful = true;
            else
                IsPaymentSuccessful = false;

            MessageBox.Show(IsPaymentSuccessful ? "Successful Payment" : "Failure Payment");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}