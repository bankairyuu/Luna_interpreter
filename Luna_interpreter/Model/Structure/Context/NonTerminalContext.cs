using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Structure.Context
{
    static public class NonTerminalContext
    {
        private static Dictionary<Enums.eNonTerminals, Interfaces.INonTerminals> _strategies = new Dictionary<Enums.eNonTerminals, Interfaces.INonTerminals>();

        static NonTerminalContext()
        {
            _strategies.Add(Enums.eNonTerminals.ProgramLine,        new Classes.ProgramLine());
            _strategies.Add(Enums.eNonTerminals.Expression,         new Classes.Expression());
            _strategies.Add(Enums.eNonTerminals.SimpleExpression,   new Classes.SimpleExpression());
            _strategies.Add(Enums.eNonTerminals.Term,               new Classes.Term());
            _strategies.Add(Enums.eNonTerminals.Factor,             new Classes.Factor());
        }

        public static void Execute (Enums.eNonTerminals type)
        {
            _strategies[type].Execute(GOLD.Reduction node);
        }
    }
}
