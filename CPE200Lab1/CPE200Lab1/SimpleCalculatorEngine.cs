using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class SimpleCalculatorEngine : CalculatorEngine
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private double memory;
        private string display;

        public string Display()
        {
            return display;
        }
        
        public void resetAll()
        {
            memory = 0;
            display = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }
        
        public void handleNumber(string inputNumber)
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                display = "0";
            }
            if (display.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            if (display is "0")
            {
                display = "";
            }
            display += inputNumber;
            isAfterOperater = false;
        }

        public void handleUnaryOperator(string inputUnaryOperate)
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = inputUnaryOperate;
            firstOperand = display;
            string result = unaryCalculate(operate, firstOperand);
            if (result is "E" || result.Length > 8)
            {
                display = "Error";

            }
            else
            {
                display = result;
            }
        }

        public void handleOperator(string inputOperator)
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            if (firstOperand != null)
            {
                string secondOperand = display;
                string result = calculate(operate, firstOperand, secondOperand);
                if (result is "E" || result.Length > 8)
                {
                    display = "Error";
                }
                else
                {
                    display = result;
                }
            }
            operate = inputOperator;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = display;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    break;
            }
            isAllowBack = false;
        }

        public void handleEqual()
        {
            if (display is "Error")
            {
                return;
            }
            string secondOperand = display;
            string result = calculate(operate, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                display = "Error";
            }
            else
            {
                display = result;
            }
            isAfterEqual = true;
        }

        public void handleDot()
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (display.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                display += ".";
                hasDot = true;
            }
        }

        public void handleSign()
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (display.Length is 8)
            {
                return;
            }
            if (display[0] is '-')
            {
                display = display.Substring(1, display.Length - 1);
            }
            else
            {
                display = "-" + display;
            }
        }

        public void handleBack()
        {
            if (display is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (display != "0")
            {
                string current = display;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                display = current.Substring(0, current.Length - 1);
                if (display is "" || display is "-")
                {
                    display = "0";
                }
            }
        }

        public void handleMP_MC_MM_MR(string inputM)
        {
            switch (inputM)
            {
                case "P":
                    if (display is "Error")
                    {
                        return;
                    }
                    memory += Convert.ToDouble(display);
                    isAfterOperater = true;
                    break;

                case "C":
                    memory = 0;
                    break;

                case "M":
                    if (display is "Error")
                    {
                        return;
                    }
                    memory -= Convert.ToDouble(display);
                    isAfterOperater = true;
                    break;

                case "R":
                    if (display is "error")
                    {
                        return;
                    }
                    display = memory.ToString();
                    break;
            }
        }

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
                        return result.ToString("G2" + remainLength);
                    }
                case "1/x":
                    if (operand != "0")
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
                        return result.ToString("G2" + remainLength);
                    }
                    break;
            }
            return "E";
        }
    }
}