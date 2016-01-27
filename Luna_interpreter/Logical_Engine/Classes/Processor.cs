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

            //ProcessTree(this.Root, 1);
        }

        private void ProcessTree(GOLD.Reduction root, int indent)
        {
            for (int i = 0; i < root.Count(); i++)
            {
                switch (root[i].Type())
                {
                    case GOLD.SymbolType.Nonterminal:
                        // Nemterminálisok vizsgálata
                        string type = Regex.Replace(root[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                        Model.Enums.eNonTerminals ntt = (Model.Enums.eNonTerminals)Enum.Parse(typeof(Model.Enums.eNonTerminals), type);

                        Model.Structure.Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)root[i].Data);

                        GOLD.Reduction branch = (GOLD.Reduction)root[i].Data;
                        ProcessTree(branch, indent + 1);
                        break;

                    case GOLD.SymbolType.Error:
                        Console.WriteLine("ERROR in Logical_Engine.Classes.Processor.ProcessTree");
                        break;

                    default:
                        // Terminálisok vizsgálata
                        break;
                }
            }
        }

        private void Process()
        {
            // feldolgozni így: Model.Structure.Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)root[i].Data);
        }
    }
}
