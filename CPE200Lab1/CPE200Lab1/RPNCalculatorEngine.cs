using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
	public class RPNCalculatorEngine : basicCalculatorEngine
	{
		protected Stack<string> mystack = new Stack<string>();
		/// <summary>
		/// process to calculate 2 number which input
		/// </summary>
		/// <param name="oper">str is string in consle for input to process </param>
		/// <returns></returns>
		public string calculate(string oper)
		{
			string[] parts = oper.Split(' ');
			if (isOperator(parts[0])) return "E";
			string fristOperator;
			string secondOperator;

			for (int i = 0; i < parts.Length; i++)
			{
				if (isNumber(parts[i]))
				{
					mystack.Push(parts[i]);
				}

				else if (isOperator(parts[i]))
				{
					if (parts[i] == "%")
					{
						secondOperator = mystack.Pop().ToString();
						fristOperator = mystack.Peek().ToString();
						mystack.Push(calculate(parts[i], fristOperator, secondOperator, 8));
					}

					else if (parts[i] == "√" || parts[i] == "1/x")
					{
						fristOperator = mystack.Pop().ToString();
						mystack.Push(calculate(parts[i], fristOperator, 8));
					}
					else
					{
						try
						{
							secondOperator = mystack.Pop().ToString();
							fristOperator = mystack.Pop().ToString();
						}
						catch(Exception ex)
						{
							Console.WriteLine(ex);
							return "E";
						}

						mystack.Push(calculate(parts[i],fristOperator,secondOperator,8));
					}
				} 

			}

			if (mystack.Count > 1) return "E";
			else return mystack.Pop().ToString();
        }
    }
}
