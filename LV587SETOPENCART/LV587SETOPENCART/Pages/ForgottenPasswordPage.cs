using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class ForgottenPasswordPage : ClassWithDriver
    {
        public IWebElement ContinueButton { get {return driver.FindElement(By.CssSelector("input[type='submit']")); } }
        public IWebElement InputEmail { get {return driver.FindElement(By.CssSelector(".col-sm-10 > input")); } }
        public IWebElement AlertMessage { get { return driver.FindElement(By.CssSelector(".alert-success:not(.fa-check-circle)")); } }

        public ForgottenPasswordPage(IWebDriver driver) : base(driver) { }

        public void ForgotPasswordEmail(string email)
        {
            InputEmail.Clear();
            InputEmail.SendKeys(email);
        }

        public void ClickOnContinueButton()
        {
            ContinueButton.Click();
        }

        public string AlertMessageText()
        {
            return AlertMessage.Text;
        }
    }
}
