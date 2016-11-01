using System;
using System.Collections.Generic;

class SummationOfPrimes
{
	static void Main()
	{
		List<int> Primes = new List<int>();
		Primes.Add(2); // First prime
		for(int i = 3; i < 2 * 1000 * 1000; i += 2)
		{
			if(IsNewPrime(i, Primes))
			{
				Primes.Add(i);
			}
			if(i % 10001 == 0) Console.WriteLine(i);
		}
		PrintSum(Primes);
	}

	// Returns true if PossiblePrime is not divisible by any int in Primes
	static bool IsNewPrime(int PossiblePrime, List<int> Primes)
	{
		foreach(int Prime in Primes)
		{
			if(IsDivisibleBy(PossiblePrime, Prime))
			{
				return false;
			}
		}
		return true;
	}

	// Returns true if Dividend is divisible by Divisor
	static bool IsDivisibleBy(int Dividend, int Divisor)
	{
		return Dividend % Divisor == 0;
	}

	// Prints the sum of IntList
	static void PrintSum(List<int> IntList)
	{
		long Sum = 0;
		foreach(int Num in IntList)
		{
			Sum += Num;
		}
		Console.WriteLine("Sum is " + Sum);
	}
}