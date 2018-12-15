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
        private double memory;
        private CalculatorEngine engine;
		private SimpleCalculatorEngine simple;

  
      

        public MainForm()
        {
            InitializeComponent();
            memory = 0;
            engine = new CalculatorEngine();
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
			RPNCalculatorEngine new101 = new RPNCalculatorEngine();
			string digit = ((Button)sender).Text;
			new101.Btn_Number(lblDisplay.Text,isAfterEqual, isAfterOperater, isAllowBack, digit,);
		}
		
			

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            

        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {

        }

        private void btnDot_Click(object sender, EventArgs e)
        {

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
           
        }
    }
}
