using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            Libary libary = new Libary();

            while (isWork)
            {
                const string CommandAddBook = "1";
                const string CommandDeleteBook = "2";
                const string CommandShowBook = "3";
                const string CommandExit = "4";

                Console.Clear();

                DrawMenu(CommandAddBook, CommandDeleteBook, CommandShowBook, CommandExit);

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        libary.AddBook();
                        break;

                    case CommandDeleteBook:
                        libary.DeleteBook();
                        break;

                    case CommandShowBook:
                        libary.ShowBook();
                        break;

                    case CommandExit:

                        break;
                }
            }
        }

        public static void DrawMenu(string addBook, string deleteBook, string showBook, string exit)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine
                ($"{addBook} - добавить книгу.\n" +
                $"{deleteBook} - удалить кнгу.\n" +
                $"{showBook} - показать книги.\n" +
                $"{exit} - выйти.");
            Console.SetCursorPosition(0, 0);
        }
    }



    class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string ReleaseDate { get; private set; }
        
        public Book(string name = "", string author = "", string date = "")
        {
            Name = name;
            Author = author;
            ReleaseDate = date;
        }
    }

    class Libary : Book
    {
        private List<Book> _books = new List<Book>();

        public void AddBook()
        {
            _books.Add(CreateBook());
        }

        private Book CreateBook()
        {
            Console.Clear();

            Console.Write("Введите название : ");
            string name = Console.ReadLine();

            Console.Write("Введите Автора : ");
            string author = Console.ReadLine();

            Console.Write("Введите год выпуска : ");
            string date = Console.ReadLine();

            Book book = new Book(name, author, date);

            Console.WriteLine("Книга добавлена.");
            Console.ReadKey();
            Console.Clear();

            return book;
        }

        public void DeleteBook()
        {
            const string CommandDeleteName = "1";
            const string CommandDeleteAuthor = "2";
            const string CommandDeleteReleaceDate = "3";

            Console.Clear();

            DrawDeleteBookMenu(CommandDeleteName, CommandDeleteAuthor, CommandDeleteReleaceDate);

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandDeleteName:
                    DeleteBookName();
                    break;

                case CommandDeleteAuthor:
                    DeleteBookAuthor();
                    break;

                case CommandDeleteReleaceDate:
                    DeleteBookReleaceDate();
                    break;
            }
            
        }

        private void DeleteBookName()
        {
            Console.Write("Введите название книги : ");
            string name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Name == name)
                {
                    _books.Remove(book);
                }
            }
        }

        private void DeleteBookAuthor()
        {
            Console.Write("Введите фамилию автора : ");
            string author = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Author == author)
                {
                    _books.Remove(book);
                }
            }
        }

        private void DeleteBookReleaceDate()
        {
            Console.Write("Введите фамилию автора : ");
            string date = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.ReleaseDate == date)
                {
                    _books.Remove(book);
                }
            }
        }

        private void DrawDeleteBookMenu(string deleteName, string deleteAuthor, string deleteReleaceDate)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine
                ($"{deleteName} - удалить книгу по названию.\n" +
                $"{deleteAuthor} - удалить книгу по автору.\n" +
                $"{deleteReleaceDate} - удалить книгу по году выпуска.");
            Console.SetCursorPosition(0, 0);
        }

        public void ShowBook()
        {
            const string CommandShowName = "1";
            const string CommandShowAuthor = "2";
            const string CommandShowReleaceDate = "3";
            const string CommandShowAllBook = "4";

            Console.Clear();

            DrawShowBookMenu(CommandShowName, CommandShowAuthor, CommandShowReleaceDate, CommandShowAllBook);

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandShowName:
                    ShowBookName();
                    break;

                case CommandShowAuthor:
                    ShowBookAuthor();
                    break;

                case CommandShowReleaceDate:
                    ShowBookReleaceDate();
                    break;

                case CommandShowAllBook:
                    ShowAllBook();
                    break;
            }
        }

        private void DrawShowBookMenu(string showName, string showAuthor, string showReleaceDate, string showAllBook)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine
                ($"{showName} - показать книги по названию.\n" +
                $"{showAuthor} - показать книги по автору.\n" +
                $"{showReleaceDate} - показать книги по году выпуска.\n" +
                $"{showAllBook} - показать все книги.");
            Console.SetCursorPosition(0, 0);
        }

        private void ShowBookName()
        {
            Console.Write("Введите название книги : ");
            string name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Name == name)
                {
                    Console.WriteLine($"Книга : {book.Name}, Автор : {book.Author}, Год выпуска : {book.ReleaseDate}");
                }
            }

            Console.ReadKey();
        }

        private void ShowBookAuthor()
        {
            Console.Write("Введите фамилию автора : ");
            string author = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Author == author)
                {
                    Console.WriteLine($"Книга : {book.Name}, Автор : {book.Author}, Год выпуска : {book.ReleaseDate}");
                }
            }

            Console.ReadKey();
        }

        private void ShowBookReleaceDate()
        {
            Console.Write("Введите год выпуска : ");
            string releaceDate = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.ReleaseDate == releaceDate)
                {
                    Console.WriteLine($"Книга : {book.Name}, Автор : {book.Author}, Год выпуска : {book.ReleaseDate}");
                }
            }

            Console.ReadKey();
        }

        private void ShowAllBook()
        {
            foreach (Book book in _books)
            {
                Console.WriteLine($"Книга : {book.Name}, Автор : {book.Author}, Год выпуска : {book.ReleaseDate}");
            }

            Console.ReadKey();
        }
    }
}
