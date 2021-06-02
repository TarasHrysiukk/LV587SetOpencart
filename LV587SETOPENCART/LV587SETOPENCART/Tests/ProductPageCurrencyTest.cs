using LV587SETOPENCART.Pages;
using LV587SETOPENCART.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace LV587SETOPENCART.Tests.Pages
{
    public class Browser_ops
    {
        IWebDriver webDriver;
        public void Init_Browser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
        [OneTimeSetUp]
        public void SetUp()
        {

        }

        [TestFixture]
        public class ProductPageCurrencyTest
        {
           
           
            Browser_ops browser = new Browser_ops();
            public void main() {
                string currencySymbol = "";
                String test_url = "https://demo.opencart.com/";
                LoginPage login = new LoginPage(browser.webDriver);
                HeaderComponent header = new HeaderComponent(browser.webDriver);
                PageWithProducts productPage = new PageWithProducts(browser.webDriver);
                ProjectTools regex = new ProjectTools(browser.webDriver);
                ProductComponents product = new ProductComponents(browser.webDriver);

                [Test]
                void Test1()
                {
                    
                    browser.Init_Browser();
                    browser.Goto(test_url);
                    //login
                    login.InputEmailText("iva@new.com");
                    login.InputPasswordText("qwerty");
                    login.ClickOnLoginButton();

                    //Select category "Phones & PDAs"
                    header.ChooseCategory(CategoryMenu.PhonesAndPDAs);
                    //Select the product 'Iphone' from the product list
                    productPage.SelectProduct(productPage.SecondProduct);
                    // Select 'Euro' in dropdown 'Currency'.
                    header.SelectSearch();
                    header.CurrencyClickAndSelect(Currencies.EUR);
                    currencySymbol = "€";
                    bool trueCurrency = regex.PriceCurrency(product.ProductPrice(),currencySymbol);
                    //Verify that product price is displayed in euro
                    Assert.True(trueCurrency);

                    // Select 'Pound Sterling' in dropdown 'Currency'.
                    header.SelectSearch();
                    header.CurrencyClickAndSelect(Currencies.GBP);
                    currencySymbol = "£";
                    trueCurrency = regex.PriceCurrency(product.ProductPrice(), currencySymbol);
                    //Verify that product price is displayed in PoundsSterling
                    Assert.True(trueCurrency);

                    // Select 'US Dollars' in dropdown 'Currency'.
                    header.SelectSearch();
                    header.CurrencyClickAndSelect(Currencies.USD);
                    currencySymbol = "$";
                    trueCurrency = regex.PriceCurrency(product.ProductPrice(), currencySymbol);
                    //Verify that product price is displayed in USA Dollars 
                    Assert.True(trueCurrency);

                    browser.Close();
                }
            }
        }
    }
}
