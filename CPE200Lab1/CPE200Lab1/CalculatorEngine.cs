using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : BasicCalculatorEngine
    {
        protected double firstOperand;
        protected double seconOperand;

        public void setfirstOperand( string num)
        {
            firstOperand = Convert.ToDouble(num);
        }

        public void setseconOperand(string num)
        {
            seconOperand = Convert.ToDouble(num);
        }

        /// <summary>
        /// Process input numberInput string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>result from calculate</returns>
        public string Calculate(string str)
        {
            string[] parts = str.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                return Calculate(parts[1], parts[0], parts[2], 4);
            }

        }
    }
}
