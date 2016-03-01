using System;
using System.Text.RegularExpressions;
using WoLaDLL.ReductionLogic;

namespace Luna_interpreter.Model.Structure.Classes
{
    class ProgramLine : Interfaces.INonTerminals
    {
        public object Execute(GOLD.Reduction node)
        {
            Console.WriteLine(Environment.NewLine + "(VVV) Program Line (VVV)" + Environment.NewLine);

            // Itt vagy Expression, vagy Statement, vagy CommentLine vagy semmi !!!
            try {
                string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                switch (ntt)
                {
                    case Enums.eNonTerminals.Expression:
                        var returnValue = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[0].Data);
                        Console.WriteLine("################################################################");
                        Console.WriteLine("# Programline value: " + returnValue + "\ttype: " + returnValue.GetType());
                        Console.WriteLine("################################################################" + Environment.NewLine);
                        return returnValue;

                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception)
            {
                string EMPTY = "Empty ProgramLine";
                return EMPTY;
            }
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            // Nincs szükség a műveletre ezen a szinten
            throw new NotImplementedException();
        }
    }
}
