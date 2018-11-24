using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CPE200Lab1
{
    public class BasicCalculatorEngine
    {
        public string calculate(string oper, string firstOperand, int maxOutputSize = 8)
        {
            string[] parts;
            int remainLength;
            double result;
            switch (oper)
            {
                case "√":
                    result = Math.Sqrt(Convert.ToDouble(firstOperand));
                    parts = result.ToString().Split('.');
                    if (parts[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    if (parts.Length <= 1)
                    {
                        return result.ToString();
                    }
                    else if (parts[1].Length < maxOutputSize)
                    {
                        return result.ToString();
                    }
                    remainLength = maxOutputSize - parts[0].Length - 1;
                    return result.ToString("N" + remainLength);
                case "1/X":
                    if (Convert.ToDouble(firstOperand) != 0)
                    {
                        result = (1.0 / Convert.ToDouble(firstOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        if (parts.Length <= 1)
                        {
                            return result.ToString();
                        }
                        else if (parts[1].Length < maxOutputSize)
                        {
                            return result.ToString();
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }
        public string calculate(string oper, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (oper)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    if (Convert.ToDouble(secondOperand) != 0)
                    {
                        string[] parts;
                        int remainLength;
                        double result;
                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        if (parts.Length <= 1)
                        {
                            return result.ToString();
                        }
                        else if (parts[1].Length < maxOutputSize)
                        {
                            return result.ToString();
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
            }
            return "E";
        }
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
                case "√":
                case "%":
                case "1/X":
                    return true;
            }
            return false;
        }
    }
}