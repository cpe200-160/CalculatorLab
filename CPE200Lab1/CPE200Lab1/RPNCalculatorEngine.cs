using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
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
                    return true;
            }
            return false;
        }
        public string RPNProcess(string str)
        {
            Stack<string> stack = new Stack<string>();
            string[] parts = str.Split(' ');
            string RPNResult,  firstOperand, secondOperand;
            
            /*List<string> partsWithoutSpace = parts.ToList<string>();
            partsWithoutSpace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = partsWithoutSpace.ToArray();*/

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
                    secondOperand = stack.Pop();
                    firstOperand = stack.Pop();
                    RPNResult = calculate(parts[i], firstOperand, secondOperand);
                    stack.Push(RPNResult);
                }
                

            }

            if(stack.Count > 1)
            {
                return "E";
            }
            return stack.Pop();
            
        }
    }
}
