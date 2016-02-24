using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;
using System.Text.RegularExpressions;
using WoLaDLL.ReductionLogic;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Container : Interfaces.INonTerminals
    {
        public object Execute(GOLD.Reduction node)
        {
            string DEBUG = "DEBUG - Container";
            List<string> _operand = null;

            // lehet List, Set vagy ID
            switch (node[0].Type())
            {
                case SymbolType.Nonterminal: // Nemterminálisok vizsgálata
                    
                    string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                    Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                    _operand = (List<string>) Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[0].Data);

                    return _operand;

                case SymbolType.Error:
                    Console.WriteLine("ERROR in Logical_Engine.Classes.Processor.ProcessTree");
                    break;

                default:
                    // Terminálisok vizsgálata - itt egy ID
                    List<string> retVal = new List<string>();
                    retVal.Add(node[0].Data as string);
                    return retVal;
            }

            return DEBUG;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            // Nincs szükség a műveletre ezen a szinten
            throw new NotImplementedException();
        }
    }
}
