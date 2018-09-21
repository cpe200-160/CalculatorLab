using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class ExtendForm : Form
    {

        private CalculatorEngine engine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = Engine();
        }
        protected virtual CalculatorEngine Engine()
        {
            return new CalculatorEngine();
        }
        private bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string hi = ((Button)sender).Text;
            engine.Num(hi);
            lblDisplay.Text = engine.Display();

        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string hi = ((Button)sender).Text;
            engine.bin(hi);
            lblDisplay.Text = engine.Display();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.black(sender, e);
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            engine.clear(sender, e);
            lblDisplay.Text = engine.Display();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result = engine.Process(lblDisplay.Text);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.sign(sender, e);
            engine.Display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.Dota2(sender, e);
            engine.Display();
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.space(sender, e);
            engine.Display();
        }
    }
}
