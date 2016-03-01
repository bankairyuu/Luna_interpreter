using System;
using GOLD;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Luna_interpreter.Model.Structure.Classes
{
    class GetExpression : Interfaces.INonTerminals
    {
        public object Execute(Reduction node)
        {
            List<string> container = null;
            string whereClosure = null;
            string orderByClosure = null;


            for (int i = 2; i < node.Count(); i++)
            {
                string type = Regex.Replace(node[i].Parent.ToString(), "[^0-9a-zA-Z]+", "");
                Enums.eNonTerminals ntt = (Enums.eNonTerminals)Enum.Parse(typeof(Enums.eNonTerminals), type);

                if (container == null)
                {
                    // egyelőre használaton kívül van, valamint ezt lehet, hogy projekt specifikusan át kell írni nyelvtan szinten is
                    container = (List<string>) Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data);
                }
                else if (whereClosure == null)
                {
                    whereClosure = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data).ToString();
                }
                else if (orderByClosure == null)
                {
                    orderByClosure = Context.NonTerminalContext.Execute(ntt, (Reduction)node[i].Data).ToString();
                }
            }

            var retVal = Operation(whereClosure, orderByClosure, null);

            string DEBUG = "DEBUG";
            return DEBUG;
        }

        public object Operation(object whereCl, string orderByCl, object operand2)
        {
            try
            {
                // service hívás
                var client = new WoLaService.WoLaServiceClient();
                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";

                var retVal = client.GetWorkforceByWhereClauseAndSorting(whereCl.ToString(), orderByCl == "" ? null : orderByCl);

                Console.WriteLine(retVal[0].Name);

                return retVal;
            }
            catch (Exception exc)
            {
                Console.WriteLine("EXCEPTION -> " + exc.Message);
                string ERROR = "ERROR";
                return ERROR;
            }
        }
    }
}
