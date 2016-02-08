using System;

namespace Luna_interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length != 2)
            //{
            //    throw new ArgumentException("The count of arguments is invalid! You have to give the Process instance, and the Command!");
            //}

            Model.Container.Container.processInstance = 43;

            GOLD_Engine.MyParserClass parser = new GOLD_Engine.MyParserClass();
            if (parser.Setup())
            {
                Console.WriteLine(Environment.NewLine + "\t---------\tParse Tree\t---------"+ Environment.NewLine);
                //Console.WriteLine(parser.Parsing("((-5 + -15) * 5) <= -20 * (2 + 3)"));
                //Console.WriteLine(parser.Parsing("yes == no"));
                //Console.WriteLine(parser.Parsing("(((-5 + -15) * 5) <= -20 * (2 + 3)) == yes"));
                //Console.WriteLine(parser.Parsing("2016.01.28"));
                //Console.WriteLine(parser.Parsing("Document[\"MF1\"].Status"));
                //Console.WriteLine(parser.Parsing("Workflow[W1M].Status"));
                //Console.WriteLine(parser.Parsing("Workflow[W1M].Status.Kecske"));
                Console.WriteLine(parser.Parsing("Document[Szerzodes].Section[Section1].Field[Datum]"));
                //Console.WriteLine(parser.Parsing("20:12"));
                //Console.WriteLine(parser.Parsing("20:12:22"));
                //Console.WriteLine(parser.Parsing("02.12.1922"));
                //Console.WriteLine(parser.Parsing("02.12.1922 12:12"));
                //Console.WriteLine(parser.Parsing("02.12.1922 11:12:13"));
                //Console.WriteLine(parser.Parsing("62.58.1922 equals 62.58.1922"));
                Console.WriteLine(Environment.NewLine + "\t---------\tParse Tree\t---------" + Environment.NewLine);
            }

            Console.ReadLine();
        }
    }
}
