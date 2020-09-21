using System;

namespace CSharpExplorations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NullExamples();
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
