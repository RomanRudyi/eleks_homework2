using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Homework_2.Classes.Implementations;

namespace Homework_2
{
    class Program
    {
        public const string FILE_PATH = "Library.xml"; 

        static void Main(string[] args)
        {
            Author stehpenKing = new Author("Stephen King", new List<Book>()
            {
                new Book("11/22/63", 894),
                new Book("It", 1340),
                new Book("Joyland", 317),
                new Book("Revival", 413)
            });

            Author maxKidruk = new Author("Max Kidruk", new List<Book>()
            {
                new Book("Bot", 434),
                new Book("Stronghold", 390)
            });

            Section thrillers = new Section("Thillers", new List<Author>()
            {
                stehpenKing,
                maxKidruk
            });

            Author jeffSutherland = new Author("Jeff Sutherland", new List<Book>()
            {
                new Book("Scrum", 278)
            });

            Author jeffreyRichter = new Author("Jeffrey Richter", new List<Book>()
            {
                new Book("CLR via C#", 895)
            });

            Author steveMcConnell = new Author("Steve McConnell", new List<Book>()
            {
                new Book("Code complete", 880)
            });

            Section education = new Section("Education", new List<Author>()
            {
                jeffSutherland,
                jeffreyRichter,
                steveMcConnell
            });

            Library library = new Library(new List<Section>()
            {
                thrillers,
                education
            });

            Console.Write(library);

            Console.WriteLine("Searching using LINQ to Objects:");

            library.ShowBiggestSection();
            library.ShowHardworkingAuthor();
            library.ShowThinnestBook();

            XmlHelper helper = new XmlHelper();

            //Write library data to the XML document
            helper.WriteDataToXml(FILE_PATH, library);

            Console.WriteLine("\nThe Library class was written to the XML file:");
            //Read data from the XML document
            Console.WriteLine(helper.ReadDataFromXml(FILE_PATH));

            Console.WriteLine("Increase count of pages of each book for 100 pages:");
            // Increase count of pages of each book for 100
            helper.EditDataFromXml(FILE_PATH);

            //Read data from the XML document
            Console.WriteLine(helper.ReadDataFromXml(FILE_PATH));

            Console.WriteLine("Remove author \"Stephen King\" and all his books from the XML document:");
            //Remove author "Stephen King" and all his books from the XML document
            helper.RemoveDataFromXml(FILE_PATH);

            //Read data from the XML document
            Console.WriteLine(helper.ReadDataFromXml(FILE_PATH));

            Console.Read();
        }
    }
}
