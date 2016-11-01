using System;

class PalindromeProduct
{
	static void Main()
	{
		Console.WriteLine(LargestPalindromeProduct());
	}

	// Returns the largest 3 digit palindrome product
	static int LargestPalindromeProduct()
	{
		int LargestPalindrome = -1;
		for(int i = 999; i > 1; i--)
		{
			for(int j = 999; j > 1; j--)
			{
				int MaybePalindrome = i * j;
				if(IsPalindrome(MaybePalindrome) && 						           MaybePalindrome > LargestPalindrome)						{
					LargestPalindrome = MaybePalindrome;
				}
			}
		}
		return LargestPalindrome;
	}

	// Returns true if Num is a palindrome
	static bool IsPalindrome(int Num)
	{
		string Number = "" + Num;
		for(int i = 0; i < Number.Length / 2; i++)
		{
			if(Number[i] != Number[Number.Length - 1 - i])
			{
				return false;
			}
		}
		return true;
	}
}