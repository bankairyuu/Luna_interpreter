﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;

namespace Luna_interpreter.Model.Structure.Classes
{
    class OrderByClosure : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            string DEBUG = "DEBUG - OrderBy";
            return DEBUG;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
