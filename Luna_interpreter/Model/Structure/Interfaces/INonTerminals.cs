using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Structure.Interfaces
{
    interface INonTerminals
    {
        object Execute(GOLD.Reduction node);

        object Operation(object operand1, string operatorString, object operand2);
    }
}
