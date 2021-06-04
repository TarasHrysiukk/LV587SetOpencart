using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class LoginPage : ClassWithDriver
    {
        //forgotten password 
        //input email + Click
        //input password + Click
        //Login button + Click

        public IWebElement InputEmail { get { return driver.FindElement(By.Id("input-email")); } } // { return driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]")); } }
        public IWebElement InputPass { get {return driver.FindElement(By.Id("input-password")); } } // { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement LoginButton { get {return driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]")); } } // { return driver.FindElement(By.Id("input-email")); } }
        public IWebElement ForgottenPassButton { get {return driver.FindElement(By.CssSelector(".form-group a[href*='/forgotten'")); } }

      //  public IWebElement AlertMessage { get; private set; } forgot success

        public LoginPage(IWebDriver driver) : base(driver)
        {
            //InputEmail = driver.FindElement(By.Id("input-email"));
            //InputPass = driver.FindElement(By.Id("input-password"));
            //LoginButton = driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]"));
            //ForgottenPassButton = driver.FindElement(By.CssSelector(".form-group a[href*='/forgotten'"));
            //AlertMessage = driver.FindElement(By.CssSelector(".alert")); forgot success
        }

        //input Email
        public void InputEmailText(string email)
        {
            InputEmail.Clear();
            InputEmail.SendKeys(email);
        }

        //input Password
        public void InputPasswordText(string pass)
        {
            InputPass.Clear();
            InputPass.SendKeys(pass);
        }

        //Click Login Button
        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }

        //Fordotten password Click
        public void ClickForgotPassword()
        {
            ForgottenPassButton.Click();
        }

        //public string AlertMessageText()
        //{
        //    return AlertMessage.Text;
        //} 
    }
}
