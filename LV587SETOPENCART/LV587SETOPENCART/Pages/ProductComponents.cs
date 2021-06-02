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

        public IWebElement productPrice;
        public IWebElement reviewButton;
        public IWebElement userNameTextBox;
        public IWebElement userReviewTextBox;
        public IWebElement sendReview;
        public IWebElement zeroRate;
        public IWebElement firstRate;
        public IWebElement secondRate;
        public IWebElement thirdRate;
        public IWebElement fourthRate;
        public IWebElement emptyReview;
        public ProductComponents(IWebDriver driver) : base(driver)
        {
            productPrice = driver.FindElement(By.CssSelector("#content > div:nth-child(1) > div.col-sm-4 > ul:nth-child(4) > li:nth-child(1) > h2"));
            reviewButton = driver.FindElement(By.CssSelector("#content > div:nth-child(1) > div.col-sm-4 > div.rating > p > a:nth-child(6)"));
            userNameTextBox = driver.FindElement(By.CssSelector("#input-name"));
            userReviewTextBox = driver.FindElement(By.CssSelector("#input-review"));
            sendReview = driver.FindElement(By.CssSelector("#button-review"));
            zeroRate = driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(2)"));
            firstRate = driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(3)"));
            secondRate = driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(4)"));
            thirdRate = driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(5)"));
            fourthRate = driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(6)"));
            emptyReview = driver.FindElement(By.CssSelector("#review > p"));
        }


        //method get price 
        public int ProductPrice()
        {
            return int.Parse(productPrice.Text);
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
        public void ViewReview()
        {
            reviewButton.Click();
        }

        //method write review (input name and etc..)
        public void WriteReview(string userName, string userReview, RateChoose rateChoose)
        {
            userNameTextBox.Click();
            userNameTextBox.SendKeys(userName);

            userReviewTextBox.Click();
            userReviewTextBox.SendKeys(userReview);

            switch (rateChoose)
            {
                case RateChoose.badRate:
                    zeroRate.Click();
                    break;
                case RateChoose.poorRate:
                    firstRate.Click();
                    break;
                case RateChoose.fairRate:
                    secondRate.Click();
                    break;
                case RateChoose.goodRate:
                    thirdRate.Click();
                    break;
                case RateChoose.excellentRate:
                    fourthRate.Click();
                    break;
            }

            sendReview.Click();
        }



        // if the review is present 
        public bool reviewPresent()
        {
            if (emptyReview.Text != "There are no reviews for this product.")
            {
                return true;
            }

            return false;
        }
    }
}
