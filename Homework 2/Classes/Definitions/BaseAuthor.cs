using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_2.Classes.Interfaces;
using Homework_2.Classes.Implementations;

namespace Homework_2.Classes.Definitions
{
    abstract class BaseAuthor : IComparable<BaseAuthor>, ICountingBooks
    {
        private string name;
        private List<Book> books;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Book> Books
        {
            get
            {
                if (books == null)
                {
                    books = new List<Book>();
                }
                return books;
            }
            set { books = value; }
        }

        public BaseAuthor() : this("unknown author", null) { }

        public BaseAuthor(string name, List<Book> books)
        {
            this.name = name;
            this.books = books;
        }

        public abstract int CompareTo(BaseAuthor author);

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name} has written {Books.Count} books\n");

            var sortedBooks = Books.OrderBy(b => b.Pages);

            foreach (Book b in sortedBooks)
            {
                builder.Append($"{b}\n");
            }
            return builder.ToString();
        }

        public int GetBooksCount() => (Books.Count);
    }
}
