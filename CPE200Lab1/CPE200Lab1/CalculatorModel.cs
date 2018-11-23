using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorModel : Model
    {

        protected CalculatorEngine engine;
        protected RPNCalculatorEngine RPNengine;
        private string display;

        public string Display()
        {
            return display;
        }

        public void calculator(string str)
        {
            string result = engine.calculate(str);
            if(result is "E")
            {
                result = RPNengine.calculate(str);
                if(result is "E")
                {
                    display = "Error";
                }
                else
                {
                    display = result;
                }
            }
            else
            {
                display = result;
            }
            NotifyAll();
        }
    }
}