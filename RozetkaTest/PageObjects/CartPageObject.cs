using System.Linq;
using OpenQA.Selenium;

namespace RozetkaPageObjectTest.PageObjects
{
    public class CartPageObject
    {
        private IWebDriver driver;

        private readonly By totalAmountInCart = By.CssSelector("div.cart-receipt__sum");

        public CartPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }


        public bool AmountInCart()
        {
            Waiters.WaitElement(driver, totalAmountInCart);
            var amountInCart = driver.FindElement(totalAmountInCart).Text;
            int.TryParse(string.Join("", amountInCart.Where(c => char.IsDigit(c))), out int sumInCart);
            bool compareAmountInCart = (sumInCart/27) < 50000;
            return compareAmountInCart;
        }
    }
}
