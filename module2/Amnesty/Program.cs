using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amnesty
{
    class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();
            string amnestyTerms = "Антиправительственное";

            Console.WriteLine("До амнистии : ");
            prison.ShowInfo();

            prison.Amnesty(amnestyTerms);

            Console.WriteLine("После амнистии : ");
            prison.ShowInfo();
        }
    }

    class Prison
    {
        private List<Prisoner> _prisoners = new List<Prisoner>() { new Prisoner("Ян Валерий Генадьевич", "Антиправительственное"), new Prisoner("Иванов Петр Григоривеч", "Разбойное"), new Prisoner("Анискин Виктор Артемович", "Антиправительственное"), new Prisoner("Сафронов Олег Григоривеч", "Мошенническое") };

        public void Amnesty(string amnestyTerms)
        {
            var amnestiedPrisoners = _prisoners.Where(prisoner => prisoner.Crime == amnestyTerms);
            _prisoners = _prisoners.Except(amnestiedPrisoners).ToList();
        }

        public void ShowInfo()
        {
            foreach (var prisoner in _prisoners)
            {
                prisoner.ShowInfo();
            }
        }
    }

    class Prisoner
    {
        private string _fullName;
        public string Crime { get; private set; }

        public Prisoner(string fullName, string crime)
        {
            _fullName = fullName;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_fullName} | {Crime}");
        }
    }
}
