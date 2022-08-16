using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiplayNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minBorder = 100;
            int maxBorder = 1000;
            int minNumber = 1;
            int maxNumber = 27;
            int number = random.Next(minNumber, maxNumber);
            int countMultiplay = 0;

            for (int numberMultiplay = 0; numberMultiplay <= maxBorder; numberMultiplay += number)
            {
                if (numberMultiplay > minBorder)
                {
                    countMultiplay += 1;
                }
            }

            Console.WriteLine("N равно - " + number);
            Console.WriteLine("Кол-во трехзначных натуральных чисел кратных N, равно - " + countMultiplay);
        }
    }
}
