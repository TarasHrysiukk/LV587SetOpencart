using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class CartPage : ClassWithDriver
    {
        //Quantity fiela
        //Unit Price (only first row)
        //Total price (down total)

        //Update button
        //remove button
        public IWebElement Quantity { get; private set; }
        public IWebElement RefreshButton { get; private set; }
        public IWebElement RemoveInCartButton { get; private set; }
        public IWebElement CartButtonSum { get; private set; }
        public IWebElement EmptyCart { get; private set; }
        public IWebElement TotalPrice { get; private set; }

        public CartPage(IWebDriver driver) : base(driver)
        {
            Quantity.FindElement(By.XPath("//input[@name='quantity[31]']"));
            RefreshButton.FindElement(By.CssSelector(".fa-refresh"));
            RemoveInCartButton.FindElement(By.CssSelector(".fa-times-circle"));
            CartButtonSum.FindElement(By.CssSelector(".table-responsive .table-bordered tbody tr > td:last-child"));
            EmptyCart.FindElement(By.CssSelector("#content > p"));
            TotalPrice.FindElement(By.CssSelector(".col-sm-offset-8 .table-bordered tr:nth-child(4) td:nth-child(2)"));
            //.col-sm-offset-8 .table-bordered tr:nth-child(4) td:nth-child(2) Total Price
        }
        public void QuantityInput(string quantity)
        {
            Quantity.Clear();
            Quantity.SendKeys(quantity);
        }
        public void RefreshButtonClick() 
        {
            RefreshButton.Click();
        }
        public void RemoveCircleInCartButton()
        {
            RemoveInCartButton.Click();
        }
        public string GetCartButtonSum()
        {
            return CartButtonSum.Text;
        }
        public string EmptyCartMessage()
        {
            return EmptyCart.Text;
        }
        public string GetTotalPrice()
        {
            return TotalPrice.Text;
        }
    }
}
