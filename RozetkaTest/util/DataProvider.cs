using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using OpenQA.Selenium;

namespace RozetkaPageObjectTest.util
{
    public class DataProvider
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Counter { get; set; }
        public string Amount { get; set; }

        public IEnumerable ProvideData()
        {
            XDocument xdoc = XDocument.Load("testData.xml");
            var items = from xe in
                            xdoc.Element("testData").Elements("data")
                        where
                        xe.Element("producer").Value == "Apple"
                        select new DataProvider
                        {
                            Name = xe.Attribute("name").Value,
                            Producer = xe.Element("producer").Value,
                            Counter = xe.Element("counter").Value,
                            Amount = xe.Element("topAmount").Value
                        };
            foreach (var item in items)
            {
                yield return item.Name;
                yield return item.Producer;
                yield return item.Counter;
                yield return item.Amount;
            }
                        
        }
        public string GetName()
        {
            DataProvider dt = new DataProvider();
            return dt.Name;
        }
    }
}
