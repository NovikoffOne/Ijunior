using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopPlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            bool isWork = true;

            while (isWork)
            {
                const string CommandShowTopByRating = "1";
                const string CommandShowTopByLevel = "2";

                Console.Write($"{CommandShowTopByRating} - Показать топ по рейтингу\n" +
                    $"{CommandShowTopByLevel} - Показать топ по уровню\n" +
                    $"Любую другую чтобы выйти" +
                    $"\nВыберите пункт : ");
                string userInput = Console.ReadLine();

                if(userInput == CommandShowTopByRating)
                {
                    server.ShowTopPlayerByRating();
                }
                else if(userInput == CommandShowTopByLevel)
                {
                    server.ShowTopPlayerByLevel();
                }
                else
                {
                    isWork = false;
                }
            }
        }
    }

    class Server
    {
        private List<Player> _players;
        private int _numberOfTopPlayers = 3;

        public Server()
        {
            _players = new List<Player>()
            {
                new Player("Fyry", 150, 30),
                new Player("Ahpers", 808, 80),
                new Player("Kleimor", 313, 45),
                new Player("Setch", 686, 52),
                new Player("Kalevin", 878, 37),
                new Player("Rico", 988, 68),
                new Player("Ling", 799, 87),
                new Player("Asterio", 511, 44),
                new Player("Kapher", 545, 65),
                new Player("Inoshe", 654, 76)
            };
        }

        public void ShowTopPlayerByRating()
        {
            var topPlayers = _players.OrderByDescending(player => player.Rating).Take(_numberOfTopPlayers);

            ShowPlayersTop(topPlayers.ToList());
        }

        public void ShowTopPlayerByLevel()
        {
            var topPlayers = _players.OrderByDescending(player => player.Level).Take(_numberOfTopPlayers);

            ShowPlayersTop(topPlayers.ToList());
        }

        private void ShowPlayersTop(List<Player> players)
        {
            foreach (var player in players)
            {
                player.ShowInfo();
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Rating { get; private set; }
        public int Level { get; private set; }

        public Player (string name, int rating, int level)
        {
            Name = name;
            Rating = rating;
            Level = level;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} | Рейтинг : {Rating} | Уровень : {Level}");
        }
    }
}
