using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class WishListPage: ClassWithDriver
    {
        //remember product name (put insude string variable)!!!!!!!!!!!!!!!!!!!!!!!!!
        //delethed first element (button)
        //Check title of page (Wish List)
        //add to cart element (button)
        //method ( get unit price first child )
        //button Continue (return My Account)

        public IWebElement PageTitle { get { return driver.FindElement(By.CssSelector("#content h2")); } } //  PageTitle ("Wish List")
        public IWebElement ProductName { get { return driver.FindElement(By.CssSelector(".table-hover tr:first-child  td.text-left a")); } } // Name of product in first row
        public IWebElement UnitPrice { get { return driver.FindElement(By.CssSelector("tr:first-child .price")); } } // Unit Price of product in first row
        public IWebElement AddToCartButton { get { return driver.FindElement(By.CssSelector("#content tr:first-child button")); } } // Select AddToCart Button in a first row
        public IWebElement RemoveButton { get { return driver.FindElement(By.CssSelector("#content tr:first-child .btn-danger")); } } // Select Remove Button in a first row
        public IWebElement ContinueButton { get { return driver.FindElement(By.CssSelector("#content .pull-right .btn-primary")); } } // Select Continue Button 

        public IWebElement AlertMessage { get { return driver.FindElement(By.CssSelector(".alert-success:not( .fa-check-circle)")); } }
        public WishListPage(IWebDriver driver) : base(driver) { }

        //Get Page Title
        public string GetPageTitle()
        {
            return PageTitle.Text;
        }
        //Get Product Name
        public string GetProductName()
        {
            return ProductName.Text;
        }
        // Get Unit Price
        public string GetUnitPrice()
        {
            return UnitPrice.Text;
        }
        // Remove product from WishList
        public void RemoveProduct()
        {
            RemoveButton.Click();
        }
        // Add to Cart method
        public void AddToCart()
        {
            AddToCartButton.Click();
        }
        //Press button Continue (return My Account)
        public void Continue()
        {
            ContinueButton.Click();
        }
        //Alert message if product was removed
        public string GetAlertMessageText()
        {
            return AlertMessage.Text;
        }

    }
}
