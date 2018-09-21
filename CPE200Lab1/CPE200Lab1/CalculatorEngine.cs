using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        public bool isSpaceAllowed = false;


        public string dp = "0";

        public virtual string Display()
        {
            return dp;
        }

        public void Num(string hi)
        {

            if (dp is "0")
            {
                dp = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            dp += hi;
            isSpaceAllowed = true;
        }

        public void bin(string hi)
        {
            isNumberPart = false;
            isContainDot = false;
            string current = dp;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2].ToString()))
            {
                dp += " " + hi + " ";
                isSpaceAllowed = false;
            }
        }
        public void black(object n, EventArgs e)
        {
            string current = dp;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2].ToString()))
            {
                dp = current.Substring(0, current.Length - 3);
            }
            else
            {
                dp = current.Substring(0, current.Length - 1);
            }
            if (dp is "")
            {
                dp = "0";
            }
        }

        public void clear(object n, EventArgs e)
        {
            dp = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }



        public void Dota2(object n, EventArgs e)
        {
            if (!isContainDot)
            {
                isContainDot = true;
                dp += ".";
                isSpaceAllowed = false;
            }
        }
        public void sign(object n, EventArgs e)
        {
            if (isNumberPart)
            {
                return;
            }
            string current = dp;
            if (current is "0")
            {
                dp = "-";
            }
            else if (current[current.Length - 1] is '-')
            {
                dp = current.Substring(0, current.Length - 1);
                if (dp is "")
                {
                    dp = "0";
                }
            }
            else
            {
                dp = current + "-";
            }
            isSpaceAllowed = false;
        }
        public virtual void space(object n, EventArgs e)
        {
            if (isSpaceAllowed)
            {
                dp += " ";
                isSpaceAllowed = false;
            }
        }
        public virtual bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public virtual bool isOperator(string str)
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

        public virtual string Process(string str)
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
                        return result.ToString("N" + remainLength);
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
                        return result.ToString("N" + remainLength);
                    }
                    break;
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
                    break;
            }
            return "E";
        }
    }
}