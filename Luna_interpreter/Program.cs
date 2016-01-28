using System;

namespace Luna_interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            GOLD_Engine.MyParserClass parser = new GOLD_Engine.MyParserClass();
            if (parser.Setup())
            {
                Console.WriteLine(Environment.NewLine + "\t---------\tParse Tree\t---------"+ Environment.NewLine);
                //Console.WriteLine(parser.Parsing("((-5 + -15) * 5) <= -20 * (2 + 3)"));
                //Console.WriteLine(parser.Parsing("yes == no"));
                //Console.WriteLine(parser.Parsing("x != D.C.v"));
                //Console.WriteLine(parser.Parsing("(((-5 + -15) * 5) <= -20 * (2 + 3)) == yes"));
                //Console.WriteLine(parser.Parsing("2016.01.28"));

                var client = new LocationService.LocationServiceClient();
                client.ClientCredentials.UserName.UserName = "test";
                client.ClientCredentials.UserName.Password = "test";

                Console.WriteLine(Environment.NewLine + "\t---------\tParse Tree\t---------" + Environment.NewLine);
            }

            Console.ReadLine();
        }
    }
}
