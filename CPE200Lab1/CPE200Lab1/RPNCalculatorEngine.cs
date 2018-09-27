using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isUnaryOperator(string str)
        {
            switch (str)
            {
                case "1/x":
                case "√":
                    return true;
            }
            return false;

        }

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

        public string Process(string str)
        {
            Stack<string> stack = new Stack<string>();
            string[] parts = str.Split(' ');
            string RPNResult, firstOperand, secondOperand;
                       
             for (int i = 0; i < parts.Length; i++)
             {
                if (parts[i] == "%")
                {
                    secondOperand = stack.Pop();
                    firstOperand = stack.Peek();
                    RPNResult = calculate(parts[i], firstOperand, secondOperand);
                    stack.Push(RPNResult);

                }
                else if (isOperator(parts[i]))
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
                else if (isUnaryOperator(parts[i]))
                {
                  firstOperand = stack.Pop();
                  RPNResult = unaryCalculate(parts[i], firstOperand);
                  stack.Push(RPNResult);
                }
                else if (isNumber(parts[i]))
                {
                    stack.Push(parts[i]);
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
