using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Structure.Classes
{
    class Document
    {
        /*

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

        */
    }
}
