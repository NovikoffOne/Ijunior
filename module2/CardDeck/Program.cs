using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardDeck deck = new CardDeck();
            Player player = new Player(deck);
            bool isWork = true;

            while (isWork)
            {
                const string CommandTakeCard = "1";
                const string CommandShowCards = "2";
                const string CommandExit = "exit";

                DrawMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandTakeCard:
                        player.TakeCard();
                        break;

                    case CommandShowCards:
                        player.ShowCard();
                        break;

                    case CommandExit:
                        Exit(ref isWork);
                        break;
                }

                Console.Clear();
            }
        }

        private static void DrawMenu()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine
                ("1 - взять карту!\n" +
                "2 - вскрыться!");
            Console.SetCursorPosition(0, 0);
        }

        private static void Exit(ref bool isWork)
        {
            isWork = false;
        }
    }

    class Card
    {
        public string Value { get; private set; }
        public string Suit { get; private set; }
        protected string[] Values = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "qeen", "king", "ace"};
        protected string[] Suits = {"crosses", "diamonds", "hearts", "piques"};

        public Card(string suit = null, string value = null)
        {
            if (Suits.Contains(suit))
            {
                Suit = suit;
            }
            if (Values.Contains(value))
            {
                Value = value;
            }
        }
    }

    class CardDeck:Card
    {
        private List<Card> _deck;
        private Random _random = new Random();
        private Queue<Card> _mixedDeck = new Queue<Card>();

        public CardDeck()
        {
            _deck = new List<Card>();

            for (int i = 0; i < Suits.Length; i++)
            {
                for (int j = 0; j < Values.Length; j++)
                {
                    _deck.Add(new Card(Suits[i], Values[j]));
                }
            }

            ShuffleTheDeck();
            CreateDeck();
        }

        public Card GiveCard()
        {
           var card = _mixedDeck.Dequeue();
           return card;
        }

        private void ShuffleTheDeck()
        {
            for (int i = 0; i < _deck.Count(); i++)
            {
                int index = _random.Next(0, _deck.Count() - 1);
                Card temp;
                temp = _deck[index];
                _deck[index] = _deck[i];
                _deck[i] = temp;
            }
        }

        private void CreateDeck()
        {
            foreach (var card in _deck)
            {
                _mixedDeck.Enqueue(card);
            }
        }
    }

    class Player
    {
        private List<Card> _cardsInHand = new List<Card>();
        private CardDeck _deck;

        public Player(CardDeck deck)
        {
            _deck = deck;
        }

        public void TakeCard()
        {
           _cardsInHand.Add(_deck.GiveCard());
        }

        public void ShowCard()
        {
            foreach (var card in _cardsInHand)
            {
                Console.WriteLine($"{card.Value} - {card.Suit}");
            }

            Console.ReadKey();
        }
    }
}
