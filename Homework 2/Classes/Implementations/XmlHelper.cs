using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Homework_2.Classes.Interfaces;

namespace Homework_2.Classes.Implementations
{
    class XmlHelper : IXmlHelper
    {
        public const string SECTION_TYPE = "type";
        public const string AUTHOR_NAME = "name";
        public const string BOOK_PAGES = "pages";
        public const string TAG_LIBRARY = "library";
        public const string TAG_SECTION = "section";
        public const string TAG_AUTHOR = "author";
        public const string TAG_BOOK = "book";


        public string ReadDataFromXml(string path)
        {
            XDocument doc = XDocument.Load(path);
            StringBuilder builder = new StringBuilder();

            if (doc.Root != null)
            {
                foreach (XElement section in doc.Root.Elements())
                {
                    XAttribute typeAttr = section.Attribute(SECTION_TYPE);
                    if (typeAttr != null)
                    {
                        builder.AppendLine($"Section {typeAttr.Value}");
                    }
                    foreach (XElement author in section.Elements())
                    {
                        XAttribute nameAttr = author.Attribute(AUTHOR_NAME);
                        if (nameAttr != null)
                        {
                            builder.AppendLine($"\tAuthor {nameAttr.Value}");
                        }
                        foreach (XElement book in author.Elements())
                        {
                            XAttribute pagesAttr = book.Attribute(BOOK_PAGES);
                            if (pagesAttr != null)
                                builder.AppendLine($"\t\t{book.Value} with {pagesAttr.Value}");
                        }
                    }
                }
            }

            return builder.ToString();
        }

        public void WriteDataToXml(string path, Library library)
        {
            XDocument doc = new XDocument();
            XElement tagLibrary = new XElement(TAG_LIBRARY);
            doc.Add(tagLibrary);

            foreach (Section section in library.Sections)
            {
                XElement tagSection = new XElement(TAG_SECTION);
                tagSection.Add(new XAttribute(SECTION_TYPE, section.Type));

                foreach (Author author in section.Authors)
                {
                    XElement tagAuthor = new XElement(TAG_AUTHOR);
                    tagAuthor.Add(new XAttribute(AUTHOR_NAME, author.Name));

                    foreach (Book book in author.Books)
                    {
                        XElement tagBook = new XElement(TAG_BOOK);
                        tagBook.Add(new XAttribute(BOOK_PAGES, book.Pages));
                        tagBook.SetValue(book.Title);
                        tagAuthor.Add(tagBook);
                    }

                    tagSection.Add(tagAuthor);
                }

                doc.Root.Add(tagSection);
            }

            doc.Save(path);
        }

        public void EditDataFromXml(string path)
        {
            XDocument doc = XDocument.Load(path);
            if (doc.Root != null)
            {
                foreach (XElement section in doc.Root.Elements())
                {
                    foreach (XElement author in section.Elements())
                    {
                        foreach (XElement book in author.Elements())
                        {
                            XAttribute pagesAttr = book.Attribute(BOOK_PAGES);
                            if (pagesAttr != null)
                            {
                                int pages = Int32.Parse(pagesAttr.Value);
                                book.SetAttributeValue(BOOK_PAGES, pages + 100);
                            }
                        }
                    }
                }
            }
            doc.Save(path);
        }

        public void RemoveDataFromXml(string path)
        {
            XDocument doc = XDocument.Load(path);
            if (doc.Root != null)
            {
                foreach (XElement section in doc.Root.Elements())
                {
                    foreach (XElement author in section.Elements())
                    {
                        XAttribute nameAttr = author.Attribute(AUTHOR_NAME);
                        if (nameAttr != null && nameAttr.Value == "Stephen King")
                        {
                            author.Remove();
                        }
                    }
                }
            }
            doc.Save(path);
        }
    }
}
