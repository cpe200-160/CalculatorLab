using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1

{
	public class RPNCalculatorEngine : CalculatorEngine
	{

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
