using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {


        public override string Process(string str)
        {
            if (isSpaceAllowed) return str;
            string[] parts = str.Split(' ');
            Stack<string> operands = new Stack<string>();
            string result = "0";
            for (int i = 0; i < parts.Length; i++)
            {



                if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    string num1;
                    string num2;
                    if (operands.Count() > 1)
                    {
                        num2 = operands.Pop();
                        num1 = operands.Pop();
                    }
                    else
                    {
                        return "E";
                    }
                    result = calculate(parts[i], ppap1, ppap2, 4);
                    operands.Push(result);
                }



            }

            return result;

        }
    }


}

