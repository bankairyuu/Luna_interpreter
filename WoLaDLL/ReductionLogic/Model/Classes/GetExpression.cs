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
            List<string> whereClosure = null;
            List<string> orderByClosure = null;


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
                    whereClosure = (List<string>) Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data);
                }
                else if (orderByClosure == null)
                {
                    orderByClosure = (List<string>) Context.NonTerminalContext.Execute(ntt, (GOLD.Reduction)node[i].Data);
                }
            }

            var retVal = SpecialOperation(container, whereClosure, orderByClosure);
            return retVal;
        }

        
        public object Operation(object operand1, string operatorString, object operand2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Az itt megvalósított Operation tagfüggvény a megszokottól eltérően működik, service hívást végezve határozza meg az adott visszatérési értéket
        /// </summary>
        /// <param name="container">A lekérendő adathalmaz jelölése</param>
        /// <param name="whereClosure">WHERE lezártban meghatározott szűrési feltételek</param>
        /// <param name="orderByClosure">ORDER BY lezártban meghatározott rendezési feltételek</param>
        /// <example>
        /// <code>
        /// get from [Workforce] where "id=5"
        /// </code>
        /// </example>
        /// <returns>Egy lekérdezés végleges visszatérési értéke</returns>
        private object SpecialOperation(List<string> container, List<string> whereClosure, List<string> orderByClosure)
        {
            try
            {
                // service hívás
                var client = new WoLaDLL.WoLaService.WoLaServiceClient();
                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";

                //var retVal = client.GetWorkforceByWhereClauseAndSorting(whereClosure == null ? null : whereClosure, orderByClosure == null ? null : orderByClosure);

                //return retVal;
            }
            catch (Exception exc)
            {
                Console.WriteLine("EXCEPTION -> " + exc.Message);
                string ERROR = "ERROR : " + exc.Message;
                return ERROR;
            }
            return null;
        }
    }
}
