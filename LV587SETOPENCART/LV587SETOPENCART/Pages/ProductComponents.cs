using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LV587SETOPENCART.Pages
{
    class ProductComponents : ClassWithDriver
    {

        public IWebElement ProductPrice { get { return driver.FindElement(By.CssSelector("#content > div:nth-child(1) > div.col-sm-4 > ul:nth-child(4) > li:nth-child(1) > h2")); } }
        public IWebElement ReviewButton { get { return driver.FindElement(By.CssSelector("#content > div:nth-child(1) > div.col-sm-4 > div.rating > p > a:nth-child(6)")); } }
        public IWebElement UserNameTextBox { get { return driver.FindElement(By.CssSelector("#input-name")); } }
        public IWebElement UserReviewTextBox { get { return driver.FindElement(By.CssSelector("#input-review")); } }
        public IWebElement SendReview { get { return driver.FindElement(By.CssSelector("#button-review")); } }
        public IWebElement ZeroRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(2)")); } }
        public IWebElement FirstRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(3)")); } }
        public IWebElement SecondRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(4)")); } }
        public IWebElement ThirdRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(5)")); } }
        public IWebElement FourthRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(6)")); } }
        public IWebElement EmptyReview { get { return driver.FindElement(By.CssSelector("#review > p")); } }
        public ProductComponents() { }
        public ProductComponents(IWebDriver driver) : base(driver)
        { }
        //method get price 
        public string GetProductPrice()
        {
            return ProductPrice.Text;
        }

        public enum RateChoose
        {
            badRate,
            poorRate,
            fairRate,
            goodRate,
            excellentRate
        }

        //method view review
        public void GetViewReview()
        {
            ReviewButton.Click();
        }

        //method write review (input name and etc..)
        public void WriteReview(string userName, string userReview, RateChoose rateChoose)
        {
            UserNameTextBox.Click();
            UserNameTextBox.SendKeys(userName);

            UserReviewTextBox.Click();
            UserReviewTextBox.SendKeys(userReview);

            switch (rateChoose)
            {
                case RateChoose.badRate:
                    ZeroRate.Click();
                    break;
                case RateChoose.poorRate:
                    FirstRate.Click();
                    break;
                case RateChoose.fairRate:
                    SecondRate.Click();
                    break;
                case RateChoose.goodRate:
                    ThirdRate.Click();
                    break;
                case RateChoose.excellentRate:
                    FourthRate.Click();
                    break;
            }

            SendReview.Click();
        }



        // if the review is present 
        public bool reviewPresent()
        {
            if (EmptyReview.Text != "There are no reviews for this product.")
            {
                return true;
            }

            return false;
        }
    }
}
