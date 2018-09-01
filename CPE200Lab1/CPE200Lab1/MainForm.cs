using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        //private string secondOperand;
        private string operate;
        private string firstoperate;
        public CalculatorEngine engine;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }

        

        public MainForm()
        {
            InitializeComponent();

            resetAll();
            engine = new CalculatorEngine();
            //engine.calculate(operate, firstOperand, secondOperand);
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if(lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }
        string memory;
        private void btnOperator_Click(object sender, EventArgs e)
        {
            
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    firstoperate = operate;
                    break;
                case "%":
                    isAfterOperater = true;
                    string percent;
                    percent = ((Convert.ToDouble(firstOperand) * Convert.ToDouble(lblDisplay.Text)) / 100).ToString();
                    lblDisplay.Text = percent;
                    break;
                 case "1/x":
                    isAfterOperater = true;
                    string overx1 ;
                    overx1 = (1/Convert.ToDouble(lblDisplay.Text)).ToString();
                    lblDisplay.Text = overx1;
                    break;
                 case "√":
                    isAfterOperater = true;
                    double root;
                    string[] limit;
                    int limitlenght;
                    root = Math.Sqrt(Convert.ToDouble(lblDisplay.Text));
                    limit = root.ToString().Split('.');
                    limitlenght = 5- limit[0].Length - 1;

                    lblDisplay.Text = root.ToString("N" + limitlenght);
                    break;
               

            }
            isAllowBack = false;
            
            if (operate == "MC")
            {
                memory = "";
            }
            else if (operate == "MS")
            {
                memory = lblDisplay.Text;
            }
            else if (operate == "MR")
            {
                lblDisplay.Text = memory;
            }
            else if (operate == "M+")
            {
                string first;
                first = lblDisplay.Text;
                lblDisplay.Text = (Convert.ToDouble(first) + Convert.ToDouble(memory)).ToString();
            }
            else if (operate == "M-")
            {
                string first;
                first = lblDisplay.Text;
                lblDisplay.Text = (Convert.ToDouble(first) - Convert.ToDouble(memory)).ToString(); 
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = engine.calculate(operate, firstOperand,secondOperand,firstoperate);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if(lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }
    }
}
