using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RpnCalculatorController : Controller
    {
         public override void Calculate(string str)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.rpnProcessingCalculate(str);
            }
        }
    }
}
