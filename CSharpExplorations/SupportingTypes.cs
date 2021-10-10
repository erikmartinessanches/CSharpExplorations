using System;
namespace CSharpExplorations
{
    public class Octopus
    {
        int Legs;
        int Weight;
        int length; /* The private backing field for the Length proprety 
                     * (Not necessary for automatic properties). */

        /* Expression-bodied prop. "value" is implicitly set to the assigned 
         * value at the calling site. */
        public int Length { get => length - 3; set => length = value + 5; }


        /* Constructor overloading, using "this" keyword to call another
         * constructor from a constructor. */
        //Explicitly write default one (if desired) when others exist.
        public Octopus() 
        {

        }
        public Octopus(int legs) { Legs = legs; }
        // Below, the called constructor (with legs) executes first.
        public Octopus(int legs, int weight) : this(legs) { Weight = weight; }


        public void Eat(int fishes)
        {
            Console.WriteLine($"Ate {fishes} fishes.");
        }

        /* A deconstructor assigns fields to variables. It must be called 
         * 'Deconstruct' and have one or more 'out' parameters. */

       
        public void Deconstruct(out int legs, out int weight)
        {
            legs = Legs;
            weight = Weight;
        }
    }
    public class Rectangle
    {
        public readonly float Width, Height;
        /* We can use deconstructing assignment to simplify a constructor: */
        public Rectangle(float width, float height) =>
            (Width, Height) = (width, height);
        public void Deconstruct(out float width, out float height)
        {
            width = Width;
            height = Height;
        }
    }

    /**In order for functions to return refs to a field, they must be set up 
    like so: */
    public class RefReturns{
        public static string x = "Old Value"; //public for demo purposes.
        public static ref string GetX() => ref x; //Returns a ref.

        //Ref returns can also be used when defining a property or indexer,
        //such a property is implicitly writable:
        public static ref string Prop => ref x; 
        //(To prevent modification, use 'ref readonly' modifier).
    }
}
