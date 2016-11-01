using System;
using static System.Console;

class DoubleBasePalindrome
{
    static int MAX = 1000 * 1000;

    static void Main()
    {
        int Sum = 0;
        for (int i = 1; i < MAX; i++)
        {
            string StrDecimal = i + "";
            string StrBinary = Convert.ToString(i, 2);
            if (isPalindrome(StrDecimal) && isPalindrome(StrBinary))
            {
                WriteLine(StrDecimal);
                WriteLine(StrBinary);
                Sum += i;
            }
        }
        WriteLine("Sum is " + Sum);
        ReadLine();
    }

    // Returns true if Str is a Palindrome
    static bool isPalindrome(String Str)
    {
        for (int i = 0; i < Str.Length / 2; i++)
        {
            if (Str[i] != Str[Str.Length - 1 - i]) return false;
        }
        return true;
    }
}