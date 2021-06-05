using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class CartButtonComponent : ClassWithDriver
    {
        //remove items button
        //view cart button

        //price total (sum)
        //price unit
        public IWebElement ProductNameInCart { get { return driver.FindElement(By.CssSelector(".table-striped .text-left :first-child")); } }
        public IWebElement TotalPriceInCart { get { return driver.FindElement(By.CssSelector(".table-bordered tbody > tr:last-child > td:last-child")); } }
        WishListPage removeButton;

        public CartButtonComponent(IWebDriver driver) : base(driver)
        {
           
        }

        public void RemoveButtonInCart()
        {
            removeButton.RemoveButton.Click();
        }
        public string GetProductNameInCart()
        {
            return ProductNameInCart.Text;
        }
        public string GetTotalPriceInCart()
        {
            return TotalPriceInCart.Text;
        }
    }
}
