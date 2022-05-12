using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckBehaviour
{

    public class DecksService
    {
        public List<Deck> decks { get; private set; } = new List<Deck>();

        public DeckSorter deckSorter { get; private set; }

       
        public DecksService(int sortType=0)
        {
            switch (sortType)
            {
                case 0:
                    deckSorter = new SimpleDeckSorter();
                    break;
                case 1:
                    deckSorter = new HandDeckSorter();
                    break;

                default:
                    deckSorter = new SimpleDeckSorter();
                    break;
            }

        }
        // Создает именованную колоду //
        public void CreateDeck(string name)
        {
            if (string.IsNullOrEmpty(name)){
                return;
            }

            string[] existDecks = GetDecksNames();

            if (existDecks != null && existDecks.Contains(name))
            {
                return;
            }

            decks.Add(new Deck(name));
        }

        // Удаляет колоду по имени //
        public void DeleteDeck(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            if (decks.Count == 0)
            {
                return;
            }

            decks = decks.Where(deck => deck.Name != name).ToList();
        }

        // Возвращает имена всех колод //
        public string[] GetDecksNames()
        {
            if (decks.Count == 0)
            {
                return null;
            }

            List<string> _deckNames = new List<string>();

            foreach (Deck deck in decks)
            {
                _deckNames.Add(deck.Name);
            }


            return _deckNames.ToArray();

        }

        // Сортрирует колоду и возвращает её//
        public Deck ShuffleDeck(Deck deck)
        {
            return deckSorter.Sort(deck);
        }

        // Возвращает колоду по имени либо null //
        public Deck GetDeckByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            if (decks.Count == 0)
            {
                return null;
            }

            return decks.Where(deck => deck.Name == name).FirstOrDefault();
        }

      
    }

    // примечание //
    /*
        По поводу сохранения в БД
        Каждая колода будет сохраняться в JSON формате, а именно таком:

        {
            "name":"deck_name",
            "hearts": ["0","1" ... ],
            "diamonds": ["0","3" ... ],
            "peaks": ["0","1" ... ],
            "clubs": ["0","1" ... ],
        }

        где числа это карты с их рангом у определенной масти;


     */

}
