using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magazin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> itemsSalesman = new List<Item> { new Item("Меч"), new Item("Щит"), new Item("Шлем"), new Item("Кираса") };

            Player player = new Player();
            Salesman salesman = new Salesman(itemsSalesman);
            bool isWork = true;

            while (isWork)
            {
                DrawMenu();

                Console.Write("Добро пожаловать! Чего желайте : ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        salesman.Inventory.ShowInventory();
                        break;

                    case "2":
                        player.Inventory.AddItem(salesman.Inventory.GiveItem());
                        break;

                    case "3":
                        salesman.Inventory.AddItem(player.Inventory.GiveItem());
                        break;
                }

                Console.Clear();
            }
        }

        static private void DrawMenu()
        {
            Console.SetCursorPosition(0,20);
            Console.WriteLine
                ("1 - Покажите, что в наличии.\n" +
                "2 - Купить предмет.\n" +
                "3 - Продать предмет.\n" +
                "4 - Выход.");
            Console.SetCursorPosition(0, 0);
        }
    }

    class Salesman
    {
        public Inventory Inventory = new Inventory();

        public Salesman(List<Item> items)
        {
            Inventory = new Inventory(items);
        }
    }

    class Player
    {
        public Inventory Inventory;

        public Player(List<Item> items = null)
        {
            Inventory = new Inventory(new List<Item>());
        }
    }

    class Item
    {
        public string Name { get; private set; }

        public Item(string name = "")
        {
            Name = name;
        }
    }

    class Inventory : Item
    {
        public List<Item> Items = new List<Item>();

        public Inventory(List<Item> items = null)
        {
            Items = items;
        }

        public void ShowInventory()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст.");
            }
            else
            {
                Console.SetCursorPosition(0, 20);

                for (int index = 0; index < Items.Count(); index++)
                {
                    Console.WriteLine($"{index}. - {Items[index].Name}.");
                }

                Console.SetCursorPosition(0, 0);
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public Item GiveItem()
        {
            ShowInventory();

            Console.Write("Введите номер предмета, который хотите получить : ");
            int index =  UserUtils.ReadInt();

            Item givinItem = Items.ElementAt(index);
            Items.RemoveAt(index);

            Console.WriteLine($"Предмет {givinItem} удален из инвентаря.");

            return givinItem;
        }
    }

    static public class UserUtils
    {
        static public int ReadInt()
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
