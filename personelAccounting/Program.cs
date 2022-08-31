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
            int userInput;
            
            while (isWork)
            {
                const int Add = 1;
                const int DrawDossiers = 2;
                const int DeletedDossiers = 3;
                const int SearchNamesakes = 4;
                const int Out = 5;

                DrawMenu(Add, DrawDossiers, DeletedDossiers, SearchNamesakes, Out);

                userInput = Convert.ToInt32(ProcessInput());

                switch (userInput)
                {
                    case Add:
                        AddDossierСonclusion(ref fullNameArray, ref jobTitleArray);
                        break;
                    case DrawDossiers:
                        DrawDossier(fullNameArray, jobTitleArray);
                        break;

                    case DeletedDossiers:
                        DeleteDossierСonclusion(ref index, fullNameArray, jobTitleArray);
                        break;

                    case SearchNamesakes:
                        SearchNamesakesСonclusion(fullNameArray, jobTitleArray);
                        break;

                    case Out:
                        Exit(ref isWork);
                        break;
                }

                Console.Clear();
            }
        }

        static void DrawMenu(int Add, int DrawDossiers, int DeletedDossiers, int SearchNamesakes, int Out)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"{Add}. Добавить досье\n" +
                $"{DrawDossiers}. Вывести все досье\n" +
                $"{DeletedDossiers}. Удалить досье\n" +
                $"{SearchNamesakes}. Поиск по фамилии\n" +
                $"{Out}. Выход");
            Console.SetCursorPosition(0, 0);
        }

        static string ProcessInput()
        {
            string userInput;
            Console.Write("Выберите пункт : ");
            return userInput = Console.ReadLine();
        }

        static string GetFullName()
        {
            Console.Write("Введите ФИО : ");
            string fullName = Console.ReadLine();
            return fullName;
        }

        static string GetJobtitle()
        {
            Console.Write("Введите должность : ");
            string jobTitle = Console.ReadLine();
            return jobTitle;
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

        static int GetIndex()
        {
            Console.Write("Введите номер досье : ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            return index;
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

        static string GetLastName()
        {
            Console.Write("Введите фамилию : ");
            string lastName = Console.ReadLine();
            return lastName;
        }

        static string SearchNamesakes(string[] fullNameArray, string[] jobTitleArray, string lastName)
        {
            int index = 0;
            string[] Namesakes = new string[5];
 
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

        static void Exit(ref bool isWork)
        {
            Console.WriteLine("До свидания!");
            Console.ReadKey();
            isWork = false;
        }

        static void AddDossierСonclusion(ref string[] fullNameArray, ref string[] jobTitleArray)
        {
            string fullName = GetFullName();
            string jobTitle = GetJobtitle();
            fullNameArray = AddDossier(fullNameArray, fullName);
            jobTitleArray = AddDossier(jobTitleArray, jobTitle);
        }

        static void DeleteDossierСonclusion(ref int index, string[] fullNameArray, string[] jobTitleArray)
        {
            index = GetIndex();
            fullNameArray = DeleteDossier(fullNameArray, index);
            jobTitleArray = DeleteDossier(jobTitleArray, index);
        }

        static void SearchNamesakesСonclusion(string[] fullNameArray, string[] jobTitleArray)
        {
            string foundDossier;
            string lastName = GetLastName();
            foundDossier = SearchNamesakes(fullNameArray, jobTitleArray, lastName);

            Console.WriteLine(foundDossier);
            Console.ReadKey();
        }
    }
}
