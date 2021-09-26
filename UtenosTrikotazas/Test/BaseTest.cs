using UtenosTrikotazas.Drivers;
using UtenosTrikotazas.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace UtenosTrikotazas.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static UTHomePage _UTHomePage;
        public static UTsearchResultPage _UTsearchResultPage;
        public static ShoppingBagPage _shoppingBagPage;
        public static ProductPage _productPage;
        public static PurchasingPage _purchasingPage;

        [SetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetIncognitoChrome();
            _UTHomePage = new UTHomePage(driver);
            _UTsearchResultPage = new UTsearchResultPage(driver);
            _shoppingBagPage = new ShoppingBagPage(driver);
            _productPage = new ProductPage(driver);
            _purchasingPage = new PurchasingPage(driver);
        }                

        [TearDown]
        public static void TearDown()
        {
           //driver.Quit();
        }
    }
}

