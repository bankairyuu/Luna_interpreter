using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Element : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {

            if (node.Count() == 2)
            {
                // ID [szóköz] Indexer
                throw new NotImplementedException();
            }
            else
            {
                // egy nem terminális van, azt kell lebontani, majd
                // értékadás/másolás
                try
                {
                    return node[0].Data.ToString();
                }
                catch (InvalidCastException ice)
                {
                    Console.WriteLine(ice.Message);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return null;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
