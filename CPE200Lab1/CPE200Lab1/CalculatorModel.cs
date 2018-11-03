using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        protected CalculatorEngine mainC;
        protected SimpleCalculatorEngine simpleC;
        protected MainForm mainForm;
        private string result;
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private string SecondOperate;
        private double memory;

        public CalculatorModel()
        {
            mainC    = new CalculatorEngine();
            simpleC = new SimpleCalculatorEngine();
            mainForm  = new MainForm();
            memory = 0;
            resetAll();
        }
        public void isNumber(string str)
        {
            mainC.isNumber(str);
        }
        public void isOperator(string str)
        {
            mainC.isOperator(str);
        }
        public string gettingSimpleAnswer()
        {
            return result;
        }
        public void simpleProcessingCalculate(string str)
        {
            result = simpleC.calculate(str);
            if(this.result == "E")
            {
                    result = "E";
            }
            NoticeMeSenpai();
        }
        public string calculate(string FirstOperand , string SecondOperand , string Operate)
        {
            return calculate(Operate, FirstOperand, SecondOperand);
        }
        public string calculate(string Operand,string Operate)
        {
            return calculate(Operate, Operand);
        }
        
        public void resetAll()
        {
            mainForm.lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }

        public void btnNumber_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                mainForm.lblDisplay.Text = "0";
            }
            if (mainForm.lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if (mainForm.lblDisplay.Text is "0")
            {
                mainForm.lblDisplay.Text = "";
            }
            mainForm.lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        public void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            firstOperand = mainForm.lblDisplay.Text;
            string result = mainC.calculate(operate, firstOperand);
            if (result is "E" || result.Length > 8)
            {
                mainForm.lblDisplay.Text = "Error";
            }
            else
            {
                mainForm.lblDisplay.Text = result;
            }

        }

        public void btnOperator_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            if (firstOperand != null)
            {
                string secondOperand = mainForm.lblDisplay.Text;
                string result = mainC.calculate(operate, firstOperand, secondOperand);
                if (result is "E" || result.Length > 8)
                {
                    mainForm.lblDisplay.Text = "Error";
                }
                else
                {
                    mainForm.lblDisplay.Text = result;
                }
            }
            SecondOperate = operate;
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = mainForm.lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    string secondOperand = mainForm.lblDisplay.Text;
                    secondOperand = mainForm.lblDisplay.Text;
                    break;
            }
            isAllowBack = false;
        }

        public void btnEqual_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = mainForm.lblDisplay.Text;
            string result = mainC.calculate(operate, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                mainForm.lblDisplay.Text = "Error";
            }
            else
            {
                mainForm.lblDisplay.Text = result;
            }
            isAfterEqual = true;
        }

        public void btnDot_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (mainForm.lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                mainForm.lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        public void btnSign_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (mainForm.lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (mainForm.lblDisplay.Text[0] is '-')
            {
                mainForm.lblDisplay.Text = mainForm.lblDisplay.Text.Substring(1, mainForm.lblDisplay.Text.Length - 1);
            }
            else
            {
                mainForm.lblDisplay.Text = "-" + mainForm.lblDisplay.Text;
            }
        }

        public void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        public void btnBack_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
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
            if (mainForm.lblDisplay.Text != "0")
            {
                string current = mainForm.lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                mainForm.lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (mainForm.lblDisplay.Text is "" || mainForm.lblDisplay.Text is "-")
                {
                    mainForm.lblDisplay.Text = "0";
                }
            }
        }

        public void btnMP_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
            {
                return;
            }
            memory += Convert.ToDouble(mainForm.lblDisplay.Text);
            isAfterOperater = true;
        }

        public void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        public void btnMM_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(mainForm.lblDisplay.Text);
            isAfterOperater = true;
        }

        public void btnMR_Click(object sender, EventArgs e)
        {
            if (mainForm.lblDisplay.Text is "error")
            {
                return;
            }
            mainForm.lblDisplay.Text = memory.ToString();
        }
       
    }
}
