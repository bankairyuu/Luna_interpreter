using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.ServiceHandler
{
    public static class ServiceHandler
    {
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
                Console.WriteLine("### Document Handling ###");
                return DocumentHandling(dataPath, type[1]);
            }
            else if (type[0].Equals("Resource"))
            {
                return ResourceHandling(dataPath);
            }
            throw new NotImplementedException("A rendszer csak a Document és a Resource típusú objektum orientált kéréseket támogatja");
        }

        private static object DocumentHandling(Stack<string> path, string docName)
        {
            // több ugyanolyan dokumentumnév van, így ... Ádámék faszok

            try
            {
                var client = new WoLaService.WoLaServiceClient();

                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");

                Stack<string> hStack = new Stack<string>();
                string[] helper;
                while (path.Count != 0)
                {
                    Console.WriteLine("~" + path.Count);
                    helper = path.Pop().Split(':');
                    if (helper.Length == 2)
                    {
                        Console.WriteLine("~" + helper[1]);
                        hStack.Push(helper[1]);
                    }
                    else
                    {
                        Console.WriteLine("~" + helper[0]);
                        hStack.Push(helper[0]);
                    }
                }
                Console.WriteLine(">>> " + hStack.Count);

                object returnValue = client.GetFieldValueByProccessInstace(Model.Container.Container.processInstance, hStack.Pop(), hStack.Pop(), hStack.Pop());
                // TODO itt valami null lesz, és exceptiont okoz... 
                Console.WriteLine(">>> " + returnValue);
                
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
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
            
            return null;
        }

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
    }
}
