using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_2.Classes.Definitions;

namespace Homework_2.Classes.Implementations
{
    class Author : BaseAuthor
    {
        public Author() : base() { }

        public Author(string name, List<Book> books) : base(name, books) { }

        public override int CompareTo(BaseAuthor author)
        {
            if (this.GetBooksCount() > author.GetBooksCount())
            {
                return 1;
            }
            else if (this.GetBooksCount() < author.GetBooksCount())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
