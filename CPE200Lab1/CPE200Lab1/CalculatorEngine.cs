using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        String Result = "";
        public string calculate(string operate, string firstOperand, string secondOperand="",string prev_operate="",int maxOutputSize = 8)
        {
      
                switch (operate)
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
                    
                    case "1/X":
                        if (firstOperand == "0")
                        {
                            return "Error";
                        }
                        else
                        {

                            Result = (1 / Convert.ToDouble(firstOperand)).ToString();
                            if (Result.Length > 8)
                            {
                                Result = Result.Remove(8, Result.Length - 8);
                            }
                            return Result;
                        }
                        
                    case "√":
                        Result = (Math.Sqrt(Convert.ToDouble(firstOperand))).ToString();
                       if (Result.Length > 8)
                        {
                            Result = Result.Remove(8, Result.Length - 8);
                        }
                        return Result;
                       
                    case "%":
                        switch (prev_operate)
                        {
                        case "+":
                            return Convert.ToString(Convert.ToDouble(firstOperand) + (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100));
                           //break;
                        case "-":
                            return Convert.ToString(Convert.ToDouble(firstOperand) - (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100));
                           //break;
                        case "X":
                            return Convert.ToString(Convert.ToDouble(firstOperand) * (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100));
                           //break;
                         case "÷":
                             if (secondOperand != "0")
                             {
                             return Convert.ToString(Convert.ToDouble(firstOperand) / (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100));
                             }
                             else
                             {
                              return "Error";
                             }
                             //break;
                        }
                        break;

                }
           
            return "E";
        }
    }

   
}
