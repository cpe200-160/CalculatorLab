using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        protected CalculatorEngine C;
        protected RPNCalculatorEngine RpnC;
        private string result;

        public CalculatorModel()
        {
            C    = new CalculatorEngine();
            RpnC = new RPNCalculatorEngine();

        }
        public bool isNumber(string str)
        {
            return C.isNumber(str);
        }
         //public bool isOpera
        public string GetAnswer()
        {
            return result;
        }
        public void SequentialCalculate(string str)
        {
            result = C.calculate(str);
            if(this.result == "E")
            {
                result = RpnC.calculate(str);
                if(this.result == "E")
                {
                    result = "E";
                }
                NoticeMeSenpai();
            }
        }
        public string calculate(string FirstOperand , string SecondOperand , string Operate)
        {
            return calculate(Operate, FirstOperand, SecondOperand);
        }
        public string calculate(string Operand,string Operate)
        {
            return calculate(Operate, Operand);
        }
        public string calculate(string Text)
        {
            return calculate(Text);
        }
    }
}
