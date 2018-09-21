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
            string firstOperand;
            string secondOperand;
            string result;


            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    stack.Push(parts[i]);
                }

                if (isOperator(parts[i]))
                {
                    if (stack.Count < 2)
                    {
                        return "E";
                    }

                    if(parts[i] == "√")
                    {
                        firstOperand = stack.Pop();
                        result = unaryCalculate(parts[i], firstOperand);
                        stack.Push(result);
                    }
                    else if (parts[i] == "1/x")
                    {
                        firstOperand = stack.Pop();
                        result = unaryCalculate(parts[i], firstOperand);
                        stack.Push(result);
                    }
                    else
                    {
                        secondOperand = stack.Pop();
                        firstOperand = stack.Pop();
                        result = calculate(parts[i], firstOperand, secondOperand);
                        stack.Push(result);
                    }
                
                }
            }
            

            if (stack.Count == 1)
            {
                return stack.Peek();
            }
            else
            {
                return "E";
            }
        }

    }
}
