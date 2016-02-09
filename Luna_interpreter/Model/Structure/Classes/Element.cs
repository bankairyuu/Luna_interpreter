using System;
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
                string _operator = null;
                object _operand = null;

                for (int i = 0; i < node.Count(); i++)
                {
                    switch (node[i].Type())
                    {
                        case SymbolType.Nonterminal: // Nemterminálisok vizsgálata

                            string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                            _operand = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                            break;

                        case SymbolType.Error:
                            Console.WriteLine("ERROR in Logical_Engine.Classes.Processor.ProcessTree");
                            break;

                        default:
                            // Terminálisok vizsgálata - itt maga az ID
                            _operator = node[i].Data as string;
                            break;
                    }
                }

                string _path = _operator + ":" + _operand.ToString();

                if (_operator != null)
                    _operand = Operation(_operand, _operator, null);
                Console.WriteLine("Element value: " + _operand + "\ttype: " + _operand.GetType());
                return _path;
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

        public object Operation(object indexerLiteral, string ID, object operand2)
        {

            return ID + indexerLiteral;

            if (ID.Equals("Document"))
            {

            }
            else if (ID.Equals("Resource"))
            {

            }
            else if (ID.Equals("Workflow"))
            {

            }
            return null;
        }
    }
}
