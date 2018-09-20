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
            bool check = false;


            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    if (check)
                    {
                        mystack.Push(parts[i]);
                        check = false;
                    }
                    else
                    {
                        mystack.Push(parts[i]);
                        check = true;
                    }
                    
                }
                if (isOperator(parts[i]))
                {
                    if (mystack.Count < 2)
                    {
                        return "E";
                    }
                   num2 = mystack.Pop();
                   num1 = mystack.Pop();
                   sum = calculate(parts[i], num1, num2);
                   mystack.Push(sum);
                   check = false;
                }

            }
            sum = mystack.Peek();

            if (mystack.Count == 1 )
            {
                if (check != true)
                {
                    return sum;
                }
                else
                {
                    return "E";
                }
            }
            else
            {
                return "E";
            }
        }
    }
}
