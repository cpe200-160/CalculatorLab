using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorController : Controller
    {
        public void BtnNumber_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnNumber_Click(sender, e);
            }

        }
        public void BtnUnaryOperator_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnUnaryOperator_Click(sender, e);
            }

        }
        public void BtnOperator_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnOperator_Click(sender, e);
            }

        }
        public void BtnEqual_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnEqual_Click(sender, e);
            }

        }
        public void BtnDot_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnDot_Click(sender, e);
            }

        }
        public void BtnSign_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnSign_Click(sender, e);
            }

        }
        public void BtnClear_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnClear_Click(sender, e);
            }

        }

        public void BtnBack_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnBack_Click(sender, e);
            }

        }

        public void BtnMP_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnMP_Click(sender, e);
            }

        }

        public void BtnMC_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnMC_Click(sender, e);
            }

        }

        public void BtnMM_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnMM_Click(sender, e);
            }

        }

        public void BtnMR_Click(object sender, EventArgs e)
        {
            foreach (CalculatorModel m in ControlList)
            {
                m.BtnMR_Click(sender, e);
            }

        }
    }
}


