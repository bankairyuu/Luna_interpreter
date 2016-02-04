using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD;
using System.Text.RegularExpressions;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Date : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            string date = node[0].Data.ToString();
            return date;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }

    class Time : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            string time = node[0].Data.ToString();
            return time;
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }

    class DateTimeLiteral : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            string DEBUG = "DEBUG";

            if (node.Count() == 2)
            {
                // Date Time
                object _operand1 = null, _operand2 = null;
                for (int i=0; i<node.Count(); i++)
                {
                    string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                    Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                    if (_operand1 == null)
                    {
                        _operand1 = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                    }
                    else
                    {
                        _operand2 = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                    }
                }

                // a visszatérési értéknek szabvány dátum formának kell lennie a megfelelő módon
                string[] _op1 = _operand1.ToString().Split('.');
                string[] _op2 = _operand2.ToString().Split(':');

                //TODO: validáció a dátumra és az időre
                if ((Int32.Parse(_op1[0]) < 1 || Int32.Parse(_op1[0]) > 31) || (Int32.Parse(_op1[1]) < 1 || Int32.Parse(_op1[1]) > 12) || Int32.Parse(_op1[2]) < 1900
                    || (Int32.Parse(_op2[0]) < 0 || Int32.Parse(_op2[0]) > 24) || (Int32.Parse(_op2[1]) < 0 || Int32.Parse(_op2[1]) > 60))
                {
                    throw new FormatException("Not valid Date-Time format");
                }
                else
                {
                    if (_op2.Length == 3)
                    {
                        if ((Int32.Parse(_op2[2]) < 0 || Int32.Parse(_op2[2]) > 60))
                        {
                            throw new FormatException("Not valid Date-Time format");
                        }
                    }
                }

                if (_op2.Length == 3)
                {
                    return new DateTime(Int32.Parse(_op1[2]), Int32.Parse(_op1[1]), Int32.Parse(_op1[0]), Int32.Parse(_op2[0]), Int32.Parse(_op2[1]), Int32.Parse(_op2[2]));
                }
                else
                {
                    return new DateTime(Int32.Parse(_op1[2]), Int32.Parse(_op1[1]), Int32.Parse(_op1[0]), Int32.Parse(_op2[0]), Int32.Parse(_op2[1]), 0);
                }
            }
            else
            {
                // vagy Date, vagy Time
                string type = Regex.Replace(node[0].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                object _operand1 = Context.NonTerminalContext.Execute(ntt, (Reduction)node[0].Data);

                // szabvány Date, vagy Time objektum visszaadása

                if (ntt == Enums.eNonTerminals.Date)
                {
                    //Date
                    string[] _op1 = _operand1.ToString().Split('.');
                    if ((Int32.Parse(_op1[0]) < 1 || Int32.Parse(_op1[0]) > 31) || (Int32.Parse(_op1[1]) < 1 || Int32.Parse(_op1[1]) > 12) || Int32.Parse(_op1[2]) < 1900)
                        throw new FormatException("Not valid Date format" + Environment.NewLine);
                    else if (Int32.Parse(_op1[1]) == 2)
                        Console.WriteLine("Február");
                    return new DateTime(Int32.Parse(_op1[2]), Int32.Parse(_op1[1]), Int32.Parse(_op1[0]));
                }
                else
                {
                    //Time
                    string[] _op2 = _operand1.ToString().Split(':');
                    if (_op2.Length == 3)
                    {
                        if ((Int32.Parse(_op2[0]) < 0 || Int32.Parse(_op2[0]) > 24) || (Int32.Parse(_op2[1]) < 0 || Int32.Parse(_op2[1]) > 60) || (Int32.Parse(_op2[2]) < 0 || Int32.Parse(_op2[2]) > 60))
                            throw new FormatException("Not valid Time format" + Environment.NewLine);
                        return new TimeSpan(Int32.Parse(_op2[0]), Int32.Parse(_op2[1]), Int32.Parse(_op2[2]));
                    }
                    else
                    {
                        if ((Int32.Parse(_op2[0]) < 0 || Int32.Parse(_op2[0]) > 24) || (Int32.Parse(_op2[1]) < 0 || Int32.Parse(_op2[1]) > 60))
                            throw new FormatException("Not valid Time format" + Environment.NewLine);
                        return new TimeSpan(Int32.Parse(_op2[0]), Int32.Parse(_op2[1]), 0);
                    }
                }

                return DEBUG;
            }
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
