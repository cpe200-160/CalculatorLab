using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class ExtendFromController : RPNCalculatorEngine
    {
        public string controller(string cont = "", string intput = "")
        {
            switch (cont)
            {
                case "":
                    break;
                case "Number":
                    handleNumber(intput);
                    break;
                case "BOperator":
                    handleBinaryOperator(intput);
                    break;
                case "Back":
                    handleBack();
                    break;
                case "reset":
                    resetAll();
                    break;
                case "Equal":
                    handleEqual();
                    break;
                case "Sign":
                    handleSign();
                    break;
                case "Dot":
                    handleDot();
                    break;
                case "Space":
                    handleSpace();
                    break;
            }
            return Display();
        }
    }
}