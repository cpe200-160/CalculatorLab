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
            // your code here
            Stack<string> rpnStack = new Stack<string>();
            string[] parts = str.ToString().Split(' ');
            string result;
            foreach (string part in parts)
            {
                if (parts.Count() < 3 && str != "0")
                {
                    return "E";
                }
                else if (isNumber(part))
                {

                    rpnStack.Push(part);
                }
                else if (isOperator(part))
                {
                    try
                    {
                        string firstOperand, secondOperand;
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(part, firstOperand, secondOperand);
                        rpnStack.Push(result);
                    }
                    catch (InvalidOperationException)
                    {

                        return "E";
                    }
                }
                else if (isUnaryOperator(part))
                {
                    string firstOperand;
                    firstOperand = rpnStack.Pop();
                    result = unaryCalculate(part, firstOperand);
                    rpnStack.Push(result);
                }
            }
            if (rpnStack.Count > 1) return "E";
            return rpnStack.Pop();
        }
    }
}
