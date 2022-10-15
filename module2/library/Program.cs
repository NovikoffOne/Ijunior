using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool isWork = true;

            while (isWork)
            {
                const string CommandShowBooks = "1";
                const string CommandDeleteBook = "2";
                const string CommandAddBook = "3";
                const string CommandSearch = "4";
                const string CommandExit = "5";

                Console.WriteLine($"{CommandShowBooks} - Показать книги.\n" +
                    $"{CommandDeleteBook} - Удалить книгу.\n" +
                    $"{CommandAddBook} - Добавить книгу.\n" +
                    $"{CommandSearch} - Найти книгу.\n" +
                    $"{CommandExit} - exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowBooks:
                        library.ShowBooks();
                        break;

                    case CommandDeleteBook:
                        library.DeleteBook();
                        break;

                    case CommandAddBook:
                        library.AddBook();
                        break;

                    case CommandSearch:
                        library.SearchBook();
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

    class Library
    {
        private List<Book> _books;
        
        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook()
        {
            _books.Add(new Book());

            Console.WriteLine("Книга добавлена!");
            Console.ReadKey();
        }
        
        public void DeleteBook()
        {
            ShowBooks();

            if (_books.Count == 0)
            {
                Console.WriteLine("Список еще пуст...");
                return;
            }

            Console.Write("Выберите книгу, которую хотите удалить : ");
            string userInput = Console.ReadLine();
            
            if (int.TryParse(userInput, out int number) && _books.Count() > number && number >= 0)
            {
                _books.RemoveAt(number);
                Console.WriteLine("Книга удалена.");
            }
            else
            {
                Console.WriteLine("Что-то пошло не так!");
            }

            Console.ReadKey();
        }
        
        public void ShowBooks()
        {
            int index = 0;

            foreach(var book in _books)
            {
                Console.Write($"{index}. ");
                book.ShowInfo();
                index++;
            }
        }

        public void SearchBook()
        {
            const string CommandSearchName = "1";
            const string CommandSearchAuthor = "2";
            const string CommandSearchYear = "3";

            Console.WriteLine($"{CommandSearchName} - Поиск по названию.\n" +
                $"{CommandSearchAuthor} - Поиск по автору.\n" +
                $"{CommandSearchYear} - Поиск по году выпуска.");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandSearchName:
                    SearchBookByName();
                    break;

                case CommandSearchAuthor:
                    SearchBookByAuthor();
                    break;

                case CommandSearchYear:
                    SearchBookByYear();
                    break;
            }
        }

        private void SearchBookByName()
        {
            string name = Console.ReadLine();

            foreach (var book in _books)
            {
                if (name == book.Name)
                {
                    book.ShowInfo();
                }
            }
        }

        private void SearchBookByAuthor()
        {
            string author = Console.ReadLine();

            foreach (var book in _books)
            {
                if (author == book.Author)
                {
                    book.ShowInfo();
                }
            }
        }

        private void SearchBookByYear()
        {
            string year = Console.ReadLine();

            foreach (var book in _books)
            {
                if (year == book.YearIssue)
                {
                    book.ShowInfo();
                }
            }
        }
    }

    class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string YearIssue { get; private set; }

        public Book()
        {
            Console.Write("Введите название : ");
            Name = Console.ReadLine();
            Console.Write("Введите автора : ");
            Author = Console.ReadLine();
            Console.Write("Введите год выпуска : ");
            YearIssue = Console.ReadLine();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} | {Author} | {YearIssue}");
        }
    }
}
