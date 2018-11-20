using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1

{
	public class RPNCalculatorEngine : CalculatorEngine
	{

		private void resetAll()
		{
			lblDisplay.Text = "0";
			isAllowBack = true;
			hasDot = false;
			isAfterOperater = false;
			isAfterEqual = false;
			firstOperand = null;
		}


		public void Btn_Number()
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
			if (lblDisplay.Text.Length is 8)
			{
				return;
			}
			isAllowBack = true;
			string digit = ((Button)sender).Text;
			if (lblDisplay.Text is "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text += digit;
			isAfterOperater = false;
		}

		public void Btn_Unary_Operator()
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
			firstOperand = lblDisplay.Text;
			string result = simple.unaryCalculate(operate, firstOperand);
			if (result is "E" || result.Length > 8)
			{
				lblDisplay.Text = "Error";
			}
			else
			{
				lblDisplay.Text = result;
			}
		}

		public void Btn_Operator()
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			if (isAfterOperater)
			{
				return;
			}
			if (firstOperand != null)
			{
				string secondOperand = lblDisplay.Text;
				string result = engine.calculate(operate, firstOperand, secondOperand);
				if (result is "E" || result.Length > 8)
				{
					lblDisplay.Text = "Error";
				}
				else
				{
					lblDisplay.Text = result;
				}
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
				case "%":
					// your code here
					break;
			}
			isAllowBack = false;
		}

		public void Btn_Equal()
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			string secondOperand = lblDisplay.Text;
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
		}

		public void Btn_Dot()
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
		public void Btn_Sign()
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
			if (lblDisplay.Text[0] is '-')
			{
				lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
			}
			else
			{
				lblDisplay.Text = "-" + lblDisplay.Text;
			}
		}
		public void Btn_clear()
		{
			resetAll();
		}
		public void Btn_Back()
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
			if (lblDisplay.Text != "0")
			{
				string current = lblDisplay.Text;
				char rightMost = current[current.Length - 1];
				if (rightMost is '.')
				{
					hasDot = false;
				}
				lblDisplay.Text = current.Substring(0, current.Length - 1);
				if (lblDisplay.Text is "" || lblDisplay.Text is "-")
				{
					lblDisplay.Text = "0";
				}
			}
		}

		public void Btn_Mp()
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			memory += Convert.ToDouble(lblDisplay.Text);
			isAfterOperater = true;
		}

		public void Btn_Mc()
		{
			memory = 0;
		}

		public void Btn_MM()
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			memory -= Convert.ToDouble(lblDisplay.Text);
			isAfterOperater = true;
		}

		public void Btn_Mr()
		{
			if (lblDisplay.Text is "error")
			{
				return;
			}
			lblDisplay.Text = memory.ToString();
		}

		public override string Process(string str)
		{
			//Boolean w = true;
			int ValueNum = 0;
			for (int j = 0;j < str.Length; j++)
			{
				if(str == null)
				{
					///w = false;
					return "E";
				}
			}

				string[] parts = str.Split(' ');
				Stack<string> operands = new Stack<string>();
				string result = "0";
				Boolean Key = false;
				int amountNum = 0, amountOper = 0;
		
				for (int i = 0; i < parts.Length; i++)
				{

					if (parts[i] == "1+" || parts[i] == "+1" || parts[i] == "++" || parts[i] == "\"\"")
					{
						return "E";
					}
					if (isNumber(parts[i]))
					{
						if (Double.Parse(parts[i]) >= 1)
							operands.Push(parts[i]);
						result = parts[i];
						amountNum = amountNum + 1;
					    ValueNum++;
					}
					else if (isOperator(parts[i]))
					{
						string ppap1 = "0";
						string ppap2 = "0";
						if (operands.Count() > 1)
						{
							ppap2 = operands.Pop();
							ppap1 = operands.Pop();

						}
						else
						{
							return "E";
						}

						result = calculate(parts[i], ppap1, ppap2, 4);
						operands.Push(result);
						Key = true;
						amountOper++;

					}
					else if (parts[i] == null)
					{
						return "E";
					}


				}
				if (amountNum - amountOper != 1 && Key == true)
				{
					return "E";
				}
				if (Key == false && ValueNum > 1)
				{
					return "E";
				}
			

			return result;
		}
	}
}
