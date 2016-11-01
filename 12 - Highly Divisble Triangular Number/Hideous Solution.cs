using System;

class TriangularNumbers
{
	static void Main()
	{
		long TriangularNumber = 0;
		int MaxDivisors = 0;
		int i = 0;
		while(MaxDivisors <= 250)
		{
			i++;
			TriangularNumber += i;
			int Divisors = 0;
			int SqrtT = (int) Math.Sqrt(TriangularNumber) + 1;
			for(int j = 1; j < SqrtT; j++)
			{
				if (IsDivisibleBy(TriangularNumber, j))
				{
					Divisors++;
				}
			}
			Console.WriteLine("T_{0} is {1}, it has {2} divisors",
				i, TriangularNumber, Divisors);
			if(Divisors > MaxDivisors) MaxDivisors = Divisors;
		}
		
	}

	// Returns true if Num is divisible by Divisor
	static bool IsDivisibleBy(long Num, int Divisor)
	{
		return Num % Divisor == 0;
	}
}
/*
For an arithmetic series starting at "a" while adding "d" for "n" times.
The ith term is a + di.
The first and last term. Second and second to last term are all (2a + ni)
They happen n/2 times
*/