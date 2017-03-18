using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_2.Classes.Definitions;

namespace Homework_2.Classes.Implementations
{   
    class Library : BaseLibrary
    {
        public Library() : base() { }

        public Library(List<Section> sections) : base(sections) { }

        public override int CompareTo(BaseLibrary library)
        {
            if (this.GetBooksCount() > library.GetBooksCount())
            {
                return 1;
            }
            else if (this.GetBooksCount() < library.GetBooksCount())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        // Additional tasks

        public void ShowBiggestSection()
        {
            int maxCount = Sections.Max(s => s.GetBooksCount());
            Section biggestSection = Sections.FirstOrDefault(s => s.GetBooksCount() == maxCount);

            Console.WriteLine(biggestSection == null ? "Error" :
                $"The biggest section is {biggestSection.Type}: {biggestSection.GetBooksCount()} books");
        }

        public void ShowHardworkingAuthor()
        {
            var authors = Sections.SelectMany(s => s.Authors);
            int maxCount = authors.Max(a => a.GetBooksCount());
            Author hardworkingAuthor = authors.FirstOrDefault(a => a.GetBooksCount() == maxCount);

            Console.WriteLine(hardworkingAuthor == null ? "Error" :
                $"The hardworking author is {hardworkingAuthor.Name}: {hardworkingAuthor.GetBooksCount()} books");
        }

        public void ShowThinnestBook()
        {
            var authors = Sections.SelectMany(s => s.Authors);
            var books = authors.SelectMany(a => a.Books);
            int minPagesCount = books.Min(b => b.Pages);
            Book thinnestBook = books.FirstOrDefault(b => b.Pages == minPagesCount);

            Console.WriteLine(thinnestBook == null ? "Error" :
                $"The thinnest book is {thinnestBook.Title}: {thinnestBook.Pages} pages");
        }
    }
}
