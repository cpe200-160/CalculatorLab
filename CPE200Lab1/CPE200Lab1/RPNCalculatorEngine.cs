using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    /// <summary>
    /// main RpncalculatorEngine class
    /// </summary>
namespace CPE200Lab1
{
    /// <summary>
    /// contain some basic methods to perform math function in Rpn terms
    /// </summary>
    /// <remarks>
    ///<para>
    ///this class can be Add,Subtract,Multiply,Divide,Percentage,OneOverX,SquareRoot
    ///</para>
    ///<para>can be perform both intreger and double
    ///</para>
    ///</remarks>
   

    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
            //separate the intreger and fraction
            string[] parts = str.ToString().Split(' ');
            string result;
            foreach (string part in parts)
            {
                //must have at least 2 stacks and non zero
                if (parts.Count() < 3 && str != "0")
                {
                    return "E";
                }
                else if (isNumber(part))
                {

                    rpnStack.Push(part);
                }
                else if (isOperator(part))
                {                        
                    try
                    {
                        string firstOperand, secondOperand;
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(part, firstOperand, secondOperand);
                        rpnStack.Push(result);
                    }
                    
                    catch (InvalidOperationException)
                    {

                        return "E";
                    }
                }
                else if (isUnaryOperator(part))
                {
                    string firstOperand;
                    firstOperand = rpnStack.Pop();
                    result = unaryCalculate(part, firstOperand);
                    rpnStack.Push(result);
                }
            }
            //when have some remaining stack output is Error
            if (rpnStack.Count > 1) return "E";
            return rpnStack.Pop();
        }
    }
}
