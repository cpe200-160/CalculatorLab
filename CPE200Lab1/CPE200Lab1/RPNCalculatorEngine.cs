using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine:CalculatorEngine
    {
        public new string Process(string str)
        {
            string[] parts;
            Stack myStack = new Stack();
            parts = str.Split(' ');

            for (int i = 0; i < parts.Length ; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (myStack.Count == 0)
                    {
                        return "E";
                    }
                    else if (myStack.Count == 1)
                    {
                        string first = myStack.Pop().ToString();
                        myStack.Push(unaryCalculate(parts[i], first, 4));
                    }
                    else if (parts[i] != "√" && parts[i] != "1/x" && parts[i] != "%")
                    {
                        string first = myStack.Pop().ToString();
                        string second = myStack.Pop().ToString();
                        myStack.Push(calculate(parts[i], second, first, 4));
                    }
                    else if (parts[i] == "%")
                    {
                        string first = myStack.Pop().ToString();
                        string second = myStack.Peek().ToString();
                        myStack.Push(calculate(parts[i], second, first, 4));
                    }
                }
            }
            if (myStack.Count == 1)
            {
                return myStack.Pop().ToString();
            }
            // your code here
            return "E";
        }

        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "√":
                case "1/x":
                case "%":


                    return true;
            }
            return false;
        }
    }
}
