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

        public IWebElement PageTitle { get; private set; } //  PageTitle ("Wish List")
        public IWebElement ProductName { get; private set; } // Name of product in first row
        public IWebElement UnitPrice { get; private set; } // Unit Price of product in first row
        public IWebElement AddToCartButton { get; private set; } // Select AddToCart Button in a first row
        public IWebElement RemoveButton { get; private set; } // Select Remove Button in a first row
        public IWebElement ContinueButton { get; private set; } // Select Continue Button 

        public WishListPage(IWebDriver driver) : base(driver)
        {
            PageTitle = driver.FindElement(By.CssSelector("#content h2"));
            ProductName = driver.FindElement(By.CssSelector(".table-hover tr:first-child  td.text-left a"));
            UnitPrice = driver.FindElement(By.CssSelector("tr:first-child .price"));
            AddToCartButton = driver.FindElement(By.CssSelector("tr:first-child .fa-shopping-cart"));
            RemoveButton = driver.FindElement(By.CssSelector("tr:first-child .fa-times"));
            ContinueButton = driver.FindElement(By.CssSelector(".pull-right .btn"));
        }

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
    }
}
