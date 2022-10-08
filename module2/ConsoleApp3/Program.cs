using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Aviaries aviaries1 = new Aviaries ( "обезьяны", new List<Animals>{ new Animals("Мартышка", "муж", "Рев"), new Animals("Горила", "жен", "Рев"), new Animals("Капуцин", "жен", "Рев"), new Animals("Капуцин", "муж", "Рев") });
            Aviaries aviaries2 = new Aviaries("собаки", new List<Animals> { new Animals("Динго", "муж", "Лай"), new Animals("Динго", "жен", "Лай"), new Animals("Гиена", "жен", "Лай"), new Animals("Гиена", "муж", "Лай"), new Animals("Гиена", "муж", "Лай") });
            Aviaries aviaries3 = new Aviaries("Львы", new List<Animals> { new Animals("Лев", "муж", "Рев"), new Animals("Лев", "жен", "Рев") });
            Aviaries aviaries4 = new Aviaries("Жирафы", new List<Animals> { new Animals("Жираф", "муж", "Мычание") });
            Aviaries[] aviaries = new Aviaries[] { aviaries1, aviaries2, aviaries3, aviaries4 };
            Zoo zoo = new Zoo(aviaries);
            bool isWork = true;

            while (isWork)
            {
                const int GoMonkey = 0;
                const int GoDogs = 1;
                const int GoLions = 2;
                const int GoGiraffs = 3;
                const int GoExit = 4;

                Console.WriteLine($"На кого хотите посмотреть : \n" +
                    $"{GoMonkey} - {aviaries1.Name}\n" +
                    $"{GoDogs} - {aviaries2.Name}\n" +
                    $"{GoLions} - {aviaries3.Name}\n" +
                    $"{GoGiraffs} - {aviaries4.Name}\n" +
                    $"{GoExit} - выход");
                int userInput = UserUtils.ReadInt() ;

                switch (userInput)
                {
                    case GoMonkey:
                        zoo.DrawAviares(GoMonkey);
                        break;

                    case GoDogs:
                        zoo.DrawAviares(GoDogs);
                        break;

                    case GoLions:
                        zoo.DrawAviares(GoLions);
                        break;

                    case GoGiraffs:
                        zoo.DrawAviares(GoGiraffs);
                        break;

                    case GoExit:
                        isWork = false;
                        break;
                }

                Console.Clear();
            }
        }
    }

    public static class UserUtils
    {
        public static int ReadInt()
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int number);

            if (isNumber)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз!");
                return number = 0;
            }
        }
    }

    class Zoo
    {
        private Aviaries[] _aviaries;

        public Zoo(Aviaries[] aviaries)
        {
            _aviaries = aviaries;
        }

        public void DrawAviares(int index)
        {
            _aviaries[index].ShowInfo();   
        }
    }

    class Aviaries
    {
        public string Name { get; private set; }
        private List<Animals> _animals;
        private int _countAnimals;

        public Aviaries(string name, List<Animals> animals )
        {
            _animals = animals;
            Name = name;
            _countAnimals = _animals.Count;
        }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"В вольере живут {Name}, в количестве {_countAnimals}.\nОбитатели :");

            foreach (var animal in _animals)
            {
                animal.ShowInfo();
            }

            Console.ReadKey();
        }
    }

    class Animals
    {
        public string Type { get; private set; }
        public string Gender { get; private set; }
        public string SoundAnimals { get; private set; }

        public Animals(string type, string gender, string sound)
        {
            Type = type;
            Gender = gender;
            SoundAnimals = sound;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Type} пол:{Gender} звук:{SoundAnimals}");
        }
    }
}
