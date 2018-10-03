using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace XmlCoutriesApp
{
    class XmlSave
    {
        private string countryName, capitalName;
        public XmlSave(string country, string capital)
        {
            countryName = country;
            capitalName = capital;
        }
        public void SaveDataToXmlFile(string _xmlPath)
        {
            if (!File.Exists(_xmlPath))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(_xmlPath, xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("CountriesDataBase");
                    xmlWriter.WriteStartElement("Country");
                    xmlWriter.WriteElementString("CountryName", countryName);
                    xmlWriter.WriteElementString("CapitalName", capitalName);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load(_xmlPath);
                XElement root = xDocument.Element("CountriesDataBase");
                IEnumerable<XElement> rows = root.Descendants("Country");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                   new XElement("Country",
                   new XElement("CountryName", countryName),
                   new XElement("CapitalName", capitalName)));
                xDocument.Save(_xmlPath);
            }
        }
    }
}