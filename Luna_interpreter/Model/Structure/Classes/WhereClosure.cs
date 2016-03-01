using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class WhereClosure : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            string returnValue = node[1].Data.ToString();
            returnValue = Regex.Replace(returnValue, "\"", "");
            Console.WriteLine(returnValue);
            return returnValue;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
