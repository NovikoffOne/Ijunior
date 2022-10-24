using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchForCriminal
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseOfCriminal baseCriminal = new BaseOfCriminal();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Введите данные :");
                Console.Write("Рост : ");
                int height = UserUtils.ReadInt();

                Console.Write("Вес : ");
                int weight = UserUtils.ReadInt();

                Console.Write("Национальность : ");
                string nationality = Console.ReadLine();

                baseCriminal.FilterCriminals(height, weight, nationality);

                Console.WriteLine("Нажмите любую клавишу чтобы продолжить, '0' - выход...");
                char key = Console.ReadKey(true).KeyChar;

                if(key == '0')
                {
                    return;
                }
            }
        }
    }

    class Criminal
    {
        public string FullName { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public bool IsGuarded { get; private set; }

        public Criminal(string fullName, int height, int weight, string nationality, bool isGuarded)
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsGuarded = isGuarded;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО : {FullName} | Рост : {Height} | Вес : {Weight} | Национальность : {Nationality}");
        }
    }

    class BaseOfCriminal
    {
        public List<Criminal> Criminals { get; private set; }

        public BaseOfCriminal()
        {
            Criminals = new List<Criminal>() 
            {
                new Criminal("Ильинов Валентин Генадьевич", 174, 66, "Русский", false),
                new Criminal("Шестак Валерий Иванович", 188, 100, "Русский", false),
                new Criminal("Карпатов Виктор Аристархович", 174, 66, "Русский", true),
                new Criminal("Кожемятько Ирина Александровна", 179, 58, "Казашка", false),
                new Criminal("Медведев Дмитрий Анатольевич", 174, 66, "Русский", false),
                new Criminal("Нитков Алексей Юрьевич", 188, 100, "Русский", true)
            };
        }

        public void FilterCriminals(int height, int weight, string nationality)
        {
            var filtredCriminals = from Criminal criminal in Criminals where criminal.Height == height 
                                                                       where criminal.Weight == weight
                                                                       where criminal.Nationality.ToLower() == nationality.ToLower()
                                                                       where criminal.IsGuarded == false 
                                                                       select criminal;

            if(filtredCriminals.Count() == 0)
            {
                Console.WriteLine("Таких нет...");
            }
            else
            {
                foreach (var criminal in filtredCriminals)
                {
                    criminal.ShowInfo();
                }
            }
        }
    }
}
