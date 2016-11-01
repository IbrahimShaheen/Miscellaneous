using System;

class EvenFibonacciCounter
{
	static void Main()
	{
		int FibNum = 2;
		int PrevFibNum = 1;
		int Sum = 0;
		while(FibNum <= 4 * 1000 * 1000)
		{
			if(FibNum % 2 == 0)
			{
				Sum += FibNum;
			}
			int Temp = FibNum;
			FibNum = PrevFibNum + FibNum;
			PrevFibNum = Temp;
		}
		Console.WriteLine(Sum);
	}
}