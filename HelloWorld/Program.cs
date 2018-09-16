using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace XmlCoutriesApp
{
    public class Program
    {
        List<string> completeList= new List<string>();
        //string countryName, capitalName;
        public Program(){}
        public void XmlFileExistCreatorAndChecker()
        {
            bool fileExists = File.Exists("C:\\users\\CountriesInfo.xml");
            if (fileExists == false)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                XmlWriter writer = XmlWriter.Create("C:\\users\\CountriesInfo.xml", null);
            }
        }
        public List<string> Main(string countryName, string capitalName)
        { 
            XmlFileExistCreatorAndChecker(); //check if Xml file exists
            var saveObject = new XmlSave(countryName, capitalName);
            saveObject.SaveDataToXmlFile();
            var readObject = new XmlRead();
            completeList = readObject.ReadXml();
            return completeList;
        }
    }
}