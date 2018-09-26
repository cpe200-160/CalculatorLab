using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if(str == null || str == "")
            {
                return "E";
            }
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            
            string result;
            string firstOperand, secondOperand;
            

            foreach (string token in parts)
            {
               if(parts.Count<=2 && str!="0")
               {
                return"E";

               }
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    try { 
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 4);
                    }
                    catch(Exception )
                    {
                        result = "E";
                    }
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
            else if(!isOperator(token) && token!= "")
                {
                    return "E";
                }
            
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            
            if(rpnStack.Count==1)
            {
            result = rpnStack.Pop();
            }
            else
            {
                return "E";
            }
            //return result;
            return decimal.Parse(result.ToString()).ToString("0.####");
        }
    }
}
