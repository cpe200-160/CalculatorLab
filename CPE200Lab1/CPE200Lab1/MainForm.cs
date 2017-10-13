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
        private bool isAllowBack = false;
        private bool isAfterOperater = false;
        private bool isAfterEqual = false;
        private bool isfirstEnter = true;
        private bool isAfterUnary = false;
        private double firstOperand = 0;
        private double secondOperand = 0;
        private string operate;
        private string history_line = "";
        private string showNumber = "0";
        private double memory;
        private CalculatorEngine engine;

        private void resetAll()
        {
            showNumber = "0";
            firstOperand = 0;
            secondOperand = 0;
            operate = null;
            isfirstEnter = true;
            isAllowBack = false;
            isAfterOperater = false;
            isAfterUnary = false;
            isAfterEqual = false;
            lblDisplay.Text = showNumber;
            hasDot = false;

            history_line = "";
            lblHistory.Text = history_line;
        }
        public MainForm()
        {
            InitializeComponent();
            memory = 0;
            engine = new SimpleCalculatorEngine();
            resetAll();
        }
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            (new ExtendForm()).Show();
            this.Hide();
        }
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (showNumber is "Error")
            {
                return;
            }
            if (isAfterEqual && history_line == "" && memory == 0)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                showNumber = "0";
            }
            if(showNumber.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(showNumber is "0")
            {
                showNumber = "";
            }
            showNumber += digit;
            lblDisplay.Text = showNumber;
            isAfterOperater = false;
            isAfterUnary = false;
        }
        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (showNumber is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            string type = ((Button)sender).Text;
            showNumber = engine.unaryCalculate(type, lblDisplay.Text);
            if (type == "√") history_line += "√";
            if (type == "1/x") history_line += "1/";
            history_line += " (";
            if (type != "%") History(lblDisplay.Text);
            else History(showNumber);
            history_line += ") ";
            if (type == "x²") history_line += "²";
            lblHistory.Text = history_line;
            isAfterUnary = true;
            /*if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }*/
            //isAfterOperater = true;
            lblDisplay.Text = showNumber;
            //isAllowBack = false;
        }
        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }

            if (isfirstEnter)
            {
                firstOperand = Convert.ToDouble(lblDisplay.Text);
                //operate = ((Button)sender).Text;
            }
            //operate = ((Button)sender).Text;
            if (isAllowBack && isAfterEqual) Processing();
            else History(lblDisplay.Text);
            isAfterEqual = true;
            operate = ((Button)sender).Text;
            history_line += operate;
            lblHistory.Text = history_line;
            //flag_key = 0;
            isAfterOperater = true;

            //History(lblDisplay.Text);

            isAllowBack = false;
            //flag_operator = 0;

            //showNumber = "0";
            isfirstEnter = false;
            lblDisplay.Text = Convert.ToString(firstOperand);
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            
            if (!isAllowBack && isfirstEnter) secondOperand = firstOperand;
            Processing();
            //lblDisplay.Text = engine.showResult(firstOperand);
            showNumber = "0";
            //operate = null;
            isAfterEqual = false;
            isfirstEnter = true;
            history_line = "";
            lblHistory.Text = history_line;
        }
        private void Processing()
        {
            secondOperand = Convert.ToDouble(showNumber);
            firstOperand = Convert.ToDouble(engine.calculate(operate, Convert.ToString(firstOperand), Convert.ToString(secondOperand)));
            /*if (result == "Error")
            {
                lblDisplay.Text = result;
                return;
            }
            firstOperand = Convert.ToDouble(result);
            lblDisplay.Text = result;*/
            History(lblDisplay.Text);
            lblDisplay.Text = Convert.ToString(firstOperand);
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual && history_line == "" && memory == 0)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                showNumber += ".";
                lblDisplay.Text = showNumber;
                hasDot = true;
            }
        }
        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual && history_line == "" && memory == 0)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if(lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            string text = ((Button)sender).Text;
            switch (text)
            {
                case "C":
                    resetAll();
                    break;
                case "CE":
                    showNumber = "0";
                    lblDisplay.Text = showNumber;
                    break;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }
        private void History(string recent)
        {
            if (isAfterUnary) return;
            if (isAllowBack) history_line += " " + recent + " ";
            else history_line = history_line.Remove(history_line.Length - 1, 1);

            //history_line += operate;
            //lblHistory.Text = history_line;
        }
        private void btnMP_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory += Convert.ToDouble(lblDisplay.Text);
            //isAfterOperater = true;
            memoryNumber.Text = (memory).ToString();
        }
        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
            memoryNumber.Text = "0";
        }
        private void btnMM_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(lblDisplay.Text);
            //isAfterOperater = true;
            memoryNumber.Text = (memory).ToString();
        }
        private void btnMR_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "error")
            {
                return;
            }
            showNumber = memory.ToString();
            lblDisplay.Text = showNumber;
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
