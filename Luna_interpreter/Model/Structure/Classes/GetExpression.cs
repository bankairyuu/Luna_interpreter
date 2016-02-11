using System;
using GOLD;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Luna_interpreter.Model.Structure.Classes
{
    class GetExpression : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            Console.WriteLine(node.Count());

            List<string> container = null;


            for (int i = 2; i < node.Count(); i++)
            {
                string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                if (container == null)
                {
                    container = (List<string>) Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                }

                object retVal = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                Console.WriteLine(retVal);
            }

            string DEBUG = "DEBUG";
            return DEBUG;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
