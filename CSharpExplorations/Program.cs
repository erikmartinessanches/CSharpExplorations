
using System;

namespace CSharpExplorations
{
    /// <summary>
    /// This program is for trying out some select aspects of C#, since I 
    /// already know some OOP.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {

            ConstructingAndDeconstructing();
            NullExamples();
            Parameters();
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
            // the function.
            string a, b;
            Split("Erik Martines Sanches", out a, out b);
            Console.WriteLine(a); // Erik
            Console.WriteLine (b); // Martines Sanches

            //We have to assign the out params before the come out of the func.
            void Split(string name, out string firstName, out string lastNames)
            {
                int i = name.IndexOf(' ');
                firstName = name.Substring(0, i);
                lastNames = name.Substring(i + 1);
            }
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
        }
    }
}
