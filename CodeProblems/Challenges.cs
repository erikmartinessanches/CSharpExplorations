using System;
namespace CSharpExplorations
{
    public class Challenges
    {
        public Challenges()
        {
            Console.WriteLine(SquareDigits(23));
            Console.WriteLine(hasDuplicate([1, 2, 3, 3])); //Should be true, contains duplicates.
            Console.WriteLine(hasDuplicate([1, 2, 3, 4])); //Should be false, no duplicates.
        }

        /// <summary>
        /// This is a code kata from
        /// https://www.codewars.com/kata/546e2562b03326a88e000020/csharp.
        /// </summary>
        /// <param name="n">A number.</param>
        /// <returns>Every digit in n squared and concatenated into a single number.</returns>
        public static int SquareDigits(int n)
        {
            String result = "";
            foreach (char c in n.ToString())
            {
                int squared = (int)(char.GetNumericValue(c) * char.GetNumericValue(c));
                result += squared; //Digits are cast to strings and appended.
            }
            return int.Parse(result);
        }

        //https://neetcode.io/problems/duplicate-integer
        public static bool hasDuplicate(int[] nums)
        {
            /*Storing seen elements in a hash map. */
            var numbersSeen = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numbersSeen.Add(nums[i])) return true; // See if I can make use of Add() returning true/false.
                // Add Returns:
                // true if the element is added to the set; false if the element is already in the set.
            }
            return false;
            //Brute O(n^2):
            /*        for(int i = 0; i < nums.Length; i++){
                        for(int y = i+1; y < nums.Length; y++){
                            if (nums[i] == nums[y]){
                                return true;
                            }
                        }
                    }
                    return false;
            */
        }
    }
}
