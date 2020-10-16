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
        public Octopus() //Explicitly write default one (if desired) when others exist.
        {

        }
        public Octopus(int legs) { Legs = legs; }
        // Below, the called constructor executes first.
        public Octopus(int legs, int weight) : this(legs) { Weight = weight; }


        public void Eat(int fishes)
        {
            Console.WriteLine($"Ate {fishes} fishes.");
        }

        public void Deconstruct(out int legs, out int weight)
        {
            legs = Legs;
            weight = Weight;
        }
    }
}
