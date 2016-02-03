﻿using System;
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
            if (path[0].Equals("Document"))
            {
                return DocumentHandling(path);
            }
            else if (path[0].Equals("Resource"))
            {
                return ResourceHandling(path);
            }
            throw new NotImplementedException("A rendszer csak a Document és a Resource típusú objektum orientált kéréseket támogatja");
        }

        private static object DocumentHandling(string[] path)
        {
            // több ugyanolyan dokumentumnév van, így ... Ádámék faszok

            if (path.Length != 4) throw new Exception("Az elérési útvonal nem teljesíti a követelményeket ( Document.<DocumentName>.<SectionName>.<FieldName> )");
            try
            {
                var client = new DocumentEditorService.DocumentEditorServiceClient();
                var bpmnclient = new BPMNEditorService.BPMNEditorClient();

                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";


                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");

                //var processes = bpmnclient.GetProcess(1);

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            
            return null;
        }

        private static object ResourceHandling(string[] path)
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
