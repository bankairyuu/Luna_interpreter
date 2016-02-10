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

                if (_op2.Length == 3)
                {
                    try
                    {
                        return new DateTime(Int32.Parse(_op1[0]), Int32.Parse(_op1[1]), Int32.Parse(_op1[2]), Int32.Parse(_op2[0]), Int32.Parse(_op2[1]), Int32.Parse(_op2[2]));
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        string ERROR = "ERROR";
                        return ERROR;
                    }
                    
                }
                else
                {
                    try
                    {
                        return new DateTime(Int32.Parse(_op1[0]), Int32.Parse(_op1[1]), Int32.Parse(_op1[2]), Int32.Parse(_op2[0]), Int32.Parse(_op2[1]), 0);
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        string ERROR = "ERROR";
                        return ERROR;
                    }
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
                    try
                    {
                        return new DateTime(Int32.Parse(_op1[0]), Int32.Parse(_op1[1]), Int32.Parse(_op1[2]));
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        string ERROR = "ERROR";
                        return ERROR;
                    }
                }
                else
                {
                    //Time
                    string[] _op2 = _operand1.ToString().Split(':');
                    if (_op2.Length == 3)
                    {
                        try
                        {
                            return new TimeSpan(Int32.Parse(_op2[0]), Int32.Parse(_op2[1]), Int32.Parse(_op2[2]));
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                            string ERROR = "ERROR";
                            return ERROR;
                        }
                    }
                    else
                    {
                        try
                        {
                            return new TimeSpan(Int32.Parse(_op2[0]), Int32.Parse(_op2[1]), 0);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                            string ERROR = "ERROR";
                            return ERROR;
                        }
                    }
                }
            }
        }

        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }
    }
}
