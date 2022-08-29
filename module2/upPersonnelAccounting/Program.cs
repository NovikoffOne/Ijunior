using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upPersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int userInput = 0;

            Dictionary<string, string> dossier = new Dictionary<string, string>()
            {
                ["Ананьев Евгений Сергеевич"] = "Крановщик",
                ["Жерандол Екатерина Гигорьевна"] = "Повар",
                ["Ян Петр Михайлович"] = "Боец",
                ["Фольфрам Олег Владимирович"] = "Учитель"
            };
            
            while (isWork)
            {
                SelectItem(ref userInput, dossier, ref isWork);
                Console.Clear();
            }
        }

        static void DrawMenu()
        {
            Console.WriteLine
                
                ("1 - Добавить досье.\n" +
                "2 - Выести все досье.\n" +
                "3 - Удалить досье.\n" +
                "4 - Выход.\n");
        }

        static void SelectItem(ref int userInput, Dictionary<string, string> dossier, ref bool isWork)
        {
            DrawMenu();

            userInput = Convert.ToInt32(Console.ReadLine());

            const int AddingDossier = 1;
            const int WithdrawDossiers = 2;
            const int DeleteDossiers = 3;
            const int Exit = 4;

            switch (userInput)
            {
                case AddingDossier:
                    AddDossier(dossier);
                    break;
                
                case WithdrawDossiers:
                    ShowDossier(dossier);
                    Console.ReadKey();
                    break;
                
                case DeleteDossiers:
                    RemoveDossier(dossier);
                    break;

                case Exit:
                    Out(ref isWork);
                    break;

                default:
                    Console.WriteLine("Попробуйте еще раз!!!");
                    break;
            }
        }

        static void AddDossier(Dictionary<string, string> dossiers)
        {
            string name;
            string job;

            Console.Write("Введите ФИО : ");
            name = Console.ReadLine();
            Console.Clear();

            Console.Write("Введите професию : ");
            job = Console.ReadLine();
            Console.Clear();

            dossiers.Add(name, job);
            Console.WriteLine("Добавлено!");
            Console.ReadKey();
        }

        static void ShowDossier(Dictionary<string, string> dossiers)
        {
            foreach (var item in dossiers)
            {
                Console.Write($"{item.Key} - {item.Value}, ");
            }
        }

        static void RemoveDossier(Dictionary<string,string> dossier)
        {
            string userInput;

            Console.Write("Введите ФИО, которое хотите удалить : ");
            userInput = Console.ReadLine();
            dossier.Remove(userInput);
        }

        static void Out(ref bool isWork)
        {
            Console.WriteLine("Довстречи!!!");
            Console.ReadKey();

            isWork = false;
        }
    }
}
