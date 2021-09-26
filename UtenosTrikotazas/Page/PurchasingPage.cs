using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace UtenosTrikotazas.Page
{
    public class PurchasingPage : BasePage
    {
        private const string LPExpressMiestas = "Alytus"; //
        private const string LPExpressAddress = "Maxima XX (Naujoji g. 90, Alytus)";
        private const string PagePurchasingHistory = "https://www.utenostrikotazas.lt/pirkimu-istorija";        
        private IWebElement phoneNumberInputField => Driver.FindElement(By.CssSelector("input[name='phone']"));        
        private SelectElement SelectLPExpressCity => new SelectElement(Driver.FindElement(By.CssSelector("select[name='city']")));
        private SelectElement SelectPostMachine => new SelectElement(Driver.FindElement(By.CssSelector("select[name='address']")));
        private IWebElement paymentMethodSwedbank => Driver.FindElement(By.CssSelector("[title='Swedbank'] .payment-title"));
        private IWebElement checkBoxMetAndAgreeWithRules => Driver.FindElement(By.CssSelector(".agree-with-terms .checkbox-bg"));
        private IWebElement confirmPurchaseButton => Driver.FindElement(By.CssSelector(".cart-actions.ng-scope"));
        private IWebElement totalPurchaseSum => Driver.FindElement(By.XPath("//div[6]/span[2]"));
        IReadOnlyCollection <IWebElement> AllMandatoryInputs => Driver.FindElements(By.CssSelector(".form-control.ng-invalid.ng-invalid-required.ng-touched"));
        IReadOnlyCollection<IWebElement> PaymentMethodsList1 => Driver.FindElements(By.XPath("//div[@class='payment-methods.has-cod']/img"));
        IReadOnlyCollection<IWebElement> PaymentMethodsList2 => Driver.FindElements(By.XPath("//div[@class='payment-method ng-scope']/img"));
        
        public PurchasingPage(IWebDriver webdriver) : base(webdriver) { }
                
        public void FillPhoneNoField(string phoneNo)
        {
            phoneNumberInputField.Clear();
            phoneNumberInputField.SendKeys(phoneNo);
        }       
        public void SelectLP_ExpressCity()
        {
            SelectLPExpressCity.SelectByText(LPExpressMiestas);
        }
        public void SelectLPExpressAddress()
        {
            SelectPostMachine.SelectByText(LPExpressAddress);
        }
        public void SelectPaymentMethod()
        {
            paymentMethodSwedbank.Click();
        }
        public void CheckAgreeWithRules()
        {
            checkBoxMetAndAgreeWithRules.Click();
        }
        public void VerifyOrderWasPlacedSuccessfully()
        {
            string _totalOrderSumBeforeConfirmingPurchase = totalPurchaseSum.Text;

            confirmPurchaseButton.Click();

            if (Driver.Url != PagePurchasingHistory)
                Driver.Url = PagePurchasingHistory;

            string expectedOrderStatus = "Užsakymas priimtas";

            IReadOnlyCollection<IWebElement> OrderStatuses = Driver.FindElements(By.CssSelector(".order-status.text-left"));
            IWebElement actualLatestOrdertatus = OrderStatuses.First();
            string _actualLatestOrderStatus = actualLatestOrdertatus.Text;
            Assert.AreEqual(expectedOrderStatus, _actualLatestOrderStatus, "Latest order was not accepted");

            IReadOnlyCollection<IWebElement> OrdersSums = Driver.FindElements(By.CssSelector(".text-right.nowrap.ng-binding"));
            IWebElement LatestOrderSum = OrdersSums.First();
            string _LatestOrderSum = LatestOrderSum.Text;
            Assert.AreEqual(_totalOrderSumBeforeConfirmingPurchase, _LatestOrderSum, $" expected {_totalOrderSumBeforeConfirmingPurchase}, but was {_LatestOrderSum}");
            //Šis assertas kartais nepraeina, kai dėl kažkokių priežasčių prie užsakymo sumos nepridedamas pristatymo mokestis, o užsakymas vistiek priimamas.
        }

        public void VerifyAllPaymentMethodsArePresent()
        {    
            IList<string> _paymentMethods1 = new List<string>();
            foreach (IWebElement paymentMethods in PaymentMethodsList1)
            {
                string paymentMethod = paymentMethods.GetAttribute("alt");                
                _paymentMethods1.Add(paymentMethod);                

                IList<string> expectedPaymentMethods1 = new List<string>() { "SwedBank", "Mokėjimas pristatymo metu", "SEB", "DNB", "Paysera", "Paypal", "Kreditinė kortelė" };
                                
                CollectionAssert.AreEquivalent(expectedPaymentMethods1, _paymentMethods1, "Some payment methods from List1 are missing");
                //CollectionAssert.Contains(expectedPaymentMethods1, _paymentMethods1);
            }
            IList<string> _paymentMethods2 = new List<string>();
            foreach (IWebElement paymentMethods in PaymentMethodsList2)
            {
                string paymentMethod = paymentMethods.GetAttribute("alt");
                _paymentMethods2.Add(paymentMethod);

                IList<string> expectedPaymentMethods2 = new List<string>() { "AB Citadele bankas", "AB Danske bankas", "AB Nordea bankas", "AB Šiaulių bankas", "UAB Medicinos bankas" };

                CollectionAssert.AreEquivalent(expectedPaymentMethods2, _paymentMethods2, "Some payment methods from List2 are missing");
            }
        }
    }
}
