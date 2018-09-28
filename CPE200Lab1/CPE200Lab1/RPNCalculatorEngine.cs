using System;
using System.Collections;
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
            string first, second, result;
            Stack<string> myStack = new Stack<string>();
            string[] parts = str.Split(' ');

            List<string> partsWithoutSpace = parts.ToList<string>();
            partsWithoutSpace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = partsWithoutSpace.ToArray();

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if ((parts[i] == "+" || parts[i] == "-" || parts[i] == "X" || parts[i] == "÷") && myStack.Count >= 2)
                    {
                        second = myStack.Pop();
                        first = myStack.Pop();
                        result = calculate(parts[i], first, second);
                        myStack.Push(result);
                    }
                    else if (parts[i] == "√" || parts[i] == "1/x" && myStack.Count == 1)
                    {
                        first = myStack.Pop();
                        myStack.Push(unaryCalculate(parts[i], first));
                    }
                    else if (parts[i] == "%")
                    {
                        second = myStack.Pop();
                        first = myStack.Pop();
                        myStack.Push(first);
                        myStack.Push(calculate(parts[i], first, second));

                    }
                    else return "E";
                }
                else
                {
                    return "E";
                }
            }
            if (myStack.Count == 1)
            {
                return myStack.Pop();
            }
            else
            {
                return "E";
            }

        }
    }
}