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
            // your code here
            Stack<string> rpnStack = new Stack<string>();
            string[] parts = str.ToString().Split(' ');
           bool check = false;
            foreach (string part in parts)
            {
                if (part != "+" && part != "-" && part != "X" && part != "÷")
                {
                    
                    rpnStack.Push(part);
                }
                else 
                {
                    try
                    {
                        check = true;
                        string firstOperand, secondOperand;
                        if (rpnStack.Count < 2) return "E";
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        rpnStack.Push(calculate(part, firstOperand, secondOperand));
                    }
                    catch(Exception ex)
                    {
                        if (check == false || rpnStack.Count > 1) 
                        return "E";
                    }
                }
                
            }
           // if (check == false|| rpnStack.Count > 1) return "E";
            check = false;
            return rpnStack.Pop();
        }
    }
}
