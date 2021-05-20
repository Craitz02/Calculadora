using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form

    {
        private bool isOperationAdded=false;
        private string operation;
        private double result = 0;
        private double first = 0;
        private double second = 0;
        public Form1()
        {
            InitializeComponent();
        }



        private void btn1_Click(object sender, EventArgs e)
        {
            if (lblResult.Text.Equals("0") || isOperationAdded)
            {
                lblResult.Text = "";
            }
            Button btn = (Button)sender;
            if (btn.Text.Equals(".", StringComparison.CurrentCultureIgnoreCase))
            {
                if (lblResult.Text.Contains("."))
                {
                    return;
                }
            }
            lblResult.Text += btn.Text;
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (first == 0 || isOperationAdded)
            {
                first = Double.Parse(lblResult.Text);
                

            }
            else
            {
                PerformOperation();
            }
            operation = btn.Text;
            isOperationAdded = true;
            lblOperation.Text = lblResult.Text + " " + operation;

        }

        private void PerformOperation()
        {
            //lblOperation.Text = lblOperation.Text + " " + lblResult.Text;
            switch (operation)
            {

                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "÷":
                    double temp = second;
                    if (first == 0 && temp == 0)
                    {
                        lblResult.Text = "Undefined";
                    }
                    else if (temp == 0)
                    {
                        lblResult.Text = "Error";
                    }
                    else
                    {
                        first /= temp;
                    }
                    break;
                case "x":
                    result = first * second;
                    break;
                default: break;
            }

            lblResult.Text = result.ToString();
            lblOperation.Text = "";

        }

        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            double No = Double.Parse(lblResult.Text);
            lblOperation.Text = $"√( {No} )";
            No = Math.Sqrt(No);
            lblResult.Text = No.ToString();
        }

        private void btnFraction_Click(object sender, EventArgs e)
        {
            double No = Double.Parse(lblResult.Text);
            lblOperation.Text = $"1 / {No}";
            No = 1 / No;
            lblResult.Text = No.ToString();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            double No = Double.Parse(lblResult.Text);
            lblOperation.Text = $"Sqr( {No} )";
            No = Math.Pow(No, 2);
            lblResult.Text = No.ToString();
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            string Result = lblResult.Text;
            if(Result.Length > 0)
            {
                Result = Result.Remove(Result.Length - 1);
                lblResult.Text = Result;
            }

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (first != 0 && isOperationAdded)
            {

                second = Double.Parse(lblResult.Text);

            }
            PerformOperation();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            lblOperation.Text = "";
            operation = "";
            first = 0;
        }

        private void btnMasMenos_Click(object sender, EventArgs e)
        {
            double No = Double.Parse(lblResult.Text);
            No *= -1;
            lblResult.Text = No.ToString();
        }
    }
}
