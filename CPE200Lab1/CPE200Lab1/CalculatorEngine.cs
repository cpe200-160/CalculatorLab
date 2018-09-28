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

        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return true;
            }
            return false;

        }

        public string calculate(string operate)
        {
            string[] parts = operate.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            return calculate(parts[1], parts[0], parts[2], 4);
        }

        public void setFirstOperand(string firstNum)
        {
            firstOperand = Convert.ToDouble(firstNum);
        }

        public void setSecondOperand(string secondNum)
        {
            secondOperand = Convert.ToDouble(secondNum);
        }
    }
        
}
