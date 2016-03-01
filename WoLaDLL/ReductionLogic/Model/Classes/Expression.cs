using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WoLaDLL.ReductionLogic;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Expression : Interfaces.INonTerminals
    {
        private static HashSet<string> _operators = new HashSet<string>();

        public Expression()
        {
            _operators.Add("=");
            _operators.Add("==");
            _operators.Add("equals");
            _operators.Add("like");
            _operators.Add("not like");
            _operators.Add("~");
            _operators.Add("!~");
            _operators.Add("regex"); // not implemented yet
            _operators.Add("_");    // not implemented yet
            _operators.Add("<>");
            _operators.Add("!=");
            _operators.Add("not =");
            _operators.Add("<");
            _operators.Add("<=");
            _operators.Add("≤");
            _operators.Add(">");
            _operators.Add(">=");
            _operators.Add("≥");
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
                    , _operand2 = null
                    ;

                for (int i = 0; i < node.Count(); i++)
                {
                    switch (node[i].Type())
                    {
                        case GOLD.SymbolType.Nonterminal: // Nemterminálisok vizsgálata

                            string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                            if (ntt == Enums.eNonTerminals.GetExpression)
                            {
                                List<string> retVal = (List<string>) Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data);
                            }

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
                Console.WriteLine("Expression value: " + _operand1 + "\ttype: " + _operand1.GetType());
                return _operand1;

            }
            else
            {
                // egy nem terminális van, azt kell lebontani, majd
                // értékadás/másolás
                string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                object returnValue = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[0].Data);
                Console.WriteLine("Expression value: " + returnValue + "\ttype: " + returnValue.GetType());
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
                    if (operatorString.Equals("=") || operatorString.Equals("==") || operatorString.Equals("equals") || operatorString.Equals("like") || operatorString.Equals("~"))
                    {
                        if (Int32.Parse(operand1.ToString()) == Int32.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<>") || operatorString.Equals("!=") || operatorString.Equals("not =") || operatorString.Equals("not like") || operatorString.Equals("!~"))
                    {
                        if (Int32.Parse(operand1.ToString()) != Int32.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<="))
                    {
                        if (Int32.Parse(operand1.ToString()) <= Int32.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals(">="))
                    {
                        if (Int32.Parse(operand1.ToString()) > Int32.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<"))
                    {
                        if (Int32.Parse(operand1.ToString()) < Int32.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals(">"))
                    {
                        if (Int32.Parse(operand1.ToString()) > Int32.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (operand1 is float)
                {
                    if (operatorString.Equals("=") || operatorString.Equals("==") || operatorString.Equals("equals") || operatorString.Equals("like") || operatorString.Equals("~"))
                    {
                        if (float.Parse(operand1.ToString()) == float.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<>") || operatorString.Equals("!=") || operatorString.Equals("not =") || operatorString.Equals("not like") || operatorString.Equals("!~"))
                    {
                        if (float.Parse(operand1.ToString()) != float.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<="))
                    {
                        if (float.Parse(operand1.ToString()) <= float.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals(">="))
                    {
                        if (float.Parse(operand1.ToString()) > float.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<"))
                    {
                        if (float.Parse(operand1.ToString()) < float.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals(">"))
                    {
                        if (float.Parse(operand1.ToString()) > float.Parse(operand2.ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (operand1 is string)
                {
                    if (operand1.Equals("ERROR") || operand2.Equals("ERROR"))
                    {
                        string ERROR = "ERROR";
                        return ERROR;
                    }

                    if (operatorString.Equals("=") || operatorString.Equals("==") || operatorString.Equals("equals") || operatorString.Equals("like") || operatorString.Equals("~"))
                    {
                        if (operand1.ToString() == operand2.ToString())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<>") || operatorString.Equals("!=") || operatorString.Equals("not =") || operatorString.Equals("not like") || operatorString.Equals("!~"))
                    {
                        if (operand1.ToString() != operand2.ToString())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (operand1 is bool)
                {
                    if (operatorString.Equals("=") || operatorString.Equals("==") || operatorString.Equals("equals") || operatorString.Equals("like") || operatorString.Equals("~"))
                    {
                        if (operand1 as bool? == operand2 as bool?)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<>") || operatorString.Equals("!=") || operatorString.Equals("not =") || operatorString.Equals("not like") || operatorString.Equals("!~"))
                    {
                        if (operand1 as bool? != operand2 as bool?)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (operand1 is DateTime)
                {
                    if (operatorString.Equals("=") || operatorString.Equals("==") || operatorString.Equals("equals") || operatorString.Equals("like") || operatorString.Equals("~"))
                    {
                        if (operand1 as DateTime? == operand2 as DateTime?)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<>") || operatorString.Equals("!=") || operatorString.Equals("not =") || operatorString.Equals("not like") || operatorString.Equals("!~"))
                    {
                        if (operand1 as DateTime? != operand2 as DateTime?)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<="))
                    {
                        if ((DateTime) operand1 <= (DateTime) operand2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals(">="))
                    {
                        if ((DateTime)operand1 >= (DateTime)operand2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<"))
                    {
                        if ((DateTime)operand1 < (DateTime)operand2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals(">"))
                    {
                        if ((DateTime)operand1 > (DateTime)operand2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (operand1 is TimeSpan)
                {
                    if (operatorString.Equals("=") || operatorString.Equals("==") || operatorString.Equals("equals") || operatorString.Equals("like") || operatorString.Equals("~"))
                    {
                        if (operand1 as TimeSpan? == operand2 as TimeSpan?)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<>") || operatorString.Equals("!=") || operatorString.Equals("not =") || operatorString.Equals("not like") || operatorString.Equals("!~"))
                    {
                        if (operand1 as TimeSpan? != operand2 as TimeSpan?)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<="))
                    {
                        if ((TimeSpan)operand1 <= (TimeSpan)operand2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals(">="))
                    {
                        if ((TimeSpan)operand1 >= (TimeSpan)operand2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals("<"))
                    {
                        if ((TimeSpan)operand1 < (TimeSpan)operand2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (operatorString.Equals(">"))
                    {
                        if ((TimeSpan)operand1 > (TimeSpan)operand2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
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
