using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace RozetkaPageObjectTest
{
    public static class Waiters
    {
        public static void WaitElement(IWebDriver driver, By locator, int second = 20)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(driver, TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
