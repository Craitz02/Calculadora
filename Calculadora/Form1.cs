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
        private bool isEqualsPressed = false;
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
            if (lblResult.Text.Equals("0"))
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

            if (!isOperationAdded)
            {
                lblResult.Text += btn.Text;
                first = Double.Parse(lblResult.Text);
                //second = Double.Parse(lblResult.Text);
            }
            else if (isOperationAdded)
            {
                lblResult.Text = lblResult.Text + btn.Text;
                second = Double.Parse(lblResult.Text);
            }
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operation = btn.Text;
            isOperationAdded = true;
            PerformOperation();
            lblResult.Text = "";

        }

        private void PerformOperation()
        {
            if (!isEqualsPressed)
            {
                lblOperation.Text = lblResult.Text + " " + operation;
            }
            if (isEqualsPressed)
            {
                switch (operation)
                {

                    case "+":
                        result = first + second;
                        break;
                    case "-":
                        result = first - second;
                        break;
                    case "÷":
                        if (first == 0 && second == 0)
                        {
                            lblResult.Text = "Undefined";
                        }
                        else if (second == 0)
                        {
                            lblResult.Text = "Error";
                        }
                        else
                        {
                            result = first / second;
                        }
                        break;
                    case "x":
                        result = first * second;
                        break;
                    default: break;
                }
                lblResult.Text = result.ToString();
                lblOperation.Text = first.ToString() + " " + operation + " " + second.ToString() + " =";
                first = result;
                isEqualsPressed = false;
            }

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
            if(Result.Length > 1)
            {
                Result = Result.Remove(Result.Length - 1);
            }
            else if(Result.Length == 1){
                Result = "0";
            }
            lblResult.Text = Result;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            isEqualsPressed = true;
            PerformOperation();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            isOperationAdded = false;
            isEqualsPressed = false;
            lblOperation.Text = "";
            operation = "";
            first = 0;
        }

        private void btnMasMenos_Click(object sender, EventArgs e)
        {
            double No = Double.Parse(lblResult.Text);
            No *= (-1);
            lblResult.Text = No.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
