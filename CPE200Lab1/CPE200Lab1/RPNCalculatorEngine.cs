using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine  : CalculatorEngine
    {
        public override string Process(string str)
        {
            string[] parts = str.Split(' ');
            Stack<string> cha = new Stack<string>();
            string s1, s2, s3;
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    cha.Push(parts[i]);
                }

                else if (isOperator(parts[i]))
                {
                    if (cha.Count() < 2)
                    {
                        return "E";
                    }
                    s2 = cha.Pop();
                    s1 = cha.Pop();
                    s3 = calculate(parts[i], s1, s2, 4);
                    cha.Push(s3);


                }

            }
            if (cha.Count() == 1)
            {

                return cha.Peek();

            }

            else
            {
                return "E";
            }
        }

    }
    
}
