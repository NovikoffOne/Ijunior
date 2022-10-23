using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            bool isWork = true;

            while (isWork)
            {
                const string CommandSortByName = "1";
                const string CommandSortByAge = "2";
                const string CommandShowPatieentsByDisease = "3";
                const string CommandExit = "0";

                Console.WriteLine($"{CommandSortByName} - Сортировка по имени.\n" +
                    $"{CommandSortByAge} - Сортировка по возврасту.\n" +
                    $"{CommandShowPatieentsByDisease} - Показать пациетнов с определенным заболеванием.\n" +
                    $"{CommandExit} - Выход.");

                Console.Write("Выберите пункт : ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSortByName:
                        hospital.SortPatientsByName();
                        break;

                    case CommandSortByAge:
                        hospital.SortPatientsByAge();
                        break;

                    case CommandShowPatieentsByDisease:
                        hospital.ShowPatieentsByDisease();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Hospital
    {
        private List<Patient> _patients;

        public Hospital()
        {
            _patients = new List<Patient>()
            {
            new Patient("Петрова Анна Васильевна", "Ангина", 30),
            new Patient("Зуева Валентина Игоревна", "Перелом", 19),
            new Patient("Пятачков Юрий Андреевич", "Ангина", 24),
            new Patient("Карпов Антон Олегович", "Сотрясение", 52),
            new Patient("Альбинов Олег Васильевич", "Перелом", 37),
            new Patient("Тамарова Юля Александровна", "Инсульт", 68),
            new Patient("Костылькин Иван Артемович", "Сотрясение", 19),
            new Patient("Кирова Диана Олеговна", "Простуда", 44),
            new Patient("Пистрова Оксана Николаевна", "Простуда", 62),
            new Patient("Ян Александр Валентинович", "Инсульт", 76)
            };
        }
        
        public void SortPatientsByName()
        {
            var sortedPatients = _patients.OrderBy(patient=>patient.FullName);
            
            foreach (var patient in sortedPatients)
            {
                patient.ShowInfo();
            }
        }

        public void SortPatientsByAge()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Age);

            foreach (var patient in sortedPatients)
            {
                patient.ShowInfo();
            }
        }

        public void ShowPatieentsByDisease()
        {
            Console.Write("Введите заболевание : ");
            string userInput = Console.ReadLine();

            var filtredPatients = _patients.Where(patient => patient.Disease.ToLower() == userInput.ToLower());

            if(filtredPatients.Count() == 0)
            {
                Console.WriteLine("Попробуйте еще раз...");
            }
            else
            {
                foreach (var patient in filtredPatients)
                {
                    patient.ShowInfo();
                }
            }
        }
    }

    class Patient
    {
        public string FullName { get; private set; }
        public string Disease { get; private set; }
        public int Age { get; private set; }

        public Patient(string fullName, string disease, int age)
        {
            FullName = fullName;
            Disease = disease;
            Age = age;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{FullName} | {Disease} | {Age}");
        }
    }
}
