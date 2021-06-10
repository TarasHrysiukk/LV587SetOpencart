using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class PageWithProducts : ClassWithDriver
    {
        //Here we create public autoproperties with path to elements on the page
        public IWebElement FirstProductName { get { return driver.FindElement(By.CssSelector("#content .product-layout:first-child .caption h4 a")); } } 
        public IWebElement SecondProductName { get { return driver.FindElement(By.CssSelector(" #content .product-layout:nth-child(2) .caption h4 a")); } } // Name of product in first row
        public IWebElement CartButton { get { return driver.FindElement(By.CssSelector("#content .product-layout:first-child .button-group button[onclick*='cart']")); } }
        public IWebElement WishListButton { get { return driver.FindElement(By.CssSelector("#content .product-layout:first-child .button-group button[onclick*='wish']")); } }
        public IWebElement ProductPrice { get { return driver.FindElement(By.CssSelector("#content .product-layout:first-child p[class='price']:not(span.price-tax)")); } }
        public IWebElement AlertMessage { get {return driver.FindElement(By.CssSelector(".alert-success:not( .fa-check-circle)")); } }

        public IWebElement CompareButtonHTCOne { get { return driver.FindElement(By.CssSelector("#content > div:nth-child(3) > div:nth-child(1) > div button:nth-child(3) > i")); } }
        public IWebElement CompareButtonIphone { get { return driver.FindElement(By.CssSelector("#content .product-layout:nth-child(2) .button-group button[onclick*='compare']")); } }
        public IWebElement ProductComparisonButton { get { return driver.FindElement(By.CssSelector(".form-group a[href*='/compare']")); } }
        public PageWithProducts(IWebDriver driver) : base(driver) { }
        public string GetProductComparisonText()
        {
            return ProductComparisonButton.Text;
        }
        public void SelectProduct(IWebElement product) // Options [FirstProduct, SecondProduct]
        {
            product.Click();
        }
        public string GetSelectedProductName(IWebElement product) 
        {
            return product.Text;
        }
        public void ClickCartButton()
        {
            CartButton.Click();
        }
        public void ClickWishListButton()
        {
            WishListButton.Click();
        }
        public string GetPrice()
        {
            return ProductPrice.Text;
        }
        public string GetFirstProductName()
        {
            return FirstProductName.Text;
        }

        public string GetAlertMessageText()
        {
            return AlertMessage.Text;
        }

    }
}