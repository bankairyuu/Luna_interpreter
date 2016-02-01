using System;
using GOLD;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Chain : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            if (node.Count() == 3)
            {
                // van operátor és két operandus, először a két nem terminálist bontom, majd a terminálisként adott operátorral
                // elvégzem a megfelelő műveletet és értéket adok/másolom

                string _operator = null;
                object _operand1 = null
                    ,  _operand2 = null
                    ;

                for (int i = 0; i < node.Count(); i++)
                {
                    switch (node[i].Type())
                    {
                        case SymbolType.Nonterminal: // Nemterminálisok vizsgálata

                            string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                            if (_operand1 == null)
                            {
                                /*
                                 * Elsőként meg kell nézni, hogy a keresett objektum Document, vagy Resource
                                 * A második lépés, hogy az ennek megfelelő objektumot az arra létrehozott service-től lekérjük
                                 * Az objektum lekérése után a lebontás kicsit másképp néz ki majd az eddigiekhez képes, ugyanis
                                 * objektumon belüli elérési vizsgálatokkal folytatódik
                                 */

                                // Element lekérés, majd ID -> megkapom a hivatkozandó neveket, ezeket pedig feldolgozom
                                _operand1 = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                            }
                            else
                            {
                                /*
                                 * Amennyiben az objektum lekérése sikeresen megtörtént, a lebontás itt folytatódik az objektumon belüli
                                 * hivatkozás kiértékelésével (létezik-e, ha igen, akkor mi az, stb...)
                                 */

                                // belső hivatkozott név, csupán a továbbbontáshoz kell
                                _operand2 = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                            }

                            break;

                        case SymbolType.Error:
                            Console.WriteLine("ERROR in Logical_Engine.Classes.Processor.ProcessTree");
                            break;

                        default:
                            // Terminálisok vizsgálata - itt operátor jel
                            _operator = node[i].Data as string;
                            break;
                    }
                }

                if (_operator != null)
                    _operand1 = Operation(_operand1, _operator, _operand2);
                Console.WriteLine("Chain value: " + _operand1 + " type: " + _operand1.GetType());
                return _operand1;

            }
            else
            {
                // egy nem terminális van, azt kell lebontani, majd
                // értékadás/másolás
                string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                object returnValue = Context.NonTerminalContext.Execute(ntt, (Reduction)node[0].Data);
                Console.WriteLine("Expression value: " + returnValue + " type: " + returnValue.GetType());
                return returnValue;
            }
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            return operand1 + operatorString + operand2;
        }
        
    }
}
