using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Items : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            string DEBUG = "DEBUG - Items";
            object _item = null, _operator = null;
            object _items = null;

            if (node.Count() == 3)
            {// <Item> ',' <Items>
                for (int i=0; i<node.Count(); i++)
                {
                    switch (node[i].Type())
                    {
                        case GOLD.SymbolType.Nonterminal: // Nemterminálisok vizsgálata

                            string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                            if (_item == null)
                            {
                                _item = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                            }
                            else if (_items == null)
                            {
                                _items = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                            }

                            break;

                        case GOLD.SymbolType.Error:
                            Console.WriteLine("ERROR in Logical_Engine.Classes.Processor.ProcessTree");
                            break;

                        default:
                            // Terminálisok vizsgálata - itt egy vessző
                            _operator = node[i].Data as string;
                            break;
                    }
                }

                object returnValue = _item.ToString() + "," + _items.ToString();
                return returnValue;

            }
            else if (node.Count() == 1)
            {// <Item>
                string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                object returnValue = Context.NonTerminalContext.Execute(ntt, (Reduction)node[0].Data);
                return returnValue;
            }

            Console.WriteLine(DEBUG);
            return DEBUG;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }




    class Item : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            return node[0].Data as string;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
