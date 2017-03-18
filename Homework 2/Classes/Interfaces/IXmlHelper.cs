using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_2.Classes.Implementations;

namespace Homework_2.Classes.Interfaces
{
    interface IXmlHelper
    {
        string ReadDataFromXml(String path);
        void WriteDataToXml(String path, Library library);
        void EditDataFromXml(String path);
        void RemoveDataFromXml(String path);
    }
}
