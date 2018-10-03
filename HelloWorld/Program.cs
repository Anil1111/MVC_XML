using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;

namespace XmlCoutriesApp
{
    public class Program
    {
        List<string> completeList= new List<string>();
        readonly string xmlPath = ConfigurationManager.AppSettings["Path"];
        //string countryName, capitalName;
        public Program(){}
        public void XmlFileExistCreatorAndChecker()
        {
            bool fileExists = File.Exists(xmlPath);
            if (fileExists == false)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                XmlWriter writer = XmlWriter.Create(xmlPath, null);
            }
        }
        public List<string> Main(string countryName, string capitalName)
        { 
            XmlFileExistCreatorAndChecker(); //check if Xml file exists
            var saveObject = new XmlSave(countryName, capitalName);
            saveObject.SaveDataToXmlFile(xmlPath);
            var readObject = new XmlRead();
            completeList = readObject.ReadXml(xmlPath);
            return completeList;
        }
    }
}