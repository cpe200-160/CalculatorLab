using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    //class public is well
    public class CalculatorEngine
    {
        //class private -> pulblic
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    double result = Math.Sqrt(Convert.ToDouble(firstOperand));
                    string lResult = result.ToString();
                    if(lResult.Length >= 8)
                    {
                        lResult = string.Format("{0:N6}", result);
                        result = Convert.ToDouble(lResult);
                    }
                    return result.ToString();
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    double firstNum = Convert.ToDouble(firstOperand);
                    double secondNum = Convert.ToDouble(secondOperand);
                    return (firstNum * secondNum/100).ToString();
                case "1/X":
                    result = 1/Convert.ToDouble(firstOperand);
                    lResult = result.ToString();
                    if (lResult.Length >= 8)
                    {
                        lResult = string.Format("{0:N6}", result);
                        result = Convert.ToDouble(lResult);
                    }
                    return result.ToString();


            }
            return "E";

        }
    }
}


        