using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guessTheWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = " ";
            string exit = "exit";
            string hiddenWord = "программирование"

            Console.WriteLine("Давай сыграем в игру!!!\nЯ загадал слово.\nНачинается на \'п\' заканчивается на \'e\'!");
            
            while (word != exit)
            {
                word = Console.ReadLine();
                
                if (word == hiddenWord)
                {
                    Console.WriteLine("Ура, ты угадал!!!");
                }
                else
                {
                    Console.WriteLine("Нет! Попробуй еще раз.\nДля выхода введите \'exit\'...'");
                }
            }
        }
    }
}
