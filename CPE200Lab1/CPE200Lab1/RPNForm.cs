﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNForm : ExtendForm
    {
        public RPNForm()
        {

        }
        protected override CalculatorEngine Engine()
        {
            return new RPNCalculatorEngine();
        }

    }
    

}
