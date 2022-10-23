using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnificationOfTroops
{
    class Program
    {
        static void Main(string[] args)
        {
            char transferTerms = 'Б';

            List<Soldier> soldiers = new List<Soldier>() 
            { 
                new Soldier("Ян Валерий Генадьевич"), 
                new Soldier("Иванов Петр Григоривеч"), 
                new Soldier("Анискин Виктор Артемович"),
                new Soldier("Сафронов Олег Григоривеч") 
            };

            List<Soldier> reinforcement = new List<Soldier>()
            {
                new Soldier("Баранов Андрей Васильевич"),
                new Soldier("Бахов Вадим Анатальевич"),
                new Soldier("Рюхов Виктор Витальевич"),
                new Soldier("Артемонов Андрей Егорович"),
                new Soldier("Бубнов Юрий Васильевич"),
                new Soldier("Папоротников Олег Олегович"),
                new Soldier("Иванов Константин Игоревич"),
                new Soldier("Березняк Юрий Васильевич"),
                new Soldier("Ядиков Ярослав Григорьевич"),
                new Soldier("Сергеев Иван Олегович"),
            };

            var filtredSoldier = reinforcement.Where(soldier => soldier.Name[0] == transferTerms);
            soldiers = soldiers.Concat(filtredSoldier).ToList();

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Name);
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }

        public Soldier(string name)
        {
            Name = name;
        }
    }
}
