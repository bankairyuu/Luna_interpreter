using System;
using System.Text;
using System.IO;

namespace Luna_interpreter.GOLD_Engine
{
    /// <summary>
    /// A MyParserClass a GOLD Engine és GOLD Parser használatával szintaktikailag elemzi a bemenetként kapott szöveget, majd ha azt elfogadja,
    /// létrehozza belőle későbbi felhasználásra a lebontási fát
    /// </summary>
    class MyParserClass
    {
        /// <summary>
        /// A parszolás műveletét végző objektum
        /// </summary>
        /// <seealso cref="GOLD.Parser"/>
        private GOLD.Parser parser = new GOLD.Parser();

        /// <summary>
        /// A lebontási fa teteje, vagyis a gyökérelem
        /// </summary>
        /// <seealso cref="GOLD.Reduction"/>
        public GOLD.Reduction Root;     //Store the top of the tree

        /// <summary>
        /// Hibaüzenet
        /// </summary>
        public string FailMessage;

        /// <summary>
        /// A Setup függvény a nyelvtanfájl megnyitásáért felelős.
        /// </summary>
        /// <returns>Logikai igaz, ha sikeres a nyelvtanfájl megnyitása, ellenkező esetben logikai hamis.</returns>
        public bool Setup()
        {
            try
            {
                return parser.LoadTables(Environment.CurrentDirectory + @"/../../../Luna_interpreter/Gold_Engine/lang0.53.egt");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return false;
            }
        }

        /// <summary>
        /// Publikus függvény, mely alapvetően egy lebontási fához vezető rekurziót indít el, valamint ennek kiértékelése után a fa bejárásáért felelős
        /// logikai motorban lévő főosztálynak a gyökérelemmel átadja a lebontási fát
        /// </summary>
        /// <param name="instructions">A bemeneti string, melyet a megadott nyelvtan segítségével vagy elfogad a rendszer, vagy nem</param>
        /// <returns>A lebontási fa szövegszerű reprezentációja, jól tagolt formában</returns>
        public string Parsing(string instructions)
        {
            if (Parse(new StringReader(instructions)))
            {
                string s = DrawReductionTree(Root);
                Logical_Engine.Classes.Processor processor = new Logical_Engine.Classes.Processor(Root);

                return s;
            }
            else
            {
                return FailMessage;
            }
        }

        /// <summary>
        /// A parszolási fa generálását elindító rekurziós fej
        /// </summary>
        /// <param name="Root">A lebontási fa gyökéreleme</param>
        /// <returns>a lebontási fa tagoltan, szöveg formátumban</returns>
        private string DrawReductionTree(GOLD.Reduction Root)
        {
            //This procedure starts the recursion that draws the parse tree.
            StringBuilder tree = new StringBuilder();

            tree.AppendLine("Non Terminal\t+-" + Root.Parent.Text(false));
            DrawReduction(tree, Root, 1);

            return tree.ToString();
        }

        /// <summary>
        /// A lebontási fa egyes leveleihez tartozó értékek adott szintnek megfelelő szöveges reprezentációját végzi tagolási eljárásokkal egybekötve
        /// </summary>
        /// <param name="tree">A visszatérési szöveget tároló StringBuilder objektum</param>
        /// <param name="reduction">Egy adott levelet reprezentáló GOLD.Reduction típus</param>
        /// <param name="indent">Az adott mélység számban kifejezve</param>
        /// <remarks>
        /// A függvény csupán a szöveges formátumú lebontási fa reprezentációját hivatott létrehozni
        /// </remarks>
        private void DrawReduction(StringBuilder tree, GOLD.Reduction reduction, int indent)
        {
            //This is a simple recursive procedure that draws an ASCII version of the parse
            //tree

            int n;
            string indentText = "";

            for (n = 1; n <= indent; n++)
            {
                indentText += "| ";
            }

            //=== Display the children of the reduction
            for (n = 0; n < reduction.Count(); n++)
            {
                switch (reduction[n].Type())
                {
                    case GOLD.SymbolType.Nonterminal:
                        GOLD.Reduction branch = (GOLD.Reduction)reduction[n].Data;

                        tree.AppendLine("Non Terminal\t" + indentText + "+-" + branch.Parent.Text(false));
                        DrawReduction(tree, branch, indent + 1);
                        break;

                    default:
                        string leaf = (string)reduction[n].Data;
                        tree.AppendLine("Terminal\t" + indentText + " + -" + leaf);
                        break;
                }
            }
        }

        /// <summary>
        /// A parszolás megtódusát ténylegesen elvégző eljárás
        /// 
        /// This procedure starts the GOLD Parser Engine and handles each of the
        /// messages it returns.
        /// Each time a reduction is made, you can create new
        /// custom object and reassign the .CurrentReduction property. Otherwise, 
        /// the system will use the Reduction object that was returned.
        ///
        /// The resulting tree will be a pure representation of the language 
        /// and will be ready to implement.
        /// </summary>
        /// <param name="reader">A bemeneti string, egy TextReader objektumba csomagolva</param>
        /// <returns>Logikai igaz, ha a bemenet szintaktikailag elfogadható</returns>
        public bool Parse(TextReader reader)
        {
            GOLD.ParseMessage response;
            bool done;                      //Controls when we leave the loop
            bool accepted = false;          //Was the parse successful?

            parser.Open(reader);
            parser.TrimReductions = false;  //Please read about this feature before enabling  

            done = false;
            while (!done)
            {
                response = parser.Parse();

                switch (response)
                {
                    case GOLD.ParseMessage.LexicalError:
                        //Cannot recognize token
                        FailMessage = "Lexical Error:\n" +
                                      "Position: " + parser.CurrentPosition().Line + ", " + parser.CurrentPosition().Column + "\n" +
                                      "Read: " + parser.CurrentToken().Data;
                        done = true;
                        break;

                    case GOLD.ParseMessage.SyntaxError:
                        //Expecting a different token
                        FailMessage = "Syntax Error:\n" +
                                      "Position: " + parser.CurrentPosition().Line + ", " + parser.CurrentPosition().Column + "\n" +
                                      "Read: " + parser.CurrentToken().Data + "\n" +
                                      "Expecting: " + parser.ExpectedSymbols().Text();
                        done = true;
                        break;

                    case GOLD.ParseMessage.Reduction:
                        //For this project, we will let the parser build a tree of Reduction objects
                        //parser.CurrentReduction = CreateNewObject(parser.CurrentReduction);
                        break;

                    case GOLD.ParseMessage.Accept:
                        //Accepted!
                        Root = (GOLD.Reduction)parser.CurrentReduction;    //The root node!                                  
                        done = true;
                        accepted = true;
                        break;

                    case GOLD.ParseMessage.TokenRead:
                        //You don't have to do anything here.
                        break;

                    case GOLD.ParseMessage.InternalError:
                        //INTERNAL ERROR! Something is horribly wrong.
                        done = true;
                        break;

                    case GOLD.ParseMessage.NotLoadedError:
                        //This error occurs if the CGT was not loaded.                   
                        FailMessage = "Tables not loaded";
                        done = true;
                        break;

                    case GOLD.ParseMessage.GroupError:
                        //GROUP ERROR! Unexpected end of file
                        FailMessage = "Runaway group";
                        done = true;
                        break;
                }
            } //while

            return accepted;
        }

    }; //MyParser


}
