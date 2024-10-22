using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Book()
        {
            Title = "Unknown title";
            Author = "Unknown author";
            Genre = "Unknown genre";
            Year = 0;
        }
        public Book(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Title}, {Author}, {Genre}, {Year}";
        }
    }

    public class Bookkeeping
    {
        private LinkedList<Book> books;

        public Bookkeeping()
        {
            books = new LinkedList<Book>();
        }

        public void AddBook(Book book)
        {
            books.AddLast(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public void UpdateBook(Book oldBook, Book newBook)
        {
            var node = books.Find(oldBook);
            if (node != null)
            {
                RemoveBook(oldBook);
                AddBook(newBook);
            }
        }

        public void AddBegin(Book book)
        {
            books.AddFirst(book);
        }
        public void AddEnd(Book book)
        {
            books.AddLast(book);
        }
        public void RemoveFromBegin()
        {
            if (books.Count > 0)
            {
                books.RemoveFirst();
            }
        }

        public void RemoveFromEnd()
        {
            if (books.Count > 0)
            {
                books.RemoveLast();
            }
        }

        public List<Book> SearchBooks(string title, string author, string genre, int? year)
        {
            return books.Where(book => (title == null || book.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) &&
                              (author == null || book.Author.Equals(author, StringComparison.OrdinalIgnoreCase)) &&
                              (genre == null || book.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)) &&
                              (year == null || book.Year == year))
                              .ToList();
        }

        public void AddPosition(Book book, int position)
        {
            if (position < 0 || position > books.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Позиція виходить за межі листа");
            }

            if (position == 0)
            {
                books.AddFirst(book);
            }
            else
            {
                var currentNode = books.First;

                for (int i = 0; i < position - 1; i++)
                {
                    if (currentNode == null)
                    {
                        throw new InvalidOperationException("Виходить за межі листа");
                    }
                    currentNode = currentNode.Next;
                }

                books.AddBefore(currentNode!, book);
            }
        }

        public void RemovePosition(int position)
        {
            if (position < 0 || position >= books.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Виходить за межі листа");
            }
            if (position == 0)
            {
                books.RemoveFirst();
            }
            else
            {
                var currentNode = books.First;

                for (int i = 0; i < position; i++)
                {
                    if (currentNode == null)
                    {
                        throw new InvalidOperationException("Виходить за межі листа");
                    }
                    currentNode = currentNode.Next;
                }

                books.Remove(currentNode!);
            }
        }

        public void InfoBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}, {book.Author}, {book.Genre}, {book.Year}");
            }
        }
    }
}

