using System;

class Factorization
{
	static void Main(string[] args)
	{
		long Num = Int64.Parse(args[0]);
		Console.WriteLine(LargestPrimeFactorOf(Num));
	}

	// Returns the largest prime factor of Num
	static long LargestPrimeFactorOf(long Num)
	{
		long LargestFactor = GetLargestFactor(Num);
		while(LargestFactor != Num)
		{
			Num = LargestFactor;
			LargestFactor = GetLargestFactor(Num);
		}
		return LargestFactor;
	}

	// Returns the largest factor of Num
	// If Num is prime it returns Num
	static long GetLargestFactor(long Num)
	{
		for(long i = 2; i <= (long)Math.Sqrt(Num); i++)
		{
			long Result = IsFactorOf(Num, i);
			if(Result != -1)
			{
				Console.WriteLine(Result + " divides " + Num);
				return Result;
			}
		}
		return Num;
	}
	
	// Returns Num / PossibleFactor if Num is divisible by PossibleFactor
	// Else returns -1
	static long IsFactorOf(long Num, long PossibleFactor)
	{
		long Result = Num / PossibleFactor;
		return Result * PossibleFactor == Num ? Result : -1;
	}
}