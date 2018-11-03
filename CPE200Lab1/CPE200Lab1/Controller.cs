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
        public virtual void calculate(string str)
        {
            throw new NotImplementedException();
        }
        internal void btnNumber_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void btnOperator_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void btnEqual_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void btnDot_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        internal void btnSign_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        internal void btnClear_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        internal void btnMP_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        internal void btnMC_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        internal void btnMR_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        internal void btnBack_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        internal void btnMM_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        internal void performedAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
