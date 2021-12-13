using System;
using System.Linq;
using OpenQA.Selenium;

namespace RozetkaPageObjectTest.PageObjects
{
    public class SearchResultsPageObject
    {
        private IWebDriver driver;

        private readonly By appleProducer = By.XPath("//a[contains(@href,'producer=apple')]/parent::li");
        private readonly By sortFromExpensiveToCheap = By.CssSelector("option[value~=expensive]");
        private readonly By addToCartButton = By.XPath("//button[contains(@class,'buy-button')]/ancestor::app-buy-button");
        private readonly By cartButton = By.XPath("//button[contains(@class,'header__button--active')]");
        private readonly By counterOfItemsInCart = By.XPath("//span[contains(@class,'counter')]");
        //private readonly By sortByList = By.XPath("//div[@data-filter-name='producer']//li");

        public SearchResultsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //public SearchResultsPageObject SortByProducerList(string producerName)
        //{
        //    Waiters.WaitElement(driver, sortByList);
        //    var sortBy = driver.FindElements(sortByList).First(x => x.Text == producerName);
        //    sortBy.Click();
        //    return this;
        //}

        public void ChoseProducer()
        {
            Waiters.WaitElement(driver, appleProducer);
            driver.FindElement(appleProducer).Click();
        }

        public void SortItems()
        {
            driver.FindElement(sortFromExpensiveToCheap).Click();
        }

        public void AddToCart()
        {
            Waiters.WaitElement(driver, addToCartButton);
            driver.FindElement(addToCartButton).Click();
        }

        public string AmountInCart()
        {
            Waiters.WaitElement(driver, counterOfItemsInCart);
            string amountInCart = driver.FindElement(counterOfItemsInCart).Text;
            return amountInCart;
        }

        public CartPageObject GoToCart()
        {
            Waiters.WaitElement(driver, cartButton);
            driver.FindElement(cartButton).Click();
            return new CartPageObject(driver);
        }
    }
}
