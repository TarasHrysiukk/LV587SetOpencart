using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LV587SETOPENCART.Pages
{
    class AccountCreatedPage : ClassWithDriver
    {
        public IWebElement textAccountCreated { get { return driver.FindElement(By.CssSelector("#content > h1")); } }
        public IWebElement clickOnButtonContinue { get { return driver.FindElement(By.CssSelector(".pull-right > .btn.btn-primary")); } }

        public AccountCreatedPage(IWebDriver driver) : base(driver)
        {
        }

        public string AccountCreatedText()
        {
            return textAccountCreated.Text;
        }
        public void ClickOnButtonContinue()
        {
            clickOnButtonContinue.Click();
        }

    }
}
