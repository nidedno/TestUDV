using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBehaviour
{
    // класс карты //
    public class Card
    {
        public CardRank Rank { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardSuit cardSuit, CardRank cardRank)
        {
            Suit = cardSuit;
            Rank = cardRank;
        }


        public override string ToString()
        {
            return $"{ Suit.ToString() } - {Rank.ToString()}";
        }
    }

}
