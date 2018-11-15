using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// ExtendForm config
/// </summary>
namespace CPE200Lab1
{   /// <summary>
/// contain Number,MathOperation to do in Rpnterm
/// </summary>
    public partial class ExtendForm : Form, View
    {
        Model model;
        Controller controller;

        public ExtendForm()
        {
            InitializeComponent();
            model = new RpnCalculatorModel();
            model.AttachObserver(this);
            controller = new RpnCalculatorController();
            controller.AddModel(model);
        }
        public void Notify(Model m)
        {
            throw new NotImplementedException();
        }
        public void BtnNumber_Click(object sender, EventArgs e) => controller.BtnNumber_Click(sender, e);

        public void BtnBinaryOperator_Click(object sender, EventArgs e) => controller.BtnBinaryOperator_Click(sender, e);

        private void BtnBack_Click(object sender, EventArgs e) => controller.BtnBack_Click(sender, e);

        public void BtnClear_Click(object sender, EventArgs e) => controller.BtnClear_Click(sender, e);

        public void BtnEqual_Click(object sender, EventArgs e) => controller.BtnEqual_Click(sender, e);

        public void BtnSign_Click(object sender, EventArgs e) => controller.BtnSign_Click(sender, e);

        public void BtnDot_Click(object sender, EventArgs e) => controller.BtnDot_Click(sender, e);

        public void BtnSpace_Click(object sender, EventArgs e) => controller.BtnSpace_Click(sender, e);

        public void BtnUnaryOperator_Click(object sender, EventArgs e) => controller.BtnUnaryOperator_Click(sender, e);
    }
}
