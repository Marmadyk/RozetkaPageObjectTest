using OpenQA.Selenium;
using RozetkaPageObjectTest.util;

namespace RozetkaPageObjectTest.PageObjects
{
    public class HomePagePageObject
    {
        private IWebDriver driver;

        private readonly By searchBox = By.XPath("//input[@name='search']");
        private readonly By searchButton = By.XPath("//button[contains(@class,'search-form__submit')]");

        //public const string searchText = "laptop";

        public HomePagePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }


        //patter fluent page object or fluent interface
        public SearchResultsPageObject Search()
        {
            DataProvider dt = new DataProvider();
            driver.FindElement(searchBox).SendKeys(dt.GetName());
            driver.FindElement(searchButton).Click();
            return new SearchResultsPageObject(driver);
        }
    }
}
