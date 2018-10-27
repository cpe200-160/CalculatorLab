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
        private ExtendFromController controller;

        public ExtendForm()
        {
            InitializeComponent();
            controller = new ExtendFromController();
        }

        public void Display()
        {
            lblDisplay.Text = controller.controller();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            controller.controller("Number", ((Button)sender).Text);
            Display();
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            controller.controller("BOperator", ((Button)sender).Text);
            Display();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            controller.controller("Back");
            Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            controller.controller("reset");
            Display();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            controller.controller("Equal");
            Display();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            controller.controller("Sign");
            Display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            controller.controller("Dot");
            Display();
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            controller.controller("Space");
            Display();
        }
    }
}