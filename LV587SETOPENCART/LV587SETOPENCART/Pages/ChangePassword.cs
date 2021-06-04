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

        public IWebElement InputNewPassword { get; private set; }
        public IWebElement InputConfirmNewPassword { get; private set; }
        public IWebElement ContinueButtonChangePassword { get; private set; }

        public ChangePassword(IWebDriver driver) : base(driver)
        {
            InputNewPassword = driver.FindElement(By.CssSelector(".col-sm-10 #input-password"));
            InputConfirmNewPassword = driver.FindElement(By.CssSelector(".col-sm-10 #input-confirm"));
            ContinueButtonChangePassword = driver.FindElement(By.XPath("input[type*='submit']"));
        }

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

        public void InputPSSSS(string mmm)
        {
            InputNewPassword.SendKeys(mmm);
        }
    }
}
