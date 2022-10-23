using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmamentCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>() 
            {
                new Soldier("Петр", "АК-74", "Рядовой", 4),
                new Soldier("Игорь", "АК-74", "Майор", 20),
                new Soldier("Афанасий", "ПП", "Генерал", 50),
                new Soldier("Олег", "АК-74", "Сержант", 8),
                new Soldier("Артем", "Миномет", "Лейтенант", 15),
                new Soldier("Дмитрий", "Сайга", "Рядовой", 2),
                new Soldier("Василий", "АКМ", "Сержант", 9),
            };

            var newSoldier = from Soldier soldier in soldiers select new { Name = soldier.Name, Rank = soldier.Rank };

            foreach(var soldier in newSoldier)
            {
                Console.WriteLine($"{soldier.Name} - {soldier.Rank}");
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int LifeTime { get; private set; }

        public Soldier(string name, string weapon, string rank, int lifeTime)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            LifeTime = lifeTime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} | {Rank} | {Weapon} | {LifeTime}");
        }
    }
}
