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
            CardDeck Deck = new CardDeck();
            Player player = new Player(Deck);

            while (true)
            {
                const string More = "1";
                const string OpenUp = "2";

                DrawMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case More:
                        player.TakeACard();
                        break;

                    case OpenUp:
                        player.OpenUp();
                        break;
                }

                Console.Clear();
            }
        }

        static void DrawMenu()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("1 - взять карту!\n" +
                "2 - вскрыться!");
            Console.SetCursorPosition(0, 0);
        }
    }



    class Card
    {
        protected string[] Values = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "qeen", "king", "ace"};
        protected string[] Suits = {"crosses", "diamonds", "hearts", "piques"};
        public string Value { get; private set; }
        public string Suit { get; private set; }

        public Card(string suit=null, string value=null)
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
        private Queue<Card> Deck = new Queue<Card>();

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
                Deck.Enqueue(card);
            }
        }

        public Card TakeCard()
        {
           return Deck.Dequeue();
        }
    }

    class Player
    {
        private List<Card> CardsInHand= new List<Card>();
        private CardDeck Deck;

        public Player(CardDeck deck)
        {
            Deck = deck;
        }

        public void TakeACard()
        {
           CardsInHand.Add(Deck.TakeCard());
        }

        public void OpenUp()
        {
            foreach (var card in CardsInHand)
            {
                Console.WriteLine($"{card.Value} - {card.Suit}");
            }

            Console.ReadKey();
        }
    }
}
