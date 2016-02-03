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

            GOLD_Engine.MyParserClass parser = new GOLD_Engine.MyParserClass();
            if (parser.Setup())
            {
                Console.WriteLine(Environment.NewLine + "\t---------\tParse Tree\t---------"+ Environment.NewLine);
                //Console.WriteLine(parser.Parsing("((-5 + -15) * 5) <= -20 * (2 + 3)"));
                //Console.WriteLine(parser.Parsing("yes == no"));
                //Console.WriteLine(parser.Parsing("x != D.C.v"));
                //Console.WriteLine(parser.Parsing("x != D.C.v()"));
                //Console.WriteLine(parser.Parsing("x != D.C.v(a)"));
                //Console.WriteLine(parser.Parsing("x != D.C.v(a, b)"));
                //Console.WriteLine(parser.Parsing("(((-5 + -15) * 5) <= -20 * (2 + 3)) == yes"));
                //Console.WriteLine(parser.Parsing("2016.01.28"));
                //Console.WriteLine(parser.Parsing("Document.Managers.JohnCena.DepartmentName"));
                //Console.WriteLine(parser.Parsing("Workflow[\"MF1\"].Status"));
                Console.WriteLine(parser.Parsing("Workflow[W1M].Status"));
                Console.WriteLine(parser.Parsing("Workflow[W1M].Status.Kecske"));
                Console.WriteLine(parser.Parsing("Workflow[W1M].Status[Kecske].veljuh"));
                Console.WriteLine(Environment.NewLine + "\t---------\tParse Tree\t---------" + Environment.NewLine);
            }

            Console.ReadLine();
        }
    }
}
