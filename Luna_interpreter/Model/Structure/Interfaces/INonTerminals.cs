using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Structure.Interfaces
{
    interface INonTerminals
    {
        void Execute(GOLD.Reduction node);
    }
}
