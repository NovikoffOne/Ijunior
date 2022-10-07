using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermarketAdministration
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client(new List<Product> { new Product("Хлеб", 12), new Product("Чай", 20) }, 31);
            Client client2 = new Client(new List<Product> { new Product("Майонез", 40), new Product("Чай", 20), new Product("Сметана", 13) }, 80);
            Client client3 = new Client(new List<Product> { new Product("Капуста", 10), new Product("Макароны", 62), new Product("Пельмени", 200) }, 250);
            Queue<Client> clients = new Queue<Client>();
            CashRegister cashRegister = new CashRegister();

            clients.Enqueue(client1);
            clients.Enqueue(client2);
            clients.Enqueue(client3);

            while(clients.Count != 0)
            {
                cashRegister.CalculataPaymentAmount(clients.Dequeue());
                Console.WriteLine("Свободная касса!");
            }

            cashRegister.CloseCashRegister();
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    class Client
    {
        public List<Product> Basket { get; private set; }
        public int Money { get; private set; }
        private Random random = new Random();

        public Client(List<Product> basket, int money)
        {
            Basket = basket;
            Money = money;
        }

        public void Pay(int grandTotal)
        {
            Money -= grandTotal;
        }

        public void RemoveGood()
        {
            Basket.RemoveAt(random.Next(0, Basket.Count - 1));
        }
    }

    class CashRegister
    {
        private int _money;
        private bool _bought = false;
        
        public CashRegister()
        {
            _money = 0;
        }

        public void CloseCashRegister()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Касса закрыта!\n Выручка : {_money} руб.") ;
        }

        public void CalculataPaymentAmount(Client client)
        {
            _bought = false;

            while(_bought == false)
            {
                List<Product> basket = client.Basket;
                int grandTotal = 0;
                foreach (Product product in basket)
                {
                    Console.WriteLine($"{product.Name} - {product.Price} руб.");
                    grandTotal += product.Price;
                }

                Console.WriteLine($"Итого : {grandTotal}");

                if (grandTotal <= client.Money)
                {
                    client.Pay(grandTotal);
                    _money += grandTotal;
                    _bought = true;
                    Console.WriteLine("Покупка оплачена. Ждем вас снова!");
                }
                else
                {
                    Console.WriteLine("У вас недостаточно денег! Придется убрать товар.");
                    client.RemoveGood();
                }
            }
        }
    }
}
