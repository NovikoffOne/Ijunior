using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Переменные
            string password = "qwer123";
            string userInput;
            int countAttempt = 3;

            // Основной цикл
            for (int i = 0; i < countAttempt; i++)
            {
                Console.WriteLine("Введите пароль : ");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("ты молодец");
                    break;
                }
                else
                {
                    Console.WriteLine($"неверный пароль, у вас осталось {(countAttempt - 1) - i} попыток");
                }
            }
        }
    }
}
