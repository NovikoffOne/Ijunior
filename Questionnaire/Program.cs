using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Расскажи немного о себе.");

            Console.Write("Как тебя зовут : ");
            string name = Console.ReadLine();

            Console.Write("Под каким знаком зодиака ты родился/ась : ");
            string zodiacSign = Console.ReadLine();

            Console.Write("Сколько тебе лет : ");
            string age = Console.ReadLine();

            Console.Write("Кем ты работаешь : ");
            string work = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Тебя зовут {name}, твой знак зодиака {zodiacSign}, тебе {age} лет, ты работаешь {work}");
            Console.ReadKey();
        }
    }
}
