using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    //This class inhertis from CalculatorEngine
    //This class is subclass, CalculatorEngine is superclass
    class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> parts = new Stack<string>();
            string[] temp = str.Split(' ');
            for(int i = 0; i < temp.Length; i++)
            {
                switch (temp[i])
                {
                    case "+":
                    case "-":
                    case "X":
                    case "÷":
                        if (parts.Count < 2) return "Error";
                        string secondOperand = parts.Pop();
                        string firstOperand = parts.Pop();
                        string result = calculate(temp[i], firstOperand, secondOperand);
                        parts.Push(result);
                        continue;
                }
                parts.Push(temp[i]);
            }
            return parts.Pop();
        }
    }
}
