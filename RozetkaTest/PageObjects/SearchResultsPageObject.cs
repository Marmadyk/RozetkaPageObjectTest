using OpenQA.Selenium;
using RozetkaPageObjectTest.util;

namespace RozetkaPageObjectTest.PageObjects
{
    public class SearchResultsPageObject
    {
        private IWebDriver driver;

        private readonly By searchProducer = By.XPath("//span[normalize-space(text())='Бренд']/parent::button//following-sibling::div//input[contains(@class,'sidebar-search__input')]");
        private readonly By appleProducer = By.XPath("//a[contains(@href,'producer=apple')]/parent::li");
        private readonly By sortFromExpensiveToCheap = By.CssSelector("option[value~=expensive]");
        private readonly By addToCartButton = By.XPath("//button[contains(@class,'buy-button')]/ancestor::app-buy-button");
        private readonly By cartButton = By.XPath("//button[contains(@class,'header__button--active')]");
        private readonly By counterOfItemsInCart = By.XPath("//span[contains(@class,'counter')]");

        public SearchResultsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ChoseProducer()
        {
            Waiters.WaitElement(driver, searchProducer);
            driver.FindElement(searchProducer).SendKeys(DataWriter.GetProducer());
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
