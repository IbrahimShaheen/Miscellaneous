using System;

class SummationOfPrimes
{
	static void Main()
	{
		bool[] Primes = InitialPrimes();
		for(int i = 2; i < Primes.Length; i++)
		{
			if(Primes[i])
			{
				SieveCompositesOf(i, Primes);
			}
		}
		PrintSum(Primes);
	}

	// Returns a bool[] where all indices are true except 0 and 1
	static bool[] InitialPrimes()
	{
		bool[] Primes = new bool[2 * 1000 * 1000];
		for(int i = 2; i < Primes.Length; i++)
		{
			Primes[i] = true;
		}
		return Primes;
	}

	// Removes numbers in Primes which are divisible by Factor
	// Removes a number by making the value of the index false
	static void SieveCompositesOf(int Factor, bool[] Primes)
	{
		for(int i = Factor * 2; i < Primes.Length; i += Factor)
		{
			Primes[i] = false;
		}
	}

	// Prints the sum of the indices of the true values in IntList
	static void PrintSum(bool[] IntList)
	{
		long Sum = 0;
		for(int i = 0; i < IntList.Length; i++)
		{
			if(IntList[i])
			{
				Sum += i;
			}
		}
		Console.WriteLine("Sum is " + Sum);
	}
}