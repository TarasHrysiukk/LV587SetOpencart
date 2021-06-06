using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LV587SETOPENCART.Pages
{
    public enum RateChoose
    {
        badRate,
        poorRate,
        fairRate,
        goodRate,
        excellentRate,
        noRate
    }

    class ProductComponents : ClassWithDriver
    {

        public IWebElement ProductPrice { get { return driver.FindElement(By.CssSelector("#content > div:nth-child(1) > div.col-sm-4 > ul:nth-child(4) > li:nth-child(1) > h2")); } }
        //public IWebElement NoReviewsButton { get { return driver.FindElement(By.CssSelector("#content > div:nth-child(1) > div.col-sm-8 > ul.nav.nav-tabs > li:nth-child(3) > a")); } }
        public IWebElement ReviewsButton { get { return driver.FindElement(By.CssSelector("#content > div > div.col-sm-4 > div.rating > p > a:nth-child(6)")); } }
        public IWebElement UserNameTextBox { get { return driver.FindElement(By.CssSelector("#input-name")); } }
        public IWebElement UserReviewTextBox { get { return driver.FindElement(By.CssSelector("#input-review")); } }
        public IWebElement SendReview { get { return driver.FindElement(By.CssSelector("#button-review")); } }
        public IWebElement ZeroRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(2)")); } }
        public IWebElement FirstRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(3)")); } }
        public IWebElement SecondRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(4)")); } }
        public IWebElement ThirdRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(5)")); } }
        public IWebElement FourthRate { get { return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(6)")); } }
        public IWebElement Description { get { return driver.FindElement(By.CssSelector("#tab-description > p")); } }

        public IWebElement ErrorText { get { return driver.FindElement(By.CssSelector("#form-review > div.alert.alert-danger.alert-dismissible")); } }

        public IWebElement SuccessText { get { return driver.FindElement(By.CssSelector("#form-review > div.alert.alert-success.alert-dismissible")); } }

        public ProductComponents() { }
        public ProductComponents(IWebDriver driver) : base(driver)
        { }
        //method get price 
        public string GetProductPrice()
        {
            return ProductPrice.Text;
        }

        //method view reviews

        public void ReviewsClick()
        {
            ReviewsButton.Click();
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
                case RateChoose.noRate:
                    break;
            }

            SendReview.Click();
        }

        public bool DescriptionPresent()
        {
            if (Description.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // if the review is present 
        public bool ReviewPresent()
        {
            if (ReviewsButton.Text != "0 reviews")
            {
                return true;
            }

            return false;
        }

        public string GetErrorText()
        {
            return ErrorText.Text;
        }

        public string GetSuccessText()
        {
            return SuccessText.Text;
        }
    }
}
