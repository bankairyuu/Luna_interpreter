﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Items : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            throw new NotImplementedException();
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }

    class Item : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            throw new NotImplementedException();
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}