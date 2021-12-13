using System.Linq;
using System.Xml.Linq;

namespace RozetkaPageObjectTest.util
{
    public class DataProvider
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Counter { get; set; }
        public string Amount { get; set; }


        public string ProvideData()
        {
            XDocument xdoc = XDocument.Load("laptop.xml");
            var items = from xe in xdoc.Element("laptops").Elements("data")
                        where xe.Element("company").Value == "Apple"
                        select new DataProvider
                        {
                            Name = xe.Attribute("name").Value,
                        };
            return Name;
        }
        
    }
}
