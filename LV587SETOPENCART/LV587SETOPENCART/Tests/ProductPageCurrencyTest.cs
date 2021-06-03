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
       

       
        public class ProductPageCurrencyTest : ClassWithDriver
        {
            [OneTimeSetUp]
            public void SetUp()
            {
                IWebDriver webDriver;
                webDriver = new ChromeDriver();
            }
            Browser_ops browser = new Browser_ops();
            string currencySymbol = "";
            String test_url = "https://demo.opencart.com/";
            public static IWebDriver newdriver;
            //constructor
            public ProductPageCurrencyTest(IWebDriver driver) : base(driver) { newdriver = driver; }

            ClassWithDriver classw = new ClassWithDriver(newdriver);
                LoginPage login = new LoginPage(newdriver);
                HeaderComponent header = new HeaderComponent(newdriver);
                PageWithProducts productPage = new PageWithProducts(newdriver);
                ProjectTools regex = new ProjectTools(newdriver);
                ProductComponents product = new ProductComponents(newdriver);
            
            [Test]
            public void Test()
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
                productPage.SelectProduct(productPage.SecondProductName);
                // Select 'Euro' in dropdown 'Currency'.
                header.SelectSearch();
                header.CurrencyClickAndSelect(Currencies.EUR);
                currencySymbol = "€";
                bool trueCurrency = regex.PriceCurrency(product.ProductPrice(), currencySymbol);
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

            [Test]
            public void Test2()
            {
                browser.Init_Browser();
                browser.Goto(test_url);
                // Select 'Euro' in dropdown 'Currency'.
                header.SelectSearch();
                header.CurrencyClickAndSelect(Currencies.EUR);
                currencySymbol = "€";
                bool trueCurrency = regex.PriceCurrency(header.GetCurrencyName(Currencies.EUR), currencySymbol);
                //Verify that currency euro is in Drop-down
                Assert.True(trueCurrency);

                // Select 'Pound Sterling' in dropdown 'Currency'.
                header.SelectSearch();
                header.CurrencyClickAndSelect(Currencies.GBP);
                currencySymbol = "£";
                trueCurrency = regex.PriceCurrency(header.GetCurrencyName(Currencies.GBP), currencySymbol);
                //Verify that currency PoundSterling is in Drop-down
                Assert.True(trueCurrency);

                // Select 'US Dollars' in dropdown 'Currency'.
                header.SelectSearch();
                header.CurrencyClickAndSelect(Currencies.USD);
                currencySymbol = "$";
                trueCurrency = regex.PriceCurrency(header.GetCurrencyName(Currencies.USD), currencySymbol);
                //Verify that currency USA Dollars is in Drop-down 
                Assert.True(trueCurrency);

                browser.Close();
            }

            [Test]
            public void Test3()
            {
                browser.Init_Browser();
                browser.Goto(test_url);
                //login
                login.InputEmailText("iva@new.com");
                login.InputPasswordText("qwerty");
                login.ClickOnLoginButton();

                //Select category "Phones & PDAs"
                header.ChooseCategory(CategoryMenu.PhonesAndPDAs);
                //Add first product to cart from the product list
                productPage.ClickCartButton();
                // Open cart page
                header.ClickOnShoppingCartLink();

                // Select 'Euro' in dropdown 'Currency'.
                header.SelectSearch();
                header.CurrencyClickAndSelect(Currencies.EUR);
                currencySymbol = "€";



                bool trueCurrency = regex.PriceCurrency(product.ProductPrice(), currencySymbol);
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
    

