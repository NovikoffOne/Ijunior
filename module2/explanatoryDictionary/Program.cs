using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace explanatoryDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            Dictionary<string, string> explanatoryDictionary = new Dictionary<string, string>();

            explanatoryDictionary.Add("Абдоминопластика", "Косметическая операция в области живота, формирование талии.");
            explanatoryDictionary.Add("Аберрация", "Искажение наблюдаемых явлений, отход от истинности.");
            explanatoryDictionary.Add("Абстиненция", "Строгое воздержание от секса, алкоголя, табака и т.д. вызванное комплексами.");
            explanatoryDictionary.Add("Балисонг", "Складной нож-бабочка.");
            explanatoryDictionary.Add("Берсерк", " По древнескандинавским легендам воин, отличавшийся неистовством и нечувствительностью к боли.");
            explanatoryDictionary.Add("Биеннале", "Выставка или иное творческое мероприятие, проводимое дважды в год.");
            explanatoryDictionary.Add("Бифуркация", "Естественное раздвоение или искусственное разделение на два потока каких-либо процессов, явлений и т.д.");
            explanatoryDictionary.Add("Жирандоль", "Фигурный подсвечник или фонтан в несколько струй.");

            while (isWork)
            {
                SearchWord(explanatoryDictionary, ref isWork);
            }
        }

        static void SearchWord(Dictionary<string, string> wordDictionary, ref bool isWork)
        {
            string userInput;
            string exit = "exit";

            Console.Write("Введите слово : ");
            userInput = Console.ReadLine();
            
            if (wordDictionary.ContainsKey(userInput))
            {
                foreach (var item in wordDictionary)
                {
                    if (item.Key.ToLower() == userInput.ToLower())
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
            else if (userInput == exit)
            {
                Console.WriteLine("Досвидания!!!");
                Console.ReadKey();
                isWork = false;
            }
            else
            {
                Console.WriteLine("Я не знаю такого слова, попробуйте еще раз...");
            }

            Console.Clear();
        }
    }
}
