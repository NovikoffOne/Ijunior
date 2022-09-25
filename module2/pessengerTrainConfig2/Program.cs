using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pessengerTrainConfig2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RailwayStation Station = new RailwayStation();
            bool isWork = true;

            while (isWork)
            {
                const string CommandCreateTrain = "1";
                const string CommandChangeTrain = "2";
                const string CommandExit = "3";

                DrawMenu(CommandCreateTrain, CommandChangeTrain, CommandExit);

                Station.DrawDirection();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandExit:
                        isWork = false;
                        break;

                    case CommandCreateTrain:
                        Station.CreateTrain();
                        break;

                    case CommandChangeTrain:
                        Station.ChangeTrain();
                        break;
                }
                
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DrawMenu(string create, string change, string exit)
        {
            Console.WriteLine
                ($"{create} - Создать поезд.\n" +
                $"{change} - Изменить поезд\n" +
                $"{exit} - Выход");
        }
    }

    class Train
    {
        private const int PassengerInWagon = 54;

        public string CityArrival;
        public string CityDepfrture;
        public int Passenger;
        public int Wagons;
        public bool IsWay;

        public Train(string cityDeparture = "", string cityArrival = "", int passenger = 0, bool isWay = false)
        {
            CityArrival = cityArrival;
            CityDepfrture = cityDeparture;
            Passenger = passenger;
            IsWay = isWay;
        }

        public void FormWagons()
        {
            decimal number = (Passenger / PassengerInWagon);
            Wagons =  Convert.ToInt32(Math.Ceiling(number));
            Console.WriteLine($"Количесвто вагонов : {Wagons}");
            Console.ReadKey();
        }
    }

    class RailwayStation
    {
        private List<Train> _trains;
        private Random _random = new Random();

        public RailwayStation()
        {
            _trains = new List<Train>();
        }

        public void CreateTrain()
        {
            Console.WriteLine("Cоздаать поезд.");

            Train train = new Train();

            ConfigTrain(train);

            _trains.Add(train);
        }

        public void ChangeTrain()
        {
            Console.WriteLine("Изменить поезд.");
            Console.Write("Выберите поезд, который хотите изменить : ");
            int index = Convert.ToInt32(Console.ReadLine());

            ConfigTrain(_trains[index]);
        }

        public void DrawDirection()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Рейсы");

            if(_trains.Count > 0)
            {
                SortTrain();
            }
            else
            {
                Console.WriteLine("Рейсов нет!");
            }
            
            Console.SetCursorPosition(0, 4);
        }

        private void ConfigTrain(Train train)
        {
            bool isWork = true;

            while (isWork)
            {
                const string CommandCreateTrain = "1";
                const string CommandSellTickets = "2";
                const string CommandFormTrain = "3";
                const string CommandSendTrain = "4";
                const string CommandExit = "5";

                Console.WriteLine("Конфигуратор поезда");

                DrawTrainConfMenu(CommandCreateTrain, CommandSellTickets, CommandFormTrain, CommandSendTrain, CommandExit);

                Console.Write("Выберите действие : ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandCreateTrain:
                        CreateDirection(train);
                        break;

                    case CommandSellTickets:
                        train.Passenger = SellTicket();
                        break;

                    case CommandFormTrain:
                        train.FormWagons();
                        break;

                    case CommandSendTrain:
                        SendTrain(train);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }

                Console.Clear();
                Console.WriteLine("Настройка завершина.");
                Console.ReadKey();
            }
        }

        private void SortTrain()
        {
            int index = 0;

            foreach (var train in _trains)
            {
                string way;

                if (train.IsWay)
                {
                    way = "В пути";
                }
                else
                {
                    way = "Ждет отправления";
                }

                Console.WriteLine
                    ($"{index}. {train.CityDepfrture} - {train.CityArrival} ({way})\n" +
                    $"Проданно билетов : {train.Passenger} | Вагонов : {train.Wagons}");
                index++;
            }
        }

        private void DrawTrainConfMenu(string createTrain, string sellTickets, string formTrain, string sendTrain, string exit)
        {
            Console.WriteLine
                ($"{createTrain}. Создать направление.\n" +
                $"{sellTickets}. Продать билеты.\n" +
                $"{formTrain}. Сформировать поезд.\n" +
                $"{sendTrain}. Отправить поезд.\n" +
                $"{exit}. Выйти из конфигуратора.");
        }

        private string CreateCityDirection()
        {
            Console.Write("Введите город : ");
            string city = Console.ReadLine();

            return city;
        }

        private void CreateDirection(Train train)
        {
            Console.WriteLine("Отправление : ");
            train.CityDepfrture = CreateCityDirection();
            Console.WriteLine("Прибывает : ");
            train.CityArrival = CreateCityDirection();
        }

        private int SellTicket()
        {
            int passenger = _random.Next(100, 1000);
            Console.WriteLine($"Количесвто пассажиров - {passenger}");
            Console.ReadKey();

            return passenger;
        }

        private void SendTrain(Train train)
        {
            train.IsWay = true;
        }
    }
}
