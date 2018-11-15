using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    class Controller
    {
        protected ArrayList ControlList;

        public Controller()
        {
            ControlList = new ArrayList();
        }

        public void AddModel(Model m)
        {
            ControlList.Add(m);
        }
        // The `virtual` keyword allows the method to be overridden
        public virtual void Calculate(string str) => throw new NotImplementedException();

        internal void BtnNumber_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnUnaryOperator_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnOperator_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnEqual_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnDot_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnSign_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnClear_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnMP_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnMC_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnMR_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnBack_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnMM_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnBinaryOperator_Click(object sender, EventArgs e) => throw new NotImplementedException();

        internal void BtnSpace_Click(object sender, EventArgs e) => throw new NotImplementedException();

    }
}
