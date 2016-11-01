using System;
using System.Linq;
using System.Numerics;
using static System.Console;

class Solution
{
    // A LOT of optimizations are available here, but were not necessary due to limits set by the problem
    //
    // 1. Memoize Lychrel and non-Lychrel numbers. Use bool[] or List<bool> (depending on how you implement memoizations)
    // 2. Pre generate (or pre check) numbers that are guarenteed to be non-Lychrel.
    //    These are numbers where adding their reverse to them does not have any two digits adding to 10 or greater.
    //    This means that no carry overs happen and thus the symmetry isn't messed up. These are trivally proven to be palindromic
    // 3. Statistical methods (maybe number theory methods?)
    // 4. Use Vaughn Suite's algorithm and other modern optimizations at p196.org
    const int MAX_NUM = 10000;
    const int MAX_ITERATIONS = 50;

    static void Main()
    {
        int LychrelNums = 0;
        for (int i = 7; i < MAX_NUM; i++)
        {
            if (IsLychrel(i)) LychrelNums++;
        }
        WriteLine(LychrelNums);
        WriteLine("Press enter to exit...");
        Read();
    }

    // Returns true if Num is a Lychrel number
    // Assumes a number is a Lychrel number if it hasn't been proven to be a non Lychrel number after MaxIterations iterations 
    static bool IsLychrel(BigInteger Num)
    {
        for (int i = 0; i < MAX_ITERATIONS; i++)
        {
            BigInteger NumReverse = BigInteger.Parse(new String(("" + Num).Reverse().ToArray()));
            BigInteger NewNum = Num + NumReverse;
            if (IsPalindrome("" + NewNum)) return false;
            Num = NewNum;
        }
        return true;
    }

    // Returns true if Str is a palindrome
    static bool IsPalindrome(string Str)
    {
        for (int i = 0; i < Str.Length / 2; i++)
        {
            if (Str[i] != Str[Str.Length - 1 - i]) return false;
        }
        return true;
    }
}