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
            string mun1, mun2, result;
            
            Stack<string> myStack = new Stack<string>();


            string[] parts = str.Split(' ');
            
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }
                
                else if (isOperator(parts[i]))
                {
                    mun2 = myStack.Pop();
                    mun1 = myStack.Pop();
                    result = calculate(parts[i], mun1, mun2, 4);
                    myStack.Push(result);
                }
                
             
            }
            
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return myStack.Peek();
            }
            else
            {
                return "E";
            }

            
            
            
        }
    }
    */
}
