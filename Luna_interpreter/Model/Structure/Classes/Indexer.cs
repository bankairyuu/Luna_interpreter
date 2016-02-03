using System;
using GOLD;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Indexer : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            string DEBUG = "DEBUG";

            if (node.Count() == 3)
            {
                // van operátor és két operandus, először a két nem terminálist bontom, majd a terminálisként adott operátorral
                // elvégzem a megfelelő műveletet és értéket adok/másolom

                if (node[1].Data.ToString().Contains("\""))
                {
                    string returnValue = Regex.Replace(node[1].Data.ToString(), "[^0-9a-zA-Z]+", "");
                    return returnValue;
                }
                else
                {
                    int tmp;
                    if (int.TryParse(node[1].Data.ToString(), out tmp))
                    {
                        return tmp;
                    }
                    return node[1].Data.ToString();
                }
            }
            
            return DEBUG;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
