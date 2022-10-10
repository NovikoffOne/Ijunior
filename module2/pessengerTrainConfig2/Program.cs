using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pessengerTrainConfig2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandCreateTrain = "1";
            const string CommandSendTrain = "2";
            const string CommandExit = "3";

            RailwayStation station = new RailwayStation();
            bool isWork = true;

            while (isWork)
            {
                station.DrawTrain();

                Console.WriteLine(
                        $"{CommandCreateTrain} - Создать поезд.\n" +
                        $"{CommandSendTrain} - Отправить поезд.\n" +
                        $"{CommandExit} - Выход."
                                 );

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandCreateTrain:
                        station.CreateTrain();
                        break;

                    case CommandSendTrain:
                        station.SendTrain();
                        break;

                    case CommandExit:
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

    class Train
    {
        private const int PassengerInWagon = 54;

        public string CityArrival { get; private set; }
        public string CityDeparture { get; private set; }
        public int Passenger { get; private set; }
        public int Wagons { get; private set; }
        public bool IsSent { get; private set; }

        public Train()
        {
            Console.Write("Введите город отправления : ");
            CityDeparture = Console.ReadLine();
            Console.Write("Введите город прибытия : ");
            CityArrival = Console.ReadLine();
            Console.Write("Введите кол-во проданных билетов : ");
            Passenger = UserUtils.ReadInt();

            FormWagons();

            Send();
        }

        public void Send()
        {
            const string CommandSendTrain = "0";
            const string CommandNotSendTrain = "1";

            Console.WriteLine
                ($"Что бы отправить поезд введите - {CommandSendTrain}.\n" +
                $"Не отправлять - {CommandNotSendTrain}");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandSendTrain:
                    IsSent = true;
                    break;

                case CommandNotSendTrain:
                    IsSent = false;
                    break;
            }
        }

        private void FormWagons()
        {
            int numberWagons = (Passenger / PassengerInWagon);
            
            if (Passenger % PassengerInWagon != 0)
            {
                Wagons = numberWagons + 1;
            }
            else
            {
                Wagons = numberWagons;
            }

            Console.WriteLine($"Количесвто вагонов : {Wagons}");
            Console.ReadKey();
        }
    }

    class RailwayStation
    {
        private List<Train> _trains;

        public RailwayStation()
        {
            _trains = new List<Train>();
        }

        public void CreateTrain()
        {
            _trains.Add(new Train());
        }

        public void DrawTrain()
        {
            Console.SetCursorPosition(0, 20);

            if (_trains.Count < 1)
            {
                Console.WriteLine("Рейсов нет!");
            }
            else
            {
                foreach (Train train in _trains)
                {
                    string way;
                    int index = 0;

                    if (train.IsSent)
                    {
                        way = "В пути";
                    }
                    else
                    {
                        way = "Ждет отправления";
                    }

                    Console.WriteLine
                        ($"{index}.{train.CityDeparture} - {train.CityArrival} ({way})\n" +
                        $"Пассажиров : {train.Passenger} | Вагонов : {train.Wagons}");
                    index++;
                }
            }

            Console.SetCursorPosition(0, 0);
        }

        public void SendTrain()
        {
            Console.Write("Введите номер поезда, который хотите отправить : ");
            int userInput = UserUtils.ReadInt();
            
            if (userInput >= 0 && userInput < _trains.Count)
            {
                if (_trains[userInput].IsSent == false)
                {
                    _trains[userInput].Send();
                }
                else
                {
                    Console.WriteLine("Поезд уже в пути!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Такого поезда не существует...");
                Console.ReadKey();
            }
        }
    }
}
