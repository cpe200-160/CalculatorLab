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
            else
            {
                string[] parts = str.Split(' ');
                Stack<string> text = new Stack<string>();
                for (int i = 0; i < parts.Length; i++)
                {
                    if (isNumber(parts[i]))
                    {
                        text.Push(parts[i]);
                    }
                    else if (isOperator(parts[i]))
                    {
                        if (text.Count < 2)
                        {
                            return "E";
                        }
                        string text2 = text.Pop();
                        string text1 = text.Pop();
                        string result = calculate(parts[i], text1, text2, 4);
                        if (result is "E")
                        {
                            return result;
                        }
                        text.Push(result);
                    }
                    else
                    {
                        string numberoroperator = parts[i];
                        for (int j = 0; j < numberoroperator.Length; j++)
                        {
                            if (isOperator(numberoroperator[j].ToString()) && numberoroperator[j] != '-')
                            {
                                return "E";
                            }
                        }
                    }  
                }
                //FIXME, what if there is more than one, or zero, items in the stack?
                if (text.Count != 1)
                {
                    return "E";
                }
                else if (text.Count == 1)
                {
                    string number = text.Pop();
                    for (int i = 0; i < number.Length; i++)
                    {
                        if (isOperator(number[i].ToString()) && number[0] != '-') return "E";
                    }

                    text.Push(number);
                }
                return text.Pop();
            }
        }
    }
}