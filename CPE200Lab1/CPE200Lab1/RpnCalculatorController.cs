using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RpnCalculatorController : Controller
    {
        public void BtnNumber_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnNumber_Click(sender, e);
            }
        }

        public void BtnBinaryOperator_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnBinaryOperator_Click(sender, e);
            }
        }
        public void BtnBack_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnBack_Click(sender, e);
            }
        }
        public void BtnClear_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnClear_Click(sender, e);
            }
        }
        public void BtnEqual_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnEqual_Click(sender, e);
            }
        }
        public void BtnSign_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnSign_Click(sender, e);
            }
        }
        public void BtnDot_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnDot_Click(sender, e);
            }
        }
        public void BtnSpace_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnSpace_Click(sender, e);
            }
        }
        public void BtnUnaryOperator_Click(object sender, EventArgs e)
        {
            foreach (RpnCalculatorModel m in ControlList)
            {
                m.BtnUnaryOperator_Click(sender, e);
            }
        }
    }
}
