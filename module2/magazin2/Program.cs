using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazin2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Salesman salesman = new Salesman();
            bool isWork = true;

            while (isWork)
            {
                const string CommandShowItem = "1";
                const string CommandBuyItem = "2";
                const string CommandSellItem = "3";
                const string CommandExit = "4";

                DrawMenu(CommandShowItem, CommandBuyItem, CommandSellItem, CommandExit);

                Console.Write("Добро пожаловать! Чего желайте : ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowItem:
                        salesman.ShowItem();
                        break;

                    case CommandBuyItem:
                        player.BuyItem(salesman.SellItem());
                        break;

                    case CommandSellItem:
                        salesman.BuyItem(player.SellItem());
                        break;

                    case CommandExit:
                        Exit(isWork);
                        break;
                }

                Console.Clear();
            }
        }

        private static void DrawMenu(string showItem, string buyItem, string sellItem, string exit)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine
                ($"{showItem} - Покажите, что в наличии.\n" +
                $"{buyItem} - Купить предмет.\n" +
                $"{sellItem} - Продать предмет.\n" +
                $"{exit} - Выход.");
            Console.SetCursorPosition(0, 0);
        }

        private static void Exit(bool isWork)
        {
            Console.WriteLine("До свиданья!");
            Console.ReadKey();

            isWork = false;
        }
    }

    class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Item(string name = "", int price = 0)
        {
            Name = name;
            Price = price;
        }
    }

    class Player
    {
        private List<Item> _inventory;

        public Player()
        {
            _inventory = new List<Item>();
        }

        public void BuyItem(Item item)
        {
            _inventory.Add(item);
        }

        public Item SellItem()
        {
            Item item;

            Console.Write("Введите номер предмета, который хотите продать : ");
            int index = UserUtils.ReadInt();

            if (_inventory.Contains(_inventory[index]))
            {
                item = _inventory.ElementAt(index);
                return item;
            }
            else
            {
                Console.WriteLine("Такого предмета нет");
            }

            return item = null;
        }
    }

    class Salesman
    {
        private List<Item> _inventory;

        public Salesman()
        {
            _inventory = new List<Item> { new Item("Меч", 3), new Item("Щит", 10), new Item("Шлем", 8), new Item("Кираса", 15) };
        }

        public Item SellItem()
        {
            ShowItem();

            Item item;

            Console.WriteLine("Выберите предмет из списка : ");
            int index = UserUtils.ReadInt();

            if (_inventory.Contains(_inventory[index]))
            {
                item = _inventory.ElementAt(index);
                _inventory.RemoveAt(index);

                return item;
            }
            else
            {
                Console.WriteLine("Такого предмета нет");
            }

            return item = null;
        }

        public void BuyItem(Item item)
        {
            _inventory.Add(item);
        }

        public void ShowItem()
        {
            int index = 0;

            foreach (var item in _inventory)
            {
                Console.WriteLine($"{index}. {item.Name} - {item.Price}");
                index++;
            }

            Console.ReadKey();
        }
    }

    static public class UserUtils
    {
        public static int ReadInt()
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int number);

            if (isNumber)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз!");
                return number = 0;
            }
        }
    }
}
