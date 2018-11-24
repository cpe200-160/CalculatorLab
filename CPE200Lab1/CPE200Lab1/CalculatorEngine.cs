using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CPE200Lab1
{
    public class CalculatorEngine : BasicCalculatorEngine
    {
        private double firstOperand;
        private double secondOperand;
        public string calculator(string str)
        {
            string[] parts = str.Split(' ');
            setFirstOperand(parts[0]);
            if (isNumber(parts[2]))
            {
                setFirstOperand(parts[0]);
                setSecondOperand(parts[2]);
                return calculate(parts[1]);
            }
            else
            {
                return "E";
            }

        }
        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }
        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }
        public string calculate(string oper)
        {
            switch (oper)
            {
                case "%":
                case "+":
                case "-":
                case "X":
                case "÷": return calculate(oper, Convert.ToString(firstOperand), Convert.ToString(secondOperand));
                case "1/X":
                case "√": return calculate(oper, Convert.ToString(firstOperand));
            }
            return "E";
        }
    }
}