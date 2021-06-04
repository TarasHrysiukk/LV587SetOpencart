using LV587SETOPENCART.Pages;
using OpenQA.Selenium;
using System;


namespace LV587SETOPENCART.BL
{
    class LoginBL : ClassWithDriver
    {
        LoginPage loginPage;
       // HeaderComponent headerComponent;
        public LoginBL(IWebDriver driver) : base(driver)
        {
           // headerComponent = new HeaderComponent(driver);
            loginPage = new LoginPage(driver);
        }

        public void Login(string email, string pass)
        {
           // headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            loginPage.InputEmailText(email);
            loginPage.InputPasswordText(pass);
            loginPage.ClickOnLoginButton();
        }
    }
}
