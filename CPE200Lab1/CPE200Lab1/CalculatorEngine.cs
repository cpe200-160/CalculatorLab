using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        public bool hasDot;
        public bool isAllowBack;
        public bool isAfterOperater;
        public bool isAfterEqual;
        public string firstOperand;
        public string operate;
        public string ChocoboDisplay;


        public string Display()
        {
            return ChocoboDisplay;
        }

        public void resetAll()
        {

            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            ChocoboDisplay = "0";
        }
        public void Num(string asd)
        {
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                ChocoboDisplay = "0";
            }
            if (ChocoboDisplay.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = asd;
            if (ChocoboDisplay is "0")
            {
                ChocoboDisplay = "";
            }
            ChocoboDisplay += digit;
            isAfterOperater = false;
        }

        
        public void handleSign()
        {
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (ChocoboDisplay.Length is 8)
            {
                return;
            }
            if (ChocoboDisplay[0] is '-')
            {
                ChocoboDisplay = ChocoboDisplay.Substring(1, ChocoboDisplay.Length - 1);
            }
            else
            {
                ChocoboDisplay = "-" + ChocoboDisplay;
            }

        }
        public void handleOperator(string save)
        {
            
            if (isAfterOperater)
            {
                return;
            }
            operate = save;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = ChocoboDisplay;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    break;
            }
            isAllowBack = false;
        }
        public void ee()
        {
            string secondOperand = ChocoboDisplay;
            string result = calculate(operate, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                ChocoboDisplay = "Error";
            }
            else
            {
                ChocoboDisplay = result;
            }
            isAfterEqual = true;
        }

        public void GG ()
            {
            if (ChocoboDisplay.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                ChocoboDisplay += ".";
                hasDot = true;
            }
        }
        public void black()
        {
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (ChocoboDisplay != "0")
            {
                string current = ChocoboDisplay;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                ChocoboDisplay = current.Substring(0, current.Length - 1);
                if (ChocoboDisplay is "" || ChocoboDisplay is "-")
                {
                    ChocoboDisplay = "0";
                }
            }
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
