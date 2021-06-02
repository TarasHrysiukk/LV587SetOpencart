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


        public IWebElement FirstProduct { get; private set; } //  PageTitle ("Wish List")
        public IWebElement SecondProduct { get; private set; } // Name of product in first row
        

        public PageWithProducts(IWebDriver driver) : base(driver)
        {
            FirstProduct = driver.FindElement(By.CssSelector("#content .product-layout:first-child .caption h4"));
            SecondProduct = driver.FindElement(By.CssSelector(" #content .product-layout:nth-child(2) .caption h4"));
        }
        public void SelectProduct(IWebElement product) // Options [FirstProduct, SecondProduct]
        {
            product.Click();
        }
    }
}