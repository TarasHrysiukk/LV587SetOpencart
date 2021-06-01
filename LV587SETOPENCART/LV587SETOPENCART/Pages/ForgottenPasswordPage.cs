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
        LoginPage loginPage;
        public IWebElement TitleForgotPassword { get; private set; }

        public ForgottenPasswordPage(IWebDriver driver) : base(driver)
        {
            TitleForgotPassword = driver.FindElement(By.CssSelector("#content h1"));
            loginPage = new LoginPage(driver);
            
        }

        public void ForgotPasswordEmail(string email)
        {
            loginPage.InputEmailMethod(email);
        }
    }
}
