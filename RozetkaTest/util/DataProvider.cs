using System.Linq;
using System.Xml.Linq;

namespace RozetkaPageObjectTest.util
{
    public class DataProvider
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Counter { get; set; }
        public string TopAmount { get; set; }
    }

    public static class DataWriter
    {
        public static string GetSearchText()
        {
            string temp = "";
            XDocument xdoc = XDocument.Load("laptop.xml");
            var items = from xe in xdoc.Element("laptops").Elements("data")
                        where xe.Element("company").Value == "Apple"
                        select new DataProvider
                        {
                            Name = xe.Attribute("name").Value
                        };

            foreach (var item in items)
                temp = item.Name;
            return temp;
        }

        public static string GetCounter()
        {
            string temp = "";
            XDocument xdoc = XDocument.Load("laptop.xml");
            var items = from xe in xdoc.Element("laptops").Elements("data")
                        where xe.Element("company").Value == "Apple"
                        select new DataProvider
                        {
                            Counter = xe.Element("counter").Value
                        };

            foreach (var item in items)
                temp = item.Counter;
            return temp;
        }

        public static string GetProducer()
        {
            string temp = "";
            XDocument xdoc = XDocument.Load("laptop.xml");
            var items = from xe in xdoc.Element("laptops").Elements("data")
                        where xe.Element("company").Value == "Apple"
                        select new DataProvider
                        {
                            Producer = xe.Element("company").Value
                        };

            foreach (var item in items)
                temp = item.Producer;
            return temp;
        }

        public static string GetTopAmount()
        {
            string temp = "";
            XDocument xdoc = XDocument.Load("laptop.xml");
            var items = from xe in xdoc.Element("laptops").Elements("data")
                        where xe.Element("company").Value == "Apple"
                        select new DataProvider
                        {
                            TopAmount = xe.Element("topAmount").Value
                        };

            foreach (var item in items)
                temp = item.TopAmount;
            return temp;
        }
    }
}
