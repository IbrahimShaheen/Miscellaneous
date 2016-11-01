using System;

class Pythagorean
{
	static void Main()
	{
		PrintArray(SpecialTriplet());
	}

	// Returns a Pythagorean triplet which sums up to 1000
	// 200, 375, 475, and 0, 500, 500
	static int[] SpecialTriplet()
	{
		for(int a = 1; a < 1000; a++)
		{
			for(int b = 1; b < 1000; b++)
			{
				double c = Math.Pow(a * a + b * b, 0.5);
				if(IsInteger(c) && a + b + c == 1000)
				{
					int[] Triplets = {a, b, (int)c};
					return Triplets;
				}
			}
		}
		return new int[0];
	}

	// Returns true if Num is an integer
	static bool IsInteger(double Num)
	{
		return Num == (int)Num;
	}
	// Prints the content of Array to the console
	static void PrintArray(int[] Array)
	{
		foreach(int Num in Array)
		{
			Console.Write(Num + ", ");
		}
		Console.WriteLine();
	}
}