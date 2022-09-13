using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Ваарк", "Орк", "Мужской", "34");
            player1.ShowInfo();
        }

        class Player
        {
            private string _name;
            private string _race;
            private string _gender;
            private string _age;

            public Player(string name, string race, string gender, string age)
            {
                _name = name;
                _race = race;
                _gender = gender;
                _age = age;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Имя - {_name}\nРаса - {_race}\nПол - {_gender}\nВозраст - {_age}");
            }
        }
    }
}
