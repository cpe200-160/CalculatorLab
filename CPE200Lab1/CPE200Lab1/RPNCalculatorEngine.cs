using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            Stack<string> stack = new Stack<string>();
            string firstOperand = null;
            string secondOperand = null;
            string result = null;

            if (parts.Length == 1)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    stack.Push(parts[i]);
                }

                else if (isOperator(parts[i]))
                {
                    if (stack.Count < 2)
                    {
                        return "E";
                    }
                secondOperand = stack.Pop();
                firstOperand = stack.Pop();
                result = calculate(parts[i], firstOperand, secondOperand);
                stack.Push(result);

                }
                else
                {
                    return "E";
                }
            }
            if (stack.Count > 1)
            {
                return "E";
            }
            else
            {
                return stack.Peek();
            }
        }

    }
}
