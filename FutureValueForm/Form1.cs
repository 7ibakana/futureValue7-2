using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValueForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal monthlyInvestment = //Conversion of the txtMonthlyInvestment to and txtInterestRate to decimal and txtYears to int
                    Convert.ToDecimal(txtMonthlyInvestment.Text);
                decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                int years = Convert.ToInt32(txtYears.Text);

                int months = years * 12; //showing the years in int months by multiplying the years by 12
                decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
                //dividing the yearlyInterestRate by 12 and then a 100 to get a decimal monthlyInterestRate
                decimal futureValue = CalculateFutureValue(monthlyInvestment, monthlyInterestRate, months);

                txtFutureValue.Text = futureValue.ToString("c");//the txtFutureValue text will be converted to a string in currency
                txtMonthlyInvestment.Focus();//the focus is set to txtMonthlyInvestement where result will appear
            }
            catch(FormatException) //a specific exception
            {
                MessageBox.Show("A format exception has occurred. Please check all entries.", "Entry Error");
            }
            catch(OverflowException) //another specific exception
            {
                MessageBox.Show("An overflow exception has occurred.  Please enter small value", "Entry Error");
            }
            catch (Exception ex) //all other exceptions
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();//closes form
        }
        private decimal CalculateFutureValue(decimal monthlyInvestment, decimal monthlyInterestRate, int months)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment) * (1 + monthlyInterestRate);
                throw new Exception("An unknown exception occurred."); //throw exception
            }
            return futureValue;
            
        }
    }
}
