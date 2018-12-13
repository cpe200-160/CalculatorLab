using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class MainFormController : SimpleCalculatorEngine
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
                case "UOperator":
                    handleUnaryOperator(intput);
                    break;
                case "Operator":
                    handleOperator(intput);
                    break;
                case "Equal":
                    handleEqual();
                    break;
                case "Dot":
                    handleDot();
                    break;
                case "Sign":
                    handleSign();
                    break;
                case "reset":
                    resetAll();
                    break;
                case "Back":
                    handleBack();
                    break;
                case "M":
                    handleMP_MC_MM_MR(intput);
                    break;
            }
            return Display();
        }
    }
}