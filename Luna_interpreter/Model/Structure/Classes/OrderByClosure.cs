using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class OrderByClosure : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            try
            {
                string returnValue = node[2].Data.ToString();
                returnValue = Regex.Replace(returnValue, "\"", "");
                Console.WriteLine(returnValue);
                return returnValue;
            }
            catch(Exception)
            {
                return "";
            }
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
