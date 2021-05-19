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
        private bool isOperationAdded;
        private string operation;
        private double result = 0;
        public Form1()
        {
            InitializeComponent();
        }



        private void btn1_Click(object sender, EventArgs e)
        {
            if (lblResult.Text.Equals("0")||isOperationAdded)
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
            if (result==0)
            {
                result = Double.Parse(lblResult.Text);
                lblOperation.Text = lblResult.Text + " " + btn.Text;
                operation = btn.Text;
                isOperationAdded = true;
                
            }
            else
            {
                operation = btn.Text;
                isOperationAdded = true;
                PerformOperation(operation);
                lblOperation.Text = lblResult.Text + " " + btn.Text;

            }
            
        }

        private void PerformOperation(string operation)
        {
            //lblOperation.Text = lblOperation.Text + " " + lblResult.Text;
            switch (operation)
            {
                case "+": 
                    result = result + Double.Parse(lblResult.Text);
                    break;
                case "-":
                    result = result - Double.Parse(lblResult.Text);
                    break;
                case "÷":
                    double temp = Double.Parse(lblResult.Text);
                    if (result == 0 && temp==0)
                    {
                        lblResult.Text = "Undefined";
                    }else if (temp == 0)
                    {
                        lblResult.Text = "Error";
                    }
                    else
                    {
                        result /= temp;
                    }
                    break;
                case "x":
                    result = result * Double.Parse(lblResult.Text);
                    break;
                default: break;
            }
            
            lblResult.Text = result.ToString();
            
            operation = "";
            
        }
    }
}
