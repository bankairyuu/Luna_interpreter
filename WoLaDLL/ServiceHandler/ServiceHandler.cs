using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.ServiceHandler
{
    /// <summary>
    /// A ServiceHandler arra a célra létrehozott objektum, hogy a főrendszer felé irányuló webservice alapú kéréseket vezérelje
    /// </summary>
    public static class ServiceHandler
    {
        /// <summary>
        /// A getData egyelőre a Dokumentum lekérések során használatos webservice hívásra készíti fel a bemeneti stringet,
        /// majd azt végrehajtva visszaadja a megfelelő visszatérési értéket
        /// </summary>
        /// <param name="_path">Egy Chain-ből generált string alapú elérési út az elérendő adatról</param>
        /// <returns>Field érték stringben kifejezve</returns>
        public static object getData( string _path )
        {
            string[] path = _path.Split('.');
            Stack<string> dataPath = new Stack<string>();
            for (int i = 0; i < path.Length; i++)
            {
                dataPath.Push(path[i]);
            }
            string[] type = path[0].Split(':');
            if (type[0].Equals("Document"))
            {
                return DocumentHandling(dataPath, type[1]);
            }
            /*
            else if (type[0].Equals("Resource"))
            {
                return ResourceHandling(dataPath);
            }
            */
            throw new NotImplementedException("A rendszer csak a Document és a Resource típusú objektum orientált kéréseket támogatja");
        }

        /// <summary>
        /// Dokumentum-elérést végző eljárás, mely az adott "elérési út" alapján lekéri a megfelelő service-n keresztül a megfelelő field értéket
        /// </summary>
        /// <param name="path">A dokumentumon belüli field érték pontos elérési útvonala</param>
        /// <param name="docName">A tartalmazó dokumentum neve, melyen belül a lekérést végzi a rendszer</param>
        /// <returns>A megfelelő field érték</returns>
        private static object DocumentHandling(Stack<string> path, string docName)
        {
            try
            {
                var client = new WoLaDLL.WoLaService.WoLaServiceClient();

                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";
                
                Stack<string> hStack = new Stack<string>();
                string[] helper;
                while (path.Count != 0)
                {
                    helper = path.Pop().Split(':');
                    if (helper.Length == 2)
                    {
                        hStack.Push(helper[1]);
                    }
                    else
                    {
                        hStack.Push(helper[0]);
                    }
                }

                object returnValue = client.GetFieldValueByProccessInstace(WoLaDLL.WoLaParser.ProcessInstanceId, hStack.Pop(), hStack.Pop(), hStack.Pop());
                
                return returnValue;
            }
            catch (Exception exc)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("x " + exc.Message);
                Console.WriteLine("x A hivatkozott érték nem létezik");
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                string ERROR = "ERROR";
                return ERROR;
            }
        }
/*
        private static object ResourceHandling(Stack<string> path)
        {

            // Resource van kibővítve workforce-á
            try
            {
                var client = new ManagerService.ManagerServiceClient();

                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";

                
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            throw new NotImplementedException();
        }
*/
    }
}
