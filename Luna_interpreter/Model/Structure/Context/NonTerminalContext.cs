﻿using System;
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
            _strategies.Add(Enums.eNonTerminals.Chain,              new Classes.Chain());
            _strategies.Add(Enums.eNonTerminals.Element,            new Classes.Element());
            _strategies.Add(Enums.eNonTerminals.DateTimeLiteral,    new Classes.DateTimeLiteral());
            _strategies.Add(Enums.eNonTerminals.Indexer,            new Classes.Indexer());
            _strategies.Add(Enums.eNonTerminals.Date,               new Classes.Date());
            _strategies.Add(Enums.eNonTerminals.Time,               new Classes.Time());
        }

        public static object Execute (Enums.eNonTerminals type, GOLD.Reduction node)
        {
            return _strategies[type].Execute(node);
        }
    }
}
