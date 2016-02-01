using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Luna_interpreter.Logical_Engine.Classes
{
    class Processor
    {
        GOLD.Reduction Root;

        public Processor(GOLD.Reduction Root)
        {
            this.Root = Root;
            Model.Structure.Context.NonTerminalContext.Execute(Model.Enums.eNonTerminals.ProgramLine, (GOLD.Reduction) Root[0].Data);
        }
    }
}
