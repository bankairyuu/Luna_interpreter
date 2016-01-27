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
                Console.WriteLine(parser.Parsing("-5 equals -5"));
                //                Console.WriteLine();
                //                Console.WriteLine(parser.Parsing("x != D.C(h)"));
                Console.WriteLine(Environment.NewLine + "\t---------\tParse Tree\t---------" + Environment.NewLine);
            }

            Console.ReadLine();
        }
    }
}
