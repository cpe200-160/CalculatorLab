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
            if(str == null || str == "+1" )
            {
                return "E";
            }
            else if(str == null || str == "")
            {
                return "E";
            }
            string[] parts = str.Split(' ');
            Stack<string> cha = new Stack<string>();
            string s1, s2, s3,result;
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
                else if (parts[i] == "++")
                {
                    break;
                }

            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (cha.Count() != 1)
            {
                return "E";
            }
            else
            {
                result = cha.Pop();
                return result;
            }
        }
    }
   
}
