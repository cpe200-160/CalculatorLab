using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class Model
    {
        protected ArrayList arr;
        public Model()
        {
            arr = new ArrayList();
        }
        public void NotifyAll()
        {
            foreach(CalculaterView m in arr)
            {
                m.Notify(this);
            }
        }
        public void AttachObserver(CalculaterView m)
        {
            if (m == null)
            {
                throw new ArgumentNullException(nameof(m));
            }

            arr.Add(m);
        }
    }
}