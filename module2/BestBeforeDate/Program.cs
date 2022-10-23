using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBeforeDate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Stew> stews = new List<Stew>() {
                new Stew("Говяжая", 2019, 5),
                new Stew("Свинная", 2013, 7),
                new Stew("Куринная", 2021, 9),
                new Stew("Буренка", 2016, 4),
                new Stew("Вкусняка", 2015, 5),
                new Stew("Свежак", 2019, 1),
                new Stew("Походная", 2008, 10),
            };

            DateTime toDay = DateTime.Today;

            var filtredStew = stews.Where(stew => stew.SellBy > toDay);

            foreach(var stew in filtredStew)
            {
                stew.ShowInfo();
            }
        }
    }

    class Stew
    {
        private string _name;
        private int _bestBeforeDate;
        private DateTime _dateOfManufacture = new DateTime();

        public DateTime SellBy { get; private set; } = new DateTime();

        public Stew(string name, int dateOfManufacture, int bestBeforeDate)
        {
            _name = name;
            _dateOfManufacture = _dateOfManufacture.AddYears(dateOfManufacture);
            _bestBeforeDate = bestBeforeDate;
            SellBy = _dateOfManufacture.AddYears(_bestBeforeDate);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} | Произведенно : {_dateOfManufacture.ToString("yyyy")} | Срок годности : {_bestBeforeDate}");
        }
    }
}
