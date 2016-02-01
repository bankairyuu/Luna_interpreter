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
            if (path.Length != 4) throw new Exception("Az elérési útvonal nem teljesíti a követelményeket ( Document.<DocumentName>.<SectionName>.<FieldName> )");
            try
            {
                var client = new DocumentEditorService.DocumentEditorServiceClient();

                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";


                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
                try
                {
                    var doksi = client.GetTemplateDocuments();
                    Console.WriteLine("doksik száma: " + doksi.Length);

                    for (int i=0; i<doksi.Length; i++)
                    {
                        Console.WriteLine("Doksi neve: " + doksi[i].Name + " id: " + doksi[i].Id + " leírás: " + doksi[i].Description);

                        var szekciók = client.GetTemplateDocumentSections(doksi[i].Id);
                        Console.WriteLine("- A dokumentum szekcióinak száma: " + szekciók.Length);
                        for (int j = 0; j<szekciók.Length; j++)
                        {
                            Console.WriteLine("\t" + szekciók[j].Name);
                            try
                            {
                                Console.WriteLine("\t- adott szekció fildjeinek száma: " + szekciók[j].Fields.Length);

                                for (int k = 0; k < szekciók[j].Fields.Length; k++)
                                {
                                    try
                                    {
                                        Console.WriteLine("\t\tA field neve: " + szekciók[j].Fields[k].Name);
                                    }
                                    catch (Exception exc) { }
                                }

                            }
                            catch (Exception Exc) { }
                        }
                    }

                    return doksi[0].Name;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

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
