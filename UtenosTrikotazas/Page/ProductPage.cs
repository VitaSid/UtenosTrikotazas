using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UtenosTrikotazas.Page
{
    public class ProductPage : BasePage
    {
        private IWebElement toCartButton => Driver.FindElement(By.CssSelector(".add-to-cart-text"));
        private IWebElement cartIcon => Driver.FindElement(By.CssSelector(".right-header-link.bag-svg"));               
        public ProductPage(IWebDriver webdriver) : base(webdriver) { }

        [System.Obsolete]
        public void AddProductToCartAndOpenCart()
        {
            toCartButton.Click();
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".right-header-link.bag-svg")));
            cartIcon.Click();
        }        
    }
}
