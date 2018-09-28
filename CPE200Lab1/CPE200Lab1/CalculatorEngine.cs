using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }
        public bool isUnaryOperator(string str)
        {
            switch (str)
            {
                case "1/x":
                case "√":
                case "%":
                    return true;
            }
            return false;
        }
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result1;
                        string[] parts;
                        int remainLength;
                        try
                        {
                            result1 = Math.Sqrt(Convert.ToDouble(operand));
                            // split between integer part and fractional part
                            parts = result1.ToString().Split('.');
                            if (Convert.ToDouble(operand) % Math.Sqrt(Convert.ToDouble(operand)) != 0)
                            {
                                // if integer part length is already break max output, return error
                                if (parts[0].Length > maxOutputSize)
                                {
                                    return "E";
                                }
                                // calculate remaining space for fractional part.
                                remainLength = maxOutputSize - parts[0].Length - 1;
                                // trim the fractional part gracefully. =
                                return result1.ToString("0.#####");
                            }
                            else
                            {
                                return result1.ToString();
                            }
                        }
                        catch (Exception)
                        {
                            return "E";
                        }
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result2;
                        string[] parts;
                        int remainLength;
                        try
                        {
                            result2 = (1.0 / Convert.ToDouble(operand));
                            // split between integer part and fractional part
                            parts = result2.ToString().Split('.');
                            if (parts[1].Length > 5)
                            {
                                // if integer part length is already break max output, return error
                                if (parts[0].Length > maxOutputSize)
                                {
                                    return "E";
                                }
                                // calculate remaining space for fractional part.
                                remainLength = maxOutputSize - parts[0].Length - 1;
                                // trim the fractional part gracefully. =
                                return result2.ToString("0.#####");
                            }
                            else
                            {
                                return result2.ToString();
                            }
                        }
                        catch (Exception)
                        {
                            return "E";
                        }
                    }
                    break;
                case "%":
                    double result3;
                    result3 = (0.01 * Convert.ToDouble(operand));
                    return result3.ToString();
            }
            return "E";
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
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
                        if (Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand) == 0)
                        {
                            return result.ToString();
                        }
                        else
                        {
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

                    }
                    break;
                case "%":
                    //your code here
                    if (operate == "+" && firstOperand != "0")
                    {
                        return (Convert.ToDouble(firstOperand) + (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    else if (operate == "+" && firstOperand != "0")
                    {
                        return (Convert.ToDouble(firstOperand) - (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    else if (operate == "X" && firstOperand != "0")
                    {
                        return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    else if (operate == "÷" && firstOperand != "0")
                    {
                        return (Convert.ToDouble(firstOperand) / (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                    }
                    else if (secondOperand == "0")
                    {
                        return (0.01 * Convert.ToDouble(firstOperand)).ToString();
                    }
                    break;
            }
            return "E";
        }
    }
}
