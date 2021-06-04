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
        // Select first product from the page
        // Select second product from the page 


        public IWebElement FirstProductName { get; private set; } //  PageTitle ("Wish List")
        public IWebElement SecondProductName { get; private set; } // Name of product in first row
        public IWebElement CartButton { get; private set; }
        public IWebElement WishListButton { get; private set; }
        public IWebElement ProductPrice { get; private set; }

        public IWebElement MustLoginMessage { get {return driver.FindElement(By.CssSelector(".alert-success:not( .fa-check-circle)")); } }

        public PageWithProducts(IWebDriver driver) : base(driver)
        {
            FirstProductName = driver.FindElement(By.CssSelector("#content .product-layout:first-child .caption h4"));
            SecondProductName = driver.FindElement(By.CssSelector(" #content .product-layout:nth-child(2) .caption h4"));
            CartButton = driver.FindElement(By.CssSelector("#content .product-layout:first-child .button-group button[onclick*='cart']"));
            WishListButton = driver.FindElement(By.CssSelector("#content .product-layout:first-child .button-group button[onclick*='wish']"));
            ProductPrice = driver.FindElement(By.CssSelector("#content .product-layout:first-child p[class='price']:not(span.price-tax)"));
        }
        public void SelectProduct(IWebElement product) // Options [FirstProduct, SecondProduct]
        {
            product.Click();
        }
        public string GetSelectedProductName(IWebElement product) // Options [FirstProduct, SecondProduct]
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

        public string GetMustLoginMessageText()
        {
            return MustLoginMessage.Text;
        }

    }
}