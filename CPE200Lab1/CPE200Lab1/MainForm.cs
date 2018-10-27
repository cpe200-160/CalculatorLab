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
        private MainFormController controller;

        public void Display()
        {
            lblDisplay.Text = controller.controller();
        }

        public MainForm()
        {
            InitializeComponent();
            controller = new MainFormController();
            controller.controller("reset");
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            controller.controller("Number", ((Button)sender).Text);
            Display();
        }

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            controller.controller("UOperator", ((Button)sender).Text);
            Display();
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            controller.controller("Operator", ((Button)sender).Text);
            Display();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            controller.controller("Equal");
            Display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            controller.controller("Dot");
            Display();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            controller.controller("Sign");
            Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            controller.controller("reset");
            Display();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            controller.controller("Back");
            Display();
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            controller.controller("M", "P");
            Display();
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            controller.controller("M", "C");
            Display();
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            controller.controller("M", "M");
            Display();
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            controller.controller("M", "R");
            Display();
        }
    }
}
