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
    public partial class ExtendForm : Form, View
    {
        private bool isNumberPart = false;
        private bool hasDot = false;
        private bool isSpaceAllowed = false;
        private bool isEqual = false;
        private string str;
        private CalculatorEngine engine;
        private RPNCalculatorEngine RPNengine;
        Controller controller;
        Model model;
        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            RPNengine = new RPNCalculatorEngine();
            model = new CalculatorModel();
            controller = new CalculatorController();
            model.AttachObserver(this);
            controller.AddModel(model);
        }
        /*private bool isOperator(char ch)
       {
           switch(ch) {
               case '+':
               case '-':
               case 'x':
               case '÷':
               case '%':
               case 'X':
               case '√':
                   return true;
           }
           return false;
       }*/
        public void Notify(Model m)
        {
            lblDisplay.Text = ((CalculatorModel)m).Display();
        }
        private void number_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            if (isEqual)
            {
                lblDisplay.Text = "";
                isEqual = false;
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                hasDot = false;
            }
            lblDisplay.Text += ((Button)sender).Text;
            isSpaceAllowed = true;
        }
        private void operator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
            }
            if (isEqual)
            {
                lblDisplay.Text = "";
                isEqual = false;
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                hasDot = false;
            }
            lblDisplay.Text += " " + ((Button)sender).Text + " ";
            isSpaceAllowed = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            hasDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
            isEqual = false;
        }
        private void btnExe_Click(object sender, EventArgs e)
        {
            string result = engine.calculator(lblDisplay.Text);
            if (result is "E")
            {
                result = RPNengine.calculate(lblDisplay.Text);
                if (result is "E")
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
            }
            else
            {
                lblDisplay.Text = result;
            }
            isEqual = true;
        }
        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = lblDisplay.Text;
            if (current is "0")
            {
                lblDisplay.Text = "-";
            }
            else if (current[current.Length - 1] is '-')
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "")
                {
                    lblDisplay.Text = "-";
                }
            }
            else
            {
                lblDisplay.Text = current + "-";
            }
            isSpaceAllowed = false;
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (!hasDot)
            {
                hasDot = true;
                lblDisplay.Text += ".";
                isSpaceAllowed = false;
            }
        }
        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isSpaceAllowed)
            {
                lblDisplay.Text += " ";
                isSpaceAllowed = false;
                hasDot = false;
            }
        }
    }
}