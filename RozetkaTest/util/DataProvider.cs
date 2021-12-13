using System;
using System.Linq;
using System.Xml.Linq;

namespace RozetkaPageObjectTest.util
{
    public class DataProvider
    {
        public string Mname;
        public string Name
        {
            get => Mname;
            set
            {
                XDocument xdoc = XDocument.Load("laptop.xml");
                var items = from xe in xdoc.Element("laptops").Elements("data")
                            where xe.Element("company").Value == "Apple"
                            select new DataProvider
                            {
                                Name = xe.Attribute("name").Value,
                            };
                foreach (var item in items)
                    Mname = item;
            }
        }
        public string Producer { get; set; }
        public string Counter { get; set; }
        public string Amount { get; set; }


        public string ProvideData()
        {
            DataProvider dt = new DataProvider();
            return dt.Name;
            //XDocument xdoc = XDocument.Load("laptop.xml");
            //var items = from xe in xdoc.Element("laptops").Elements("data")
            //            where xe.Element("company").Value == "Apple"
            //            select new DataProvider
            //            {
            //                Name = xe.Attribute("name").Value,
            //            };
            //return Name;
        }

        public static implicit operator string(DataProvider v)
        {
            throw new NotImplementedException();
        }
    }
}
