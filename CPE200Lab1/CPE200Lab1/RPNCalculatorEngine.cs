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
                case "%":
                    return true;
            }
            return false;
        }
       
        private bool isUnaryOperator(string str)
        {
            switch (str)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }
        public string RPNProcess(string str)
        {
            Stack<string> stack = new Stack<string>();
            string[] parts = str.Split(' ');
            string RPNResult, firstOperand, secondOperand;
            List<string> partsWithoutSpace = parts.ToList<string>();
            partsWithoutSpace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = partsWithoutSpace.ToArray();
            
             for (int i = 0; i < parts.Length; i++)
             {
                if (isNumber(parts[i]))
                {
                    stack.Push(parts[i]);
                }

                if (parts[i] == "%")
                {
                    secondOperand = stack.Pop();
                    firstOperand = stack.Pop();
                    RPNResult = calculate(parts[i], firstOperand, secondOperand);
                    stack.Push(firstOperand);
                    stack.Push(RPNResult);
                }

                if (isOperator(parts[i]))
                {
                    try
                    {
                        secondOperand = stack.Pop();
                        firstOperand = stack.Pop();
                        RPNResult = calculate(parts[i], firstOperand, secondOperand);
                        stack.Push(RPNResult);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("An error occurred: '0'", ex);
                        return "E";
                    }
                   

                }

                if (isUnaryOperator(parts[i]))
                {
                  firstOperand = stack.Pop();
                  RPNResult = unaryCalculate(parts[i], firstOperand);
                  stack.Push(RPNResult);
                }
             }
                
             if (stack.Count > 1)
             {
                return "E";
             }
             return stack.Pop();
            
            


        }
    }
}
