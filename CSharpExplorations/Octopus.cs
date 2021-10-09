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
         * 'Deconstruct' and have one or more 'out' parameters. 

        /* An 'out' argument is like a 'ref' except: 
         * 
         * *It need not be assigned before going into the function
         * *It must be assigned before going out of the function
         * 
         */
        public void Deconstruct(out int legs, out int weight)
        {
            legs = Legs;
            weight = Weight;
        }
    }
    class Rectangle
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
}
