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
        /*
        private IWebElement inputLogin;
        private IWebElement inputPass;
        private IWebElement loginButton;*/

        public IWebElement InputLogin { get; private set; }// { return driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]")); } }
        public IWebElement InputPass { get; private set; }// { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement LoginButton { get; private set; }// { return driver.FindElement(By.Id("input-email")); } }

        public LoginPage(IWebDriver driver) :base(driver)
        {
            InputLogin = driver.FindElement(By.Id("input-email"));
            InputPass = driver.FindElement(By.Id("input-password"));
            LoginButton = driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]"));
        }
        
        //input Email
        public void InputEmail(string email)
        {
            InputLogin.Clear();
            InputLogin.SendKeys(email);
        }

        //input Password
        public void InputPassword(string pass)
        {
            InputPass.Clear();
            InputPass.SendKeys(pass);
        }

        //Click Login Button
        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }
    }
}
