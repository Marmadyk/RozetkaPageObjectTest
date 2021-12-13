using OpenQA.Selenium;

namespace RozetkaPageObjectTest.PageObjects
{
    public class HomePagePageObject
    {
        private IWebDriver driver;

        private readonly By searchBox = By.XPath("//input[@name='search']");
        private readonly By searchButton = By.XPath("//button[contains(@class,'search-form__submit')]");

        public const string searchText = "laptop";

        public HomePagePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }


        public SearchResultsPageObject Search()
        {
            driver.FindElement(searchBox).SendKeys(searchText);
            driver.FindElement(searchButton).Click();
            return new SearchResultsPageObject(driver);
        }
    }
}
