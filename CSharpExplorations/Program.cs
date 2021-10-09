
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
