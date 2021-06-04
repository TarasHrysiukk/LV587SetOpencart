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

        public IWebElement InputNewPassword { get {return driver.FindElement(By.CssSelector(".col-sm-10 #input-password")); } }
        public IWebElement InputConfirmNewPassword { get {return driver.FindElement(By.CssSelector(".col-sm-10 #input-confirm")); } }
        public IWebElement ContinueButtonChangePassword { get {return driver.FindElement(By.CssSelector("input[type*='submit']")); } }
        public IWebElement AlertMessage { get { return driver.FindElement(By.CssSelector(".alert-success:not(.fa-check-circle)")); } }


        public ChangePassword(IWebDriver driver) : base(driver) { }

        public void InputChangePasswordText(string pass)
        {
            InputNewPassword.Clear();
            InputNewPassword.SendKeys(pass);

            InputConfirmNewPassword.Click();
            InputConfirmNewPassword.Clear();
            InputConfirmNewPassword.SendKeys(pass);
        }

        public void ClickContinueButtonChangePassword()
        {
            ContinueButtonChangePassword.Click();
        }

        public string AlertMessageText()
        {
            return AlertMessage.Text;
        }
    }
}
