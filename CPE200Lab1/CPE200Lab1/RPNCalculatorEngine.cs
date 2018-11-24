using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        Stack<string> myStack = new Stack<string>();
        public string calculate(string oper)
        {
            string firstOperand;
            string secondOperand;
            string result;
            string[] parts = oper.Split(' ');
            foreach (string list in parts)
            {
                if (isNumber(list))
                {
                    myStack.Push(list);
                }
                else if (isOperator(list))
                {
                    try
                    {
                        if (list == "+" || list == "-" || list == "X" || list == "÷")
                        {
                            secondOperand = myStack.Pop();
                            firstOperand = myStack.Pop();
                            result = calculate(list, firstOperand, secondOperand);
                            myStack.Push(result);
                        }
                        else if (list == "%")
                        {
                            if (myStack.Count == 1)
                            {
                                secondOperand = myStack.Pop();
                                firstOperand = "1";
                            }
                            else
                            {
                                secondOperand = myStack.Pop();
                                firstOperand = myStack.Peek();
                            }
                            result = calculate(list, firstOperand, secondOperand);
                            myStack.Push(result);
                        }
                        else
                        {
                            secondOperand = myStack.Pop();
                            result = calculate(list, secondOperand);
                            myStack.Push(result);
                        }
                    }
                    catch (Exception e)
                    {
                        return "E";
                    }
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