using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UtenosTrikotazas.Page
{
    public class ShoppingBagPage : BasePage
    {
        private IWebElement productInCart => Driver.FindElement(By.CssSelector(".products-row a"));
        private IWebElement proceedToCheckOutButton => Driver.FindElement(By.CssSelector(".cart-btn"));        
        public ShoppingBagPage(IWebDriver webdriver) : base(webdriver) { }

        [System.Obsolete]
        public void ProceedToCheckOut()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-btn")));
            proceedToCheckOutButton.Click();
        }
        public void VerifyIfProductWasAddedToCart()
        {            
            Assert.IsTrue(productInCart.Text.Contains("KAUKĖ"), "Product was not added to cart, or wrong product was added");
        }        
    }
}
