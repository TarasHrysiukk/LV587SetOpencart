using LV587SETOPENCART.Pages;
using OpenQA.Selenium;
using System;


namespace LV587SETOPENCART.BL
{
    class LoginBL : ClassWithDriver
    {
        LoginPage loginPage;
        public LoginBL(IWebDriver driver) : base(driver)
        {
            loginPage = new LoginPage(driver);
        }

        public void Login(string email, string pass)
        {
            loginPage.InputEmailText(email);
            loginPage.InputPasswordText(pass);
            loginPage.ClickOnLoginButton();
        }
    }
}
