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
            decimal monthlyInvestment = //Conversion of the txtMonthlyInvestment to and txtInterestRate to decimal and txtYears to int
                Convert.ToDecimal(txtMonthlyInvestment.Text);
            decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            int months = years * 12; //showing the years in int months by multiplying the years by 12
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100 
            //dividing the yearlyInterestRate by 12 and then a 100 to get a decimal monthlyInterestRate
            decimal futureValue = 0m; //initiating the decimal futureValue to 0.0
            for (int i = 0; i < months; i++) //for loop that starts at 0 if the bolean expression is less than months and the Increment expression is adding 1
            {
                futureValue = (futureValue + monthlyInterestRate)//futureValue is equal to futureValue plus monthlyInterestRate
                            * (1 + monthlyInterestRate);//then multiplied by 1 plus monthlyInterestRate
            }
            txtFutureValue.Text = futureValue.ToString("c");//the txtFutureValue text will be converted to a string in currency
            txtMonthlyInvestment.Focus();//the focus is set to txtMonthlyInvestement where result will appear
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();//closes form
        }
    }
}
