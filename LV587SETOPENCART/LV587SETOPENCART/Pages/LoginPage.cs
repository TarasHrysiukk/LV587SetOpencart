using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class LoginPage
    {

        //forgotten password 
        //input email + Click
        //input password + Click
        //Login button + Click

        public IWebDriver driver;
        public IWebElement inputLogin { get; private set; }
        public IWebElement inputPass { get; private set; }
        public IWebElement loginButton { get; private set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            inputLogin = driver.FindElement(By.Id("input-email"));
            inputPass = driver.FindElement(By.Id("input-password"));
            loginButton = driver.FindElement(By.XPath("//input[contains(@type,\"submit\")]"));
            // :)
        }

        //input Email
        public void InputEmail()
        {
            inputLogin.Clear();
            inputLogin.SendKeys("user1@gmal.com");
        }

        //input Password
        public void InputPassword()
        {
            inputPass.Clear();
            inputPass.SendKeys("qwerty");
        }
    }
}
