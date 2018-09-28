using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        /// <summary>
        /// check input is a number
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true if it is a number</returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        /// <summary>
        /// check input is an operator
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true if it is an operator</returns>
        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }

        /// <summary>
        ///  process input to calculate result
        /// </summary>
        /// <param name="str"></param>
        /// <returns>result</returns>
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            
            if (isNumber(parts[0]) && (parts[1] == "%")) //calculate percent   Ex: 20 % = 0.2
            {
                return calculate("%", "1", parts[0]);
            }
            else if (parts.Length >= 4 && parts[3] == "%") //calculate percent   Ex: 50 + 20 % = 75
            {
                string percent = calculate("%", parts[0], parts[2]);
                return calculate(parts[1], parts[0], percent, 4);
            }
            if (isNumber(parts[0]) && (parts[1] == "√")) //calculate √   Ex: 2 √ = 1.4...
            {
                return unaryCalculate("√", parts[0]);
            }
            else if (isNumber(parts[0]) && (parts[1] == "1/x")) //calculate one over x   Ex: 1 1/x = 1
            {
                return unaryCalculate("1/x", parts[0]);
            }
            else if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])) //calculate number  Ex: 1 + 2 = 3
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else
            {
                return "E";
            }

        }
        /// <summary>
        /// check operator are √ and 1/x then calculate result
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="operand"></param>
        /// <param name="maxOutputSize"></param>
        /// <returns>result</returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
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
                        double result2 = Convert.ToDouble(result.ToString("N" + remainLength));
                        return result2.ToString();
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
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
                        double result2 = Convert.ToDouble(result.ToString("N" + remainLength));
                        return result2.ToString(); ;
                    }
                    break;
            }
            return "E";
        }
        /// <summary>
        /// check operator are +,-,X and ÷  then calculate result
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <param name="maxOutputSize"></param>
        /// <returns>result</returns>
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
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        double result2 = Convert.ToDouble(result.ToString("N" + remainLength));
                        return result2.ToString();
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
            }
            return "E";
        }
    }
}
