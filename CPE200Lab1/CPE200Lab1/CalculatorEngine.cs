using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine :basicCalculatorEngine
    {
		protected double firstOperand;
		protected double secondOperand;

		public void setFirstOperand(string num)
		{
			firstOperand = Convert.ToDouble(num);
		}

		public void setSecondOperand(string num)
		{
			secondOperand = Convert.ToDouble(num);
		}

		/// <summary>
		/// process to calculate 2 number which input
		/// </summary>
		/// <param name="oper"></param>
		/// <returns></returns>
		public string calculate(string oper)
        {
            string[] parts = oper.Split(' ');
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            } else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }
    }
}
