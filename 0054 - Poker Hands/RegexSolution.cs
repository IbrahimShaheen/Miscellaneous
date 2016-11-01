// I think trying to implement the GetHandRank function using Regex might be worse
// I might get back to this anyways...
/*
using System.Text.RegularExpressions;
using static System.Console;

class RegexTesting
{

    enum HandRank { RoyalFlush, StraightFlush, FourOfAKind, FullHouse, Flush, Straight, ThreeOfAKind, TwoPairs, OnePair, HighCard };

    static void Main()
    {
        string Hand = "5H 5H 2H 2H 2H";
        GetHandRank(Hand);

        Read();
    }

    // Returns the rank of the given Hand.
    static void GetHandRank(string Hand)
    {
        bool Flush = new Regex(@".(.)\s(.\1\s?){4}").Match(Hand).Success;
        bool FourOfAKind = new Regex(@"(.).\s(.*\1.*){3}").Match(Hand).Success;
        bool Consecutive = new Regex(@"");
    }
}
*/
