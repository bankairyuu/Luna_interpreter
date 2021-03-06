﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;
using System.Text.RegularExpressions;
using WoLaDLL.ReductionLogic;

namespace Luna_interpreter.Model.Structure.Classes
{
    class List : Interfaces.INonTerminals
    {
        public object Execute(GOLD.Reduction node)
        {
            object _operand = null;

            string type = Regex.Replace(node[1].Parent.ToString(), "[^0-9a-zA-Z]+", "");
            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

            _operand = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[1].Data);

            List<string> returnValue = (List<string>) Operation(null, _operand.ToString(), null);

            return returnValue;
        }

        public object Operation(object operand1, string operand, object operand2)
        {
            string[] list = operand.ToString().Split(',');
            List<string> retVal;

            if (list.Length >= 1)
            {
                retVal = list.OfType<string>().ToList();
            }
            else
            {
                retVal = new List<string>();
                retVal.Add(operand);
            }
            
            return retVal;
        }
    }
}
