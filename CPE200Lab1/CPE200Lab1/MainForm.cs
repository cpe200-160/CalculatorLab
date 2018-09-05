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
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        


        private CalculatorEngine engine = new CalculatorEngine();

        
        private void resetAll()
        {
            engine.resetAll();
            lblDisplay.Text = engine.Display();
        }

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        public void cal(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            engine.calculate(operate,firstOperand,secondOperand,maxOutputSize);
            lblDisplay.Text = engine.Display();

        }
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string digit = ((Button)sender).Text;
            engine.Num(digit);
            lblDisplay.Text = engine.Display();
        }

        
        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            operate = ((Button)sender).Text;
            engine.handleOperator(operate);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            engine.ee();
            lblDisplay.Text = engine.Display();

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            engine.GG();
            lblDisplay.Text = engine.Display();
        }
        

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.handleSign();
            lblDisplay.Text = engine.Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            engine.black();
            lblDisplay.Text = engine.Display();
        }
    }
}
