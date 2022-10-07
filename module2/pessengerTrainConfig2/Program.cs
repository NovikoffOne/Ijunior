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

                DrawMenu(CommandCreateTrain, CommandSendTrain, CommandExit);

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

        private static void DrawMenu(string createTrain, string sendTrain, string exit)
        {
            Console.WriteLine(
                $"{createTrain} - Создать поезд.\n" +
                $"{sendTrain} - Отправить поезд.\n" +
                $"{exit} - Выход."
                );
        }
    }

    static public class UserUtils
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
        public bool IsWay { get; private set; }

        public Train()
        {
            Console.Write("Введите город отправления : ");
            CityDeparture = Console.ReadLine();
            Console.Write("Введите город прибытия : ");
            CityArrival = Console.ReadLine();
            Console.Write("Введите кол-во проданных билетов : ");
            Passenger = UserUtils.ReadInt();

            FormWagons();

            SendTrain();
        }

        public void SendTrain()
        {
            const string CommandTrain = "0";
            const string CommandNotTrain = "1";

            Console.WriteLine
                ($"Что бы отправить поезд введите - {CommandTrain}.\n" +
                $"Не отправлять - {CommandNotTrain}");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandTrain:
                    IsWay = true;
                    break;

                case CommandNotTrain:
                    IsWay = false;
                    break;
            }
        }

        private void FormWagons()
        {
            decimal numberWagons = (Passenger / PassengerInWagon);

            Wagons = Convert.ToInt32(Math.Ceiling(numberWagons));
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

                    if (train.IsWay)
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

            _trains[userInput].SendTrain();
        }
    }
}
