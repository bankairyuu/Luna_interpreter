﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WoLaDLL.ReductionLogic;

namespace Luna_interpreter.Model.Structure.Classes
{
    class SimpleExpression : Interfaces.INonTerminals
    {
        private static HashSet<string> _operators = new HashSet<string>();

        public SimpleExpression()
        {
            _operators.Add("+");
            _operators.Add("-");
            _operators.Add("or");
            _operators.Add("|");
            _operators.Add("||");
            _operators.Add("xor");
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
                Console.WriteLine("Simple Expression value: " + _operand1 + "\ttype: " + _operand1.GetType());
                return _operand1;

            }
            else
            {
                // egy nem terminális van, azt kell lebontani, majd
                // értékadás/másolás
                string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                object returnValue = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[0].Data);
                Console.WriteLine("Simple Expression value: " + returnValue + "\ttype: " + returnValue.GetType());
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
                        case "+":
                            operand1 = Int32.Parse(operand1.ToString()) + Int32.Parse(operand2.ToString());
                            return operand1;
                        case "-":
                            operand1 = Int32.Parse(operand1.ToString()) - Int32.Parse(operand2.ToString());
                            return operand1;
                        case "or":
                            throw new InvalidOperationException();
                        case "|":
                            operand1 = Int32.Parse(operand1.ToString()) | Int32.Parse(operand2.ToString());
                            return operand1;
                        case "||":
                            throw new InvalidOperationException();
                        case "xor":
                            operand1 = Int32.Parse(operand1.ToString()) ^ Int32.Parse(operand2.ToString());
                            return operand1;
                        default:
                            return null;
                    }
                }
                else if (operand1 is float)
                {
                    switch (operatorString)
                    {
                        case "+":
                            operand1 = float.Parse(operand1.ToString()) + float.Parse(operand2.ToString());
                            return operand1;
                        case "-":
                            operand1 = float.Parse(operand1.ToString()) - float.Parse(operand2.ToString());
                            return operand1;
                        case "or":
                            throw new InvalidOperationException();
                        case "|":
                            throw new InvalidOperationException();
                        case "||":
                            throw new InvalidOperationException();
                        case "xor":
                            throw new InvalidOperationException();
                        default:
                            return null;
                    }
                }
                else if (operand1 is string)
                {
                    switch (operatorString)
                    {
                        case "+":
                            operand1 = operand1.ToString() + operand2.ToString();
                            return operand1;
                        case "-":
                            throw new InvalidOperationException();
                        case "or":
                            throw new InvalidOperationException();
                        case "|":
                            throw new InvalidOperationException();
                        case "||":
                            throw new InvalidOperationException();
                        case "xor":
                            throw new InvalidOperationException();
                        default:
                            return null;
                    }
                }
                else if (operand1 is bool)
                {
                    switch (operatorString)
                    {
                        case "+":
                            throw new InvalidOperationException();
                        case "-":
                            throw new InvalidOperationException();
                        case "or":
                            if ((bool)operand1 || (bool)operand2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case "|":
                            throw new InvalidOperationException();
                        case "||":
                            if ((bool)operand1 || (bool)operand2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case "xor":
                            if (((bool)operand1 == true && (bool)operand2 == false) || ((bool)operand1 == false && (bool)operand2 == true))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        default:
                            return null;
                    }
                }
                else if (operand1 is DateTime)
                {
                    switch (operatorString)
                    {
                        case "+":
                            throw new NotImplementedException();
                        case "-":
                            throw new NotImplementedException();
                        case "or":
                            throw new InvalidOperationException();
                        case "|":
                            throw new InvalidOperationException();
                        case "||":
                            throw new InvalidOperationException();
                        case "xor":
                            throw new InvalidOperationException();
                        default:
                            return null;
                    }
                }
                else if (operand1 is TimeSpan)
                {
                    switch (operatorString)
                    {
                        case "+":
                            throw new NotImplementedException();
                        case "-":
                            throw new NotImplementedException();
                        case "or":
                            throw new InvalidOperationException();
                        case "|":
                            throw new InvalidOperationException();
                        case "||":
                            throw new InvalidOperationException();
                        case "xor":
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
