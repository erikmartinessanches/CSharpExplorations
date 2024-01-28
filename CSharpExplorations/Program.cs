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
      Types();
      Arrays();
    }

    private static void Arrays()
    {
      /* Elements are always stored in a contiguous block of memory. After 
      creating, it's length are unchageable. All arrays inherit from 
      System.Array class, providing common services. */
      char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
      /* When the element type is of ~value~ type, each element value is allocated
      as part of the array:
      */
      Point[] a = new Point[1000];
      //var x = a[500].X;

      /* Had Point been a class, creatiung an array would have merely 
      allocated 1000 null references that could be manually instantiated
      using a loop. */
      Point2[] a2 = new Point2[1000];
      //int x2 = a2[500].X; //NullReferenceException... ususally.
      /*The array itself is always a reference object, regardless. */

      /* Our own types can be made to work with indices and ranges by defining 
      an indexer of type 'Index' or 'Range'. */
      char lastElement = vowels[^1]; //'u'
      char secontToLast = vowels[^2]; //'o'
                                      // [^0] equals the length of the array.

      //We can also use an 'Index' type.
      Index first = 0;
      Index last = ^1;
      char firstElem = vowels[first]; //'a'
      char lastElem = vowels[first]; // 'u'

      // Or using Ranges. The second number in ranges is ~exclusive~.
      char[] firstTwo = vowels[..2];
      char[] lastThree = vowels[2..];
      char[] middleOne = vowels[2..3];
      char[] lastTwoChars = vowels[^2..];

      Range firstTwoRange = 0..2;
      char[] firstTwoChars = vowels[firstTwoRange];
    }

    private static void Types()
    {
      //INDEXER USAGE
      Sentence s = new Sentence();
      Console.WriteLine(s[3]); //"forever"
      s[3] = "a blast";
      Console.WriteLine(s[3]); //"a blast"

      Sentence s2 = new Sentence();
      string[] firstTwo = s2[..2];
      foreach (string str in firstTwo) Console.WriteLine(str);

      /*CONST
       * Constants are static fields that must be initialized with a value. 
       They differ from 'static readonly' fields in that consts are evaluated at
      compile time. 'static reaonly' fields can have different values per
      application. */

      /**   STATIC CLASSES AND STATIC CONSTRUCTORS
       * Static constructors execute once per type rather than once per 
       * instance, a type can have only one (must be parameterless) static 
       * constructor and have the same name as the type. The static constructor
       * is invoked just prior to the type being used.
       * 
       * Static classes can only be composed of static members and cannot be
       * subclassed.
       * 
       *    FINALIZERS
       * are class-only methods that execute before the garbage collector 
       * reclaims memory for an unreferenced onject. 
       * 
       *    PARTIAL TYPES AND METHODS
       * Each participant (typically in different files) must have the 'partial' 
       * declaration. Participants cannot have conflicting members. Partial
       * types are resolved at compile time. One or more partial class 
       * declarations can specify the same base class. Each participant can 
       * independently specify interfaces to be implemented.
       * 
       * A partial type can contain partial methods, which must be void are 
       * implicitly private. A partial method consists of two parts, a 
       * definition (typically automatically generated) and an implementation 
       * (typically hand-written). Cannot include 'out' parameters.
       * 
       *    ABSTRACT CLASSES AND ABSTRACT MEMBERS
       * An abstract class can never be instantiated, only its concrete 
       * ~subclasses~ can be instantiated. 
       * 
       * Abstract classes can contain abstract
       * members which are like virtual members (can be overridden by 
       * subclasses using 'override'), except they don't provide a default 
       * implementation which must be provided by the subclass unless it itself 
       * is abstract.
       */


    }

    private static void Statements()
    {
      //Switching on types and their values.
      object x = 5; //object can be any type.
      switch (x)
      {
        case int i when i < 10:
          Console.WriteLine($"The square of {i} is {i * i}");
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
          Console.WriteLine("Uncertain about x's type.");
          break;
      }

      /**     SWITCH EXPRESSIONS
      We can use switch in the context of an ~expression~. Assume cardNumber
      is of type int. Case clauses are expressions terminated by commas, 
      rather than statements as in regular switch. Switch expressions are 
      more compact and can be used in LINQ quesries. */
      int cardNumber = 12;
      string cardName = cardNumber switch
      {
        13 => "King",
        12 => "Queen",
        11 => "Jack",
        _ => "Pip card" //equivalent to 'default' case.
      };
      Console.WriteLine(cardName);
      /**We can also switch on multiple values (the tuple pattern):*/
      string suite = "spades";
      string cardName2 = (cardNumber, suite) switch
      {
          (13, "spades") => "King of spades",
          (12, "spades") => "Queen of spades",
          _ => throw new NotImplementedException()
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
      Console.WriteLine(b); // Martines Sanches

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
      static void Boo(in int p)
      {

      }
      int g = 1;
      Boo(in g); // 'in' here is optional if there is no overload ambiguity.

      /*'params' modifier applied on the last param of a method allows
      for any number of arguments of that type. The parameter type must
      be declared as an array. */
      int Sum(params int[] ints)
      {
        int sum = 0;
        for (int i = 0; i < ints.Length; i++)
          sum += ints[i];
        return sum;
      }
      Console.WriteLine(Sum(1, 2, 3, 4, 5)); //equivalent to:
      Console.WriteLine(Sum(new int[] { 1, 2, 3, 4, 5 }));

      /*Side note: optional parameters cannot be 'ref' or 'out'. Optional
      parameters can be used with named arguments and called like this: 

          Bar(arg3:123);   //Calling the named argument 'arg3' with value 123.
       */

      /** With REF LOCALS, it's possible to define a local variable that
         references an element in an array or field in an object, or
         a local variable. It cannot be a property. Ref locals are 
         typically used for micro-optimization together with ref returns. */
      int[] numbers = { 0, 1, 2, 3, 4 };
      //numref is a ~reference~ to numbers[2] and modifies the array element:
      ref int numRef = ref numbers[2];
      numRef *= 10;
      Console.WriteLine(numRef); // 20
      Console.WriteLine(numbers[2]); // 20

      /**     REF RETURNS 
      can be considered a micro-optimization feature and 
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
      int? couldBeNull = null; //Nullable value type.
      Console.WriteLine($"couldBeNull (int) is null and should print nothing: {couldBeNull}"); //Writes nothing
      Console.WriteLine($"The default value of couldBeNull is {couldBeNull.GetValueOrDefault()}"); //0
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
