using System;
using System.Configuration;
using DeckBehaviour;

namespace DeckConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // загружаем из конфига
            var typeOfSorting = ConfigurationManager.AppSettings["sortType"];
            int valueSort;
            if (!int.TryParse(typeOfSorting, out valueSort))
            {
                valueSort = 0;
            }
           

            

            // создаем сервис
            var service = new DecksService(valueSort);

            // добавляем колоды
            service.CreateDeck("deck1");
            service.CreateDeck("deck1");
            service.CreateDeck("deck2");
            service.CreateDeck("123123");
            service.CreateDeck("dda");
            service.CreateDeck("asddad");
             
            // выводим колоды списком
            foreach (var deckName in service.GetDecksNames())
            {
                Console.WriteLine(deckName);
            }

            // удаляем колоду
            service.DeleteDeck("deck2");

            Console.WriteLine("================================");

            // выводим все имена
            foreach (var deckName in service.GetDecksNames())
            {
                Console.WriteLine(deckName);
            }

           
            // ищем колоду
            var deck = service.GetDeckByName("dda");
            Console.WriteLine("================================");

            // выводим карты колоды
            foreach (var item in deck.Cards)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(deck.Cards.Count);


            // перемешиваем колоду
            var d = service.ShuffleDeck(deck);

            Console.WriteLine("================================");

            foreach (var item in d.Cards)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(d.Cards.Count);



            Console.WriteLine(service.deckSorter);

            Console.ReadLine();







        }
    }
}
