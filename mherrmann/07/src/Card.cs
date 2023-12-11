using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07;

public enum Card : byte { Joker = 1, Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

public enum Category : byte { HighCard = 1, OnePair, TwoPair, ThreeOfAKind, FullHouse, FourOfAKind, FiveOfAKind }

public struct Hand
{
    public string Encoded;
    public Card[] Cards;
    public Category Category;
    public int Bid;

    public Hand(string encoded, int bid, bool useJoker = false)
    {
        Encoded = encoded;
        Bid = bid;
        Cards = CardParser.ParseEncodedHandString(encoded, useJoker);
        Category = CardParser.ParseCardCategory(Cards);
    }

    public static int Compare(Hand a, Hand b)
    {
        int firstCmp = a.Category.CompareTo(b.Category);
        if (firstCmp != 0) return firstCmp;

        int secondCmp;
        for (int i = 0; i < a.Cards.Length; i++)
        {
            secondCmp = a.Cards[i].CompareTo(b.Cards[i]);
            if (secondCmp != 0) return secondCmp;
        }

        return 0;
    }
}

public class Game
{
    public List<Hand> Hands;

    public Game(List<Hand> hands)
    {
        Hands = hands;
        Hands.Sort(Hand.Compare);
    }

    public int GetRank(Hand hand) => Hands.IndexOf(hand) + 1;

    public int GetWinning(Hand hand) => hand.Bid * GetRank(hand);

    public int GetTotalWinnings() => Hands
        .Select(GetWinning)
        .Aggregate((a, b) => a + b);
}