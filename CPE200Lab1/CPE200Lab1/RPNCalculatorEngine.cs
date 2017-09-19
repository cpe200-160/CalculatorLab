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
        public new string Process(string str)
        {
            if (str == null || str == "") { return "E"; }
            string result;
            Stack rpnStack = new Stack();
            String[] parts = str.Split(' ');
            bool check = true;

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    if (parts[i].First() == '+')
                    {
                        return "E";
                    }
                    rpnStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (check == false)
                    {
                        return "E";
                    }
                    if (rpnStack.Count <= 1)
                    {

                        return "E";
                    }
                    String second = rpnStack.Pop().ToString();
                    String first = rpnStack.Pop().ToString();
                    result = calculate(parts[i], first, second);
                    rpnStack.Push(result);
                }
                else { check = false; }
            }
            if (rpnStack.Count == 0 || rpnStack.Count > 1)
            {
                return "E";
            }
            result = rpnStack.Pop().ToString();
            return result;
        }
    }
}
