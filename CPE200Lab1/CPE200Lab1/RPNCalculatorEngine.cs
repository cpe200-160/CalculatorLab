using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine :CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> mystack = new Stack<string>();
            string[] parts = str.Split(' ');
            string sum, num1, num2;

            for (int i = 0; i < parts.Length; i++)
            {

                if (isNumber(parts[i]))
                {
                    mystack.Push(parts[i]);
                }
                if (isOperator(parts[i]))
                {
                    if (mystack.Count < 2)
                    {
                        return "E";
                    }
                    try
                    {
                        num2 = mystack.Pop();
                        num1 = mystack.Pop();
                        sum = calculate(parts[i], num1, num2);
                        mystack.Push(sum);
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                }
                if (isOperator2(parts[i]))
                {

                    num1 = mystack.Pop();
                    sum = unaryCalculate(parts[i], num1);
                    mystack.Push(sum);
                }
            }
            sum = mystack.Peek();

            if (mystack.Count == 1)
            {
                return sum;
            }
            else
            {
                return "E";
            }
            
        }
    }
}
