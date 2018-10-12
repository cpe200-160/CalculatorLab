using System;

namespace CPE200Lab1
{
	public class basicCalculatorEngine
	{
		/// <summary>
		/// this boolean check str is number ?
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public bool isNumber(string str)
		{
			double retNum;
			return Double.TryParse(str, out retNum);
		}
		/// <summary>
		/// this boolean check str is Operator ?
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public bool isOperator(string str)
		{
			switch (str)
			{
				case "+":
				case "-":
				case "X":
				case "÷":
				case "%":
				case "√":
				case "1/x":
					return true;
			}
			return false;
		}

		/// <summary>
		/// this function to calculate 1/x and loot
		/// </summary>
		/// <param name="operate"></param>
		/// <param name="operand"></param>
		/// <param name="maxOutputSize"></param>
		/// <returns></returns>
		public string calculate(string operate, string operand, int maxOutputSize = 8)
		{
			switch (operate)
			{
				case "√":
					{
						double result;
						string[] parts;
						int remainLength;
						try
						{
							result = Math.Sqrt(Convert.ToDouble(operand));
						}
						catch (Exception ex)
						{
							return "E";
						}
						// split between integer part and fractional part
						parts = result.ToString().Split('.');
						// if integer part length is already break max output, return error
						if (parts[0].Length > maxOutputSize)
						{
							return "E";
						}
						// calculate remaining space for fractional part.
						maxOutputSize = 8;
						remainLength = maxOutputSize - parts[0].Length - 1;
						// trim the fractional part gracefully. =
						return result.ToString("G" + remainLength);
					}
				case "1/x":
					if (operand != "0")
					{
						double result;
						string[] parts;
						int remainLength;

						result = (1.0 / Convert.ToDouble(operand));
						// split between integer part and fractional part
						parts = result.ToString().Split('.');
						// if integer part length is already break max output, return error
						if (parts[0].Length > maxOutputSize)
						{
							return "E";
						}
						// calculate remaining space for fractional part.
						maxOutputSize = 8;
						remainLength = maxOutputSize - parts[0].Length - 1;
						// trim the fractional part gracefully. =
						return result.ToString("G" + remainLength);
					}
					break;
			}
			return "E";
		}

		/// <summary>
		/// this is function to calculate +,-,*,/,%
		/// </summary>
		/// <param name="operate"></param>
		/// <param name="firstOperand"></param>
		/// <param name="secondOperand"></param>
		/// <param name="maxOutputSize"></param>
		/// <returns></returns>
		public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
		{
			switch (operate)
			{
				case "+":
					return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
				case "-":
					return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
				case "X":
					return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
				case "÷":
					// Not allow devide be zero
					if (secondOperand != "0")
					{
						double result;
						string[] parts;
						int remainLength;

						result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
						// split between integer part and fractional part
						parts = result.ToString().Split('.');
						// if integer part length is already break max output, return error
						if (parts[0].Length > maxOutputSize)
						{
							return "E";
						}
						// calculate remaining space for fractional part.
						maxOutputSize = 8;
						remainLength = maxOutputSize - parts[0].Length - 1;
						// trim the fractional part gracefully. =
						return result.ToString("G" + remainLength);
					}
					break;
				case "%":
					return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
			}
			return "E";
		}
	}
}