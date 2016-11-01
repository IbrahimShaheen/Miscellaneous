using System;

class MultiplesCounter
{
	static void Main()
	{
		int Sum = 0;
		for(int i = 1; i < 1000; i++)
		{
			if(IsMultipleOf(i, 3) || IsMultipleOf(i, 5))
			{
				Sum += i;
			}
		}
		Console.WriteLine(Sum);
	}

	// Returns whether or not Num is a multiple of Unit
	static bool IsMultipleOf(int Num, int Unit)
	{
		return Num % Unit == 0;
	}
}