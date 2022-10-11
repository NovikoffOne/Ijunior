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
            Aviary aviaries1 = new Aviary ( "обезьяны", new List<Animals>{ new Animals("Мартышка", "муж", "Рев"), new Animals("Горила", "жен", "Рев"), new Animals("Капуцин", "жен", "Рев"), new Animals("Капуцин", "муж", "Рев") });
            Aviary aviaries2 = new Aviary("собаки", new List<Animals> { new Animals("Динго", "муж", "Лай"), new Animals("Динго", "жен", "Лай"), new Animals("Гиена", "жен", "Лай"), new Animals("Гиена", "муж", "Лай"), new Animals("Гиена", "муж", "Лай") });
            Aviary aviaries3 = new Aviary("Львы", new List<Animals> { new Animals("Лев", "муж", "Рев"), new Animals("Лев", "жен", "Рев") });
            Aviary aviaries4 = new Aviary("Жирафы", new List<Animals> { new Animals("Жираф", "муж", "Мычание") });
            Aviary[] aviaries = new Aviary[] { aviaries1, aviaries2, aviaries3, aviaries4 };
            Zoo zoo = new Zoo(aviaries);
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("На кого хотите посмотреть : ");
                
                for (int i = 0; i < zoo.Aviaries.Count(); i++)
                {
                    Console.WriteLine($"{i}. {zoo.Aviaries[i].Name}");
                }

                Console.WriteLine("exit - ВЫХОД");

                string userInput = Console.ReadLine();

                if (userInput == "exit")
                {
                    isWork = false;
                }
                else
                {
                    int index = UserUtils.ReadInt(userInput);

                    if (index < zoo.Aviaries.Length && index >= 0)
                    {
                        zoo.DrawAviares(index);
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте еще раз.");
                    }
                }

                Console.Clear();
            }
        }
    }

    public static class UserUtils
    {
        public static int ReadInt(string userInput)
        {
            bool isNumber = int.TryParse(userInput, out int number);

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
        public Aviary[] Aviaries { get; private set; }

        public Zoo(Aviary[] aviaries)
        {
            Aviaries = aviaries;
        }

        public void DrawAviares(int index)
        {
            Aviaries[index].ShowInfo();   
        }
    }

    class Aviary
    {
        private List<Animals> _animals;
        public string Name { get; private set; }

        public Aviary(string name, List<Animals> animals )
        {
            _animals = animals;
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"В вольере живут {Name}, в количестве {_animals.Count}.\nОбитатели :");

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
