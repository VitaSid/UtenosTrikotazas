using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace UtenosTrikotazas.Page
{
    public class UTsearchResultPage : BasePage
    {
        IReadOnlyCollection<IWebElement> FilteredProducts => Driver.FindElements(By.CssSelector("div:nth-of-type(1)  .ng-binding.product-short-desc"));        
        private IWebElement MainHeading => Driver.FindElement(By.CssSelector(".main-heading"));  
        public UTsearchResultPage(IWebDriver webdriver) : base(webdriver) { }
               
        public void HideSearchFieldDropdownList()
        {
            MainHeading.Click();
        }

        [System.Obsolete]
        public void ClickOnProductToOpenProductPage()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div:nth-of-type(1)  .ng-binding.product-short-desc")));
            FilteredProducts.First().Click();
        }                                          
        public void VerifySearchResultsAreCorrect()
        {
            IList<string> _productList = new List<string>();

            foreach (IWebElement productList in FilteredProducts)
            {
                string product = productList.Text;
                _productList.Add(product);
                Assert.IsTrue(product.Contains("KAUKĖ"));
            }
        }        
    }
}
