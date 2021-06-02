using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class ChangePassword : ClassWithDriver
    {
        //input newPass + clear
        //input confirmPass+ clear

        //Click Continue button

        LoginPage loginPage;
        public IWebElement InputNewPassword { get; private set; }
        public IWebElement InputConfurmNewPassword { get; private set; }
        public IWebElement ContinueButtonChangePassword { get; private set; }

        public ChangePassword(IWebDriver driver) : base(driver)
        {
            loginPage = new LoginPage(driver);
            InputConfurmNewPassword = driver.FindElement(By.Id("input-confirm"));
            ContinueButtonChangePassword = driver.FindElement(By.XPath("input[type*='submit']"));
        }

        public void InputChangePasswordText(string pass)
        {
            loginPage.InputPasswordText(pass);
            InputConfurmNewPassword.Clear();
            InputConfurmNewPassword.SendKeys(pass);
        }

        public void ClickContinueButtonChangePassword()
        {
            ContinueButtonChangePassword.Click();
        }



    }
}
