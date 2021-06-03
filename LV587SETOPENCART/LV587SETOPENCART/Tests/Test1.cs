using LV587SETOPENCART.Pages;
using LV587SETOPENCART.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Tests
{
    class Test1
    {
        // Create a driver instance for chromedriver
        static IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {
            IWebDriver driver = new ChromeDriver();

            //Navigate to NashFormat.ua page
            driver.Navigate().GoToUrl("https://nashformat.ua/");

            //Maximize the window
            driver.Manage().Window.Maximize();
        }

        
        string currencySymbol = "";

        //constructor
        ClassWithDriver dr = new ClassWithDriver();
        LoginPage login = new LoginPage();
        //HeaderComponent header = new HeaderComponent(driver);
        //PageWithProducts productPage = new PageWithProducts(driver);
        //ProjectTools regex = new ProjectTools(driver);
        //ProductComponents product = new ProductComponents(driver);

        [Test]
        public void Test12()
        {
            driver.Navigate().GoToUrl("https://nashformat.ua/");
            Thread.Sleep(2000);
            //login
            login.InputEmailText("iva@new.com");
            login.InputPasswordText("qwerty");
            login.ClickOnLoginButton();

            ////Select category "Phones & PDAs"
            //header.ChooseCategory(CategoryMenu.PhonesAndPDAs);
            ////Select the product 'Iphone' from the product list
            //productPage.SelectProduct(productPage.SecondProductName);
            //// Select 'Euro' in dropdown 'Currency'.
            //header.SelectSearch();
            //header.CurrencyClickAndSelect(Currencies.EUR);
            //currencySymbol = "€";
            //bool trueCurrency = regex.PriceCurrency(product.ProductPrice(), currencySymbol);
            ////Verify that product price is displayed in euro
            //Assert.True(trueCurrency);

            //// Select 'Pound Sterling' in dropdown 'Currency'.
            //header.SelectSearch();
            //header.CurrencyClickAndSelect(Currencies.GBP);
            //currencySymbol = "£";
            //trueCurrency = regex.PriceCurrency(product.ProductPrice(), currencySymbol);
            ////Verify that product price is displayed in PoundsSterling
            //Assert.True(trueCurrency);

            //// Select 'US Dollars' in dropdown 'Currency'.
            //header.SelectSearch();
            //header.CurrencyClickAndSelect(Currencies.USD);
            //currencySymbol = "$";
            //trueCurrency = regex.PriceCurrency(product.ProductPrice(), currencySymbol);
            ////Verify that product price is displayed in USA Dollars 
            //Assert.True(trueCurrency);

            //driver.Close();
        }
    }
}
