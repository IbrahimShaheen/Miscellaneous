using System;
using System.Linq;
using System.Collections.Generic;
using static System.IO.File;
using static System.Console;

// I'm quite happy with how readable this turned out to be, considering how ugly it started out...
class PokerHands
{
    static string CardValues = "23456789TJQKA";
    enum HandRank { HighCard, OnePair, TwoPairs, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush };
    const string GamesFileDir = "D:/Others/Programming/Project Euler/54 - Poker Hands/ProblemData.txt";

    static void Main()
    {
        int Player1Wins = 0;
        foreach (string Game in ReadAllLines(GamesFileDir))
        {
            if (Player1Won(Game)) Player1Wins++;
        }
        WriteLine("Player 1 won {0} games!", Player1Wins);
        WriteLine("Press enter to exit...");
        Read();
    }

    // Returns true if Player1 won Game using draw poker rules
    static bool Player1Won(string Game)
    {
        string[] Hand1 = Game.Substring(0, 14).Split(' ');
        string[] Hand2 = Game.Substring(15).Split(' ');
        int[] Hand1CardCounters = GetCardCounters(Hand1);
        int[] Hand2CardCounters = GetCardCounters(Hand2);

        HandRank Hand1Rank = GetHandRank(Hand1, Hand1CardCounters);
        HandRank Hand2Rank = GetHandRank(Hand2, Hand2CardCounters);
        if (Hand1Rank != Hand2Rank) return Hand1Rank > Hand2Rank;

        int RankCard1 = GetRankCard(Hand1Rank, Hand1CardCounters);
        int RankCard2 = GetRankCard(Hand2Rank, Hand2CardCounters);
        if (RankCard1 != RankCard2) return RankCard1 > RankCard2;

        for (int i = CardValues.Length - 1; i >= 0; i--)
        {
            int CardCounter1 = Hand1CardCounters[i];
            int CardCounter2 = Hand2CardCounters[i];
            if (CardCounter1 != CardCounter2) return CardCounter1 > CardCounter2;
        }
        throw new Exception("No winner found for " + Game);
    }

    // Returns the rank of the given Hand. Populates CardCounters with the number of card of each value
    static HandRank GetHandRank(string[] Hand, int[] CardCounters)
    {
        bool Flush = AreFlush(Hand);
        if (Flush && AreRoyal(Hand)) return HandRank.RoyalFlush;
        bool Straight = AreStraight(Hand);
        if (Flush && Straight) return HandRank.StraightFlush;
        if (CardCounters.Contains(4)) return HandRank.FourOfAKind;
        bool ThreeOfAKind = CardCounters.Contains(3);
        bool OnePair = CardCounters.Contains(2);
        if (ThreeOfAKind && OnePair) return HandRank.FullHouse;
        if (Flush) return HandRank.Flush;
        if (Straight) return HandRank.Straight;
        if (ThreeOfAKind) return HandRank.ThreeOfAKind;
        if (CardCounters.Where(x => x == 2).Count() == 2) return HandRank.TwoPairs;
        if (OnePair) return HandRank.OnePair;
        return HandRank.HighCard;
    }

    // Returns the value of the card in HandCardCounters that makes up HandRank
    static int GetRankCard(HandRank HandRank, int[] HandCardCounters)
    {
        switch (HandRank)
        {
            case HandRank.RoyalFlush: return 12; // Royal flush is Ace-high flush
            case HandRank.FourOfAKind: return Array.IndexOf(HandCardCounters, 4);
            case HandRank.FullHouse:
            case HandRank.ThreeOfAKind: return Array.IndexOf(HandCardCounters, 3);
            case HandRank.TwoPairs: return Array.LastIndexOf(HandCardCounters, 2); // Highest card which is a pair
            case HandRank.OnePair: return Array.IndexOf(HandCardCounters, 2);
            default: return Array.FindLastIndex(HandCardCounters, x => x != 0); // Highest card in the hand
        }
    }

    // Returns how many of each card are in Hand in the form of an array of counters
    static int[] GetCardCounters(string[] Hand)
    {
        int[] CardCounters = new int[CardValues.Length];
        foreach (string Card in Hand)
        {
            CardCounters[CardValues.IndexOf(Card[0])]++;
        }
        return CardCounters;
    }

    // Returns true if Cards are consecutive. Otherwise, returns false.
    // Ex: "8D", "QS", "TD", "9C", "JH" returns true
    static bool AreStraight(string[] Hand)
    {
        SortedSet<int> Cards = new SortedSet<int>();
        foreach (string Card in Hand)
        {
            int CardIndex = CardValues.IndexOf(Card[0]);
            if (Cards.Contains(CardIndex)) return false; // Hand contains duplicates, thus it cannot be straight
            Cards.Add(CardIndex);
        }
        int PrevCardValueIndex = -1;
        foreach (int CardValueIndex in Cards)
        {
            if (PrevCardValueIndex != -1 && PrevCardValueIndex + 1 != CardValueIndex) return false;
            PrevCardValueIndex = CardValueIndex;
        }
        return true;
    }

    // Returns true if the Hand cards are Ten, Jack, Queen, King, and Ace. Otherwise, returns false.
    static bool AreRoyal(string[] Hand)
    {
        HashSet<char> Royals = new HashSet<char>() { 'T', 'J', 'Q', 'K', 'A' }; // The royals are Ten, Jack, Queen, King, and Ace
        foreach (string Card in Hand)
        {
            if (!Royals.Remove(Card[0])) return false;
        }
        return true;
    }

    // Returns true if every card in Hand is of the same suit. Otherwise, returns false.
    static bool AreFlush(string[] Hand)
    {
        char CardSuit = Hand[0][1];
        for (int i = 1; i < Hand.Length; i++)
        {
            if (Hand[i][1] != CardSuit) return false;
        }
        return true;
    }
}