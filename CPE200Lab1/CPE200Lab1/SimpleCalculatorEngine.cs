using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class SimpleCalculatorEngine : CalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;
        public void setFirstOperand(string FirstOperand)
        {
            firstOperand = Double.Parse(FirstOperand);
        }
        public void setSecondOperand(string SecondOperand)
        {
            secondOperand = Double.Parse(SecondOperand);
        }
        public String Calculate(string operate)
        {
            return Calculate(operate);
        }
    }
}

