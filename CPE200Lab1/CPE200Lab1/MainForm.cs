﻿using System;
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
		private bool hasPercantage;
		private string saveNumber = "0";
		private string mOperate;
		private string tranformNumber; 

		CalculatorEngine engine;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
			hasPercantage = false;
        }

        /*private string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch(operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if(secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if(parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    //your code here
                    break;
            }
            return "E";
        }
		*/

        public MainForm()
        {
            InitializeComponent();
			//create new engine
			engine = new CalculatorEngine();
			

            resetAll();
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
                    break;
			}
            isAllowBack = false;
        }

		private void btnTranformNumber_Click(object sender, EventArgs e)
		{
			tranformNumber = ((Button)sender).Text;
			switch (tranformNumber)
			{
				case "%":
					// your code here
					double secondNumber = (Convert.ToDouble(lblDisplay.Text) / 100) * Convert.ToDouble(firstOperand);
					secondOperand = secondNumber.ToString();
					lblDisplay.Text = secondOperand;
					hasPercantage = true;
					break;
				case "√":
					double rootNumber = (double)Math.Sqrt(Convert.ToDouble(lblDisplay.Text));
					lblDisplay.Text = rootNumber.ToString();
					firstOperand = lblDisplay.Text;
					break;
				case "1/x":
					double oneOverNumber = 1 / Convert.ToDouble(lblDisplay.Text);
					lblDisplay.Text = oneOverNumber.ToString();
					firstOperand = lblDisplay.Text;
					break;

			}
			
			
		}
		
		private void btnM_operate_Click(object sender, EventArgs e)
		{
			mOperate = ((Button)sender).Text;
			double saveNum = Convert.ToDouble(saveNumber);
			switch (mOperate)
			{
				
				case "MC":
					saveNumber = "0";
					saveNum = 0;
					break;
				case "MR":
					lblDisplay.Text = saveNumber;
					break;
				case "MS":
					saveNumber = lblDisplay.Text;
					break;
				case "M+":
					saveNum += Convert.ToDouble(lblDisplay.Text);
					saveNumber = saveNum.ToString();
					break;
				case "M-":
					saveNum -= Convert.ToDouble(lblDisplay.Text);
					saveNumber = saveNum.ToString();
					break;
			}
			isAfterOperater = true;
		}



		private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
			if (hasPercantage == false)
			{
				secondOperand = lblDisplay.Text;
			}
            string result = engine.calculate(operate, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;
			hasPercantage = false;
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
