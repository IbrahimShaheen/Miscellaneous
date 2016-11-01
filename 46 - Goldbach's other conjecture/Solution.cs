using static System.Console;

class GoldbachsWrongConjecture
{
    static void Main()
    {
        ExtendablePrimesList Primes = new ExtendablePrimesList();
        TwiceSquaresSeries TwiceSquares = new TwiceSquaresSeries();
        int OddComposite = 9; // First odd composite

        bool CounterExampleFound = false;
        while (!CounterExampleFound)
        {
            if (!Primes.Contains(OddComposite)) // Make sure it's a composite
            {
                bool FoundAWay = false;
                foreach (int Prime in Primes.GetPrimes(OddComposite))
                {
                    if(TwiceSquares.InSeries(OddComposite - Prime))
                    {
                        FoundAWay = true;
                        break;
                    }
                }
                if(!FoundAWay)
                {
                    CounterExampleFound = true;
                    WriteLine(OddComposite);
                }
            }
            OddComposite += 2;
        }
        Write("Press enter to exit...");
        Read();
    }
}