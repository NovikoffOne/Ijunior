using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermarketAdministration2
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();
            supermarket.Work();
        }
    }

    class Supermarket
    {
        private Queue<Client> _clients = new Queue<Client>();
        private CashRegister _cashRegister;

        public Supermarket()
        {
            _clients.Enqueue(new Client(new List<Product> { new Product("Хлеб", 12), new Product("Чай", 20) }, 31));
            _clients.Enqueue(new Client(new List<Product> { new Product("Майонез", 40), new Product("Чай", 20), new Product("Сметана", 13) }, 80));
            _clients.Enqueue(new Client(new List<Product> { new Product("Капуста", 10), new Product("Макароны", 62), new Product("Пельмени", 200) }, 250));

            _cashRegister = new CashRegister();
        }

        public void Work()
        {
            while(_clients.Count > 0)
            {
                _cashRegister.ServeBuyer(_clients.Dequeue());
            }

            _cashRegister.CloseCashRegister();
        }
    }
    
    class Client
    {
        private List<Product> _basket;
        private Random _random = new Random();
        
        public int Money { get; private set; }

        public Client(List<Product> basket, int money)
        {
           _basket = basket;
            Money = money;
        }

        public void Pay(int grandTotal)
        {
            Money -= grandTotal;
        }

        public void RemoveProduct()
        {
            _basket.RemoveAt(_random.Next(_basket.Count));
        }

        public int CountPrice()
        {
            int grandTotal = 0;

            foreach (var product in _basket)
            {
                Console.WriteLine($"{product.Name} - {product.Price} руб.");
                grandTotal += product.Price;
            }

            return grandTotal;
        }
    }

    class CashRegister
    {
        private int _money;

        public void ServeBuyer(Client client)
        {
            int grandTotal = client.CountPrice();

            if(grandTotal <= client.Money)
            {
                client.Pay(grandTotal);
                AcceptPayment(grandTotal);
            }
            else
            {
                while (grandTotal > client.Money)
                {
                    Console.WriteLine("Не достаточно денег!!!");
                    client.RemoveProduct();
                    grandTotal = client.CountPrice();
                }

                client.Pay(grandTotal);
                AcceptPayment(grandTotal);
            }

        }

        public void CloseCashRegister()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Касса закрыта!\n Выручка : {_money} руб.");
        }

        private void AcceptPayment(int grandTotal)
        {
            _money += grandTotal;
            Console.WriteLine("Покупка оплачена!");
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
}
