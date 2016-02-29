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
    class OrderByClosure : Interfaces.INonTerminals
    {
        public object Execute(GOLD.Reduction node)
        {
            List<string> _operand = null;

            // lehet List vagy ID
            switch (node[2].Type())
            {
                case SymbolType.Nonterminal: // Nemterminálisok vizsgálata

                    string type = Regex.Replace(node[2].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                    Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                    _operand = (List<string>)Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[2].Data);

                    return _operand;

                case SymbolType.Error:
                    break;

                default:
                    // Terminálisok vizsgálata - itt egy StringLiteral vagy null
                    try
                    {
                        List<string> retVal = new List<string>();
                        string returnValue = node[2].Data.ToString();
                        returnValue = Regex.Replace(returnValue, "\"", "");
                        retVal.Add(returnValue);
                        return retVal;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    
            }
            return null;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            // Nincs szükség a műveletre ezen a szinten
            throw new NotImplementedException();
        }
    }
}
