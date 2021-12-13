using NUnit.Framework;
using OpenQA.Selenium;
using RozetkaPageObjectTest.PageObjects;

namespace RozetkaPageObjectTest
{
    public class Tests
    {
        private IWebDriver driver;
        private const string expectedCountOfItemsInCart = "1";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://rozetka.com.ua/ua/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var homePage = new HomePagePageObject(driver);
            homePage
                .Search();

            var searchPage = new SearchResultsPageObject(driver);
            searchPage
                .ChoseProducer();
            searchPage
                .SortItems();
            searchPage
                .AddToCart();
            searchPage
                .GoToCart();


            Assert.AreEqual(expectedCountOfItemsInCart, searchPage.AmountInCart(), "not enough items");

            var cartPage = new CartPageObject(driver);
            Assert.IsTrue(cartPage.AmountInCart());

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }


    }
}
