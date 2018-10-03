using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace XmlCoutriesApp
{
    class XmlRead
    {
        List<string> countryNamesList = new List<string>();
        List<string> capitalNamesList = new List<string>();
        List<string> fullList = new List<string>();

        public List<string> ReadXml(string _xmlPath)
        {
            if (File.Exists(_xmlPath))
            {
                XmlDocument oXmlDocument = new XmlDocument();
                oXmlDocument.Load(_xmlPath);
                XmlNodeList oCountryNodesList = oXmlDocument.GetElementsByTagName("Country");
                //Console.WriteLine("Countries saved in database: ");
                int countriesCount = oCountryNodesList.Count;
                foreach (XmlNode oCountry in oCountryNodesList)
                {
                    fullList.Add(oCountry.FirstChild.NextSibling.InnerText);
                    fullList.Add(oCountry.LastChild.PreviousSibling.InnerText);
                }
            }
            else
                Console.WriteLine("XML file not found!");
            return fullList;
        }
    }
}
