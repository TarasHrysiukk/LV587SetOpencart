using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LV587SETOPENCART.Pages
{
    class ProductComponents
    {
        public IWebDriver driver;

        
        public IWebElement productPrice
        {
            get
            {
                return driver.FindElement(By.CssSelector("#content > div:nth-child(1) > div.col-sm-4 > ul:nth-child(4) > li:nth-child(1) > h2"));
            }
        }

        public IWebElement reviewButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("#content > div:nth-child(1) > div.col-sm-4 > div.rating > p > a:nth-child(6)"));
            }
        }

        public IWebElement userNameTextBox
        {
            get
            {
                return driver.FindElement(By.CssSelector("#input-name"));
            }
        }

        public IWebElement userReviewTextBox
        {
            get
            {
                return driver.FindElement(By.CssSelector("#input-review"));
            }
        }

        public IWebElement sendReview
        {
            get
            {
                return driver.FindElement(By.CssSelector("#button-review"));
            }
        }

        public IWebElement zeroRate
        {
            get
            {
                return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(2)"));
            }
        }

        public IWebElement firstRate
        {
            get
            {
                return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(3)"));
            }
        }

        public IWebElement secondRate
        {
            get
            {
                return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(4)"));
            }
        }

        public IWebElement thirdRate
        {
            get
            {
                return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(5)"));
            }
        }

        public IWebElement fourthRate
        {
            get
            {
                return driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > div > input[type=radio]:nth-child(6)"));
            }
        }

        //method get price 
        public int ProductPrice()
        {
            return int.Parse(productPrice.Text);
        }

        //method view review
        public void ViewReview()
        {
            reviewButton.Click();
        }

        //method write review (input name and etc..)
        public void WriteReview(string userName, string userReview, int rate)
        {
            userNameTextBox.Click();
            userNameTextBox.SendKeys(userName);

            userReviewTextBox.Click();
            userReviewTextBox.SendKeys(userReview);

            if (rate==0)
            {
                zeroRate.Click();
            }

            if(rate==1)
            {
                firstRate.Click();
            }

            if(rate==2)
            {
                secondRate.Click();
            }

            if(rate==3)
            {
                thirdRate.Click();
            }

            if(rate==4)
            {
                fourthRate.Click();
            }

            sendReview.Click();
        }
        // if the review is present 
        public bool reviewPresent()
        {
            var emptyReview = driver.FindElement(By.CssSelector("#review > p"));
            if(emptyReview.Text!= "There are no reviews for this product.")
            {
                return true;
            }

            return false;
        }
    }
}
