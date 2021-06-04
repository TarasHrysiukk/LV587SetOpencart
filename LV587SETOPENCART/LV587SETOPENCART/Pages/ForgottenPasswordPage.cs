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
       // LoginPage loginPage;
        //public IWebElement TitleForgotPassword { get; private set; }
        public IWebElement ContinueButton { get {return driver.FindElement(By.CssSelector("input[type='submit']")); } }
        public IWebElement InputEmail { get {return driver.FindElement(By.CssSelector(".col-sm-10 > input")); } }

        public ForgottenPasswordPage(IWebDriver driver) : base(driver)
        {
            //InputEmail = driver.FindElement(By.CssSelector(".col-sm-10 > input"));
            //TitleForgotPassword = driver.FindElement(By.CssSelector("#content h1"));
            //ContinueButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            //loginPage = new LoginPage(driver);
        }

        public void ForgotPasswordEmail(string email)
        {
            InputEmail.Clear();
            InputEmail.SendKeys(email);
        }

        public void ClickOnContinueButton()
        {
            ContinueButton.Click();
        }

        //public void InputEmailText(string email)
        //{
        //    InputEmail.Clear();
        //    InputEmail.SendKeys(email);
        //}
    }
}
