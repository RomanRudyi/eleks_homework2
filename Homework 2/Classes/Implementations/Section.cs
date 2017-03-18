using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_2.Classes.Definitions;

namespace Homework_2.Classes.Implementations
{
    class Section : BaseSection
    {
        public Section() : base() { }

        public Section(string type, List<Author> authors) : base(type, authors) { }

        public override int CompareTo(BaseSection section)
        {
            if (this.GetBooksCount() > section.GetBooksCount())
            {
                return 1;
            }
            else if (this.GetBooksCount() < section.GetBooksCount())
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
