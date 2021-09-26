using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UtenosTrikotazas.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public WebDriverWait GetWait(int seconds = 7)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            return wait;
        }

        public void CloseBrowser()
        {
            //Driver.Quit();
        }
    }
}
