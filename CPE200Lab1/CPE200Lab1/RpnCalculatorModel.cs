using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RpnCalculatorModel : Model
    {
        protected RPNCalculatorEngine rpnC;
        protected CalculatorEngine mainC;
        private string result;

        public RpnCalculatorModel()
        {
            rpnC = new RPNCalculatorEngine();

        }
        public bool isNumber(string str)
        {
            return mainC.isNumber(str);
        }
        public bool isOperator(string str)
        {
            return mainC.isOperator(str);
        }
        public string gettingRpnAnswer()
        {
            return result;
        }
        public void rpnProcessingCalculate(string str)
        {
            result = rpnC.calculate(str);
            if (this.result == "E")
                {
                    result = "E";
                }
            NoticeMeSenpai();
            
        }
        public string calculate(string Text)
        {
            return calculate(Text);
        }
    }
}
