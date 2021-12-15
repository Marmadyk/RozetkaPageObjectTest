using System.Linq;
using OpenQA.Selenium;
using RozetkaPageObjectTest.util;

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
            var topAmount = DataWriter.GetTopAmount();
            var amountInCart = driver.FindElement(totalAmountInCart).Text;
            int.TryParse(string.Join("", amountInCart.Where(c => char.IsDigit(c))), out int sumInCart);
            int.TryParse(string.Join("", topAmount.Where(x => char.IsDigit(x))), out int topAmountToCompare);
            bool compareAmountInCart = (sumInCart/27) < topAmountToCompare;
            return compareAmountInCart;
        }
    }
}
