using System;

class SumsOfTypes
{
	static void Main()
	{
		int SumOfSquares = SumOfSquaresUntil(100);
		int SquareOfSum = SquareOfSumUntil(100);
		Console.WriteLine(SquareOfSum - SumOfSquares);
	}
	
	// Returns the sum of the squares from 1 to Num
	static int SumOfSquaresUntil(int Num)
	{
		int Sum = 0;
		for(int i = 1; i <= Num; i++)
		{
			Sum += i * i;
		}
		return Sum;
	}

	// Returns the square of the sum from 1 to Num
	static int SquareOfSumUntil(int Num)
	{
		int Sum = 0;
		for(int i = 1; i <= Num; i++)
		{
			Sum += i;
		}
		return Sum * Sum;
	}
}