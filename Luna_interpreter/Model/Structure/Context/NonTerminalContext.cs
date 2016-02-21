using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Structure.Context
{
    /// <summary>
    /// A Strategy Pattern (Stratégiai tervezési minta) magja.
    /// Az osztály példányosítja a megfelelő szótár változót, mely egy megadott interfésszel és enum típussal definiálható osztályokból álló lista, ahol a kulcs az enum típusa
    /// </summary>
    /// <seealso cref="Luna_interpreter.Model.Enums.eNonTerminals"/>
    /// <seealso cref="Luna_interpreter.Model.Structure.Interfaces.INonTerminals"/>
    /// <remarks>
    /// Az objektum célja, hogy minden irányított függvényhívást egybegyűjtsön és vezéreljen a lebontás során (Az Execute függvényeket)
    /// </remarks>
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
            _strategies.Add(Enums.eNonTerminals.GetExpression,      new Classes.GetExpression());
            _strategies.Add(Enums.eNonTerminals.Container,          new Classes.Container());
            _strategies.Add(Enums.eNonTerminals.List,               new Classes.List());
            _strategies.Add(Enums.eNonTerminals.WhereClosure,       new Classes.WhereClosure());
            _strategies.Add(Enums.eNonTerminals.OrderByClosure,     new Classes.OrderByClosure());
            _strategies.Add(Enums.eNonTerminals.Items,              new Classes.Items());
            _strategies.Add(Enums.eNonTerminals.Item,               new Classes.Item());
            _strategies.Add(Enums.eNonTerminals.Statement,          new Classes.Statement());
        }

        /// <summary>
        /// A megfelelő nemterminálishoz tartozó lefutási függvény hívását vezérlő eljárás
        /// </summary>
        /// <param name="type">Az eljárást végző nemterminális</param>
        /// <param name="node">Adott levél a parszolási fában</param>
        /// <returns>Az adott nemterminális által, az adott levélhez kiértékelt objektum</returns>
        public static object Execute (Enums.eNonTerminals type, GOLD.Reduction node)
        {
            return _strategies[type].Execute(node);
        }
    }
}
