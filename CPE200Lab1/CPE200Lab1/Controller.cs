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
        
         public virtual void Calculate(string str)
        {
            throw new InvalidOperationException();
        }
       
    }
}
