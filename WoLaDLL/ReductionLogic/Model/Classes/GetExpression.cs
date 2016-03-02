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

            List<string> retVal;

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

            ///Amennyiben a szervertől valamiért csak egy obj jönne vissza, azt is listába kell rakni, mert a GetExpression mindenképp listval tér vissza
            object SO = SpecialOperation(container, whereClosure, orderByClosure);
            if (SO is List<string>)
            {
                retVal = (List<string>)SO;
                return retVal;
            }
            else
            {
                retVal = new List<string>();
                retVal.Add(SO as string);
                return retVal;
            }
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
                List<string> retVal = null;
                // service hívás                
                foreach (string s in container)
                {
                    if (s.Equals("Processes"))
                    {
                        var mcl = new WoLaDLL.ManagerService.ManagerServiceClient();
                        mcl.ClientCredentials.UserName.UserName = "test";
                        mcl.ClientCredentials.UserName.Password = "test";
                        var processes = mcl.ListProcesses();

                        List<string> lst = new List<string>();
                        foreach (var o in processes)
                        {
                            lst.Add(o.Id + " " +  o.Name);
                        }
                        return lst;
                    }
                    else if (s.Equals("Instances"))
                    {
                        var ecl = new WoLaDLL.EngineService.EngineServiceClient();
                        ecl.ClientCredentials.UserName.UserName = "test";
                        ecl.ClientCredentials.UserName.Password = "test";

                        var instances = ecl.GetProcessInstances(whereClosure[0] == null ? -1 : Int32.Parse(whereClosure[0]));
                        
                        List<string> lst = new List<string>();
                        foreach (var o in instances)
                        {
                            lst.Add(o.Id.ToString() + " " + o.TemplateProcessName + " " + o.ProcessState);
                        }
                        return lst;
                    }
                    else if (s.Equals("Skills"))
                    {
                        var mcl = new WoLaDLL.ManagerService.ManagerServiceClient();
                        mcl.ClientCredentials.UserName.UserName = "test";
                        mcl.ClientCredentials.UserName.Password = "test";
                        var skills = mcl.ListSkills();

                        List<string> lst = new List<string>();
                        foreach (var o in skills)
                        {
                            lst.Add(o.Id + " " + o.Name);
                        }
                        return lst;
                    }
                }

                //var retVal = client.GetWorkforceByWhereClauseAndSorting(whereClosure == null ? null : whereClosure, orderByClosure == null ? null : orderByClosure);

                return retVal;
            }
            catch (Exception exc)
            {
                Console.WriteLine("EXCEPTION -> " + exc.Message);
                string ERROR = "ERROR : " + exc.Message;
                return ERROR;
            }
        }
    }
}
