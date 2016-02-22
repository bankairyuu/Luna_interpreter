using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model
{
    /// <summary>
    /// A rendszer által használt enumokat egybegyűjtő statikus osztály
    /// </summary>
    /// <seealso cref="Luna_interpreter.Model.Enums"/>
    /// <remarks>
    /// Az Enum statikus osztály egyetlen publikus enumot tartalmaz, melynek célja, hogy a lebontás során felhasználandó nemterminálisokat egybe gyűjtse
    /// </remarks>
    public static class Enums
    {
        /// <summary>
        /// A rendszer által használt nemterminálisok enumerációja
        /// </summary>
        /// <seealso cref="Luna_interpreter.Model.Enums.eNonTerminals"/>
        /// <example>
        /// Például: Program, Expression, SimpleExpression, stb...
        /// </example>
        public enum eNonTerminals
        {
            /// <summary>
            /// Egy program szerkezetét leíró nemterminális. A program programsorokból áll. (kezdő nemterminális)
            /// </summary>
            /// <remarks>
            /// Program ::= ProgramLine End Program
            ///             | ProgramLine
            /// </remarks>
            Program,

            /// <summary>
            /// Egy programsor lehet egy kifejezés, komment, állítás, vagy üres.
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.ProgramLine"/>
            /// <remarks>
            /// ProgramLine ::= Expression
            ///                 | CommentItem
            ///                 | Statement
            ///                 | 
            /// </remarks>
            ProgramLine,

            /// <summary>
            /// Expression - Egy "nagy" kifejezés reprezentációja
            /// negyedik precedencia szint
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Expression"/>
            /// <remarks>
            /// Expression ::= SimpleExpression
            ///          |  SimpleExpression = SimpleExpression
            ///          |  SimpleExpression == SimpleExpression
            ///          |  SimpleExpression equals SimpleExpression
            ///          |  SimpleExpression like SimpleExpression
            ///          |  SimpleExpression not like SimpleExpression
            ///          |  SimpleExpression ~ SimpleExpression
            ///          |  SimpleExpression !~ SimpleExpression
            ///          |  SimpleExpression != SimpleExpression
            ///          |  SimpleExpression not equals SimpleExpression
            ///          |  SimpleExpression &lt;&gt; SimpleExpression
            ///          |  SimpleExpression regex SimpleExpression
            ///          |  SimpleExpression _ SimpleExpression
            ///          |  SimpleExpression &lt; SimpleExpression
            ///          |  SimpleExpression &lt;= SimpleExpression
            ///          |  SimpleExpression &gt; SimpleExpression
            ///          |  SimpleExpression &gt;= SimpleExpression
            ///          |  GetExpression
            /// </remarks>
            Expression,

            /// <summary>
            /// SimpleExpression - Egyszerű kifejezés reprezentációja
            /// harmadik precedencia szint
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.SimpleExpression"/>
            /// <remarks>
            /// SimpleExpression ::= Term
            ///          |  SimpleExpression + Term
            ///          |  SimpleExpression - Term
            ///          |  SimpleExpression or Term
            ///          |  SimpleExpression | Term
            ///          |  SimpleExpression || Term
            ///          |  SimpleExpression xor Term
            /// </remarks>
            SimpleExpression,

            /// <summary>
            /// Term - 'Kis' kifejezés reprezentációja
            /// második precedencia szint
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Term"/>
            /// <remarks>
            /// Term ::= Factor
            ///       |  Term * Factor
            ///       |  Term / Factor
            ///       |  Term mod Factor
            ///       |  Term % Factor
            ///       |  Term and Factor
            ///       |  Term &amp; Factor
            ///       |  Term &amp;&amp; Factor
            /// </remarks>
            Term,

            /// <summary>
            /// Factor - Egy faktor (tényező) reprezentációja
            /// első precedencia szint
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Factor"/>
            /// <remarks>
            /// Factor ::= ( Expression )
            ///    |  + Factor
            ///    |  - Factor
            ///    |  not Factor
            ///    |  ! Factor
            ///    |  StringLiteral     (ez már egy terminális típus)
            ///    |  NumberLiteral     (ez már egy terminális típus)
            ///    |  RealLiteral       (ez már egy terminális típus)
            ///    |  Chain
            ///    |  BooleanLiteral    (ez már egy terminális típus)
            ///    |  DateTimeLiteral
            /// </remarks>
            Factor,

            /// <summary>
            /// Chain - Lánc típus reprezentációja.
            /// Egy híváslánc elemekből és függvényekből áll, közöttük . elválasztó karakterrel.
            /// A rendszer az ilyen jellegű adatokat minden esetben hivatkozásnak veszi egy adott dokumentumon belüli elem elérésére,
            /// ennek megfelelően a rendszer jelenleg nem támogatja a FunctionCall nemterminálist
            /// Példa: Document[DocumentName].Section[SectionName].Field[FieldName]
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Chain"/>
            /// <remarks>
            /// Chain ::= Element
            ///     |  FunctionCall
            ///     |  Element.Chain
            ///     |  FunctionCall.Chain
            /// </remarks>
            Chain,

            /// <summary>
            /// Element - Elem typus reprezentációja
            /// Egy elem lehet egy azonosító önmagában, vagy egy azonosító és egy azt követő indexer.
            /// Példa:  Z51
            ///         Document[DocumentName]
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Element"/>
            /// <remarks>
            /// Element ::= ID
            ///      |  ID Indexer
            /// </remarks>
            Element,

            /// <summary>
            /// FunctionCall - függvényhívást reprezentáló nemterminális
            /// A rendszer jelenleg ezt a nemterminálist nem használja
            /// </summary>
            FunctionCall,

            /// <summary>
            /// FunctionParameters - függvény paraméterek nemterminálisa
            /// A rendszer jelenleg ezt a nemterminálist nem használja
            /// </summary>
            FunctionParameters,

            /// <summary>
            /// ExpressionList - kifejezés lista
            /// A rendszer jelenleg ezt a nemterminálist nem használja
            /// </summary>
            ExpressionList,

            /// <summary>
            /// Statement - állítás reprezentációja
            /// Értékadásra, műveletvégzésre szólítja fel a rendszert, azonban jelenleg ezt a nemterminálist a rendszer nem használja
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Statement"/>
            /// <remarks>
            /// Statement ::= debug Expression
            ///    |  copy Expression to Chain
            ///    |  trace TraceEnum
            ///    |  let ID = Expression
            ///    |  let ID := Expression
            ///    |  ID := Expression
            /// </remarks>
            Statement,

            /// <summary>
            /// DateTimeLiteral - Dátum-idő nem terminális, a rendszer számára egy DateTime objektumot reprezentál
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.DateTimeLiteral"/>
            /// <remarks>
            /// DateTimeLiteral ::= Date
            ///    | Time
            ///    | Date Time
            /// </remarks>
            DateTimeLiteral,

            /// <summary>
            /// Időt reprezentáló nemterminális.
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Time"/>
            /// <remarks>
            /// Time ::= TimeLiteral                (ez már egy terminális érték)
            ///      |  TimeWithSecondLiteral       (ez már egy terminális érték)
            /// </remarks>
            Time,

            /// <summary>
            /// Date - Dátum értéket reprezentáló nem terminális
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Date"/>
            /// <remarks>
            /// Date ::= DateLiteral    (ez már egy terminális)
            /// </remarks>
            Date,

            /// <summary>
            /// Indexer - Az indexer elem teszi lehetővé, hogy az alábbihoz hasonló kifejezéseket használhassunk: Document[Contract]
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Indexer"/>
            /// <remarks>
            /// Indexer ::= [ StringLiteral ] 
            ///     |  [ NumberLiteral ]
            ///     |  [ ID ]
            /// </remarks>
            Indexer,

            /// <summary>
            /// GetExpression - Egy GetExpression egy lekérdezéshez hasonló szintaktikájú nemterminálisként írható le.
            /// A rendszeren belül való használatnál meg kell adni elsőként a lekérdezés típusát (pl: Worforce, Resource, stb...)
            /// a második paraméterben a szűrési feltételt, a harmadik paraméterben pedig a rendezési feltételt
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.GetExpression"/>
            /// <remarks>
            /// GetExpression ::= get from Container WhereClosure OrderByClosure
            /// </remarks>
            GetExpression,

            /// <summary>
            /// Container - Egy GetExpression paraméter, mely a lekérendő helyet jelöli. Megfelel az SQL-ben használt SELECT * FROM "ContainerName"-nek
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Container"/>
            /// <remarks>
            /// Container ::= ID
            ///       |  List
            /// </remarks>
            Container,

            /// <summary>
            /// List - lista, melyet jelenleg kizárólag a Container nemterminális használ.
            /// Értelem szerűen listákat reprezentáló nemterminális
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.List"/>
            /// <remarks>
            /// List ::= [ Items ]
            ///       |  { Items }
            /// </remarks>
            List,

            /// <summary>
            /// WhereClosure - Szűrési feltételeket tartalmazó nemterminális, megfelel az SQL-ben használt WHERE "szűrési feltételek"-nek
            /// vagy egy stringet tartalmaz a feltételekről, vagy üres
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.WhereClosure"/>
            /// <remarks>
            /// WhereClosure ::= where StringLiteral    (ez már egy terminális érték)
            ///             |
            /// </remarks>
            WhereClosure,

            /// <summary>
            /// OrderByClosure - Rendezési feltételeket tartalmazó nemterminális, megfelel az SQL-ben használt ORDER BY "rendezési feltétlek"-nek
            /// vagy egy stringet tartalmaz a feltételekről, vagy üres
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.OrderByClosure"/>
            /// <remarks>
            /// OrderByClosure ::= order by StringLiteral
            ///             |  
            /// </remarks>
            OrderByClosure,

            /// <summary>
            /// Items - Item, vagy itemek felsorolását reprezentáló nemterminális
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Items"/>
            /// <remarks>
            /// Items ::= Item , Items
            ///     |  Item
            /// </remarks>
            Items,

            /// <summary>
            /// Item - egy felsorolás elemet jelölő nemterminális
            /// </summary>
            /// <seealso cref="Luna_interpreter.Model.Structure.Classes.Item"/>
            /// <remarks>
            /// Item ::= ID
            /// </remarks>
            Item,

            /// <summary>
            /// undefined - A rendszer számára hibakezelésre létrehozott nemterminális enum-elem
            /// </summary>
            undefined
        }
    }
}
