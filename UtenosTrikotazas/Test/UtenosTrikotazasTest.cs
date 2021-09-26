using NUnit.Framework;
using System;

namespace UtenosTrikotazas.Test
{
    public class AvitelaTest : BaseTest
    {
        [Test]
        [Obsolete]
        public static void TestProductSearchResults()
        {
            _UTHomePage.NavigateToPage();
            _UTHomePage.CloseCookies();
            _UTHomePage.LoginToProfile("angrybird997799@gmail.com", "labaigerai753");
            _UTHomePage.SearchByText("kaukė");
            _UTsearchResultPage.HideSearchFieldDropdownList();
            _UTsearchResultPage.VerifySearchResultsAreCorrect();
        }

        [Test]
        [Obsolete]
        public static void TestProductWasAddedToShoppingCart()
        {
            _UTHomePage.NavigateToPage();
            _UTHomePage.CloseCookies();
            _UTHomePage.SearchByText("kaukė");
            _UTsearchResultPage.ClickOnProductToOpenProductPage();
            _productPage.AddProductToCartAndOpenCart();
            _shoppingBagPage.VerifyIfProductWasAddedToCart();
        }

        [Test]
        public static void TestAllPaymentMethodsArePresent()
        {
            _UTHomePage.NavigateToPage();
            _UTHomePage.CloseCookies();
            _UTHomePage.SearchByText("kaukė");
            _UTsearchResultPage.ClickOnProductToOpenProductPage();
            _productPage.AddProductToCartAndOpenCart();
            _shoppingBagPage.ProceedToCheckOut();
            _purchasingPage.VerifyAllPaymentMethodsArePresent();
        }

        [TestCase("kaukė", "+37069999999", TestName = "Test kaukė Order Was Placed Successfully")]
        [Obsolete]
        public static void TestOrderWasPlacedSuccessfully(string product, string phoneNo)
        {
            _UTHomePage.NavigateToPage();
            _UTHomePage.CloseCookies();
            _UTHomePage.LoginToProfile("angrybird997799@gmail.com", "labaigerai753");
            _UTHomePage.SearchByText(product);
            _UTsearchResultPage.ClickOnProductToOpenProductPage();
            _productPage.AddProductToCartAndOpenCart();
            _shoppingBagPage.ProceedToCheckOut();            
            _purchasingPage.FillPhoneNoField(phoneNo);            
            _purchasingPage.SelectLP_ExpressCity();
            _purchasingPage.SelectLPExpressAddress();
            _purchasingPage.SelectPaymentMethod();
            _purchasingPage.CheckAgreeWithRules();
            _purchasingPage.VerifyOrderWasPlacedSuccessfully();
        }            
    }
}
