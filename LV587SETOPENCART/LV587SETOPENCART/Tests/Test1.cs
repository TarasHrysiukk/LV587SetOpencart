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
           

           
        }

        
        string currencySymbol = "";

        //constructor
        ClassWithDriver dr = new ClassWithDriver();
        LoginPage login = new LoginPage();
        HeaderComponent header = new HeaderComponent();
       PageWithProducts productPage = new PageWithProducts();
       ProjectTools regex = new ProjectTools();
        ProductComponents product = new ProductComponents();

        [Test]
        public void Test12()
        {
            //Navigate to NashFormat.ua page
            driver.Navigate().GoToUrl("https://demo.opencart.com/");

            //Maximize the window
            driver.Manage().Window.Maximize();
            driver.FindElement(By.CssSelector(".fa-user")).Click();
            driver.FindElement(By.CssSelector("a[href*='account/login']")).Click();
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
