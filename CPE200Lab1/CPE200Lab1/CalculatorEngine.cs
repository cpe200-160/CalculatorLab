using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, string firstoperate)
        {
            
            int maxOutputSize = 8;

            switch (firstoperate)
            {

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
                        double result;
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
                    
                    if ( firstoperate == "+" )
                    {
                        return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                    }
                    if(firstoperate == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (firstoperate == "*")
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (firstoperate == "/")
                    {
                        return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    }
                    //your code here
                    break;
                case "1/x":
                    if (firstoperate == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (firstoperate == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (firstoperate == "*")
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (firstoperate == "/")
                    {
                        return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    }
                    break;
                case "√":
                    if (firstoperate == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (firstoperate == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (firstoperate == "*")
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (firstoperate == "/")
                    {
                        return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    }
                    

                    break;
            }
            return "E";
        }
    }

}
