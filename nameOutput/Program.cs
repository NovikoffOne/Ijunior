using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nameOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Переменные
            string userName;
            char userChar;
            int lengthCharLine;
            int charAround = 2;
            bool isWork = true;

            while (isWork)
            {
                // Ввод
                Console.Write("Добрый день, как вас зовут : ");
                userName = Console.ReadLine();

                Console.Write("Введите символ : ");
                userChar = Convert.ToChar(Console.ReadLine());

                // Форматирование строк с символами
                lengthCharLine = (userName.Length) + charAround;

                switch (userName)
                {
                    case "выход":
                        break;
                    default:
                        // Вывод
                        Console.WriteLine(new string(userChar, lengthCharLine));
                        Console.WriteLine(userChar + userName + userChar);
                        Console.WriteLine(new string(userChar, lengthCharLine));
                        Console.WriteLine("Введите \"выход\" для завешения");
                        break;
                }
            }
        }
    }
}
