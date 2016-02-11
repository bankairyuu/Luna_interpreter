using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Container : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            string DEBUG = "DEBUG - Container";
            object _operand = null;

            // lehet List, Set vagy ID
            switch (node[0].Type())
            {
                case GOLD.SymbolType.Nonterminal: // Nemterminálisok vizsgálata
                    
                    string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                    Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                    _operand = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[0].Data);

                    break;

                case GOLD.SymbolType.Error:
                    Console.WriteLine("ERROR in Logical_Engine.Classes.Processor.ProcessTree");
                    break;

                default:
                    // Terminálisok vizsgálata - itt egy ID
                    _operand = node[0].Data as string;
                    break;
            }

            return DEBUG;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
