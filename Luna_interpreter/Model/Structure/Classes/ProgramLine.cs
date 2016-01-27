using System;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class ProgramLine : Interfaces.INonTerminals
    {
        public object Execute(GOLD.Reduction node)
        {
            Console.WriteLine(Environment.NewLine + "(VVV) Program Line (VVV)" + Environment.NewLine);

            // Itt vagy Expression, vagy Statement, vagy CommentLine
            string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);
            
            switch (ntt)
            {
                case Enums.eNonTerminals.Expression:
                    Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[0].Data);
                    break;

                default:
                    throw new NotImplementedException();
            }

            Console.WriteLine(Environment.NewLine + "(AAA) Program Line (AAA)" + Environment.NewLine);
            return null;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
