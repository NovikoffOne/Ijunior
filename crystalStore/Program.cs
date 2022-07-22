using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crystalStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int courseOfCrystals = 10;

            Console.WriteLine("Добро пожаловть в магазин кристаллов! Курс равен 1:10 ");

            Console.Write("Сколько у вас золота : ");
            int goldInInventory = Convert.ToInt32(Console.ReadLine());

            Console.Write("Сколько кристаллов вы хотите приобрести? : ");
            int purchasedCrystals = Convert.ToInt32(Console.ReadLine());

            int crystalsInInventory = purchasedCrystals; 
            goldInInventory -= (purchasedCrystals * courseOfCrystals);

            Console.WriteLine($"В вашем инвентаре {crystalsInInventory} кристаллов и {goldInInventory}");
        }
    }
}
