using System;
using System.Collections.Generic;

// Right to left addition algoritm
class SumThemUp
{
	static void Main()
	{
		int[,] Nums = ReadNums();
		int SigFigs = 2;

		int Answer = AddNums(Nums, SigFigs);
		Console.WriteLine(Answer);
        Console.ReadLine();
	}

	// Returns the number of digits in Num, less one
	static int DigitCount(int Num)
	{
		int Digits = 0;
		while(Num > 10)
		{
			Num = Num / 10;
			Digits++;
		}
		return Digits;
	}

	// Tidies up a num stored in a list digit by digit fashion
	static void CarryOver(List<int> Num)
	{
		for(int i = Num.Count - 1; i >= 0; i--)
		{
			if(Num[i] > 9)
			{
				if(i == 0)
				{
					Num.Insert(0, 0);
					i++;
				}
				Num[i - 1] += Num[i] / 10;
				Num[i] = Num[i] % 10;
			}
		}
	}

	// Reads in a file with numbers into a 2d array, returns the array
	static int[,] ReadNums()
	{
		int[,] Nums = new int[5,5];
		return Nums;
	}

	// Adds Numbers in an 2d array, does not care about carry overs
	// Takes in a parameter to determine the sigfigs (# of digits returned)
	static int AddNums(int[,] Nums, int SigFigs)
	{	
		int NumberOfNumbers = Nums.GetLength(0);

		// The max num of digits (to the left) that can be affected
		int MaxCarryOver = DigitCount(NumberOfNumbers * 9);
		
		List<int> Answer = new List<int>();		

		for(int i = 0; i < NumberOfNumbers; i++)
		{
			int Sum = 0;
			for(int j = 0; j < SigFigs + MaxCarryOver; j++)
			{
				Sum += Nums[i, j];
			}
			Answer.Add(Sum);
		}
		
		CarryOver(Answer);
		return Int32.Parse(String.Join("", Answer.ToArray()).Substring(0, SigFigs));
	}
}