using System;

namespace CurrencyConverter2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pricePerCrystal = 10;

            Console.WriteLine("Добро пожаловть в магазин кристаллов! Курс равен 1:10 ");

            Console.Write("Сколько у вас золота : ");
            int gold = Convert.ToInt32(Console.ReadLine());

            Console.Write("Сколько кристаллов вы хотите приобрести? : ");
            int crystalsQuantity = Convert.ToInt32(Console.ReadLine());

            int crystalsInInventory = crystalsQuantity;
            gold -= crystalsQuantity * pricePerCrystal;

            Console.WriteLine($"В вашем инвентаре {crystalsInInventory} кристаллов и {gold}");
        }
    }
}
