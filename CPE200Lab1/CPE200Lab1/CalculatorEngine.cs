using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        private bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }
        /*public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "Error";
            } else
            {
                return calculate(parts[1], Convert.ToDouble(parts[0]), Convert.ToDouble(parts[2]), 4);
            }
        }*/
        public string unaryCalculate(string operate, double operand, double firstOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        if(0 <= Convert.ToDouble(operand))
                        {
                            double result = Math.Sqrt(Convert.ToDouble(operand));
                            return showResult(result, Convert.ToString(result).Length);
                        }
                        break;
                    }
                case "1/x":
                    if(operand != 0)
                    {
                        double result = (1.0 / Convert.ToDouble(operand));
                        return showResult(result, Convert.ToString(result).Length);
                    }
                    break;
                case "x²":
                    {
                        double result = Math.Pow(Convert.ToDouble(operand),2);
                        return showResult(result, Convert.ToString(result).Length);
                    }
                case "%":
                    {
                        double result = (firstOperand * Convert.ToDouble(operand) / 100);
                        return showResult(result, Convert.ToString(result).Length);
                    }
            }
            return "Error";
        }

        public void calculate(string operate,ref double firstOperand, double secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    {
                        firstOperand = (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand));
                    }
                    break;
                case "-":
                    {
                        firstOperand = (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand));
                    }
                    break;
                case "X":
                    {
                        firstOperand = (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand));
                    }
                    break;
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != 0)
                    {
                        firstOperand = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                    }
                    break;
            }
            //return "Error";
        }

        public string showResult(double currentOperand, int maxOutputSize = 8)
        {
            //string temp = Convert.ToString(currentOperand);
            //int locdot = temp.IndexOf('.');
            /*if (currentOperand%1 != 0)
            {
                string[] parts;
                int remainLength;
                // split between integer part and fractional part
                parts = currentOperand.ToString().Split('.');
                // if integer part length is already break max output, return error
                if (parts[0].Length > maxOutputSize)
                {
                    return "Error";
                }           
                // calculate remaining space for fractional part.
                remainLength = maxOutputSize - parts[0].Length - 1;
                // trim the fractional part gracefully. =
                return currentOperand.ToString("N" + remainLength);
            }
            return temp;*/
            string content_to_str = Convert.ToString(currentOperand);
            if (content_to_str == "-∞" || content_to_str == "∞" || content_to_str == "NaN") return "Error";
            if (content_to_str.Length > 8 && currentOperand <= 999999.1)
            {
                content_to_str = content_to_str.Remove(8, content_to_str.Length - 8);
            }
            
            if (content_to_str.Length > 8)
            {
                content_to_str = "Error";
            }
            return content_to_str;
        }
    }
}
