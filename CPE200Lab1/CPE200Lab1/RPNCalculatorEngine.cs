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
                    string ppap1;
                    string ppap2;
                    if (operands.Count() > 1)
                    {
                        ppap2 = operands.Pop();
                        ppap1 = operands.Pop();

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