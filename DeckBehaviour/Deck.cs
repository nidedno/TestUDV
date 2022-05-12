using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBehaviour
{
    // класс колоды //
    public class Deck
    {
        public string Name { get; private set; }
        public List<Card> Cards { get; private set; } = new List<Card>();


        public Deck(string deckName)
        {
            Name = deckName;
            List<Card> _cards = new List<Card>();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    _cards.Add(new Card(suit, rank));
                }
            }

            Cards = _cards;
        }

        // Есть возможность задать свои карты
        public void SetCards(List<Card> cards)
        {
            if(cards == null)
            {
                return;
            }
                

            this.Cards = cards;
        }

    }
}
