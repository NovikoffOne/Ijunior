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
            Player[] players = {new Player("filip", 1, 0), new Player("artem", 4, 1) };
            Database database = new Database(players);
            bool isWork = true;

            while (isWork)
            {
                DrawMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        database.Add();
                        break;

                    case "2":
                        database.Ban();
                        break;

                    case "3":
                        database.Unban();
                        break;

                    case "4":
                        database.Delete();
                        break;

                    case "5":
                        database.ShowInfo();
                        break;

                    case "6":
                    case "exit":
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
        Player[] players;

        public Database(Player[] players)
        {
            this.players = players;
        }

        public int CheckInt()
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

        public Player NewPlayer()
        {
            Console.Write("Введите имя : ");
            string name = Console.ReadLine();

            Console.Write("Введите лвл : ");

            int level = CheckInt();

            Console.Write("Введите порядковый номер : ");
            int number = Convert.ToInt32(Console.ReadLine());

            Player player = new Player(name, level, number);

            return player;
        }

        public void Add()
        {
            Player[] tempPlayers = new Player[players.Length + 1];

            for (int i = 0; i < players.Length; i++)
            {
                tempPlayers[i] = players[i];
            }

            players = tempPlayers;
            players[players.Length - 1] = NewPlayer();
        }

        public void Ban()
        {
            Console.Write("Введите номер игрока, которого хотите забанить : ");
            int number = CheckInt();

            foreach (var player in players)
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

        public void Unban()
        {
            Console.Write("Введите номер игрока, которого хотите разбанить : ");
            int number = CheckInt();

            foreach (var player in players)
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

        public void Delete()
        {
            Console.WriteLine("Введите номер игрока, которого хотите удалить");
            int number = CheckInt();

            Player[] tempPlayers = new Player[players.Length - 1];

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Number != number)
                {
                    tempPlayers[i] = players[i];
                }
                else
                {
                    continue;
                }
            }

            players = tempPlayers;
        }

        public void ShowInfo()
        {
            foreach(var player in players)
            {
                Console.WriteLine($"Имя - {player.Name} | Уровень - {player.Level} | Номер - {player.Number} | Бан - {player.Banned}");
            }

            Console.ReadKey();
        }

    }

}
