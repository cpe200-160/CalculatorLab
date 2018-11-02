using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class Model
    {
        protected ArrayList ModelList;

        public Model()
        {
            ModelList = new ArrayList();
        }

        public void NoticeMeSenpai()
        {
            foreach (View m in ModelList)
            {
                m.Notify(this);
            }
        }
        public void AttachObserver(View m)
        {
            ModelList.Add(m);
        }
    }
}
