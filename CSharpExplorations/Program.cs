using System;
namespace CSharpExplorations
{
    /// <summary>
    /// This program is for trying out some select aspects of C#, since I 
    /// already know about programming.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            ConstructingAndDeconstructing();
            NullExamples();
            Parameters();
            Statements();
        }

    private static void Statements()
    {
        //Switching on types and their values.
        object x = 5; //object can be any type.
        switch (x)
        {
            case int i when i < 10:
                Console.WriteLine($"The square of {i} is {i*i}");
                break;
            //We can stack multiple cases
            case double d when d < 10:
            case decimal m when m < 10:
                Console.WriteLine("Here we can only refer to x but not d or m.");
                break;
            case int _: 
                Console.WriteLine("It's an int, (discarded it's value).");
                break;
            default:
                Console.WriteLine("Uncertain abiut x's type.");
                break;
        }

        /**     SWITCH EXPRESSIONS
        We can use switch in the context of an ~expression~. Assume cardNumber
        is of type int. Case clauses are expressions terminated by commas, 
        rather than statements as in regular switch. Switch expressions are 
        more compact and can be used in LINQ quesries. */
        int cardNumber = 12;
        string cardName = cardNumber switch {
            13 => "King",
            12 => "Queen",
            11 => "Jack",
            _ => "Pip card" //equivalent to 'default' case.
        };
        Console.WriteLine(cardName);
        /**We can also switch on multiple values (the tuple pattern):*/
        string suite = "spades";
        string cardName2 = (cardNumber, suite) switch {
            (13, "spades") => "King of spades",
            (12, "spades") => "Queen of spades"
        };
        Console.WriteLine(cardName2);
    }

    /// <summary>
    /// Learning about parameters and trying out out, ref, and in parameters.
    /// </summary>
    private static void Parameters()
        {
            //We have to tell this func is expecting a 'ref' param.
            static void Foo(ref int p) 
            {
                p = p + 1;
                Console.WriteLine(p);
            }
            /* To pass by reference, use 'ref' parameter modifier, p and x
             * refer to the same memory location. */
            int x = 8;
            Foo(ref x); //Ask foo to deal directly with x and
            //now assigning p a new value changes the contents of x.
            Console.WriteLine(x); //9

            /* BIG TAKEAWAY 
             * 
             * A param. can be passed by value or reference regardless 
             * of whether the param is a reference ro value type.  
             */

            /* 'out' param modifier is mostly used to return multiple 
             * return values from a function.
             *  /* An 'out' argument is like a 'ref' except: 
             * 
             * * It need not be assigned before going into the function
             * * It must be assigned before going out of the function
            * 
            */
            // Notice how a, b don't have to be assigned before going into 
            // the function and can be declared on the fly, inside the 
            // method call.
            //string a, b;
            Split("Erik Martines Sanches", out string a, out string b);
            Console.WriteLine(a); // Erik
            Console.WriteLine (b); // Martines Sanches

            //We have to assign the out params before the come out of the func.
            void Split(string name, out string firstName, out string lastNames)
            {
                int i = name.IndexOf(' ');
                firstName = name.Substring(0, i);
                lastNames = name.Substring(i + 1);
            }

            /* 'in' parameters is similar to ref, except that the argument's
                value cannot be modified by the method. */
            // Overloading solely on the presence of 'in' (in the same scope as 
            // 'ref') is permitted. Foo has two overloaded definitions in this 
            // scope.
            // Recommended for large value types, (rather than int).
            static void Boo(in int p){
                
            }
            int g=1;
            Boo(in g); // 'in' here is optional if there is no overload ambiguity.


            /*'params' modifier applied on the last param of a method allows
            for any number of arguments of that type. The parameter type must
            be declared as an array. */
            int Sum(params int[] ints){
                int sum = 0;
                for (int i = 0; i < ints.Length; i++)
                    sum += ints [i];
                return sum;
            }
            Console.WriteLine(Sum(1,2,3,4,5)); //equivalent to:
            Console.WriteLine(Sum(new int[] {1,2,3,4,5}));

            /*Side note: optional parameters cannot be 'ref' or 'out'. Optional
            parameters can be used with named arguments and called like this: 

                Bar(arg3:123);   //Calling the named argument 'arg3' with value 123.
             */

             /** With REF LOCALS, it's possible to define a local variable that
                references an element in an array or field in an object, or
                a local variable. It cannot be a property. Ref locals are 
                typically used for micro-optimization together with ref returns. */
            int[] numbers = {0,1,2,3,4};
            //numref is a ~reference~ to numbers[2] and modifies the array element:
            ref int numRef = ref numbers[2]; 
            numRef *= 10;
            Console.WriteLine(numRef); // 20
            Console.WriteLine(numbers[2]); // 20

            /**REF RETURNS can be considered a micro-optimization feature and 
            used sparingly. One can return a 'ref local' form a method, this is
            called a 'ref return'. (Real gains can occur with custom value types
            if the struct is marked as 'readonly'.) */
        
            ref string xRef = ref RefReturns.GetX(); //Assign result to a ref local.
            //Now we can use the ref local to change the field it refers to.
            xRef = "New Value";
            Console.WriteLine(xRef);
            Console.WriteLine(RefReturns.x);
            RefReturns.Prop = "New Value 2";
            Console.WriteLine(RefReturns.Prop);

            /**If we omit the 'ref' on the calling site, it reverts to returning
            an ordinary value: */
            string localX = RefReturns.GetX();
        }

        private static void ConstructingAndDeconstructing()
        {
            Octopus octo = new Octopus(8, 35);
            octo.Eat(4);
            var (legs, weight) = octo; //Deconstructing, equivalent to:
            //octo.Deconstruct(out var legs, out var weight);
            Console.WriteLine($"Legs: {legs}, weight: {weight} units.");
            octo.Eat(6);

            //Using properties with extra set and get logic.
            octo.Length = 50;
            Console.WriteLine(octo.Length);

            //Creating a Rectangle using deconstructing assignment in its
            //constructor.
            var rect = new Rectangle(3, 4);

        }

        private static void NullExamples()
        {
            int cantBeNull = 5;
            //cantBeNull = null; //error, clearly
            int? couldBeNull = null;
            Console.WriteLine(couldBeNull); //Writes nothing
            Console.WriteLine(couldBeNull.GetValueOrDefault()); //0
            couldBeNull = 7;
            Console.WriteLine(couldBeNull); //7
            Console.WriteLine(couldBeNull.GetValueOrDefault()); //7
            //couldBeNull = null;
            int? y = couldBeNull;

            // Null-coalescing operator. ??
            //"Give me LHS if it is not null, else the value on the RHS."
            string s1 = null;
            string s2 = s1 ?? "Something is better than nothing.";

            // Null-coalescing assignment operator. ??=
            //"If the left operand is null, assign the right operand to the left."
            string myVariable = null;
            myVariable ??= "yo";

            // Null conditional ?. 
            // If the operand to the left is null, the experession evaluates
            // to null, instead of throwing a NullReferenceException.
            System.Text.StringBuilder sb = null;
            string s = sb?.ToString();
            /* Upon encountring a null, the ?. operator short-circuits the 
            remainder of the expression, even with standard dot operator to the
            right. Repeated use of ?. is necessary only if the operand 
            immediately to its left may be null. The following expression is 
            robust to both x and y being null:

                x?.y?.z;

            The final expression must be able to accept a null. ?. can also be
            used to call a void method, if someObject is null, this will be a 
            'no-operation' rather than a NullReferenceException.

                someObject?.SomeVoidMethod();

            ?. can be used with the commonly used type members, including methods,
            fields, properties, indexers. It also combines with ??

                string s = sb?.ToString() ?? "something"; //Evaluates to "something".
            */
        }
    }
}
