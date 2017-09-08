using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(String str)
        {
            List<String> parts = str.Split(' ').ToList<String>();
            String result;
            //
            while(parts.Count >1)
            {


            }
        }
    }
}