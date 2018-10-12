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
        ///  process input to calculate result
        /// </summary>
        /// <param name="str"></param>
        /// <returns>result</returns>
        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            
            if (isNumber(parts[0]) && (parts[1] == "%")) //calculate percent   Ex: 20 % = 0.2
            {
                return calculate("%", "1", parts[0]);
            }
            else if (parts.Length >= 4 && parts[3] == "%") //calculate percent   Ex: 50 + 20 % = 75
            {
                string percent = calculate("%", parts[0], parts[2]);
                return calculate(parts[1], parts[0], percent, 4);
            }
            if (isNumber(parts[0]) && (parts[1] == "√")) //calculate √   Ex: 2 √ = 1.4...
            {
                return calculate("√", parts[0]);
            }
            else if (isNumber(parts[0]) && (parts[1] == "1/x")) //calculate one over x   Ex: 1 1/x = 1
            {
                return calculate("1/x", parts[0]);
            }
            else if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])) //calculate number  Ex: 1 + 2 = 3
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else
            {
                return "E";
            }

        }
        
    }
}
