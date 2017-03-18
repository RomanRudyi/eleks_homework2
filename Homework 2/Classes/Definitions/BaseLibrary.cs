using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_2.Classes.Interfaces;
using Homework_2.Classes.Implementations;

namespace Homework_2.Classes.Definitions
{
    abstract class BaseLibrary : IComparable<BaseLibrary>, ICountingBooks
    {
        private List<Section> sections;

        public List<Section> Sections
        {
            get
            {
                if (sections == null)
                {
                    sections = new List<Section>();
                }
                return sections;
            }
            set { sections = value; }
        }

        public BaseLibrary() : this(null) { }

        public BaseLibrary(List<Section> sections)
        {
            this.sections = sections;
        }

        public abstract int CompareTo(BaseLibrary library);

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"The library has {GetBooksCount()} books total\n\n");

            var sortedSections = Sections.OrderBy(s => s.GetBooksCount());

            foreach (Section s in sortedSections)
            {
                builder.Append($"{s}\n");
            }
            return builder.ToString();
        }

        public int GetBooksCount()
        {
            int booksCount = 0;
            foreach (Section s in sections)
            {
                booksCount += s.GetBooksCount();
            }
            return booksCount;
        }
    }
}
