using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class ProductComparisonPage : ClassWithDriver
    {
        //use method from header component to choose category (Phone)
        //method choose firrst product and click on add to comparison
        //method choose second product and click on add to comparison

        //click on label product comparison (add waite)
        public IWebElement FirstProductName {get { return driver.FindElement(By.CssSelector(".table.table-bordered a[href*='/htc-touch-hd']")); } }
        public IWebElement SecondProductName { get { return driver.FindElement(By.CssSelector(".table.table-bordered a[href*='iphone']")); } }
        public IWebElement Product { get { return driver.FindElement(By.CssSelector("a[href*='/htc-touch-hd'] strong")); } }
        public IWebElement Image { get { return driver.FindElement(By.CssSelector(".text-center img")); } }
        public IWebElement Price { get { return driver.FindElement(By.CssSelector(".table-bordered tbody tr:nth-child(3) td:last-child")); } }
        public IWebElement Model { get { return driver.FindElement(By.CssSelector(".table-bordered tbody tr:nth-child(4) td:last-child")); } }
        public IWebElement Brand { get { return driver.FindElement(By.CssSelector(".table-bordered tbody tr:nth-child(5) td:last-child")); } }
        public IWebElement Availability { get { return driver.FindElement(By.CssSelector(".table-bordered tbody tr:nth-child(6) td:last-child")); } }
        public IWebElement Rating { get { return driver.FindElement(By.CssSelector(".table-bordered tbody tr:nth-child(7) td:last-child")); } }
        public IWebElement Summary { get { return driver.FindElement(By.CssSelector(".table-bordered tbody tr:nth-child(8) td:last-child")); } }
        public IWebElement Weight { get { return driver.FindElement(By.CssSelector(".table-bordered tbody tr:nth-child(9) td:last-child")); } }
        public IWebElement Dimensions { get { return driver.FindElement(By.CssSelector(".table-bordered tbody tr:nth-child(10) td:last-child")); } }

        public ProductComparisonPage(IWebDriver driver) : base(driver) { }

        public void ClickButton(IWebElement product)
        {
            product.Click();
        }

        public string GetSelectedProductName(IWebElement product)
        {
            return product.Text;
        }
        public string GetDimensions()
        {
            return Dimensions.Text;
        }
        public string GetProduct()
        {
            return Product.Text;
        }
        public string GetImage()
        {
            return Image.Text;
        }
        public string GetPrice()
        {
            return Price.Text;
        }
        public string GetModel()
        {
            return Model.Text;
        }
        public string GetBrand()
        {
            return Brand.Text;
        }
        public string GetAvailability()
        {
            return Availability.Text;
        }
        public string GetRating()
        {
            return Rating.Text;
        }
        public string GetSummary()
        {
            return Summary.Text;
        }
        public string GetWeight()
        {
            return Weight.Text;
        }

        //remember product name (put insude string variable) 

        //check title (Product Comparison)

        //check numb off column (3 (2 and 3 its a product))
    }
}
