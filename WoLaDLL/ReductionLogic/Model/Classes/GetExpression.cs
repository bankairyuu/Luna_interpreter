using System;
using GOLD;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using WoLaDLL.ReductionLogic;

namespace Luna_interpreter.Model.Structure.Classes
{
    class GetExpression : Interfaces.INonTerminals
    {
        public object Execute(GOLD.Reduction node)
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
                    container = (List<string>) Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data);
                }
                else if (whereClosure == null)
                {
                    whereClosure = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data).ToString();
                }
                else if (orderByClosure == null)
                {
                    orderByClosure = Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data).ToString();
                }
            }

            var retVal = Operation(whereClosure, orderByClosure, null);
            return retVal;
        }

        /// <summary>
        /// Az itt megvalósított Operation tagfüggvény a megszokottól eltérően működik, service hívást végezve határozza meg az adott visszatérési értéket
        /// </summary>
        /// <param name="whereCl">WHERE lezártban meghatározott szűrési feltételek</param>
        /// <param name="orderByCl">ORDER BY lezártban meghatározott rendezési feltételek</param>
        /// <param name="operand2">Üres paraméter, nincs nincs szükség rá</param>
        /// <example>
        /// <code>
        /// get from [Workforce] where "id=5"
        /// </code>
        /// </example>
        /// <returns>Egy lekérdezés végleges visszatérési értéke</returns>
        public object Operation(object whereCl, string orderByCl, object operand2)
        {
            try
            {
                // service hívás
                var client = new WoLaDLL.WoLaService.WoLaServiceClient();
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
