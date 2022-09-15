using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playerDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            bool isWork = true;

            while (isWork)
            {
                const string AddPlayers = "1";
                const string BanPlayers = "2";
                const string UnbanPlayers = "3";
                const string DeletePlayers = "4";
                const string ShowInfo = "5";
                const string ExitProgramm = "6";
                const string ExitProgramm2 = "exit";

                DrawMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddPlayers:
                        database.AddPlayer();
                        break;

                    case BanPlayers:
                        database.BanPlayer();
                        break;

                    case UnbanPlayers:
                        database.UnbanPlayer();
                        break;

                    case DeletePlayers:
                        database.DeletePlayer();
                        break;

                    case ShowInfo:
                        database.ShowInfo();
                        break;

                    case ExitProgramm:
                    case ExitProgramm2:
                        Exit(isWork);
                        break;
                }

                Console.Clear();
            }
            
        }

        static void DrawMenu()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Выберите пункт :\n" +
                "1 - Добавить игрока.\n" +
                "2 - Забанить игрока.\n" +
                "3 - Разбанить игрока.\n" +
                "4 - Удалить игрока.\n" +
                "5 - Вывести всех игроков\n" +
                "Введите '6' или 'exit' чтобы выйти!");

            Console.SetCursorPosition(0, 0);
        }

        static void Exit(bool isWork)
        {
            Console.WriteLine("Прощайте!");
            Console.ReadKey();
            isWork = false;
        }
    }

    static class UserUtils
    {
        public static int CheckInt()
        {
            if ((int.TryParse(Console.ReadLine(), out int number)) == false)
            {
                Console.WriteLine("В следующий раз, попробуйте число!");
                return number;
            }
            else
            {
                return number;
            }
        }
    }

    class Player
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool Banned { get; private set; }

        public Player(string name, int level, int number, bool banned = false)
        {
            Name = name;
            Level = level;
            Number = number;
            Banned = banned;
        }

        public void Ban()
        {
            if (Banned == false)
            {
                Banned = true;
                Console.WriteLine("Игрок забанен.");
            }
            else
            {
                Console.WriteLine("Игрок уже забанен, попробуйте еще раз.");
            }  
        }

        public void Unban()
        {
            if (Banned == true)
            {
                Banned = false;
                Console.WriteLine("Игрок разбанен.");
            }
            else
            {
                Console.WriteLine("Игрок не был забанен, попробуйте еще раз.");
            }
        }
    }

    class Database
    {
        private Player[] _players;

        public Database()
        {
            _players =  new Player[] {};
        }

        public Player CreatePlayer()
        {
            Console.Write("Введите имя : ");
            string name = Console.ReadLine();

            Console.Write("Введите лвл : ");

            int level = UserUtils.CheckInt();

            Console.Write("Введите порядковый номер : ");
            int number = UserUtils.CheckInt();
            
            Player player = new Player(name, level, number);

            return player;
        }

        public void AddPlayer()
        {
            Player[] tempPlayers = new Player[_players.Length + 1];

            for (int i = 0; i < _players.Length; i++)
            {
                tempPlayers[i] = _players[i];
            }

            _players = tempPlayers;
            _players[_players.Length - 1] = CreatePlayer();
        }

        public void BanPlayer()
        {
            Console.Write("Введите номер игрока, которого хотите забанить : ");
            int number = UserUtils.CheckInt();

            foreach (var player in _players)
            {
                if (player.Number == number)
                {
                    player.Ban();
                }
                else
                {
                    Console.WriteLine("Игрока с таким индефикатором не существует!");
                }
            }
        }

        public void UnbanPlayer()
        {
            Console.Write("Введите номер игрока, которого хотите разбанить : ");
            int number = UserUtils.CheckInt();

            foreach (var player in _players)
            {
                if (player.Number == number)
                {
                    player.Unban();
                }
                else
                {
                    Console.WriteLine("Игрока с таким индефикатором не существует!");
                }
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Введите номер игрока, которого хотите удалить");
            int number = UserUtils.CheckInt();

            Player[] tempPlayers = new Player[_players.Length - 1];

            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i].Number != number)
                {
                    tempPlayers[i] = _players[i];
                }
                else
                {
                    continue;
                }
            }

            _players = tempPlayers;
        }

        public void ShowInfo()
        {
            foreach(var player in _players)
            {
                Console.WriteLine($"Имя - {player.Name} | Уровень - {player.Level} | Номер - {player.Number} | Бан - {player.Banned}");
            }

            Console.ReadKey();
        }

    }

}
