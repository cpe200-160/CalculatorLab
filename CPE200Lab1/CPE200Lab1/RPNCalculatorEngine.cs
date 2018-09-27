using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
	public class RPNCalculatorEngine : CalculatorEngine
	{
		public string Process(string str)
		{
			string[] parts = str.Split(' ');
			Stack<string> mystack = new Stack<string>();
			if (isOperator(parts[0]) || isOperator(parts[1])) return "E";

			for (int i = 0; i < parts.Length; i++)
			{
				if (!isOperator(parts[i]))
				{
					mystack.Push(parts[i]);
				}
				else if (mystack.Count > 1)
				{
					String secondOperator = mystack.Pop().ToString();
					string fristOperator = mystack.Pop().ToString();
					mystack.Push(calculate(parts[i], fristOperator, secondOperator));
				}
				else return "E";
			}
			if (mystack.Count > 1) return "E";
			return mystack.Pop().ToString() ;
        }
    }
}
