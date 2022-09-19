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
                const string CommandAddPlayer = "1";
                const string CommandBanPlayer = "2";
                const string CommandUnbanPlayer = "3";
                const string CommandDeletePlayer = "4";
                const string CommandShowInfo = "5";
                const string CommandExit = "6";
                const string CommandExit2 = "exit";

                DrawMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddPlayer:
                        database.AddPlayer();
                        break;

                    case CommandBanPlayer:
                        database.BanPlayer();
                        break;

                    case CommandUnbanPlayer:
                        database.UnbanPlayer();
                        break;

                    case CommandDeletePlayer:
                        database.DeletePlayer();
                        break;

                    case CommandShowInfo:
                        database.ShowInfo();
                        break;

                    case CommandExit:
                    case CommandExit2:
                        Exit(isWork);
                        break;
                }

                Console.Clear();
            }
            
        }

        public static void DrawMenu()
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

        public static void Exit(bool isWork)
        {
            Console.WriteLine("Прощайте!");
            Console.ReadKey();
            isWork = false;
        }
    }

    static class UserUtils
    {
        public static int ReadInt()
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
        public bool IsBanned { get; private set; }

        public Player(string name, int level, int number, bool banned = false)
        {
            Name = name;
            Level = level;
            Number = number;
            IsBanned = banned;
        }

        public void Ban()
        {
            if (IsBanned == false)
            {
                IsBanned = true;
                Console.WriteLine("Игрок забанен.");
            }
            else
            {
                Console.WriteLine("Игрок уже забанен, попробуйте еще раз.");
            }  
        }

        public void Unban()
        {
            if (IsBanned == true)
            {
                IsBanned = false;
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
        private List<Player> _players;

        public Database()
        {
            _players =  new List<Player>();
        }

        private Player CreatePlayer()
        {
            Console.Write("Введите имя : ");
            string name = Console.ReadLine();

            Console.Write("Введите лвл : ");

            int level = UserUtils.ReadInt();

            Console.Write("Введите порядковый номер : ");
            int number = UserUtils.ReadInt();
            
            Player player = new Player(name, level, number);

            return player;
        }

        public void AddPlayer()
        {
            _players.Add(CreatePlayer());
        }

        public void BanPlayer()
        {
            Console.Write("Введите номер игрока, которого хотите забанить : ");
            int number = UserUtils.ReadInt();

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
            int number = UserUtils.ReadInt();

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
            int number = UserUtils.ReadInt();

            _players.RemoveAt(number);
        }

        public void ShowInfo()
        {
            foreach(var player in _players)
            {
                Console.WriteLine($"Имя - {player.Name} | Уровень - {player.Level} | Номер - {player.Number} | Бан - {player.IsBanned}");
            }

            Console.ReadKey();
        }

    }

}
