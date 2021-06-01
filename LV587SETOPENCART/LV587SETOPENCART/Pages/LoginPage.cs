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


        public IWebElement inputLogin { get { return driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]")); } }
        public IWebElement inputPass { get { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement loginButton { get { return driver.FindElement(By.Id("input-email")); } }

        public LoginPage(IWebDriver driver) :base(driver)
        {
           //поки параша не трогайте мій мусор
            inputLogin = driver.FindElement(By.Id("input-email"));
            inputPass = driver.FindElement(By.Id("input-password"));
            loginButton = driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]"));
            // :)
        }

        //input Email
        public void InputEmail(string email)
        {
            inputLogin.Clear();
            inputLogin.SendKeys(email);
        }

        //input Password
        public void InputPassword(string pass)
        {
            inputPass.Clear();
            inputPass.SendKeys(pass);
        }

        //Click Login Button
        public void ClickOnLoginButton()
        {
            loginButton.Click();
        }
    }
}
