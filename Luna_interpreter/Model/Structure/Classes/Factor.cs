using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Factor : Interfaces.INonTerminals
    {
        private static HashSet<string> _operators = new HashSet<string>();

        public Factor()
        {
            _operators.Add("(");
            _operators.Add(")");
            _operators.Add("+");
            _operators.Add("-");
            _operators.Add("not");
            _operators.Add("!");
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
                // zárójel és benne egy expression van
                // az expressiont kiértékelem és azzal majd valamit kezdek

                string  _operator1 = null
                    ,   _operator2 = null
                    ;
                object _operand = null;

                for (int i = 0; i < node.Count(); i++)
                {
                    switch (node[i].Type())
                    {
                        case GOLD.SymbolType.Nonterminal: // Nemterminálisok vizsgálata

                            string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);
                            
                            _operand = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data);
                            
                            break;

                        case GOLD.SymbolType.Error:
                            Console.WriteLine("ERROR in Logical_Engine.Classes.Processor.ProcessTree");
                            break;

                        default:
                            // Terminálisok vizsgálata - itt operátor jel
                            if (_operator1 == null)
                            {
                                _operator1 = node[i].Data as string;
                            }
                            else
                            {
                                _operator2 = node[i].Data as string;
                            }
                            break;
                    }
                }

                if (_operator1 != null && _operator2 == null)
                    throw new OperationCanceledException("Missing bracket(s)");
                Console.WriteLine("Expression value: " + _operand + "\ttype: " + _operand.GetType());
                return _operand;
            }
            else if (node.Count() == 2)
            {
                // valamilyen operátor és egy nem terminális
                // kiértékelem a nem terminálist, majd alkalmazom az operátor által megszabott műveletet
                string _operator = null;
                object _operand = null;

                for (int i = 0; i < node.Count(); i++)
                {
                    switch (node[i].Type())
                    {
                        case GOLD.SymbolType.Nonterminal: // Nemterminálisok vizsgálata

                            string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                            Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);
                            
                            _operand = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data);

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
                    _operand = Operation(_operand, _operator, null);
                Console.WriteLine("Factor value: " + _operand + "\ttype: " + _operand.GetType());
                return _operand;

            }
            else
            {
                // egy nem terminális van, azt kell lebontani, majd
                // értékadás/másolás
                object returnValue = null;
                try
                {
                    if (node[0].Parent.ToString().Equals("NumberLiteral"))
                    {
                        returnValue = Int32.Parse(node[0].Data.ToString());
                        Console.WriteLine("Factor value: " + returnValue + "\ttype: " + returnValue.GetType());
                        return Int32.Parse(node[0].Data.ToString());
                    }
                    else if (node[0].Parent.ToString().Equals("RealLiteral"))
                    {
                        returnValue = float.Parse(node[0].Data.ToString());
                        Console.WriteLine("Factor value: " + returnValue + "\ttype: " + returnValue.GetType());
                        return float.Parse(node[0].Data.ToString());
                    }
                    else if (node[0].Parent.ToString().Equals("StringLiteral"))
                    {
                        returnValue = node[0].Data.ToString();
                        Console.WriteLine("Factor value: " + returnValue + "\ttype: " + returnValue.GetType());
                        return node[0].Data.ToString();
                    }
                    else if (node[0].Parent.ToString().Equals("BooleanLiteral"))
                    {
                        if (node[0].Data.ToString().Equals("true") || node[0].Data.ToString().Equals("yes"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (node[0].Parent.ToString().Equals("<Chain>"))
                    {
                        string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                        Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                        returnValue = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[0].Data);
                        Console.WriteLine("Factor value: " + returnValue + "\ttype: " + returnValue.GetType());
                        return returnValue;
                    }
                    else
                    {
                        throw new Exception("Literal define error - Luna_interpreter.Model.Structure.Classes.Factor.Execute");
                    }
                }
                catch(InvalidCastException ice)
                {
                    Console.WriteLine(ice.Message);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            Console.WriteLine(Environment.NewLine + "(AAA) Factor (AAA)" + Environment.NewLine);
            return null;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            if (!Operators.Contains(operatorString))
                throw new Exception("ERROR: Operator string interpret failure");

            if (operand1 is Int32)
            {
                switch (operatorString)
                {
                    case "-":
                        return Int32.Parse(operand1.ToString()) * -1;
                    case "+":
                        throw new NotImplementedException();
                    case "not":
                        throw new NotImplementedException();
                    case "!":
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (operand1 is float)
            {
                switch (operatorString)
                {
                    case "-":
                        return float.Parse(operand1.ToString()) * -1;
                    case "+":
                        throw new NotImplementedException();
                    case "not":
                        throw new NotImplementedException();
                    case "!":
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (operand1 is string)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
