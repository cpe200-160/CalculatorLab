using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        private Stack<string> myStack;

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
            myStack = new Stack<string>();
            string[] parts = str.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                else
                {
                    myStack.Push(calculate(parts[i]));
                }
            }

            if (myStack.Count > 1)
            {
                return "E";
            }
            return myStack.Pop();

        }

        public string calculate(string operate)
        {
            string RPNResult, firstOperand, secondOperand;
            if (operate == "%")
            {
                secondOperand = myStack.Pop();
                firstOperand = myStack.Peek();
                RPNResult = calculate(operate, firstOperand, secondOperand);
                myStack.Push(RPNResult);

            }
            else if (isOperator(operate))
            {
                try
                {
                    secondOperand = myStack.Pop();
                    firstOperand = myStack.Pop();
                    RPNResult = calculate(operate, firstOperand, secondOperand);
                    myStack.Push(RPNResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: '0'", ex);
                    return "E";
                }
            }
            else if (isUnaryOperator(operate))
            {
                firstOperand = myStack.Pop();
                RPNResult = calculate(operate, firstOperand);
                myStack.Push(RPNResult);
            }

            return myStack.Pop();
        }
    }
}
