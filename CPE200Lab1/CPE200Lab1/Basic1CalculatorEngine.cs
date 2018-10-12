﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class BasicCalculatorEngine
    {
        /// <summary>
        /// chack wether input is number
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>True if str repersent a number </returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// chack wether input is operator
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>True if str repersent a operator</returns>
        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// chack wether input is operator "√" and "1/x"
        /// </summary>
        /// <param name="ch">Input string</param>
        /// <returns>True if str repersent a operator "√" and "1/x"</returns>
        public bool isOperator2(string ch)
        {
            switch (ch)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// calculate input number
        /// </summary>
        /// <param name="operate">Input string</param>
        /// <param name="operand">Input string</param>
        /// <param name="maxOutputSize">Input int</param>
        /// <returns>result</returns>
        public string Calculate(string operate, string operand, int maxOutputSize = 8)
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
                        return result.ToString(); //return result.ToString("N" + remainLength);
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
                        return result.ToString(); //return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }

        /// <summary>
        /// calculate input number
        /// </summary>
        /// <param name="operate">Input string</param>
        /// <param name="firstOperand">Input string</param>
        /// <param name="secondOperand">Input string</param>
        /// <param name="maxOutputSize">Input int</param>
        /// <returns>result</returns>
        public string Calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
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
                        return result.ToString(); //return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    double first = Convert.ToDouble(firstOperand);
                    double secon = Convert.ToDouble(secondOperand);
                    return (first + (first * secon) / 100).ToString();
            }
            return "E";
        }
    }
}
