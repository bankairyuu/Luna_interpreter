﻿using System;
using GOLD;

namespace Luna_interpreter.Model.Structure.Classes
{
    class GetExpression : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {

            Console.WriteLine(node.Count());

            string DEBUG = "DEBUG";
            return DEBUG;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}