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
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "Error";
            } else
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
                        if(0 <= Convert.ToDouble(operand))
                        {
                            double result = Math.Sqrt(Convert.ToDouble(operand));
                            return numberShowed(result, Convert.ToString(result).Length);
                        }
                        break;
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result = (1.0 / Convert.ToDouble(operand));
                        return numberShowed(result, Convert.ToString(result).Length);
                    }
                    break;
                case "x²":
                    {
                        double result = Math.Pow(Convert.ToDouble(operand),2);
                        return numberShowed(result, Convert.ToString(result).Length);
                    }
            }
            return "Error";
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
                        double result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        return numberShowed(result, Convert.ToString(result).Length);
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString(); //your code here
                    //break;
            }
            return "Error";
        }

        private string numberShowed(double currentOperand, int maxOutputSize = 8)
        {
            string temp = Convert.ToString(currentOperand);
            if (currentOperand > 99999999) return "Error";
            int locdot = temp.IndexOf('.');
            if (locdot > 0)
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
                /*double Roundnumber = Convert.ToDouble(temp);
                Roundnumber = System.Math.Ceiling(Roundnumber * 100) / 100;
                return Roundnumber.ToString();*/
                // calculate remaining space for fractional part.
                remainLength = maxOutputSize - parts[0].Length - 1;
                // trim the fractional part gracefully. =
                return currentOperand.ToString("N" + remainLength);
            }
            return temp;
        }
    }
}
