using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programActivate = true;
            // Balance
            float rub = 5000;
            float usd = 1000;
            float eur = 300;

            // Exchange Rates
            float rubInEur = 0.017f;
            float rubInUsd = 0.013f;
            float eurInRub = 80;
            float eurInUsd = 1.2f;
            float usdInRub = 65;
            float usdInEur = 0.9f;

            // Аuxiliary variables
            float convertibleСurrency;
            string userInput;

            Console.WriteLine("Приветсвтуем вас на бирже валют!");

            while (programActivate)
            {
                Console.WriteLine($"\nВаш баланс составляет :\n| {rub} рублей | {usd} долларов | {eur} евро |");
                Console.WriteLine("\nВыберите опцию : \n1. Обменять рубли на евро \n2. Обменять рубли на доллары\n" +
                    "3. Обменять евро на рубли\n4. Обменять евро на доллры\n5. Обменять доллары на рубли\n" +
                    "6. Обменять доллары на евро\n7. ВЫХОД\n");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.Write("Сколько рублей вы хотите обменять на евро : ");
                    convertibleСurrency = Convert.ToSingle(Console.ReadLine());

                    eur += convertibleСurrency * rubInEur;
                    rub -= convertibleСurrency;
                }
                else if (userInput == "2")
                {
                    Console.Write("Сколько рублей вы хотите обменять на доллары : ");
                    convertibleСurrency = Convert.ToSingle(Console.ReadLine());

                    usd += convertibleСurrency * rubInUsd;
                    rub -= convertibleСurrency;
                }
                else if (userInput == "3")
                {
                    Console.Write("Сколько евро вы хотите обменять на рубли : ");
                    convertibleСurrency = Convert.ToSingle(Console.ReadLine());

                    rub += convertibleСurrency * eurInRub;
                    eur -= convertibleСurrency;
                }
                else if (userInput == "4")
                {
                    Console.Write("Сколько евро вы хотите обменять на доллары : ");
                    convertibleСurrency = Convert.ToSingle(Console.ReadLine());

                    usd += convertibleСurrency * eurInUsd;
                    eur -= convertibleСurrency;
                }
                else if (userInput == "5")
                {
                    Console.Write("Сколько долларов вы хотите обменять на рубли : ");
                    convertibleСurrency = Convert.ToSingle(Console.ReadLine());

                    rub += convertibleСurrency * usdInRub;
                    usd -= convertibleСurrency;
                }
                else if (userInput == "6")
                {
                    Console.Write("Сколько долларов вы хотите обменять на евро : ");
                    convertibleСurrency = Convert.ToSingle(Console.ReadLine());

                    eur += convertibleСurrency * usdInEur;
                    usd -= convertibleСurrency;
                }
                else if (userInput == "7")
                {
                    programActivate = false;
                }
                else
                {
                    Console.WriteLine("Такого пункта не существует, попробуйте снова");
                }
            }
        }
    }
}
