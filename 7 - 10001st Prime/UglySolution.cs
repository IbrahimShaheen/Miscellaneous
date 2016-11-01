using System;

class Primes
{
	static void Main()
	{
		int[] Primes = new int[10001];
		PopulateWithPrimes(Primes);
		Print(Primes);
	}

	// Populates all elements of Primes with prime numbers
	static void PopulateWithPrimes(int[] Primes)
	{
		int Num = 2; // First prime
		for(int i = 0; i < Primes.Length; i++)
		{
			for(int j = 0; j < i; j++)
			{
				if(IsDivisibleBy(Num, Primes[j]))
				{
					Num++;
					j = -1; // Restart to check all primes
				}
			}
			Primes[i] = Num;
			Num++;
		}
	}

	// Check to see if Dividend is divisible by Divisor
	static bool IsDivisibleBy(int Dividend, int Divisor)
	{
		return Dividend / Divisor * Divisor == Dividend;
	}

	// Prints the elements in IntArray to the console
	static void Print(int[] IntArray)
	{
		if(IntArray == null)
		{
			Console.WriteLine("Array is null.");
		}	
		else if(IntArray.Length == 0)
		{
			Console.WriteLine("Array is Empty.");
		}
		else
		{
			Console.Write(IntArray[0]);
			for(int i = 1; i < IntArray.Length; i++)
			{
				Console.Write(", " + IntArray[i]);
			}
			Console.WriteLine("");
		}
	}
}