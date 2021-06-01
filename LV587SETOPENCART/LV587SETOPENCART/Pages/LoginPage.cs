using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    public class LoginPage
    {

        //forgotten password 
        //input email + Click
        //input password + Click
        //Login button + Click

        public IWebElement loginInput;
        public IWebElement passwordInput;
        public IWebElement loginbutton;

        public IWebDriver driver;
        public IWebElement inputLogin { get; private set; }// { return driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]")); } }
        public IWebElement inputPass { get; private set; }// { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement loginButton { get; private set; }// { return driver.FindElement(By.Id("input-email")); } }
       
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            inputLogin = driver.FindElement(By.Id("input-email"));
            inputPass = driver.FindElement(By.Id("input-password"));
            loginButton = driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]"));
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
