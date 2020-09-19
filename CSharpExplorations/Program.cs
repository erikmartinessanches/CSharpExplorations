﻿using System;
using System.Collections;

namespace CSharpExplorations
{
    public class Program
    {
        public static void Main(string[] args) { }

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
                result += squared;
            }
            return int.Parse(result);
        }
    }
}
