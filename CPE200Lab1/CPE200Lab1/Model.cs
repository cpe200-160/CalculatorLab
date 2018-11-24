using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CPE200Lab1
{
    public class Model
    {
        protected ArrayList oList;
        public Model()
        {
            oList = new ArrayList();
        }
        public void NotifyAll()
        {
            foreach (View m in oList)
            {
                m.Notify(this);
            }
        }
        public void AttachObserver(View m)
        {
            oList.Add(m);
        }
    }
}