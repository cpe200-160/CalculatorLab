using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    class RpnCalculatorModel : Model
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        protected ExtendForm extendForm;
        protected RPNCalculatorEngine rpnC;

        public RpnCalculatorModel()
        {
            rpnC = new RPNCalculatorEngine();
            extendForm = new ExtendForm();
        }
        private bool IsOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }
        public void BtnNumber_Click(object sender, EventArgs e)
        {
            if (extendForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (extendForm.lblDisplay.Text is "0")
            {
                extendForm.lblDisplay.Text = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            extendForm.lblDisplay.Text += ((Button)sender).Text;
            isSpaceAllowed = true;
        }

        public void BtnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (extendForm.lblDisplay.Text is "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = extendForm.lblDisplay.Text;
            if (current[current.Length - 1] != ' ' || IsOperator(current[current.Length - 2]))
            {
                extendForm.lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
            }
        }

        public void BtnBack_Click(object sender, EventArgs e)
        {
            if (extendForm.lblDisplay.Text is "Error")
            {
                return;
            }
            // check if the last one is operator
            string current = extendForm.lblDisplay.Text;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && IsOperator(current[current.Length - 2]))
            {
                extendForm.lblDisplay.Text = current.Substring(0, current.Length - 3);
            }
            else
            {
                extendForm.lblDisplay.Text = current.Substring(0, current.Length - 1);
            }
            if (extendForm.lblDisplay.Text is "")
            {
                extendForm.lblDisplay.Text = "0";
            }
        }

        public void BtnClear_Click(object sender, EventArgs e)
        {
            extendForm.lblDisplay.Text = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        public void BtnEqual_Click(object sender, EventArgs e)
        {
            //controller.Calculate(lblDisplay.Text);
            string result = rpnC.calculate(extendForm.lblDisplay.Text);

            if (result is "E")
            {
                extendForm.lblDisplay.Text = "Error";
            }
            extendForm.lblDisplay.Text = result;
        }

        public void BtnSign_Click(object sender, EventArgs e)
        {
            if (extendForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = extendForm.lblDisplay.Text;
            if (current is "0")
            {
                extendForm.lblDisplay.Text = "-";
            }
            else if (current[current.Length - 1] is '-')
            {
                extendForm.lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (extendForm.lblDisplay.Text is "")
                {
                    extendForm.lblDisplay.Text = "0";
                }
            }
            else
            {
                extendForm.lblDisplay.Text = current + "-";
            }
            isSpaceAllowed = false;
        }

        public void BtnDot_Click(object sender, EventArgs e)
        {
            if (extendForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (!isContainDot)
            {
                isContainDot = true;
                extendForm.lblDisplay.Text += ".";
                isSpaceAllowed = false;
            }
        }

        public void BtnSpace_Click(object sender, EventArgs e)
        {
            if (extendForm.lblDisplay.Text is "Error")
            {
                return;
            }
            if (isSpaceAllowed)
            {
                extendForm.lblDisplay.Text += " ";
                isSpaceAllowed = false;
            }
        }

        public void BtnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (extendForm.lblDisplay.Text is "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = extendForm.lblDisplay.Text;
            extendForm.lblDisplay.Text += " " + ((Button)sender).Text + " ";
            isSpaceAllowed = false;
        }
    }
}
