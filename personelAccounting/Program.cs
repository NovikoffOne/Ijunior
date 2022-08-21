using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fullNameArray = new string[] {"Новиков Иван Олегович", "Назаренко Илья Александрович", "Солодяникна Елаена Егоровна"};
            string[] jobTitleArray = new string[] {"Фрезировщик", "Менеджер", "Директор"};

            int index = 0;
            bool isWork = true;
            string userInput;
            string foundDossier;

            while (isWork)
            {
                DrawMenu();
                Console.Write("Выберите пункт : ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Write("Введите ФИО : ");
                        string fullName = Console.ReadLine();
                        Console.Write("Введите должность : ");
                        string jobTitle = Console.ReadLine();

                        fullNameArray = AddDossier(fullNameArray, fullName);
                        jobTitleArray = AddDossier(jobTitleArray, jobTitle);
                        break;

                    case "2":
                        DrawDossier(fullNameArray, jobTitleArray);
                        break;

                    case "3":
                        Console.Write("Введите номер досье : ");
                        index = Convert.ToInt32(Console.ReadLine()) - 1;

                        fullNameArray = DeleteDossier(fullNameArray, index);
                        jobTitleArray = DeleteDossier(jobTitleArray, index);
                        break;

                    case "4":
                        Console.Write("Введите фамилию : ");
                        string lastName = Console.ReadLine();
                        
                        foundDossier = SearchLastName(fullNameArray, jobTitleArray, lastName);

                        Console.WriteLine(foundDossier);
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("До свидания!");
                        Console.ReadKey();
                        isWork = false;
                        break;
                }
                
                Console.Clear();
            }
        }

        static void DrawMenu()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("1. Добавить досье\n" +
                "2. Вывести все досье\n" +
                "3. Удалить досье\n" +
                "4. Поиск по фамилии\n" +
                "5. Выход");
            Console.SetCursorPosition(0, 0);
        }

        static string[] AddDossier(string[] array, string name)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[array.Length] = name;
            array = tempArray;
            
            return array;
        }

        static void DrawDossier(string[] fullNameArray, string[] jobTitleArray)
        {
            for (int i = 0; i < fullNameArray.Length; i++)
            {
                Console.Write($"{i + 1}. {fullNameArray[i]} {jobTitleArray[i]}");
                
                if (i != fullNameArray.Length - 1)
                {
                    Console.Write(" - ");
                }
            }
            
            Console.ReadKey();
        }

        static string[] DeleteDossier(string[] array, int index)
        {
            if (index > array.Length || index < 0)
            {
                Console.WriteLine("неверный индекс");
            }

            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }
            
            for (int i = index; i < tempArray.Length; i++)
            {
                tempArray[i] = array[i + 1];
            }

            array = tempArray;
            return array;
        }

        static string SearchLastName(string[] fullNameArray, string[] jobTitleArray, string lastName)
        {
            int index = 0;
 
            for (int i = 0; i < fullNameArray.Length; i++)
            {
                string[] tempArray = fullNameArray[i].Split(' ');
                
                if (tempArray[0].ToLower() == lastName.ToLower())
                {
                    index = i;
                }
            }

            return $"{fullNameArray[index]} {jobTitleArray[index]}";
        }
    }
}
