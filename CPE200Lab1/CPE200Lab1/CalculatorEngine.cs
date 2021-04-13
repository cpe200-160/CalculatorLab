using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand,int maxOutputSize = 8)
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
                case "%":
                    //your code here
                    return (((Convert.ToDouble(secondOperand)) / 100) * Convert.ToDouble(firstOperand)).ToString();
                case "√":
                    double result2;
                    string[] parts2;
                    int remainLength2;

                    result2 = (Math.Sqrt(Convert.ToDouble(firstOperand)));
                    // split between integer part and fractional part
                    parts2 = result2.ToString().Split('.');
                    // if integer part length is already break max output, return error
                    if (parts2[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    // calculate remaining space for fractional part.
                    remainLength2 = maxOutputSize - parts2[0].Length - 1;
                    // trim the fractional part gracefully. =
                    return result2.ToString("N" + remainLength2);
                case "1/X":
                    double result3;
                    string[] parts3;
                    int remainLength3;

                    result3 = (1 / Convert.ToDouble(firstOperand));
                    // split between integer part and fractional part
                    parts3 = result3.ToString().Split('.');
                    // if integer part length is already break max output, return error
                    if (parts3[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    // calculate remaining space for fractional part.
                    remainLength3 = maxOutputSize - parts3[0].Length - 1;
                    // trim the fractional part gracefully. =
                    return result3.ToString("N" + remainLength3);
            }
            return "E";
        }
    }
}
