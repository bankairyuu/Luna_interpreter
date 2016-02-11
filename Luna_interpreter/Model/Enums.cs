using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model
{
    public static class Enums
    {
        public enum eNonTerminals
        {
            Program,
            ProgramLine,
            Expression,
            SimpleExpression,
            Term,
            Factor,

            Chain,
            Element,
            FunctionCall,
            FunctionParameters,
            ExpressionList,
            Statement,
            DateTimeLiteral,
            Time,
            Date,
            Indexer,

            GetExpression,
            Container,
            List,
            WhereClosure,
            OrderByClosure,
            Items,
            Item,
            
            undefined
        }

        public enum eTerminals
        {
            NumberLiteral,
            RealLiteral,
            StringLiteral,
            undefined
        }

        public enum eCompositionTypes
        {
            Number,
            Real,
            String,
            Object,
            Logical,
            undefined
        }
    }
}
