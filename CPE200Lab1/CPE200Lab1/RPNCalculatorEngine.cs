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
            Stack<string> stack = new Stack<string>();
            string[] parts = str.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if ((isNumber(parts[i]) && isNumber(parts[i+1]) && isOperator(parts[i+2])))
                {
                    return calculate(parts[i + 2], parts[i], parts[i + 1], 4);
                }
                else
                {
                    string firstOperand, secondOperand;
                    stack.Push(parts[i]);

                    string next = calculate(parts[i + 3], parts[i+1], parts[i + 2], 4);
                    stack.Push(next);

                    secondOperand = stack.Pop();
                    firstOperand = stack.Pop();

                    return calculate(parts[i + 2], firstOperand, secondOperand, 4);

                }
                
            }

            return stack.Pop();
            
        }
    }
}
