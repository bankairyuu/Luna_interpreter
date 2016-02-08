using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Term : Interfaces.INonTerminals
    {
        private static HashSet<string> _operators = new HashSet<string>();

        public Term()
        {
            _operators.Add("*");
            _operators.Add("/");
            _operators.Add("mod");
            _operators.Add("%");
            _operators.Add("and");
            _operators.Add("&");
            _operators.Add("&&");
        }

        public HashSet<string> Operators
        {
            get
            {
                return _operators;
            }
        }

        public object Execute(GOLD.Reduction node)
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
                        case GOLD.SymbolType.Nonterminal: // Nemterminálisok vizsgálata

                            string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                            if (_operand1 == null)
                            {
                                _operand1 = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data);
                            }
                            else
                            {
                                _operand2 = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data);
                            }

                            break;

                        case GOLD.SymbolType.Error:
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
                Console.WriteLine("Term value: " + _operand1 + "\ttype: " + _operand1.GetType());
                return _operand1;

            }
            else
            {
                // egy nem terminális van, azt kell lebontani, majd
                // értékadás/másolás
                string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);
                object returnValue = null;
                try
                {
                    returnValue = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[0].Data);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    string ERROR = "ERROR";
                    return ERROR;
                }
                Console.WriteLine("Term value: " + returnValue + "\ttype: " + returnValue.GetType());

                return returnValue;
            }
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            if (!Operators.Contains(operatorString))
                throw new Exception("ERROR: Operator string interpret failure");

            if (operand1.GetType() == operand2.GetType())
            {
                if (operand1 is Int32)
                {
                    switch (operatorString)
                    {
                        case "*":
                            operand1 = Int32.Parse(operand1.ToString()) * Int32.Parse(operand2.ToString());
                            return operand1;
                        case "/":
                            operand1 = Int32.Parse(operand1.ToString()) / Int32.Parse(operand2.ToString());
                            return operand1;
                        case "mod":
                            operand1 = Int32.Parse(operand1.ToString()) % Int32.Parse(operand2.ToString());
                            return operand1;
                        case "%":
                            operand1 = Int32.Parse(operand1.ToString()) % Int32.Parse(operand2.ToString());
                            return operand1;
                        case "and":
                            throw new InvalidOperationException();
                        case "&":
                            operand1 = Int32.Parse(operand1.ToString()) & Int32.Parse(operand2.ToString());
                            return operand1;
                        case "&&":
                            throw new InvalidOperationException();
                        default:
                            return null;
                    }
                }
                else if (operand1 is float)
                {
                    switch (operatorString)
                    {
                        case "*":
                            operand1 = float.Parse(operand1.ToString()) * float.Parse(operand2.ToString());
                            return operand1;
                        case "/":
                            operand1 = float.Parse(operand1.ToString()) / float.Parse(operand2.ToString());
                            return operand1;
                        case "mod":
                            operand1 = float.Parse(operand1.ToString()) % float.Parse(operand2.ToString());
                            return operand1;
                        case "%":
                            operand1 = float.Parse(operand1.ToString()) % float.Parse(operand2.ToString());
                            return operand1;
                        case "and":
                            throw new InvalidOperationException();
                        case "&":
                            throw new InvalidOperationException();
                        case "&&":
                            throw new InvalidOperationException();
                        default:
                            return null;
                    }
                }
                else if (operand1 is string)
                {
                    switch (operatorString)
                    {
                        case "*":
                            throw new InvalidOperationException();
                        case "/":
                            throw new InvalidOperationException();
                        case "mod":
                            throw new InvalidOperationException();
                        case "%":
                            throw new InvalidOperationException();
                        case "and":
                            throw new InvalidOperationException();
                        case "&":
                            throw new InvalidOperationException();
                        case "&&":
                            throw new InvalidOperationException();
                        default:
                            return null;
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            return operand1;
        }
    }
}
