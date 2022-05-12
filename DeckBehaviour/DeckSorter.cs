using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBehaviour
{
    public abstract class DeckSorter
    {
        public abstract Deck Sort(Deck deck);

    }


    public class SimpleDeckSorter : DeckSorter {

        private static Random rnd = new Random();
        public override Deck Sort(Deck deck)
        {

            deck.SetCards(deck.Cards.OrderBy(r => rnd.Next()).ToList());

            return deck;
        }
    }

    public class HandDeckSorter : DeckSorter
    {

        private int _itterations = 47;
        
        // Сортировка вышла так-себе, как обычно и мешают мои друзья
        private static List<Card> HandSort(List<Card> cards, int i)
        {
            int count = cards.Count;
            int mid = (count / 2) + 1;



            cards.Reverse();

            if(i % 2 == 0)
            {
                cards.Reverse(mid, mid - mid / 4);
                cards.Reverse(0, mid);
                cards.Reverse(mid, mid - mid / 5);
                cards.Reverse(0, mid / 3 );
                cards.Reverse(mid, mid - mid / 2);
                cards.Reverse(0, mid / 7);
                cards.Reverse(0, mid / 8);
            }
            else
            {
                cards.Reverse(0, mid);
                cards.Reverse(0, mid / 8);
                cards.Reverse(mid, mid - 2 );
                cards.Reverse(mid, mid - mid/2);

                cards.Reverse(0, mid / 3);
                cards.Reverse(mid, mid - mid/4); 

                cards.Reverse(mid, mid - mid/8);
                cards.Reverse(0, mid / 8);
            }

            return cards;

        }


        public override Deck Sort(Deck decks)
        {
            List<Card> result = decks.Cards;

            for (int i = 0; i < _itterations; i++)
            {
                
                result = HandSort(result, i);
            }

            decks.SetCards(result);

            return decks;
        }
    }


}
