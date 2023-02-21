using System;

namespace CurrencyConverter2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int crystalPrice = 10;

            Console.WriteLine("Добро пожаловть в магазин кристаллов! Курс равен 1:10 ");

            Console.Write("Сколько у вас золота : ");
            int gold = Convert.ToInt32(Console.ReadLine());

            Console.Write("Сколько кристаллов вы хотите приобрести? : ");
            int crystals = Convert.ToInt32(Console.ReadLine());

            gold -= crystals * crystalPrice;

            Console.WriteLine($"В вашем инвентаре {crystals} кристаллов и {gold}");
        }
    }
}
