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

    public partial class MainForm : Form ,View
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private string SecondOperate;
        private double memory;
        Model model;
        Controller controller;

        public void Notify(Model m)
        {
            throw new NotImplementedException();
        }

        public MainForm()
        {
            InitializeComponent();
            model = new CalculatorModel();
            model.AttachObserver(this);
            controller = new CalculatorController();
            controller.AddModel(model);
           
        }

        public void btnNumber_Click(object sender, EventArgs e)
         {
             controller.performedAction()
           // controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

         public void btnUnaryOperator_Click(object sender, EventArgs e)
         {
            controller.btnUnaryOperator_Click(sender, e);
         }

         public void btnOperator_Click(object sender, EventArgs e)
         {
            controller.btnOperator_Click(sender, e);
         }

         public void btnEqual_Click(object sender, EventArgs e)
         {
            controller.btnEqual_Click(sender, e);
         }

         public void btnDot_Click(object sender, EventArgs e)
         {
            controller.btnDot_Click(sender, e);
         }

         public void btnSign_Click(object sender, EventArgs e)
         {
            controller.btnSign_Click(sender, e);
         }

         public void btnClear_Click(object sender, EventArgs e)
         {
            controller.btnClear_Click(sender, e);
         }

         public void btnBack_Click(object sender, EventArgs e)
         {
            controller.btnBack_Click(sender, e);
         }

         public void btnMP_Click(object sender, EventArgs e)
         {
            controller.btnMP_Click(sender, e);
         }

         public void btnMC_Click(object sender, EventArgs e)
         {
            controller.btnMC_Click(sender, e);
         }

         public void btnMM_Click(object sender, EventArgs e)
         {
            controller.btnMM_Click(sender, e);
         }

         public void btnMR_Click(object sender, EventArgs e)
         {
            controller.btnMR_Click(sender, e);
         }
         
    }
}