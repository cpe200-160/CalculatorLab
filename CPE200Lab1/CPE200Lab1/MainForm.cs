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

    public partial class MainForm : Form, View
    {
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

        public void BtnNumber_Click(object sender, EventArgs e) => controller.BtnNumber_Click(sender, e);

        public void BtnUnaryOperator_Click(object sender, EventArgs e) => controller.BtnUnaryOperator_Click(sender, e);

        public void BtnOperator_Click(object sender, EventArgs e) => controller.BtnOperator_Click(sender, e);

        public void BtnEqual_Click(object sender, EventArgs e) => controller.BtnEqual_Click(sender, e);

        public void BtnDot_Click(object sender, EventArgs e) => controller.BtnDot_Click(sender, e);

        public void BtnSign_Click(object sender, EventArgs e) => controller.BtnSign_Click(sender, e);

        public void BtnClear_Click(object sender, EventArgs e) => controller.BtnClear_Click(sender, e);

        public void BtnBack_Click(object sender, EventArgs e) => controller.BtnBack_Click(sender, e);

        public void BtnMP_Click(object sender, EventArgs e) => controller.BtnMP_Click(sender, e);

        public void BtnMC_Click(object sender, EventArgs e) => controller.BtnMC_Click(sender, e);

        public void BtnMM_Click(object sender, EventArgs e) => controller.BtnMM_Click(sender, e);

        public void BtnMR_Click(object sender, EventArgs e) => controller.BtnMR_Click(sender, e);

    }
}