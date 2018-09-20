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
            string[] rpnTokens = str.Split(' ');
            Stack<string> stack = new Stack<string>();

            foreach (string token in rpnTokens)
            {
                if (isNumber(token))
                {
                    stack.Push(token);
                }
                else if (isOperator(token))
                {
                    if (stack.Count < 2)
                    {
                        return "E";
                    }
                    switch (token)
                    {
                        case "+":
                        case "-":
                        case "X":
                        case "÷":
                            string secondOperand = stack.Pop();
                            stack.Push(calculate(token, stack.Pop(), secondOperand));
                            break;
                        case "%":
                            secondOperand = stack.Pop();
                            stack.Push(calculate(token, stack.Peek(), secondOperand));
                            break;
                        case "√":
                            stack.Push(unaryCalculate(token, stack.Pop()));
                            break;
                        case "1/x":
                            stack.Push(unaryCalculate(token, stack.Pop()));
                            break;
                    }
                }
            }
            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            return "E";
        }
        
    }
}
