using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Logical_Engine.Classes
{
    class Processor
    {
        GOLD.Reduction Root;

        public Processor (GOLD.Reduction Root)
        {
            this.Root = Root;
            Process();
        }

        private void Process()
        {

        }
    }
}
