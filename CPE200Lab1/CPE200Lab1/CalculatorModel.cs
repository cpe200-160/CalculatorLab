using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        protected CalculatorEngine mainC;
        protected SimpleCalculatorEngine simpleC;
        private string result;

        public CalculatorModel()
        {
            mainC    = new CalculatorEngine();
            simpleC = new SimpleCalculatorEngine();
        }
        public bool isNumber(string str)
        {
            return mainC.isNumber(str);
        }
        
        public string gettingSimpleAnswer()
        {
            return result;
        }
        public void simpleProcessingCalculate(string str)
        {
            result = simpleC.calculate(str);
            if(this.result == "E")
            {
                    result = "E";
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
       
    }
}
