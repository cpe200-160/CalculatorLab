using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    { 
        public string RPNProcess(string str)
        {
            bool Is_Have_Operator = false;
            bool Errorx = false;
            Stack myStack = new Stack();
            List<string> parts = str.Split(' ').ToList<string>();
            for ( int i =0;i < parts.Count; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);
                }else if(isOperator(parts[i]))
                {
                    Console.WriteLine(myStack.Count);
                    if(myStack.Count <= 1 )
                    {
                        return ("Error");
                    }else
                    {
                        Is_Have_Operator = true;
                        string SecondNumber = myStack.Pop().ToString();
                        string FristNumber = myStack.Pop().ToString();
                        myStack.Push(calculate(parts[i], FristNumber, SecondNumber));
                    }

                }
            }
            if (Is_Have_Operator == false || Errorx == true)
            {
                return ("Error");
            }
            return myStack.Pop().ToString() ;
        }
    }
}
