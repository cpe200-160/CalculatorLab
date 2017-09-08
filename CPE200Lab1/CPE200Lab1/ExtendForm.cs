﻿using System;
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
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private CalculatorEngine engine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
        }
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            MainForm switchForm = new MainForm();
            switchForm.Show();
            this.Hide();
        }
        private string getLastInString(string str)
        {
            if (str.Length is 1)
                return str;
            return str.Substring(str.Length - 1);
        }
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            lblDisplay.Text += ((Button)sender).Text;
        }
        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (!isNumberPart)
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            lblDisplay.Text += " " + ((Button)sender).Text + " ";
        }
        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            string type = ((Button)sender).Text;
            string[] parts = lblDisplay.Text.Split(' ');
            engine.isConstant(ref parts);
            if (lblDisplay.Text.IndexOf(' ') == -1)
            {
                parts[0] = lblDisplay.Text;
                engine.isConstant(ref parts);
                parts[0] = engine.unaryCalculate(type, Convert.ToDouble(parts[0]), 0);
            }else parts[parts.Length - 1] = engine.unaryCalculate(type, Convert.ToDouble(parts[parts.Length - 1]), Convert.ToDouble(parts[parts.Length - 3]));
            //lblDisplay.Text += parts[parts.Length - 1];
            lblDisplay.Text = "";
            for (int i = 0;i < parts.Length; i++)
            {
                if(i%2==1) lblDisplay.Text += " " + parts[i] + " ";
                else lblDisplay.Text += parts[i];
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            // check if the last one is operator
            string current = lblDisplay.Text;
            if (getLastInString(current) is " ")
            {
                lblDisplay.Text = current.Substring(0, current.Length - 3);
            } else
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
            }
            if (lblDisplay.Text is "")
            {
                lblDisplay.Text = "0";
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            isContainDot = false;
            isNumberPart = false;
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result = engine.Process(lblDisplay.Text);
            if (result is "Error")
            {
                lblDisplay.Text = "Error";
            } else
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
            if (isNumberPart)
            {
                return;
            }
            string current = lblDisplay.Text;
            if (current is "0")
            {
                lblDisplay.Text = "-";
            } else if (getLastInString(current) is "-")
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "")
                {
                    lblDisplay.Text = "0";
                }
            } else
            {
                lblDisplay.Text = current + "-";
            }
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if(!isContainDot)
            {
                isContainDot = true;
                lblDisplay.Text += ".";
            }
        }
    }
}
