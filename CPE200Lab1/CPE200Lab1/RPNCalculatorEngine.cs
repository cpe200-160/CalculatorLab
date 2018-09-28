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
            if (str == null || str == "")
            {
                return "E";
            }
            string[] parts = str.Split(' ');
            Stack<string> operands = new Stack<string>();
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (operands.Count < 2)
                    {
                        return "E";
                    }
                    string operands2 = operands.Pop();
                    string operands1 = operands.Pop();
                    string result = calculate(parts[i], operands1, operands2, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    operands.Push(result);
                }
            }
            if (operands.Count > 1)
            {
                return "E";
            }
            return operands.Pop();
        }
        
        /*public override void handleSpace()
        {
            base.handleSpace();
            isNumberPart = false;


        }*/
    }
}