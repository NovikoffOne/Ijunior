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
            int number = random.Next(1, 27);
            int numberMultiplay = 0;
            int countMultiplay = 0;

            for (int i = 0; numberMultiplay < 1000; i++)
            {
                numberMultiplay += number;
                
                if (numberMultiplay > 100)
                {
                    countMultiplay += 1;
                }
            }

            Console.WriteLine("N равно - " + number);
            Console.WriteLine("Кол-во трехзначных натуральных чисел кратных N, равно - " + countMultiplay);
        }
    }
}
