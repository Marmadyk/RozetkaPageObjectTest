using OpenQA.Selenium;
using RozetkaPageObjectTest.util;

namespace RozetkaPageObjectTest.PageObjects
{
    public class HomePagePageObject
    {
        private IWebDriver driver;

        private readonly By searchBox = By.XPath("//input[@name='search']");
        private readonly By searchButton = By.XPath("//button[contains(@class,'search-form__submit')]");

        public HomePagePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }


        public SearchResultsPageObject Search()
        {
            driver.FindElement(searchBox).SendKeys(DataWriter.GetSearchText());
            driver.FindElement(searchButton).Click();
            return new SearchResultsPageObject(driver);
        }
    }
}
