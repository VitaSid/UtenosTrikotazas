using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UtenosTrikotazas.Page
{
    public class UTHomePage : BasePage
    {
        private const string PageAddress = "https://www.utenostrikotazas.lt/";      
        private IWebElement cookieButton => Driver.FindElement(By.CssSelector(".cookie-banner__accept-button"));
        private IWebElement profileIcon => Driver.FindElement(By.CssSelector(".right-header-link.profile-svg"));
        private IWebElement emailInputField => Driver.FindElement(By.CssSelector("input#l_email"));
        private IWebElement passwordInputField => Driver.FindElement(By.CssSelector("input#l_password"));
        private IWebElement loginButton => Driver.FindElement(By.CssSelector(".ng-valid-parse .form-submit"));
        private IWebElement searchField => Driver.FindElement(By.CssSelector(".search-input"));              
        public UTHomePage(IWebDriver webdriver) : base(webdriver)   { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }       
        public void CloseCookies()
        {
            cookieButton.Click();
        }
        public void LoginToProfile(string email, string password)
        {
            profileIcon.Click();
            emailInputField.Clear();
            emailInputField.SendKeys(email);
            passwordInputField.Clear();
            passwordInputField.SendKeys(password);
            loginButton.Click();
        }
        public void SearchByText(string text)
        {
            searchField.Clear();
            searchField.SendKeys(text);
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();
        }
    }
}
