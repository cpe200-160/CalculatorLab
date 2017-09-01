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
        private string secondOperand;
        private string operate;
        private string history_line;
        private double memory;
        private CalculatorEngine engine;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
            secondOperand = "0";

            history_line = "";
            lblHistory.Text = history_line;
        }

        public MainForm()
        {
            InitializeComponent();
            memory = 0;
            engine = new CalculatorEngine();
            resetAll();            
        }
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            ExtendForm switchForm = new ExtendForm();
            switchForm.Show();
            this.Hide();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual && history_line == "")
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

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            string type = ((Button)sender).Text;
            lblDisplay.Text = engine.unaryCalculate(type, lblDisplay.Text);
            /*if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }*/
            //isAfterOperater = true;
            isAllowBack = false;
        }

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
            string temp_operate = operate;
            operate = ((Button)sender).Text;
            if (firstOperand == null) firstOperand = lblDisplay.Text;
            else secondOperand = lblDisplay.Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    {
                        if (isAllowBack && isAfterEqual)
                        {
                            //secondOperand = lblDisplay.Text;
                            firstOperand = engine.calculate(operate, firstOperand, secondOperand);
                            lblDisplay.Text = firstOperand;
                        }
                        //isAfterEqual = true;
                        History(lblDisplay.Text);
                        break;
                    }
                case "%":
                    {
                        //secondOperand = lblDisplay.Text;
                        lblDisplay.Text = engine.calculate(operate, firstOperand, secondOperand);
                        operate = temp_operate;
                        break;
                    }
            }
            /*isAfterEqual = true;
            operate = ((Button)sender).Text;
            History(lblDisplay.Text);*/
            isAfterOperater = true;
            isAllowBack = false;
            //lblDisplay.Text = firstOperand;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = engine.calculate(operate, firstOperand, secondOperand);
            if (result is "Error" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                double Roundnumber = Convert.ToDouble(result);
                Roundnumber = System.Math.Ceiling(Roundnumber * 100) / 100;
                lblDisplay.Text = Roundnumber.ToString();
            }
            isAfterEqual = true;

            history_line = "";
            lblHistory.Text = history_line;
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
            string text = ((Button)sender).Text;
            switch (text)
            {
                case "C":
                    resetAll();
                    break;
                case "CE":
                    lblDisplay.Text = "0";
                    break;
            }
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

        private void History(string recent)
        {
            if (isAllowBack) history_line += " " + recent + " ";
            else history_line = history_line.Remove(history_line.Length - 1, 1);

            history_line += operate;
            lblHistory.Text = history_line;
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory += Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "error")
            {
                return;
            }
            lblDisplay.Text = memory.ToString();
        }
    }
}
