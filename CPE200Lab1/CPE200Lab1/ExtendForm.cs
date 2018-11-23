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
    public partial class ExtendForm : Form, View
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private RPNCalculatorEngine engine;
        private CalculatorEngine basicEngine;
        public Model model;
        public Controller controller;
       



        public ExtendForm()
        {
            InitializeComponent();
            engine = new RPNCalculatorEngine();
            basicEngine = new CalculatorEngine();
            model = new CalculatorModel();
            model.AttachObserver(this);
            controller = new CalculatorController();
            controller.Model(model);
        }

        public void Notify(Model m)
        {
            lblDisplay.Text = ((CalculatorModel)m).Display();
        }

        public bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                case '%':
                case '1':
                case '√':
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
            isSpaceAllowed = true;
        }

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            string operate, firstOperand;
            operate = ((Button)sender).Text;
            firstOperand = lblDisplay.Text;
            string result = engine.calculate(operate, firstOperand);

            string current = lblDisplay.Text;
            if (current[current.Length - 1] != ' ')
            {
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                    return;
                }
            }
            if (current[current.Length - 2] != ' ' || isOperator(current[current.Length - 1]))
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
            }

        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = lblDisplay.Text;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
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
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text = current.Substring(0, current.Length - 3);
            }
            else
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
            isSpaceAllowed = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result;
            string memDisplay;

            result = engine.calculate(lblDisplay.Text);
            memDisplay = lblDisplay.Text;
            if (result == "B")
            {
                result = basicEngine.calculate(memDisplay);
            }

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
                    lblDisplay.Text = "0";
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
            if (!isContainDot)
            {
                isContainDot = true;
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
            }
        }
    }
}

