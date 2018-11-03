using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorController : Controller
    {
        public const int btnNumber_Click = 0;
        public override void calculate(string str)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.simpleProcessingCalculate(str);
            }
        }
        public override void performedAction(int action)
        {
            foreach (CalculatorModel m in ControlList)
            {
                switch (action)
                {
                    case btnNumber_Click:
                        m.btnNumber_Click(object sender, EventArgs e);

                        break;
                }
                m.btnBack_Click(sender, e);
                m.btnClear_Click(sender, e);
                m.btnDot_Click(sender, e);
                m.btnEqual_Click(sender, e);
                m.btnMC_Click(sender, e);
                m.btnMM_Click(sender, e);
                m.btnMP_Click(sender, e);
                m.btnMR_Click(sender, e);
                m.btnNumber_Click(sender, e);
                m.btnOperator_Click(sender, e);
                m.btnSign_Click(sender, e);
                m.btnUnaryOperator_Click(sender, e);
            }
        }
        
    }
}

