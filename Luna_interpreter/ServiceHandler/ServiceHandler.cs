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
            for (int i = path.Length - 1; i > 0; i--)
            {
                dataPath.Push(path[i]);
            }
            string[] type = path[0].Split(':');
            if (type[0].Equals("Document"))
            {
                return DocumentHandling(dataPath);
            }
            else if (type[0].Equals("Resource"))
            {
                return ResourceHandling(dataPath);
            }
            throw new NotImplementedException("A rendszer csak a Document és a Resource típusú objektum orientált kéréseket támogatja");
        }

        private static object DocumentHandling(Stack<string> path)
        {
            // több ugyanolyan dokumentumnév van, így ... Ádámék faszok

            try
            {
                var client = new WoLaService.WoLaServiceClient();

                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");

                string[] innerPath = path.Pop().Split(':');
                int docID = client.GetDocumentId(innerPath[1], 43, null);

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
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
