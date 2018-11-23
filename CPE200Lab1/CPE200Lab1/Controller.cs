using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class Controller
    {
        protected ArrayList arrList;

        public Controller()
        {
            arrList = new ArrayList();
        }

        public void Model(Model m)
        {
            arrList.Add(m);
        }

    }
}